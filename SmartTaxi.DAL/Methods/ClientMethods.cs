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

		public int Accept(string order_id, string taxi_id, string phone, int is_accept = 1){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("order_id", order_id);
			parameters.Add ("taxi_id", taxi_id);
			parameters.Add ("phone", phone);
			parameters.Add ("is_accept", is_accept.ToString());

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/ClientAnswer/", parameters, Method.POST);
			return 200;
		}

		public void DeleteOrder(string order_id){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("order_id", order_id??"");

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/DeleteOrder/", parameters, Method.POST);
		}

		public void GetTaxiLocation(string order_id){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("order_id", order_id);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/GetTaxiLocation/", parameters, Method.POST);
		}

		public void NoDriver(string order_id){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("order_id", order_id);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/NoDriver/", parameters, Method.POST);
		}
	}
}

