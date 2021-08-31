using System.ComponentModel.DataAnnotations;

namespace Webapp.Viewmodel {
    public class Game {
	[Required]
	//	[Range(1,100, "Talet är 1 <= x <= 100")]
	[Display(Name = "En gissning på ett tal")]
	public int Talgissning { get; set; }
    }
}
