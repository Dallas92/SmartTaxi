using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using SmartTaxi.Models;
using MonoTouch.CoreLocation;
using Newtonsoft.Json;

namespace SmartTaxi.iOS
{
	public class GoogleHelper
	{
		public static string STREETNAME;
		public GoogleHelper ()
		{
		}

		public static List<Step> GetCoordinates(CLLocationCoordinate2D pointA, CLLocationCoordinate2D pointB){
			string baseUrlCustom = "http://maps.googleapis.com"; 
			string resource = "/maps/api/directions/json?"
				+ "origin=" + pointA.Latitude + "," + pointA.Longitude
				+ "&destination=" + pointB.Latitude + "," + pointB.Longitude
				+ "&sensor=false&units=metric&mode=driving";
			Method httpMethod = Method.GET;

			var restCustomClient = new RestClient ();
			restCustomClient.BaseUrl = baseUrlCustom;

			RestRequest request = new RestRequest ();
			request.Method = httpMethod;
			request.RequestFormat = DataFormat.Json;

			request.Resource = resource;
			var response = restCustomClient.Execute (request);
			//return JObject.Parse(response.Content);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<SmartTaxi.iOS.GoggleData> (JObject.Parse(response.Content).ToString());


			var route = data.Routes.FirstOrDefault ();
			if (route == null) return null;

			var leg = route.Legs.FirstOrDefault ();
			if (leg == null) return null;

			var steps = leg.Steps.ToList();
			if (steps == null)
				return null;

			return steps;
		}

		public static CLLocationCoordinate2D GetCoordinatesFromAddress(string initialaddress)
		{
			string baseUrlCustom = "http://maps.google.com/"; 
			string resource = "/maps/api/geocode/json?"
				+ "address=" + initialaddress.Replace(" ", "+") + "&sensor=false";
			Method httpMethod = Method.GET;

			var restCustomClient = new RestClient ();
			restCustomClient.BaseUrl = baseUrlCustom;

			RestRequest request = new RestRequest ();
			request.Method = httpMethod;
			request.RequestFormat = DataFormat.Json;

			request.Resource = resource;
			var response = restCustomClient.Execute (request);
			//return JObject.Parse(response.Content);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GoogleMap> (JObject.Parse(response.Content).ToString());
			//if(data == null)
				//return null;

			var res = data.Results.FirstOrDefault();
			//if(res == null)
				//return null;

			STREETNAME = res.FormattedAddress.ToString();

			var geo = res.Geometry;
			//if(geo == null)
				//return null;

			var loc = geo.Location;
			//if(loc == null)
				//return null;

			CLLocationCoordinate2D LL = new CLLocationCoordinate2D((double)loc.Lat, (double)loc.Lng);

			return LL;
		}

		public static List<CLLocationCoordinate2D> decodePoly(String encoded) {

			List<CLLocationCoordinate2D> poly = new List<CLLocationCoordinate2D>();
			int index = 0, len = encoded.Length;
			int lat = 0, lng = 0;

			while (index < len) {
				int b, shift = 0, result = 0;
				do {
					b = encoded.ElementAt(index++) - 63;
					result |= (b & 0x1f) << shift;
					shift += 5;
				} while (b >= 0x20);
				int dlat = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
				lat += dlat;

				shift = 0;
				result = 0;
				do {
					b = encoded.ElementAt(index++) - 63;
					result |= (b & 0x1f) << shift;
					shift += 5;
				} while (b >= 0x20);
				int dlng = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
				lng += dlng;




				string dla = ((((double)lat / 1E5) * 1E6).ToString()).Insert(2,".");
				string dlo = (((double) lng / 1E5) * 1E6).ToString().Insert(2,".");

				CLLocationCoordinate2D p = new CLLocationCoordinate2D (double.Parse (dla), double.Parse (dlo));
				poly.Add(p);
			}

			return poly;
		}
	}


}
