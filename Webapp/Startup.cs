// Time-stamp: <2021-08-20 12:32:42 stefan>

using System;
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-5.0
// using System.Collections.Generic;
// https://docs.microsoft.com/en-us/dotnet/api/system.linq?view=net-5.0
// using System.Linq;
// https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks?view=net-5.0
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
    public class Kickstart
    {
	public Kickstart(IConfiguration configuration)
	{
	    Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	// This method gets called by the runtime. Use this method to add services to the container.
	// For more information on how to configure your
	// application, visit https://go.microsoft.com/fwlink/?LinkID=398940
	public void ConfigureServices(IServiceCollection services)
	{
	    services.AddControllersWithViews();
	    services.AddRazorPages();
	}

	// This method gets called by the runtime. Use this method to configure the HTTP
	// request pipeline.
	public void Configure( IApplicationBuilder app,
			       IWebHostEnvironment env)
	{
	    Console.WriteLine( "Configure: 1");
	    if (env.IsDevelopment())
	    {
		Console.WriteLine( "Configure: IsDevelopment");
		app.UseDeveloperExceptionPage();
	    } else {
		Console.WriteLine( "Configure: Drift");
		app.UseExceptionHandler("/Home/Error");
		app.UseHsts();
	    }
	    Console.WriteLine( "Configure: 4");
	    app.UseHttpsRedirection();
	    app.UseStaticFiles();

	    //
	    // aktivera vidarebefordran av frågor till olika kontrollanter
	    app.UseRouting();

	    //
	    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-5.0
	    //
	    // beroende av UseRouting()
	    //
	    app.UseEndpoints(endpoints =>
	    {
		Console.WriteLine( "Configure: 5");
		endpoints.MapControllerRoute(
		    name: "default",
		    pattern: "{controller=Home}/{action=Index}/{id?}");  // 127.0.0.1/{controller ?}/{action ?}/{Id ?}

		// A controller with at least three views.
		//   - About – Containing information about yourself (CV, for example).
		//   - Contact – Containing your contact information
		//   - Projects – Containing the GitHub links to your assignments you have finished with small description about them.
		//
		endpoints.MapControllerRoute(
		    name: "github repos",
		    pattern: "{controller=github}/{action=repos}/");     // 127.0.0.1/{controller=github}/{action=repos}/
		// endpoints.MapGet("/", async context =>
		// {
		//     await context.Response.WriteAsync("Hello World!");
		// })
	    });
	}
    }
}
