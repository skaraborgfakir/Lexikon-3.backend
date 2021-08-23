// Time-stamp: <2021-08-23 17:01:29 stefan>

// using System;
// using System.Collections.Generic;
using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;

// https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc?view=aspnetcore-5.0
using Microsoft.AspNetCore.Mvc;
// https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging?view=dotnet-plat-ext-3.1
using Microsoft.Extensions.Logging;

using webapp.Models;

namespace webapp.Controllers
{
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
	    return View("OmMig");
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
