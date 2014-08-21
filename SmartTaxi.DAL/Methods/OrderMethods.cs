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
			parameters.Add ("order_time", order.Minutes);
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
	}
}

