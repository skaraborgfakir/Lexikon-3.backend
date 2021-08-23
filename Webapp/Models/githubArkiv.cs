// Time-stamp: <2021-08-23 14:26:41 stefan>

using System.Net;
using System.IO;

public class githubArkiv {
    public string result;

    public string Result { get => result; }

    public githubArkiv() {
	// https://reqbin.com/req/csharp/c-vdhoummp/curl-get-json-example:
	var url = "https://api.github.com/Skaraborgfakir/repos";
	var httpRequest = (HttpWebRequest)WebRequest.Create(url);
	httpRequest.Accept = "application/json";

	var httpResponse = (HttpWebResponse) httpRequest.GetResponse();

	using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
	{
	    result = streamReader.ReadToEnd();
	}
    }

}
