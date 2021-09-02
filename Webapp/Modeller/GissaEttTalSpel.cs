using System;

using Webapp.Hjälpklasser;

namespace Webapp.Modeller {
    public class GissaEttTalSpelModell {
	private int ettSlumpTal;
	private int antalGissningar=0;
	public GissaEttTalSpelModell() {
	    ettSlumpTal = Slumptalskälla.tal( 1, 100);
	    Console.WriteLine( "ettSlumpTal: " + ettSlumpTal.ToString());
	}
	public bool Gissning( int enGissning) {
	    antalGissningar = antalGissningar + 1;
	    if ( enGissning == ettSlumpTal ) { // kunde skrivas om till return(( enGissning==ettSlumpTal)true?false)
		return true;
	    }
	    return false;
	}
	public string EttTips(int enGissning) {
	    if (enGissning < ettSlumpTal) {
		return "Det är för litet";
	    } else if { enGissning > ettSlumpTal) {
		return "Det är för stort";
	    }
	    return "Det är rätt";
	}

	public int EttSlumpTal { get { return ettSlumpTal; }}
	//
	// behövs för att controller ska kunna uppdatera
	// GissaEttTalSpelVyModell innan varje gissning
	//
	public int AntalGissningar { get { return antalGissningar; } }
    }
}
