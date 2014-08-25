using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartTaxi.Models;
using System.Net;

namespace SmartTaxi.DAL
{
	public class APIHelper
	{
		//private static string baseUrl = "http://smart.wk/";
		private static string baseUrl = "http://smarttaxi.1gb.ru/";
		private static RestClient restClient = null;
		public static string taxiId;
			

		private CityMethods cities;
		private TaxiMethods taxi;
		private OrderMethods orders;
		private ClientMethods clients;

		public APIHelper(){
			restClient = new RestClient (baseUrl + "");
		}

		public CityMethods Cities{
			get{ return this.cities??(this.cities = new CityMethods());}
		}

		public TaxiMethods Taxi{
			get{ return this.taxi??(this.taxi = new TaxiMethods());}
		}

		public OrderMethods Orders{
			get{ return this.orders??(this.orders = new OrderMethods());}
		}

		public ClientMethods Clients{
			get{ return this.clients??(this.clients = new ClientMethods());}
		}

		public static JObject Execute(	string method, 
										Dictionary<string,string> parameters, 
										Method httpMethod, 
										Dictionary<string,string> files = null, object obj = null){


			RestRequest request = new RestRequest ();
			request.Method = httpMethod;
			request.RequestFormat = DataFormat.Json;
			request.AddHeader("Content-Type", "application/json; charset=utf-8");


			if (files != null && files.Keys.Count > 0) {
				foreach (var key in files.Keys) {
					request.AddFile (key, files[key]);
				}
			}

			request.Resource = method;
			//StringBuilder sb = new StringBuilder ();
			foreach (var key in parameters.Keys) {
				request.AddParameter (key, parameters [key].ToString ());
			}

			var response = APIHelper.restClient.Execute (request);

			var sessionCookie = response.Cookies.SingleOrDefault(x => x.Name == "WRAD_SESSION");
			if (sessionCookie != null && APIHelper.restClient.CookieContainer==null)
			{
				APIHelper.restClient.CookieContainer = new CookieContainer ();
				APIHelper.restClient.CookieContainer.Add(new Uri(APIHelper.baseUrl),new Cookie(sessionCookie.Name, sessionCookie.Value, sessionCookie.Path, sessionCookie.Domain));
			}

			return JObject.Parse(response.Content);
		}

		public static JObject ExecuteCustom(string baseUrlCustom, 
			string resource,	 
			Method httpMethod, 
			Dictionary<string,string> files = null	){

			var restCustomClient = new RestClient ();
			restCustomClient.BaseUrl = baseUrlCustom;

			RestRequest request = new RestRequest ();
			request.Method = httpMethod;
			request.RequestFormat = DataFormat.Json;

			request.Resource = resource;
			var response = restCustomClient.Execute (request);
			return JObject.Parse(response.Content);
		}
	}
}

