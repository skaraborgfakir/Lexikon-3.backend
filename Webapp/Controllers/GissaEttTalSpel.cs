// Time-stamp: <2021-09-03 14:01:54 stefan>

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

// https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http?view=aspnetcore-3.1
using Microsoft.AspNetCore.Http;

// https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration?view=dotnet-plat-ext-3.1
using Microsoft.Extensions.Configuration; // IConfiguration

using Webapp.Vydata;
using Webapp.Modeller;
using Webapp.Hjälpklasser;

// public class TodoController : ControllerBase
// {
//     private readonly ILogger _logger;

//     public TodoController(ILogger<TodoController> logger)
//     {
//         _logger = logger;
//     }

//     [HttpGet("{id}", Name = "GetTodo")]
//     public ActionResult<TodoItem> GetById(string id)
//     {
//         _logger.LogInformation(LoggingEvents.GetItem, "Getting item {Id}", id);

//         // Item lookup code removed.

//         if (item == null)
//         {
//             _logger.LogWarning(LoggingEvents.GetItemNotFound, "GetById({Id}) NOT FOUND", id);
//             return NotFound();
//         }

//         return item;
//     }
// }

namespace Webapp.Controllers
{
    public class GissaEttTalSpel : Controller {
    private readonly ILogger _logger;

	public GissaEttTalSpel(ILogger<TodoController> logger) {
	    _logger = logger;
	}

	//
	// GET:
	//
	// code requirements:
	//   1  The guessing game View should be accessible through a custom route, using the
	//       “/GuessingGame” pattern, regardless of what the controller is named.
	//
	//   2  The random number should be stored in the Session state.
	//
	//   3  Guessing should be handled through overloaded Actions, referring to the same View.
	//      - When the page is loaded through a GET request (such as through the URL), the
	//        app should reset, and start over with a new number.
	//      - When the page is loaded through a POST request, it should make a guess, unless
	//        the value isn’t provided or invalid, in which case it should display an error message.
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
