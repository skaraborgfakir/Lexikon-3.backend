// Time-stamp: <2021-08-30 23:10:55 stefan>

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

using Microsoft.Docs.Samples;

namespace Webapp.Controllers
{
    // A controller with at least three views.
    //   - About – Containing information about yourself (CV, for example).
    //   - Contact – Containing your contact information
    //   - Projects – Containing the GitHub links to your assignments you have finished with small description about them.
    //

    public class HemController : Controller
    {
	private readonly ILogger<HemController> _logger;

	public HemController(ILogger<HemController> logger)
	{
	    _logger = logger;
	}

	//
	// GET: Hem
	//
	public IActionResult Index()
	{
	    Console.WriteLine( "Index: return view index");

	    return View("Index");
	    // return ControllerContext.MyDisplayRouteInfo();
	}

	//
	// GET: Kontaktinfo
	//
	public IActionResult Kontaktuppgifter()
	{
	    Console.WriteLine( "Kontaktuppgifter: return view Kontaktuppgifter");

	    return View("Kontaktuppgifter");
	}

	//
	// GET: Om mig
	//
	public IActionResult OmMig()
	{
	    Console.WriteLine( "OmMig: return view OmMig");

	    ViewData["hemort"]= "Stenstorp";
	    return View("OmMig");
	}

	//
	// GET: GitRepos
	//
	public IActionResult GitRepos()
	{
	    Console.WriteLine( "GitRepos: return View(arkivuppgifter)");
	    githubArkiv arkivuppgifter = new githubArkiv();
	    // ViewBag.repos = arkivuppgifter.samtligaArkiv;

	    // return View("githubRepos");
	    return View(arkivuppgifter);
	}

	//
	// GET: GitRepos
	//
	public IActionResult Projects()
	{
	    Console.WriteLine( "Projects: return View(arkivuppgifter)");

	    githubArkiv arkivuppgifter = new githubArkiv();
	    //    ViewBag.repos = arkivuppgifter.samtligaArkiv;

	    // return View("githubRepos");
	    return View( "GitRepos", arkivuppgifter);
	}

	//
	// GET: persondatasäkerhet
	//
	public IActionResult Privacy()
	{
	    Console.WriteLine( "Privacy: return view");

	    return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
	    Console.WriteLine( "Error: return view(new ErrorVi...");

	    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
    }
}
