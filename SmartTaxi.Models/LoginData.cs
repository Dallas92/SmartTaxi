using System;
using Newtonsoft.Json;

namespace SmartTaxi.Models
{
	public class LoginData
	{
		[JsonProperty("meta")]
		public Meta Meta{get;set;}

		[JsonProperty("data")]
		public L2Data Data{get;set;}
	}

	public class L2Data{
		[JsonProperty("taxist_id")]
		public string TaxistId{get;set;}

		[JsonProperty("NEED_PHONE_CONFIRM")]
		public bool NeedToConfirmPhone{get;set;}

		[JsonProperty("current_order")]
		public bool HasOrders{get;set;}
	}

}

