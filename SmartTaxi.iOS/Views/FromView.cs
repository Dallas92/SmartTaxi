using System;
using MonoTouch.UIKit;
using System.Drawing;
using Google.Maps;

namespace SmartTaxi.iOS
{
	public class FromView:UIView
	{
		MapView mapView;

		public FromView (RectangleF frame, UIViewController _ctrl)
		{
			var camera = CameraPosition.FromCamera (
				latitude: 37.797865, 
				longitude: -122.402526, 
				zoom: 13);

			MapView mapView = MapView.FromCamera (RectangleF.Empty, camera);
			mapView.Frame = frame;

			Google.Maps.Marker infoWindow = new Marker ();
			infoWindow.Position = new MonoTouch.CoreLocation.CLLocationCoordinate2D (37.797860, -122.402520);
			infoWindow.Icon = UIImage.FromBundle ("Map/from.png");
			infoWindow.Map = mapView;
			infoWindow.Tappable = true;
			infoWindow.Draggable = true;

			this.AddSubview(mapView);
			mapView.StartRendering ();
		}
			
	}
}

