// Time-stamp: <2021-09-03 11:57:17 stefan>
//

using System;

namespace Webapp.Hjälpklasser {
    public static class Slumptalskälla {
	private static Random slumptalskälla = new Random();

	public static int tal( int lägst, int högst)
	{
	    return slumptalskälla.Next( lägst, högst);
	}
    }
}
