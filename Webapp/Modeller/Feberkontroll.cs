// Time-stamp: <2021-09-03 11:53:13 stefan>
//

using System.ComponentModel.DataAnnotations;

namespace Webapp.Vydata {
    public class Feberkontroll {
	[Required]
	[Display(Name = "Kroppstemperatur i celsius")]
	public float Kroppstemp { get; set; }
    }
}
