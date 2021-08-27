// Time-stamp: <2021-08-27 12:09:44 stefan>

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

namespace webapp.Controllers
{
    public class HomeController : Controller
    {
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger)
	{
	    _logger = logger;
	}

	public IActionResult Index()
	{
	    return View();
	}

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
