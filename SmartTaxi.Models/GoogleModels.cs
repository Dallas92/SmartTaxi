using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartTaxi.Models
{

	public class Bounds
	{

		[JsonProperty("northeast")]
		public Loc Northeast { get; set; }

		[JsonProperty("southwest")]
		public Loc Southwest { get; set; }
	}

	public class Distance
	{

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("value")]
		public int Value { get; set; }
	}

	public class Duration
	{

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("value")]
		public int Value { get; set; }
	}

	public class Loc
	{

		[JsonProperty("lat")]
		public double Lat { get; set; }

		[JsonProperty("lng")]
		public double Lng { get; set; }
	}

	public class Polyline
	{

		[JsonProperty("points")]
		public string Points { get; set; }
	}


	public class Step
	{

		[JsonProperty("distance")]
		public Distance Distance { get; set; }

		[JsonProperty("duration")]
		public Duration Duration { get; set; }

		[JsonProperty("end_location")]
		public Loc EndLocation { get; set; }

		[JsonProperty("html_instructions")]
		public string HtmlInstructions { get; set; }

		[JsonProperty("polyline")]
		public Polyline Polyline { get; set; }

		[JsonProperty("start_location")]
		public Loc StartLocation { get; set; }

		[JsonProperty("travel_mode")]
		public string TravelMode { get; set; }

		[JsonProperty("maneuver")]
		public string Maneuver { get; set; }
	}

	public class Legs
	{

		[JsonProperty("distance")]
		public Distance Distance { get; set; }

		[JsonProperty("duration")]
		public Duration Duration { get; set; }

		[JsonProperty("end_address")]
		public string EndAddress { get; set; }

		[JsonProperty("end_location")]
		public Loc EndLocation { get; set; }

		[JsonProperty("start_address")]
		public string StartAddress { get; set; }

		[JsonProperty("start_location")]
		public Loc StartLocation { get; set; }

		[JsonProperty("steps")]
		public IList<Step> Steps { get; set; }

		[JsonProperty("via_waypoint")]
		public IList<string> ViaWaypoint { get; set; }
	}

	public class OverviewPolyline
	{

		[JsonProperty("points")]
		public string Points { get; set; }
	}

	public class Route
	{

		[JsonProperty("bounds")]
		public Bounds Bounds { get; set; }

		[JsonProperty("copyrights")]
		public string Copyrights { get; set; }

		[JsonProperty("legs")]
		public IList<Legs> Legs { get; set; }

		[JsonProperty("overview_polyline")]
		public OverviewPolyline OverviewPolyline { get; set; }

		[JsonProperty("summary")]
		public string Summary { get; set; }

		[JsonProperty("warnings")]
		public IList<string> Warnings { get; set; }

		[JsonProperty("waypoint_order")]
		public IList<string> WaypointOrder { get; set; }
	}

	public class GoggleData
	{

		[JsonProperty("routes")]
		public IList<Route> Routes { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }
	}


}

