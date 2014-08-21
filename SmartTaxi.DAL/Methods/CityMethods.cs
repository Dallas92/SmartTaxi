using System;
using System.Linq;
using RestSharp;
using System.Collections.Generic;
using SmartTaxi.Models;

namespace SmartTaxi.DAL
{
	public class CityMethods
	{
		public string GetCityByName(string name){
			Dictionary<string,string> parameters = new Dictionary<string, string> ();
			parameters.Add ("name", name);

			var json = APIHelper.Execute ("wrada/method/call/class/WRAD_Login/func/GetCityId/", parameters, Method.GET);
			string val = json["data"]["city_id"].ToString ();
			return val;
		}

		public string GetCityNameByLocation(string lat, string lon){
			//http://maps.googleapis.com/maps/api/geocode/json?latlng=43.239784,76.82616200000007&sensor=false
			//http://stackoverflow.com/questions/17830686/how-to-get-city-from-coordinates
			//https://developers.google.com/maps/documentation/geocoding/

			string cityName = "Не определен";

			try{
				var json = APIHelper.ExecuteCustom ("http://maps.googleapis.com", 
					"/maps/api/geocode/json?latlng=" + lat + "," + lon + "&sensor=false&language=ru", Method.GET);

				GoogleMap gmap = Newtonsoft.Json.JsonConvert.DeserializeObject<GoogleMap> (json.ToString());

				if(gmap.Status.Equals("OK")){
					var res = gmap.Results.FirstOrDefault (a => a.Types.Any (b => b.Equals ("locality")));
					cityName = res.AddressComponents [0].LongName;
				}
			}catch{
			}

			return cityName;
		}
	}
}

