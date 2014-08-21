using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartTaxi.Models
{
	public class AddressComponents
	{
		[JsonProperty("long_name")]
		public string LongName { get; set; }

		[JsonProperty("short_name")]
		public string ShortName { get; set; }

		[JsonProperty("types")]
		public IList<string> Types { get; set; }
	}

	public class LocationO
	{

		[JsonProperty("lat")]
		public double Lat { get; set; }

		[JsonProperty("lng")]
		public double Lng { get; set; }
	}

	public class NS
	{

		[JsonProperty("lat")]
		public double Lat { get; set; }

		[JsonProperty("lng")]
		public double Lng { get; set; }
	}

	public class Viewport
	{

		[JsonProperty("northeast")]
		public NS Northeast { get; set; }

		[JsonProperty("southwest")]
		public NS Southwest { get; set; }
	}

	public class Bounds2
	{

		[JsonProperty("northeast")]
		public NS Northeast { get; set; }

		[JsonProperty("southwest")]
		public NS Southwest { get; set; }
	}

	public class Geometry
	{

		[JsonProperty("location")]
		public LocationO Location { get; set; }

		[JsonProperty("location_type")]
		public string LocationType { get; set; }

		[JsonProperty("viewport")]
		public Viewport Viewport { get; set; }

		[JsonProperty("bounds")]
		public Bounds2 Bounds { get; set; }
	}

	public class Result
	{

		[JsonProperty("address_components")]
		public IList<AddressComponents> AddressComponents { get; set; }

		[JsonProperty("formatted_address")]
		public string FormattedAddress { get; set; }

		[JsonProperty("geometry")]
		public Geometry Geometry { get; set; }

		[JsonProperty("types")]
		public IList<string> Types { get; set; }
	}

	public class GoogleMap
	{

		[JsonProperty("results")]
		public IList<Result> Results { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }
	}
}

