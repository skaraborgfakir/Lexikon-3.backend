// Time-stamp: <2021-09-02 15:04:12 stefan>

using System;
// using System.Collections.Generic;
using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;

// behövs för dictionary
using System.Collections.Generic;

using System.Web;
using System.Net.Http.Headers;

// https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc?view=aspnetcore-5.0
using Microsoft.AspNetCore.Mvc;
// https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging?view=dotnet-plat-ext-3.1
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Http;

using Webapp.Vydata;
using Webapp.Modeller;
using Webapp.Hjälpklasser;

namespace Webapp.Controllers
{
    public class GissaEttTalSpel : Controller {
	public GissaEttTalSpel() {
	}

	//
	// GET:
	//
	// https://www.infoworld.com/article/3600190/how-to-overload-action-methods-in-aspnet-core-mvc-5.html
	//
	[HttpGet]
	public IActionResult Spela()
	{
	    Console.WriteLine( "Game: GET: return View()");

	    int slumpadSessionID = Slumptalskälla.tal( 1, 500000000);

	    GissaEttTalSpelModell enSpelomgång = new GissaEttTalSpelModell();
	    HttpContext.Session.SetString( "test_slumptal", enSpelomgång.Hemligheten.ToString());

	    CookieOptions cookieOptions = new CookieOptions();
	    cookieOptions.Domain = "127.0.0.1";

	    HttpContext.Response.Cookies.Append( ".fakirenstenstorp.st", slumpadSessionID.ToString(), cookieOptions);

	    GissaEttTalSpelVyModell spelbrädan = new GissaEttTalSpelVyModell();
	    spelbrädan.AntalNuvarandeGissningar = enSpelomgång.AntalGissningar;
	    spelbrädan.Hemligheten = enSpelomgång.Hemligheten;

	    //
	    // alternativ för att få över data till vy:n (../Views/GissaEttTalSpel/Spela.cshtml)
	    //
	    // ViewData - grunden
	    // ViewBag  - ViewData i en annan tappning
	    // ViewModel -
	    //

	    return View(spelbrädan);
	}

	//
	// POST
	//
	// https://www.infoworld.com/article/3600190/how-to-overload-action-methods-in-aspnet-core-mvc-5.html
	//
	[HttpPost]
	public IActionResult Spela(GissaEttTalSpelVyModell spelbrädan)
	{
	    GissaEttTalSpelModell enSpelomgång = new GissaEttTalSpelModell( spelbrädan.Hemligheten,
									    spelbrädan.AntalNuvarandeGissningar);

	    if (enSpelomgång.Gissning(spelbrädan.Talgissning)) {
		//
		// det var rätt
		//
		SucceGissaEttTalSpelVy meddelande = new SucceGissaEttTalSpelVy();
		meddelande.Hemligheten = enSpelomgång.Hemligheten;
		meddelande.AntalNuvarandeGissningar = enSpelomgång.AntalNuvarandeGissningar;

		return Lycka( meddelande);
	    }

	    GissaEttTalSpelVyModell nyChans = new GissaEttTalSpelVyModell();
	    nyChans.AntalNuvarandeGissningar = enSpelomgång.AntalGissningar;
	    nyChans.Hemligheten = enSpelomgång.AntalGissningar;
	    nyChans.Tips = enSpelomgång.EttTips(enSpelomgång.AntalGissningar);

	    return View(nyChans);
	}
    }
}
