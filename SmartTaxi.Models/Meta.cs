using System;
using Newtonsoft.Json;

namespace SmartTaxi.Models
{
	public class Meta
	{
		[JsonProperty("code")]
		public int Code{get;set;}

		[JsonProperty("message")]
		public string Message{get;set;}
	}
}

