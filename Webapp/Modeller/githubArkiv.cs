// Time-stamp: <2021-08-30 01:49:22 stefan>

using System;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Webapp.Modeller {
    public class Repo {
	private int    _id;
	private string _node_id;
	private string _name;
	private string _full_name;
	private string _url;
	private string _html_url;
	private string _description;

	public int Id {
	    get { return _id; }
	    set { _id = value; }
	}
	public string Node_Id {
	    get { return _node_id; }
	    set { _node_id = value; }
	}
	public string Name {
	    get { return _name; }
	    set { _name = value; }
	}
	public string Full_Name {
	    get { return _full_name; }
	    set { _full_name = value; }
	}
	public string Description {
	    get { return _description; }
	    set { _description = value; }
	}
	public string Html_Url {
	    get { return _html_url; }
	    set { _html_url = value; }
	}
	public string Url {
	    get { return _url; }
	    set { _url = value; }
	}

	public Repo(string html_url,
		    string url,
		    string description,
		    string name) {
	    Url = url;
	    Html_Url = html_url;
	    Name = name;
	    Description = description;
	}
    }

    public class githubArkiv {
	public List<Repo> samtligaArkiv;

	// HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
	static readonly HttpClient httpKlient = new HttpClient();

	public githubArkiv() {
	    // https://reqbin.com/req/csharp/c-vdhoummp/curl-get-json-example:
	    var         url = "https://api.github.com/users/Skaraborgfakir/repos";
	    var httpRequest = (HttpWebRequest) WebRequest.Create( requestUriString: url);

	    // markera att GET:paketet att vi vill ha JSON
	    httpRequest.Accept = "application/json";
	    // api.github.com kräver att användaren anger UserAgent, men...
	    httpRequest.UserAgent = "Mosaic3/Kronos executive"; // fungerar det ? Konstig CYBER maskin
	    // det fungerar .... alltså kan man hitta på ganska så fritt.... :-)
	    Console.WriteLine( "\nThe HttpHeaders are \n{0}", httpRequest.Headers);

	    //
	    // sug ner strukturen
	    //
	    var httpResponse = (HttpWebResponse) httpRequest.GetResponse();
	    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
	    {
		string JSONstruktur = streamReader.ReadToEnd();

		samtligaArkiv = JsonConvert.DeserializeObject<List<Repo>>(JSONstruktur);
	    }
	}
    }
}
