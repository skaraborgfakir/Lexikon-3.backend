// Time-stamp: <2021-08-30 09:12:19 stefan>

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

namespace Webapp
{
    // kan egentligen heta vad som helst exv REVELJ !
    public class REVELJ
    {
	private IConfiguration _configuration;
	public REVELJ(IConfiguration configuration)
	{
	    _configuration = configuration;
	}

	public IConfiguration Configuration {
	    get { return _configuration; }
	}

	// This method gets called by the runtime. Use this method to add services to the container.
	// For more information on how to configure your
	// application, visit https://go.microsoft.com/fwlink/?LinkID=398940
	public void ConfigureServices(IServiceCollection services)
	{
	    services.AddControllersWithViews();
	    services.AddRazorPages();
	    services.AddMvc();
	}

	// This method gets called by the runtime. Use this method to configure the HTTP
	// request pipeline.
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
	    app.UseStaticFiles();

	    //
	    // aktivera vidarebefordran av frågor till olika kontrollanter
	    // MapControllerRoute är beroende
	    app.UseRouting();

	    //
	    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-5.0
	    //
	    // avgrening till olika styrprogram (Controller) - ingen egentlig återuppsamling efter dessa
	    // så inte en egentlig gaffling
	    //
	    // beroende av UseRouting() !
	    //
	    // mönsterigenkänning:
	    //   en inkommande URL ska ha ett nominerat styrprogram (Controller)
	    //   och som option en aktion som eventuellt kan använda ett Id
	    //
	    // för varje fördelning ska det finnas ett unikt namn (id)
	    //
	    // UseEndpoints är en utökning av samma type som de tidigare UseStaticFiles (middleware component)
	    // men den är speciell i att den dvs slutdestination
	    //
	    app.UseEndpoints( reseslutdestinationer => { Console.WriteLine( "Configure: 5");
		    // request delegate ?
		    // in-line middle ware ?
		    reseslutdestinationer.MapControllerRoute( name:     "normalfall",                       // ingång via /Hem/
							      pattern:  "/Hem/{action=Index}",
							      defaults: new { controller="Hem" } );  // 127.0.0.1/{controller ?}/{action ?}/{Id ?}
	    });
	}
    }
}
