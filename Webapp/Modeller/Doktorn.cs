// Time-stamp: <2021-09-03 12:10:36 stefan>
//

namespace Webapp.Modeller {
    public class DoktorBoström {
	public static string Utlåtande(float temp) {
	    if (temp >= 38.0)
		return "Du har feber";
	    else if (temp > 37.5 && temp < 38 )
		return "Du kanske har lite feber";
	    else if (temp < 36.0 )
		return "Du HAR hypotermi";
	    else
		return "Din kroppstemperatur är helt normal";
	}
    }
}
