using System;
using System.Collections.Generic;
using SmartTaxi.Models;
using RestSharp;

namespace SmartTaxi.DAL
{
	public class TaxiMethods
	{
		public void Register(Taxi taxi, Dictionary<string,string> files=null){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("firstname", taxi.TaxtFirstname);
			parameters.Add ("lastname", taxi.TaxiLastname);
			parameters.Add ("phone", taxi.TaxiPhone);
			parameters.Add ("password", taxi.TaxiPassword);
			parameters.Add ("cityId", taxi.City.CityId);
			parameters.Add ("marka", taxi.TaxiMarka);
			parameters.Add ("model", taxi.TaxiModel);
			parameters.Add ("autoNumber", taxi.TaxiCarnumber);
			parameters.Add ("color", taxi.TaxiColor);

			try{
			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/WRAD_Register/", parameters, Method.POST, files, taxi);
			}
			catch{
			}
			//if (json ["meta"]["code"].ToString () == 200.ToString()) {
			//}
			//else if (json ["meta"]["code"].ToString () == 500.ToString()) {
			//}
		}

		public void Login(string phone,string password){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("username", phone);
			parameters.Add ("password", password);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/WRAD_Login/", parameters, Method.POST);

			if (json ["meta"]["code"].ToString () == 200.ToString()) {
				APIHelper.taxiId = json ["data"] ["taxist_id"].ToString ();
			}
			else if (json ["meta"]["code"].ToString () == 500.ToString()) {
			}
		}

		public void Logout(){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/Logout/", parameters, Method.POST);
		}

		public void Activate(string code){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("code", code);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/ActivateUser/", parameters, Method.POST);
		}

		public void ResetPassword(string phone){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("phone", phone);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/ResetPassword/", parameters, Method.POST);
		}

		public void GetProfile(string id=""){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();

			if (string.IsNullOrEmpty (id)) {
				parameters.Add ("taxi_id", APIHelper.taxiId);
			} else {
				parameters.Add ("taxi_id",id);
			}

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/GetTaxiProfile/", parameters, Method.POST);
			var taxi = Newtonsoft.Json.JsonConvert.DeserializeObject<Taxi> (json["data"].ToString ());
		}

		public void SetOnline(string coord){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("coords", coord);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/ImHere/", parameters, Method.POST);
		}
	
		public List<Order> GetMyOrders(int status){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/GetMyOrders/", parameters, Method.POST);
			var orders = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Order>> (json["data"]["orders"].ToString ());
			return orders;
		}
	}
}

