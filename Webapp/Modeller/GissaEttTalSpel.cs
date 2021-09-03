using System;

using Newtonsoft.Json;

using Webapp.Hjälpklasser;

namespace Webapp.Modeller {
    [Serializable]
    public class GissaEttTalSpelModell {
	[JsonProperty]
	private int hemligheten;
	[JsonProperty]
	private int antalGissningar=0;

	public GissaEttTalSpelModell() {
	    antalGissningar = 0;
	    hemligheten = Slumptalskälla.tal( 1, 100);
	}

	public bool Gissning( int enGissning) {
	    Console.WriteLine( "Game Gissning hemligheten.ToString: " + hemligheten.ToString());
	    antalGissningar = antalGissningar + 1;
	    if ( enGissning == hemligheten ) { // kunde skrivas om till return(( enGissning==ettSlumpTal)true?false)
		return true;
	    }
	    // gissningen är fel
	    return false;
	}

	public string EttTips(int enGissning) {
	    if (enGissning < hemligheten) {
		return "Det är för litet";
	    } else if ( enGissning > hemligheten) {
		return "Det är för stort";
	    } else
		return "Det är rätt";
	}
	[JsonIgnore]
	public int Hemligheten => hemligheten;

	//
	// behövs för att controller ska kunna uppdatera
	// GissaEttTalSpelVyModell innan varje gissning
	//
	[JsonIgnore]
	public int AntalGissningar => antalGissningar;
    }
}
