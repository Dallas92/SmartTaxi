// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Google.Maps;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Linq;
using MonoTouch.CoreLocation;

namespace SmartTaxi.iOS
{
	public partial class TrackingViewController : UIViewController
	{
		public MapView mapView;
		public int Mode;

		public TrackingViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (Mode == 1) {
				_statusLabel.Hidden = true;
				//_statusLB.Text = "Я НА МЕСТЕ";
				//_statusImage.Image = UIImage.FromBundle ("Map/molniya.png");
			} else if (Mode == 2) {
				_statusLB.Text = AppDelegate.Order.Minutes + " мин " + "+ 10 мин";
				_statusImage.Image = UIImage.FromBundle ("Map/timer.png")
				;
			}
			_statusLB.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);

			AppDelegate.currentViewController = this;

			AppDelegate.AddGestureRecognizer (this.View);

			_img1.Image = UIImage.FromBundle ("Menu/compass.png");
			_btn1.SetImage (UIImage.FromBundle ("Common/back.png"), UIControlState.Normal);
			_btn1.TouchUpInside += (sender, e) => {

				AppDelegate.API.Clients.DeleteOrder(AppDelegate.Order.OrderId);
				AppDelegate.Order = new SmartTaxi.Models.Order();

				var vController = (AppDelegate.Storyboard.InstantiateViewController ("MainViewController") as UIViewController);
				this.NavigationController.PushViewController (vController, false);
			};

			_txt1.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,25f);


			var camera = CameraPosition.FromCamera (
				latitude: double.Parse (AppDelegate.Order.FromLocation.Split (',') [0]), 
				longitude: double.Parse (AppDelegate.Order.FromLocation.Split (',') [1]), 
				zoom: 13);

			mapView = MapView.FromCamera (RectangleF.Empty, camera);
			if (Mode == 1) {
				mapView.Frame = new RectangleF (0, 94, this.View.Frame.Width, this.View.Frame.Height - 94);
			} else {
				mapView.Frame = new RectangleF (0, 94, this.View.Frame.Width, this.View.Frame.Height - 94 - 44);
			}
//			mapView.TappedMarker = (map, marker) => {
//				if(marker.UserData!=null){
//					var drId = (marker.UserData as NSString).ToString();
//					var dr = AppDelegate.Drivers.FirstOrDefault(a=>a.TaxiId==drId);
//
//					if(dr!=null){
//						TaxiInfoViewController.taxi = dr;
//						var vController = (AppDelegate.Storyboard.InstantiateViewController ("TaxiInfoViewController") as UIViewController); 
//						NavigationController.PushViewController (vController, true);
//					}
//				}
//
//				return true;
//			};

			mapView.StartRendering ();
			this.View.AddSubview (mapView);


			//DRAW ROUTE
			CLLocationCoordinate2D start = new CLLocationCoordinate2D();
			CLLocationCoordinate2D end = new CLLocationCoordinate2D();

			if (Mode == 1) {
				start = new MonoTouch.CoreLocation.CLLocationCoordinate2D (double.Parse (AppDelegate.Order.ToLocation.Split (',') [0]), double.Parse (AppDelegate.Order.ToLocation.Split (',') [1]));
				end = new MonoTouch.CoreLocation.CLLocationCoordinate2D (double.Parse (AppDelegate.Order.FromLocation.Split (',') [0]), double.Parse (AppDelegate.Order.FromLocation.Split (',') [1]));
			} else if (Mode == 2) {
				start = new MonoTouch.CoreLocation.CLLocationCoordinate2D (53.218316, 63.630535);
				end = new MonoTouch.CoreLocation.CLLocationCoordinate2D (double.Parse (AppDelegate.Order.FromLocation.Split (',') [0]), double.Parse (AppDelegate.Order.FromLocation.Split (',') [1]));
			}

			//SET FROM
			if (Mode == 1) {
				Google.Maps.Marker marker4 = new Marker (){
					Position = start,
					Icon = UIImage.FromBundle ("Map/from.png"),
					Map = mapView,
					Tappable = true
				};

				Google.Maps.Marker marker5 = new Marker (){
					Position = end,
					Icon = UIImage.FromBundle ("Map/to.png"),
					Map = mapView,
					Tappable = true
				};

				Google.Maps.Marker marker21 = new Marker (){
					Position = new CLLocationCoordinate2D(53.220768, 63.655300),
					//Position = new CLLocationCoordinate2D(AppDelegate.MyLocation.Coordinate.Latitude,AppDelegate.MyLocation.Coordinate.Longitude),
					Icon = UIImage.FromBundle ("Map/taxi.png"),
					Map = mapView,
					Tappable = true
				};
			} else {
				Google.Maps.Marker marker31 = new Marker (){
					Position = start,
					Icon = UIImage.FromBundle ("Map/taxi.png"),
					Map = mapView,
					Tappable = true
				};

				Google.Maps.Marker marker41 = new Marker (){
					Position = end,
					Icon = UIImage.FromBundle ("Map/from.png"),
					Map = mapView,
					Tappable = true
				};

				Google.Maps.Marker marker51 = new Marker (){
					Position = new MonoTouch.CoreLocation.CLLocationCoordinate2D (53.212508, 63.615343),
					Icon = UIImage.FromBundle ("Map/to.png"),
					Map = mapView,
					Tappable = true
				};
			}



			try{
			var steps = GoogleHelper.GetCoordinates(start, end);
			if (steps != null) {


				foreach (var step in steps) {
					Google.Maps.Polyline rectOptions = new Google.Maps.Polyline ();
					rectOptions.StrokeColor = AppDelegate.AppColorYellow;
					rectOptions.StrokeWidth = 4;


					MutablePath mPath = new MutablePath ();

					List<CLLocationCoordinate2D> arr = GoogleHelper.decodePoly (step.Polyline.Points);
					for(int j = 0 ; j < arr.Count; j++) 
					{
						mPath.AddCoordinate (new CLLocationCoordinate2D (arr [j].Latitude, arr [j].Longitude));
					}
					rectOptions.Path = mPath;
					rectOptions.Map = mapView;
				}
			} else {
				var alert = new UIAlertView ("Уведомление", "Не удалось построить маршрут", null, "ок");
				alert.Show ();
			}
			}catch{
				var alert = new UIAlertView ("Уведомление", "Не удалось построить маршрут", null, "ок");
				alert.Show ();
			}

		}


		public void ShowDriverLocation(){
			mapView.Clear ();

			Google.Maps.Marker marker2 = new Marker (){
				Position = new MonoTouch.CoreLocation.CLLocationCoordinate2D (53.216040, 63.631954),
				Icon = UIImage.FromBundle ("Map/from.png"),
				Map = mapView,
				Tappable = true,
				//UserData =  new NSString(Appde)
			};

			Google.Maps.Circle circle = new Circle () {


			};
			circle.FillColor = UIColor.FromRGBA(255, 216, 0,50);
			circle.StrokeColor = UIColor.FromRGB(240,240,240);
			circle.StrokeWidth = 1;
			circle.Position = new MonoTouch.CoreLocation.CLLocationCoordinate2D (53.216040, 63.631954);
			circle.Radius = 1000;
			circle.Map = mapView;



//			if (AppDelegate.Drivers != null && AppDelegate.Drivers.Count > 0) {
//				foreach (var dr in AppDelegate.Drivers) {
//					Google.Maps.Marker marker = new Marker (){
//						Position = new MonoTouch.CoreLocation.CLLocationCoordinate2D (double.Parse(dr.TaxiLocation.Split(',')[0]),
//							double.Parse(dr.TaxiLocation.Split(',')[1])),
//						Icon = UIImage.FromBundle ("Map/taxi.png"),
//						Map = mapView,
//						Tappable = true,
//						UserData = new NSString(dr.TaxiId)
//							//Draggable = true
//					};
//				}
//			}
		}
	}
}