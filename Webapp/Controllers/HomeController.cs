// Time-stamp: <2021-08-31 11:46:44 stefan>

using System;
// using System.Collections.Generic;
using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;

// https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc?view=aspnetcore-5.0
using Microsoft.AspNetCore.Mvc;
// https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging?view=dotnet-plat-ext-3.1
using Microsoft.Extensions.Logging;

using Webapp.Modeller;

namespace Webapp.Controllers
{
    public class HomeController : Controller
    {
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger)
	{
	    _logger = logger;
	}

	//
	// GET: Hem
	//
	public IActionResult Index()
	{
	    return View("Index");
	}

	//
	// GET: Kontaktinfo
	//
	public IActionResult Kontaktuppgifter()
	{
	    return View("Contact");
	}

	//
	// GET: Om mig
	//
	public IActionResult About()
	{
	    Console.WriteLine( "AboutMe: return view About");
	    ViewData["hemort"]= "Stenstorp";

	    return View("About");
	}

	//
	// GET: GitRepos
	//
	public IActionResult GitRepos()
	{
	    githubArkiv arkivuppgifter = new githubArkiv();
	    ViewBag.repos = arkivuppgifter.Result;

	    return View("githubRepos");
	}

	//
	// GET:
	//
	[HttpGet]
	public IActionResult Game()
	{
	    Console.WriteLine( "Game: Get: return View(Game)3");

	    return View("Game");
	}

	//
	// POST
	//
	[HttpPost]
	public IActionResult Game(int gissning)
	{
	    Console.WriteLine( "Game: Post: return View(Game)3");

	    return View("Game");
	}

	//
	// GET: persondatasäkerhet
	//
	public IActionResult Privacy()
	{
	    return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
	    Console.WriteLine( "Error: return view(new ErrorViewModel");

	    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
    }
}
