using System;

using System.ComponentModel.DataAnnotations;

namespace Webapp.Vydata {
    [Serializable]
    public class GissaEttTalSpelVyModell {
	[Required]
	[Range( 1, 100)]
	public int Talgissning { get; set; }

	[Display(Name = "Antal tidigare gissningar")]
	public int AntalNuvarandeGissningar { get; set; }

	[Display(Name = "Ett litet tips")]
	public string Tips { get; set; }
    }
}
