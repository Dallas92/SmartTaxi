using System;
using System.Collections.Generic;
using RestSharp;

namespace SmartTaxi.DAL
{
	public class ClientMethods
	{
		public void Connect(string udid, string location = ""){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("udid", udid);
			if (!string.IsNullOrEmpty (location)) {
				parameters.Add ("location", location);
			}

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/ClientConnect/", parameters, Method.POST);
			string val = json.ToString ();
		}
	}
}

