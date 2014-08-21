// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Google.Maps;
using System.Drawing;

namespace SmartTaxi.iOS
{
	public partial class FromViewController : UIViewController
	{
		public FromViewController (IntPtr handle) : base (handle){}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			AppDelegate.AddGestureRecognizer (this.View);
			_previewImg.Image = UIImage.FromBundle ("Menu/from.png");

			_fromTextField.AttributedPlaceholder = new NSAttributedString (
				"ОТКУДА",
				font: _fromTextField.Font,
				foregroundColor: UIColor.FromRGB(50,50,50)
			);
			_fromTextField.BecomeFirstResponder ();
			_fromTextField.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,25f);


			var camera = CameraPosition.FromCamera (
				latitude: 37.797865, 
				longitude: -122.402526, 
				zoom: 13);

			MapView mapView = MapView.FromCamera (RectangleF.Empty, camera);
			mapView.Frame = new RectangleF(0,94,this.View.Frame.Width, this.View.Frame.Height-94);

			Google.Maps.Marker marker = new Marker (){
				Position = new MonoTouch.CoreLocation.CLLocationCoordinate2D (37.797860, -122.402520),
				Icon = UIImage.FromBundle ("Map/from.png"),
				Map = mapView,
				Tappable = true,
				Draggable = true
			};
			mapView.StartRendering ();
			this.View.AddSubview (mapView);
		}
	}
}
