// Time-stamp: <2021-08-19 19:45:35 stefan>

using System;

// https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting?view=aspnetcore-3.1
using Microsoft.AspNetCore.Hosting;
// https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting?view=dotnet-plat-ext-3.1
using Microsoft.Extensions.Hosting; // IHostBuilder

namespace Webapp
{
    public class Program
    {
	public static void Main(string[] args)
	{
	    CreateHostBuilder(args).Build().Run();
	}

	public static IHostBuilder CreateHostBuilder(string[] args) =>
	    Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
	    {
		foreach (string arg in args) {
		    Console.WriteLine( "Program.cs: args" + " " + arg);
		}

		webBuilder.UseStartup<Kickstart>();
	    });
    }
}
