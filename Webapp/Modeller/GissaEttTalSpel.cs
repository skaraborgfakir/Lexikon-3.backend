using System;

using Webapp.Hjälpklasser;

namespace Webapp.Modeller {
    public class GissaEttTalSpelModell {
	public int hemligheten;
	public int antalGissningar=0;

	public GissaEttTalSpelModell() {
	    antalGissningar = 0;
	    hemligheten = Slumptalskälla.tal( 1, 100);
	}
	public GissaEttTalSpelModell( int _hemligheten,
				      int _antalGissningar) {
	    hemligheten = _hemligheten;
	    antalGissningar = _antalGissningar;
	}

	public bool Gissning( int enGissning) {
	    antalGissningar = antalGissningar + 1;
	    if ( enGissning == hemligheten ) { // kunde skrivas om till return(( enGissning==ettSlumpTal)true?false)
		return true;
	    }
	    return false;
	}
	public string EttTips(int enGissning) {
	    if (enGissning < hemligheten) {
		return "Det är för litet";
	    } else if ( enGissning > hemligheten) {
		return "Det är för stort";
	    }
	    return "Det är rätt";
	}

	public int Hemligheten {
	    get { return hemligheten; }
	}

	//
	// behövs för att controller ska kunna uppdatera
	// GissaEttTalSpelVyModell innan varje gissning
	//
	public int AntalGissningar {
	    get { return antalGissningar; }
	}
    }
}
