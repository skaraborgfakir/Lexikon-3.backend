// Time-stamp: <2021-09-03 13:26:24 stefan>

using System;
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=netcore-3.1
// using System.Collections.Generic;
// https://docs.microsoft.com/en-us/dotnet/api/system.linq?view=netcore-3.1
// using System.Linq;
// https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks?view=netcore-3.1
// using System.Threading.Tasks;

// https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting?view=aspnetcore-3.1
using Microsoft.AspNetCore.Hosting;
// https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting?view=dotnet-plat-ext-3.1
using Microsoft.Extensions.Hosting; // IsDevelopment

// https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder?view=aspnetcore-3.1
using Microsoft.AspNetCore.Builder; // IApplicationBuilder

// https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http?view=aspnetcore-3.1
// using Microsoft.AspNetCore.Http;

// https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration?view=dotnet-plat-ext-3.1
using Microsoft.Extensions.Configuration; // IConfiguration

// https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection?view=dotnet-plat-ext-3.1
using Microsoft.Extensions.DependencyInjection; // IServiceCollection

using Microsoft.AspNetCore.Session; //

namespace Webapp
{
    // kan egentligen heta vad som helst exv REVELJ !
    public class REVELJ
    {
	//
	private IConfiguration _configuration;
	public REVELJ(IConfiguration configuration)
	{
	    _configuration = configuration;
	}

	public IConfiguration Configuration {
	    get { return _configuration; }
	}

	//
	// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-3.1
	//
	public void ConfigureServices(IServiceCollection services)
	{
	    services.AddDistributedMemoryCache();

	    //
	    // GDPR:anpassningar i .net innebar att det inte längre automatiskt
	    // i laissez-faire anda går att som programmerare förvänta sig att användaren
	    // kan tvingas att acceptera cookies. Därför är som standard session-kakan (och alla andra
	    // kakor) blockerade
	    //
	    // options.Cookie.IsEssential tar bort blockeringen för session-kakan och enbart den !
	    //
	    // https://andrewlock.net/session-state-gdpr-and-non-essential-cookies/
	    //
	    services.AddSession( options => {
		options.Cookie.Name = Configuration["session_kakans_namn"];
		options.IdleTimeout = TimeSpan.FromSeconds(40);
		options.Cookie.HttpOnly = true;
		options.Cookie.IsEssential = true;
	    }
	    );
	    services.AddControllersWithViews();
	    services.AddRazorPages();
	    services.AddMvc();
	}

	//
	//
	public void Configure( IApplicationBuilder app,
			       IWebHostEnvironment env)
	{
	    //
	    // klistra in olika funktioner i ramverkets avveckling av jobb (inkommande trafik via http och returnerade svar)
	    //
	    Console.WriteLine( "Configure: 1");
	    //
	    // gaffling i flödet beroende på programmets startmiljö
	    if (env.IsDevelopment())
	    {
		Console.WriteLine( "Configure: 2-1 IsDevelopment");
		app.UseDeveloperExceptionPage();
	    } else {
		Console.WriteLine( "Configure: 2-2 Drift");
		app.UseExceptionHandler("/Home/Error");
		app.UseHsts();                          /// ställ krav på https - men inte med i Developerversionen, som används
	    }
	    // återuppsamling efter gaffel
	    Console.WriteLine( "Configure: 3");
	    app.UseHttpsRedirection();
	    app.UseStatusCodePages();
	    app.UseStaticFiles();

	    //
	    // aktivera vidarebefordran av frågor till olika kontrollanter
	    // MapControllerRoute är beroende
	    app.UseRouting();

	    //
	    // sessions-kakan - det här anropet måste vara placerad för de moduler (exv aktion-metoder)
	    // som ska ha tillgång till kakan.
	    //
	    app.UseSession();

	    //
	    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-3.1
	    //
	    // avgrening till olika styrprogram (Controller) - ingen egentlig återuppsamling efter
	    // dessa så inte en egentlig gaffling
	    //
	    // beroende av UseRouting() !
	    //
	    // mönsterigenkänning:
	    //   en inkommande URL ska ha ett nominerat styrprogram (Controller)
	    //   och som option en aktion som eventuellt kan använda ett Id
	    //
	    // för varje fördelning ska det finnas ett unikt namn (id)
	    //
	    // UseEndpoints är en utökning av samma typ som de tidigare UseStaticFiles (middleware component)
	    // men den är speciell i att den är final dvs slutdestination
	    //
	    app.UseEndpoints(endpoints =>
	    {
		Console.WriteLine( "Configure: 5");
		// A controller with at least three views.
		//   - About – Containing information about yourself (CV, for example).
		//   - Contact – Containing your contact information
		//   - Projects – Containing the GitHub links to your assignments you have finished with small description about them.
		//

		// vilka mönster (pattern) kommer att passa vilka url ?
		//          /Home/   /Home/{vad som helst}   /AboutMe/   /    /FeverCheck   /Home/FeverCheck
		// fall 1    N          N                        N       N        J            N
		// fall 2    J          J                        J       J        J            J
		//
		//
		// en specifik kontrollant - Doctor med aktör-metod: FeverCheck
		//
		// omvänd kontroll - låt dotNet-ramverket kontrollera när något utförs men ange
		// vilka funktioner som det ska använda.
		// Funktionerna ska uppfylla vissa krav (som implementeras som Interface)
		//
		endpoints.MapControllerRoute(
		    name: "drboström",
		    pattern: "FeverCheck",
		    defaults: new {
						 controller="Doctor",
						 action="FeverCheck"
					     }
		);

		//
		// code requirements:
		//   1  The guessing game View should be accessible through a custom route, using the
		//       “/GuessingGame” pattern, regardless of what the controller is named.
		//
		// beroende av UseSession
		endpoints.MapControllerRoute(
		    name:    "gissa ett tal-spel",
		    pattern: "GuessingGame",
		    defaults: new {
						 controller="GissaEttTalSpel",
						 action="Spela"
					     }
		);
		endpoints.MapControllerRoute(
		    name:    "normalfall",
		    pattern: "{controller=Home}/{action=Index}");  // 127.0.0.1/{controller ?}/{action ?}
	    });
	}
    }
}
