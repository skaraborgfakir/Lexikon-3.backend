// Time-stamp: <2021-09-03 12:07:44 stefan>

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
using Webapp.Vydata;

namespace Webapp.Controllers
{
    public class Doctor : Controller
    {
	public IActionResult FeverCheck() {
	    return View("FeverCheck");
	}

	public IActionResult inmatning(Feberkontroll temp) {
	    Console.WriteLine( "inmatning: temp: "+ temp.Kroppstemp );

	    ViewData["status"]= DoktorBoström.Utlåtande(temp.Kroppstemp);

	    return View("FeverCheckStatus");
	}

	public IActionResult FeverCheckStatus() {
	    return View();
	}
    }
}
