// Time-stamp: <2021-09-03 21:01:40 stefan>

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


using Newtonsoft.Json;

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
	private IConfiguration _configuration;
	private readonly ILogger _logger;

	public GissaEttTalSpel(IConfiguration configuration,
			       ILogger<GissaEttTalSpel> logger) {
	    _configuration = configuration;
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
	    // int slumpadSessionID = Slumptalskälla.tal( 1, 500000000);

	    //
	    // initialisera spelet - ett slumptal !
	    //
	    GissaEttTalSpelModell enSpelomgång = new GissaEttTalSpelModell();
	    // Console.WriteLine( "Game: GET: string hemligheten " + enSpelomgång.Hemligheten.ToString());

	    //
	    // klistra in slumptalet i session-kakan
	    Console.WriteLine( "Game: GET: HttpContext.Session.SetString()");
	    _logger.LogInformation( "Game: GET: HttpContext.Session.SetString()");
	    HttpContext.Session.SetInt32( "hemligheten.gissatal.netcore3.1.fakirenstenstorp.st", enSpelomgång.Hemligheten);
	    HttpContext.Session.SetString( "spelomgång.gissatal.netcore3.1.fakirenstenstorp.st", JsonConvert.SerializeObject(enSpelomgång));

	    Console.WriteLine( "Game: GET: HttpContext.Session.GetString + " + HttpContext.Session.GetString( "spelomgång.gissatal.netcore3.1.fakirenstenstorp.st"));

	    // en annan kaka, inte session
	    // CookieOptions cookieOptions = new CookieOptions();
	    // cookieOptions.Domain = "127.0.0.1";
	    // hur refererar man till Configuration i Startup.cs ??
	    // HttpContext.Response.Cookies.Append( "slumptal." + Configuration["session_kakans_namn"], slumpadSessionID.ToString(), cookieOptions);
	    // HttpContext.Response.Cookies.Append( "gissatal.netcore3.1.fakirenstenstorp.st", slumpadSessionID.ToString(), cookieOptions);

	    //
	    // vydata
	    GissaEttTalSpelVyModell spelbrädan = new GissaEttTalSpelVyModell();
	    spelbrädan.AntalNuvarandeGissningar = enSpelomgång.AntalGissningar;

	    //
	    // alternativ för att få över data till vy:n (../Views/GissaEttTalSpel/Spela.cshtml)
	    //
	    // ViewData - grunden
	    // ViewBag  - ViewData i en annan tappning
	    // ViewModel -
	    //

	    Console.WriteLine( "Game: GET: return View()");
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
	    Console.WriteLine( "Game: POST 1-1: spelbrädan.Talgissning: " + spelbrädan.Talgissning.ToString());
	    Console.WriteLine( "Game: POST 1-2: JsonConvert.SerializeObject(spelbrädan " + JsonConvert.SerializeObject(spelbrädan));
	    Console.WriteLine( "Game: POST 1-3: HttpContext.Session.GetString " + HttpContext.Session.GetString( "spelomgång.gissatal.netcore3.1.fakirenstenstorp.st"));

	    GissaEttTalSpelModell enSpelomgång = JsonConvert.DeserializeObject<GissaEttTalSpelModell>(HttpContext.Session.GetString( "spelomgång.gissatal.netcore3.1.fakirenstenstorp.st"));
	    int hemligheten = (int) HttpContext.Session.GetInt32( "hemligheten.gissatal.netcore3.1.fakirenstenstorp.st");
	    Console.WriteLine( "Game: POST 1-5: int hemligheten = (int) HttpContext.Session "+ hemligheten.ToString());

	    if (enSpelomgång.Gissning(spelbrädan.Talgissning)) {
		//
		// det var rätt
		//
		Console.WriteLine( "Game: POST 2-1: det var rätt");
		SucceGissaEttTalSpelVy meddelande = new SucceGissaEttTalSpelVy();
		meddelande.Hemligheten = enSpelomgång.Hemligheten;
		meddelande.AntalNuvarandeGissningar = enSpelomgång.AntalGissningar;

		return View("Lycka", meddelande);
	    }

	    GissaEttTalSpelVyModell nyChans = new GissaEttTalSpelVyModell();
	    nyChans.AntalNuvarandeGissningar = enSpelomgång.AntalGissningar;
	    nyChans.Tips = enSpelomgång.EttTips(spelbrädan.Talgissning);

	    HttpContext.Session.SetString( "spelomgång.gissatal.netcore3.1.fakirenstenstorp.st", JsonConvert.SerializeObject(enSpelomgång));
	    Console.WriteLine( "Game: POST 3-1: JsonConvert.SerializeObject(enSpelomgång " + JsonConvert.SerializeObject(enSpelomgång));
	    Console.WriteLine( "Game: POST 3-2: HttpContext.Session.GetString " + HttpContext.Session.GetString( "spelomgång.gissatal.netcore3.1.fakirenstenstorp.st"));

	    return View(nyChans);
	}
    }
}
