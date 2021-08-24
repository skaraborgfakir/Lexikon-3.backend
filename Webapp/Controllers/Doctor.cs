// Time-stamp: <2021-08-24 11:04:57 stefan>

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
    public class Doctor : Controller
    {
	public IActionResult FeverCheck () {
	    return View("FeverCheck");
	}
    }
}
