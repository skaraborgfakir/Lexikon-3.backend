// Time-stamp: <2021-09-02 09:26:37 stefan>

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
	private static Dictionary<string, GissaEttTalSpelModell> uteståendeSpel = new Dictionary<string, GissaEttTalSpelModell>();

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
	    uteståendeSpel.Add( slumpadSessionID.ToString(), enSpelomgång);

	    HttpContext.Session.SetString( "test_slumptal", enSpelomgång.EttSlumpTal.ToString());
	    Console.WriteLine( "uteståendeSpel.Count.ToString : " + uteståendeSpel.Count.ToString());

	    GissaEttTalSpelVyModell spelbrädan = new GissaEttTalSpelVyModell();
	    spelbrädan.AntalNuvarandeGissningar = enSpelomgång.AntalGissningar; // kommer iofs alltid att vara ==0

	    CookieOptions cookieOptions = new CookieOptions();
	    cookieOptions.Domain = "127.0.0.1";

	    HttpContext.Response.Cookies.Append( ".fakirenstenstorp.st", slumpadSessionID.ToString(), cookieOptions);

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
	    var requestLen = Request.ContentLength;
	    Console.WriteLine( "Game: POST: requestLen.ToString " + requestLen.ToString());
	    Console.WriteLine( "Game: POST: spelbrädan.Talgissning " + spelbrädan.Talgissning.ToString());

	    Console.WriteLine( "uteståendeSpel.Count.ToString : " + uteståendeSpel.Count.ToString());

	    var cookie = Request.Cookies[".fakirenstenstorp.st"];
	    var cookieStr = cookie.ToString();

	    Console.WriteLine( "Game: POST: " + cookie.ToString());
	    // var useragent = Request.UserAgent;
	    // Console.WriteLine( "Game: POST: " + (HttpWebRequest) Request.UserAgent);

	    // if ( cookie != null) {
	    //	Console.WriteLine( "Game: POST: " + cookie);

	    //	// GissaEttTalSpelModell enSpelomgång = uteståendeSpel[cookie];

	    //	if ( enSpelomgång.Gissning( spelbrädan.Talgissning)) {
	    //	    // det blev rätt

	    //	    RedirectToAction( "Index", "Home");
	    //	}

	    //	spelbrädan.AntalNuvarandeGissningar = enSpelomgång.AntalGissningar;
	    // }


	    // HttpCookieCollection inkluderadeCookies = request.Cookies;

	    // foreach (string nycklar in inkluderadeCookies.AllKeys) {
	    //	Console.WriteLine( "Game: POST: " + nycklar);
	    // }

	    //Console.WriteLine( "Game: POST: " + HttpContext.Request.GetString(".fakirenstenstorp.st") + "---");

	    return View(spelbrädan);
	}
    }
}
