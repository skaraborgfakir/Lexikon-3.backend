// Time-stamp: <2021-08-31 00:44:13 stefan>

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
using Webapp.Viewmodel;

namespace Webapp.Controllers
{
    public class Doctor : Controller
    {
	public IActionResult FeverCheck() {
	    return View("FeverCheck");
	}

	public IActionResult inmatning(Feberkontroll temp) {
	    Console.WriteLine( "inmatning: temp: "+ temp.Kroppstemp );


	    if (temp.Kroppstemp >= 38 ) {
		Console.WriteLine( "Du har feber");
		ViewData["status"]= "Du har feber";
	    } else if (temp.Kroppstemp > 37.2 && temp.Kroppstemp < 38 ) {
		Console.WriteLine( "Du kanske har lite feber");
		ViewData["status"]= "Du kanske har lite feber";
	    } else if (temp.Kroppstemp < 36.2 ) {
		Console.WriteLine( "Du HAR hypotermi");
		ViewData["status"]= "Du HAR hypotermi";
	    } else {
		Console.WriteLine( "Du har inte någon feber, ja du har faktiskt en normal temperatur");
		ViewData["status"]= "Din kroppstemperatur är helt normal";
	    }

	    return View("FeverCheckStatus");
	}
	public IActionResult FeverCheckStatus() {
	    return View();
	}
    }
}
