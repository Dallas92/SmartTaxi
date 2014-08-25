using System;
using System.Collections.Generic;
using RestSharp;
using SmartTaxi.Models;

namespace SmartTaxi.DAL
{
	public class OrderMethods
	{
		public string Create(Order order){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("client_id", order.ClientId.ToString());
			parameters.Add ("order_from_address", order.FromAddress);
			parameters.Add ("order_from_location", order.FromLocation);
			parameters.Add ("order_to_address", order.ToAddress);
			parameters.Add ("order_to_location", order.ToLocation);
			parameters.Add ("order_comment", order.Comment);
			parameters.Add ("order_time", order.Minutes.ToString());
			//parameters.Add ("order_user_phone", "77713241546");
			parameters.Add ("city_id", order.CityId);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/CreateOrder/", parameters, Method.POST);

			string msg = json.ToString ();

			if (json ["meta"]["code"].ToString () == 200.ToString()) {
				return json ["data"] ["order_id"].ToString ();
			}
			else if (json ["meta"]["code"].ToString () == 500.ToString()) {
				return "";
			}

			return "";
		}

		public void GetById(string id){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("order_id", id);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/GetOrderById/", parameters, Method.POST);
			string val = json.ToString ();
		}

		public void Rate(string clientId, string orderId, int ratingRate, string taxiId){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("client_id", clientId);
			parameters.Add ("order_id", orderId);
			parameters.Add ("rating_rate", ratingRate.ToString());
			parameters.Add ("taxi_id", taxiId);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/AddComment/", parameters, Method.POST);
		}

		public List<Taxi> Processing(string order_id, string city_id ){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("order_id", order_id);
			parameters.Add ("city_id", city_id);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/ProcessingOrder/", parameters, Method.GET);
			var drivers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Taxi>> (json["data"]["drivers"].ToString ());
			return drivers;
		}
	}
}

