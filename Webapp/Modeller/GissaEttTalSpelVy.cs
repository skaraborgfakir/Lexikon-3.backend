using System.ComponentModel.DataAnnotations;

namespace Webapp.Vydata {
    public class GissaEttTalSpelVyModell {
	[Required]
	// [Range( 1, 100, "Talet är 1 <= x <= 100")]
	[Display(Name = "En gissning på ett tal")]
	public int Talgissning { get; set; }

	[Required]
	[Display(Name = "Antal tidigare gissningar på talet")]
	public int AntalNuvarandeGissningar { get; set; }

	public string Tips { get; set; }

	public int Hemligheten { get; set; }
    }
}
