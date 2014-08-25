using System;
using System.Collections.Generic;
using SmartTaxi.Models;
using RestSharp;

namespace SmartTaxi.DAL
{
	public class TaxiMethods
	{
		public int Register(Taxi taxi, Dictionary<string,string> files=null){
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

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/WRAD_Register/", parameters, Method.POST, files, taxi);
			return int.Parse (json ["meta"] ["code"].ToString ());
		}

		public LoginData Login(string phone,string password){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("username", phone);
			parameters.Add ("password", password);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/WRAD_Login/", parameters, Method.POST);
			string str = json.ToString ();

			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginData> (json.ToString());

			if (json ["meta"]["code"].ToString () == 200.ToString()) {
				APIHelper.taxiId = json ["data"] ["taxist_id"].ToString ();
			}
			else if (json ["meta"]["code"].ToString () == 500.ToString()) {
			}

			return data;
			//return json ["meta"] ["code"].ToString ();
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

		public Taxi GetProfile(string id=""){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();

			if (string.IsNullOrEmpty (id)) {
				parameters.Add ("taxi_id", APIHelper.taxiId);
			} else {
				parameters.Add ("taxi_id",id);
			}

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/GetTaxiProfile/", parameters, Method.POST);
			var str = json.ToString ();
			var taxi = Newtonsoft.Json.JsonConvert.DeserializeObject<Taxi> (json["data"].ToString());
			return taxi;
		}

		public void SetOnline(string coord){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("coords", coord);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/ImHere/", parameters, Method.POST);
		}
	
		public List<Order> GetMyOrders(){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/GetMyOrders/", parameters, Method.POST);
			var orders = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Order>> (json["data"]["orders"].ToString ());
			return orders;
		}

		public void SetPrice(string order_id, int price){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("order_id", order_id);
			parameters.Add ("price", price.ToString());

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/MakeResponse/", parameters, Method.POST);
		}

		public void CancelOrder(string order_id){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("order_id", order_id);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/SayNo/", parameters, Method.POST);
		}

		public void DriverCome(string order_id){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("order_id", order_id);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/DriverCome/", parameters, Method.POST);
		}

		public void ResendSMSCode(){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/Resend/", parameters, Method.POST);
		}
	}
}

