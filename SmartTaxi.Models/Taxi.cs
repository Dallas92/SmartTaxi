using System;
using Newtonsoft.Json;

namespace SmartTaxi.Models
{
	public class Taxi
	{
		[JsonProperty("taxi_carnumber")]
		public string TaxiCarnumber { get; set; }

		[JsonProperty("taxi_color")]
		public string TaxiColor { get; set; }

		[JsonProperty("taxi_created")]
		public DateTime TaxiCreated { get; set; }

		[JsonProperty("taxi_id")]
		public string TaxiId { get; set; }

		[JsonProperty("taxi_password")]
		public string TaxiPassword { get; set; }

		[JsonProperty("taxi_isonline")]
		public bool TaxiIsonline { get; set; }

		[JsonProperty("taxi_lastname")]
		public string TaxiLastname { get; set; }

		[JsonProperty("taxi_location")]
		public string TaxiLocation { get; set; }

		[JsonProperty("taxi_marka")]
		public string TaxiMarka { get; set; }

		[JsonProperty("taxi_model")]
		public string TaxiModel { get; set; }

		[JsonProperty("taxi_phone")]
		public string TaxiPhone { get; set; }

		[JsonProperty("taxt_firstname")]
		public string TaxtFirstname { get; set; }

		[JsonProperty("taxi_photo")]
		public string TaxiPhoto { get; set; }

		[JsonProperty("city")]
		public City City{get;set;}

		public Taxi(){
			this.City = new City();
		}
	}
}



