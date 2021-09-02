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
