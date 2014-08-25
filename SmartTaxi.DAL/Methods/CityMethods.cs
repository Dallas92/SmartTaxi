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
			}catch(Exception ex){
				int x = 0;
			}

			return cityName;
		}

		public string GetAddressByLocation(string lat, string lon){
			string address = "Не определен";

			try{
				var json = APIHelper.ExecuteCustom ("http://maps.googleapis.com", 
					"/maps/api/geocode/json?latlng=" + lat + "," + lon + "&sensor=false&language=ru", Method.GET);

				GoogleMap gmap = Newtonsoft.Json.JsonConvert.DeserializeObject<GoogleMap> (json.ToString());

				if(gmap.Status.Equals("OK")){
					address = gmap.Results.FirstOrDefault().FormattedAddress;
				}


				var res = gmap.Results.FirstOrDefault();
				if(res!=null){
					address="";

					string[] types = new string[]{"bus_station","transit_station","route","street_number","political","postal_code","establishment", "locality","administrative_area_level_2","administrative_area_level_1","country"};

					var acs = (from x in res.AddressComponents
						select new {
						name = x.LongName,
						types = x.Types
						}).ToList();

					var hasNewType = acs.Any(a=> a.types.Where(b=> !types.Contains(b)).Count() > 0);
					if(hasNewType){
						int x = 0;
					}



					var city = acs.FirstOrDefault(a=>a.types.Contains("locality"));
					if(city!=null){
						address +="г." + city.name;
					}

					var route = acs.FirstOrDefault(a=>a.types.Contains("route"));
					if(route!=null){
						var st_number = acs.FirstOrDefault(a=>a.types.Contains("street_number"));

						if(!string.IsNullOrEmpty(address)){
							address+=", ";
						}
						address +=route.name.Replace("улица","ул.").Replace("Улица","ул.");

						if(st_number!=null){
							address += " " + st_number.name;
						}

						var establishment = acs.FirstOrDefault(a=>a.types.Contains("establishment"));
						if(establishment!=null){
							address += ", " + establishment.name;
						}
					}
				}


			}catch(Exception ex){

			}

			return address;
		}
	}
}

