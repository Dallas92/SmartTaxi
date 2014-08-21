using System;
using Newtonsoft.Json;

namespace SmartTaxi.Models
{
	public class Order
	{
		[JsonProperty("client_id")]
		public string ClientId{get;set;}

		[JsonProperty("order_from_address")]
		public string FromAddress{ get; set; }

		[JsonProperty("order_from_location")]
		public string FromLocation{ get; set; }

		[JsonProperty("order_to_address")]
		public string ToAddress{ get; set; }

		[JsonProperty("order_to_location")]
		public string ToLocation{ get; set; }

		[JsonProperty("order_comment")]
		public string Comment{get;set;}

		[JsonProperty("order_time")]
		public string Minutes{get;set;}

		[JsonProperty("city_id")]
		public string CityId{get;set;}
	}
}

