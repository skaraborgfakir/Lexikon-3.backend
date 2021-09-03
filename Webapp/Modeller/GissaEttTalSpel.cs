using System;

using Newtonsoft.Json;

using Webapp.Hjälpklasser;

namespace Webapp.Modeller {
    public class GissaEttTalSpelModell {
	private int _hemligheten;
	private int _antalGissningar=0;

	public GissaEttTalSpelModell() {
	    _antalGissningar = 0;
	    _hemligheten = Slumptalskälla.tal( 1, 100);
	}

	public GissaEttTalSpelModell( int hemlighet, int antalGissningar) {
	    _antalGissningar = antalGissningar;
	    _hemligheten = hemlighet;
	}

	public bool Gissning( int enGissning) {
	    Console.WriteLine( "Game Gissning hemligheten.ToString: " + _hemligheten.ToString());
	    _antalGissningar = _antalGissningar + 1;
	    if ( enGissning == _hemligheten ) { // kunde skrivas om till return(( enGissning==ettSlumpTal)true?false)
		return true;
	    }
	    // gissningen är fel
	    return false;
	}

	public string EttTips(int enGissning) {
	    if (enGissning < _hemligheten) {
		return "Det är för litet";
	    } else if ( enGissning > _hemligheten) {
		return "Det är för stort";
	    } else
		return "Det är rätt";
	}

	public int Hemligheten => _hemligheten;

	//
	// behövs för att controller ska kunna uppdatera
	// GissaEttTalSpelVyModell innan varje gissning
	//
	public int AntalGissningar => _antalGissningar;
    }
}
