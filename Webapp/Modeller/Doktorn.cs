namespace Webapp.Modeller {
    public class Doktorn {
	public Doktorn() {
	}

	public static  Utlåtande(float temp) {
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
	}

	public static string Utlåtande(float temp) {
	    if (temp >= 38)
		return "Du har feber";
	    else if (temp.Kroppstemp > 37.2 && temp.Kroppstemp < 38 )
		return "Du kanske har lite feber";
	    else if (temp.Kroppstemp < 36.2 )
		return "Du HAR hypotermi"
		else
		    return "Din kroppstemperatur är helt normal";
	}
    }
}
