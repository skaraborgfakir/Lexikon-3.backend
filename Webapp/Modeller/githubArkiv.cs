// Time-stamp: <2021-08-27 13:48:16 stefan>

using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace Webapp.Modeller {
    public class Repo {
	private string _namn;
	private string _url;
	private string _description;

	public string Namn {
	    get { return _namn; }
	    set { _namn = value; }
	}
	public string Description {
	    get { return _description; }
	    set { _description = value; }
	}
	public string Url {
	    get { return _url; }
	    set { _url = value; }
	}
	public Repo(string url,
		    string description,
		    string namn) {
	    Url = url;
	    Namn=namn;
	    Description = description;
	}
    }

    public class githubArkiv {
	public List<Repo> samtligaArkiv;
	public string result;

	public string Result {
	    get         { return result; }
	    private set { result = value; }
	}

	public githubArkiv() {
	    // https://reqbin.com/req/csharp/c-vdhoummp/curl-get-json-example:
	    var         url = "https://api.github.com/users/Skaraborgfakir/repos";
	    var httpRequest = (HttpWebRequest) WebRequest.Create(requestUriString: url);

	    httpRequest.Accept = "application/json";
	    // api.github.com kräver att användaren anger UserAgent, men...
	    httpRequest.UserAgent = "Mosaic3/Kronos executive"; // fungerar det ? Konstig CYBER maskin
	    // det fungerar .... alltså kan man hitta på ganska så fritt.... :-)
	    // Console.WriteLine("\nThe HttpHeaders are \n{0}",
	    //		  httpRequest.Headers);

	    //
	    // sug ner strukturen
	    //
	    // var httpResponse = (HttpWebResponse) httpRequest.GetResponse();

	    samtligaArkiv = new List<Repo>();
	    samtligaArkiv.Add(new Repo( url: "https://github.com/skaraborgfakir/Lexikon-3.backend",
					namn: "Lexikon-3.backend",
					description: "inlämningsuppgifter"));
	    samtligaArkiv.Add(new Repo( url: "https://github.com/skaraborgfakir/corebts.com-test",
					namn: "corebts.com-test",
					description: "test av .Net"));
	    samtligaArkiv.Add(new Repo( url: "https://github.com/skaraborgfakir/skaraborgfakir.github.io",
					namn: "skaraborgfakir.github.io",
					description: "www skaraborgfakir.github.io"));

	    // using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
	    // {
	    //	Result = streamReader.ReadToEnd();
	    // }
	}

    }
}
