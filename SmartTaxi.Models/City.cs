using System;
using Newtonsoft.Json;

namespace SmartTaxi.Models
{
	public class City
	{
		[JsonProperty("city_name")]
		public string CityName { get; set; }

		[JsonProperty("city_id")]
		public string CityId { get; set; }
	}
}

