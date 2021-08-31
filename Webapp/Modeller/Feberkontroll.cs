using System.ComponentModel.DataAnnotations;

namespace Webapp.Viewmodel {
    public class Feberkontroll {
	[Required]
	[Display(Name = "Kroppstemperatur i celsius")]
	public float Kroppstemp { get; set; }
    }
}
