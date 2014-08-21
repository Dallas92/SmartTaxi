using System;
using MonoTouch.CoreLocation;
using MonoTouch.UIKit;

namespace SmartTaxi.iOS
{
	public class LocationManager
	{
		public LocationManager (){
			this.locMgr = new CLLocationManager();
		}

		protected CLLocationManager locMgr;

		public CLLocationManager LocMgr{
			get { return this.locMgr; }
		}

		public void StartLocationUpdates()
		{
			// we need the user’s permission to use GPS, so we check to make sure they’ve accepted
			if (CLLocationManager.LocationServicesEnabled) {
				//set the desired accuracy, in meters
				LocMgr.DesiredAccuracy = 1;
				//LocMgr.StartUpdatingLocation();



				if (CLLocationManager.LocationServicesEnabled) {
					//set the desired accuracy, in meters
					LocMgr.DesiredAccuracy = 1;

					LocMgr.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
					{
						// fire our custom Location Updated event
						LocationUpdated (this, new LocationUpdatedEventArgs (e.Locations [e.Locations.Length - 1]));
					};

					LocMgr.StartUpdatingLocation();
				}

			} else {
				Console.WriteLine ("Location services not enabled");
			}
		}

		// event for the location changing
		public event EventHandler<LocationUpdatedEventArgs> LocationUpdated = delegate { };

	}

	public class LocationUpdatedEventArgs : EventArgs
	{
		CLLocation location;

		public LocationUpdatedEventArgs(CLLocation location)
		{
			this.location = location;
		}

		public CLLocation Location
		{
			get { return location; }
		}
	}
}

