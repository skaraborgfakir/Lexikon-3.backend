// Time-stamp: <2021-08-30 21:00:15 stefan>

// using System;
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
	    return View("Index");
	    // return ControllerContext.MyDisplayRouteInfo();
	}

	//
	// GET: Kontaktinfo
	//
	public IActionResult Kontaktuppgifter()
	{
	    return View("Kontaktuppgifter");
	}

	//
	// GET: Om mig
	//
	public IActionResult OmMig()
	{
	    ViewData["hemort"]= "Stenstorp";
	    return View("OmMig");
	}

	//
	// GET: GitRepos
	//
	public IActionResult GitRepos()
	{
	    githubArkiv arkivuppgifter = new githubArkiv();
	    ViewBag.repos = arkivuppgifter.samtligaArkiv;

	    return View("githubRepos");
	}

	//
	// GET: GitRepos
	//
	public IActionResult Projects()
	{
	    githubArkiv arkivuppgifter = new githubArkiv();
	    ViewBag.repos = arkivuppgifter.samtligaArkiv;

	    return View("githubRepos");
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
	    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
    }
}
