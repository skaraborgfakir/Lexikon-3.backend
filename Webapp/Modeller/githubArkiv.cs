// Time-stamp: <2021-08-31 12:56:12 stefan>

using System;
using System.Net;
using System.IO;

// using JQ;

public class githubArkiv {
    public string result;

    public string Result {
	get { return result; }
	private set { result = value; }
    }

    public githubArkiv() {
	// https://reqbin.com/req/csharp/c-vdhoummp/curl-get-json-example:
	var url = "https://api.github.com/users/Skaraborgfakir/repos";
	var httpRequest = (HttpWebRequest) WebRequest.Create(url);

	httpRequest.Accept = "application/json";
	// api.github.com kräver att användaren anger UserAgent, men...
	httpRequest.UserAgent = "Mosaic3/Kronos executive"; // fungerar det ? Konstig CYBER maskin
	// det fungerar .... alltså kan man hitta på ganska så fritt.... :-)
	Console.WriteLine("\nThe HttpHeaders are \n{0}",httpRequest.Headers);

	//
	// sug ner strukturen
	//
	var httpResponse = (HttpWebResponse) httpRequest.GetResponse();

	using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
	{
	    Result = streamReader.ReadToEnd();
	}
    }

}
