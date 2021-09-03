using System.ComponentModel.DataAnnotations;

namespace Webapp.Vydata {
    public class GissaEttTalSpelVyModell {
	[Required]
	[Range( 1, 100)]
	[Display(Name = "En gissning på ett tal")]
	public int Talgissning { get; set; }

	[Display(Name = "Antal tidigare gissningar på talet")]
	public int AntalNuvarandeGissningar { get; set; }

	public string Tips { get; set; }

	public int Hemligheten { get; set; }
    }
}
