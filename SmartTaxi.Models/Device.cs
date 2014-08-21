using System;
using System.Runtime.Serialization;

namespace SmartTaxi.Models
{
	[DataContract(Name="Devices")]
	public class Device
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "DeviceType")]
		public string DeviceType { get; set; }

		[DataMember(Name = "DeviceToken")]
		public string DeviceToken { get; set; }
	}
}

