// // Time-stamp: <2021-09-01 16:43:09 stefan>

// using System;
// // using System.Collections.Generic;
// using System.Diagnostics;
// // using System.Linq;
// // using System.Threading.Tasks;

// // https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc?view=aspnetcore-5.0
// using Microsoft.AspNetCore.Mvc;
// // https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging?view=dotnet-plat-ext-3.1
// using Microsoft.Extensions.Logging;

// using Webapp.Vydata;
// using Webapp.Modeller;

// namespace Webapp.Controllers
// {
//     public class GissaEttTal : Controller {
//	public GissaEttTal() {
//	}

//	//
//	// GET:
//	//
//	// https://www.infoworld.com/article/3600190/how-to-overload-action-methods-in-aspnet-core-mvc-5.html
//	//
//	[HttpGet]
//	public IActionResult Spela()
//	{
//	    Console.WriteLine( "Game: GET: return View()");

//	    return View();
//	}

//	// public IActionResult ettTal() {
//	//     }

//	//
//	// POST
//	//
//	// https://www.infoworld.com/article/3600190/how-to-overload-action-methods-in-aspnet-core-mvc-5.html
//	//
//	[HttpPost]
//	public IActionResult Spela(GissaEttTalSpelVy vilketSpel)
//	{
//	    Console.WriteLine( "Game: POST: return View()");

//	    return View();
//	}
//     }
// }
