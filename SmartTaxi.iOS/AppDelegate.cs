using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SmartTaxi.DAL;
using Google.Maps;
using MonoTouch.CoreLocation;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using SmartTaxi.Models;
using Microsoft.WindowsAzure.MobileServices;
using System.Diagnostics;

namespace SmartTaxi.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		//App objects
		public UIWindow window;
		public static UIStoryboard Storyboard = UIStoryboard.FromName ("MainStoryboard", null);
		public static UIViewController initialViewController;
		public static UIViewController currentViewController;

		//Setting Keys
		public const string CLIENT_ID_KEY = "CLIENT_ID";
		public const string CLIENT_PHONE_KEY = "CLIENT_PHONE";
		public static string CityId = "447055bf-db72-4313-af71-e7a84ae2ccd3";

		//Services Keys
		public const string MapsApiKey = "AIzaSyA5HVvoDnP9SR0DOtyvMCR94FI-srOs36o";

		//Global Fonts
		public static string FontRobotoCondensedLight = "RobotoCondensed-Light";

		//Global Colors
		public static UIColor AppColorYellow = UIColor.FromRGB (255, 216, 0);
		public static UIColor AppColorHalfYellow = UIColor.FromRGB (255, 247, 204);

		//Push Notifications
		public static MobileServiceClient MobileService = new MobileServiceClient(
			"https://smarttaxi.azure-mobile.net/",
			"TePRzrBubdDeznZltpRKkPKRLQqLdD22"
		);

		//Background Location Manager
		public static LocationManager Manager { get; set;}

		//Static Data
		public static APIHelper API = new APIHelper ();
		public static string ClientId{ get; set; }
		public static string TaxiId{ get; set; }
		public string DeviceToken { get; set; }
		public static Order Order{ get; set; }
		public static Taxi Taxi{get;set;}
		public static bool isTaxi{get;set;}
		public static List<Order> Orders{get;set;}
		public static List<Taxi> Drivers{get;set;}
		public static CLLocation MyLocation{ get; set; }

		#region Temporary data
		public bool Test{ get; set; }
		public bool Flag {get;set;}
		public bool Flag2 = false;
		public bool Flag3 {get;set;}
		public string OrderId;
		#endregion

		public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
		{
			string trimmedDeviceToken = deviceToken.Description;
			if (!string.IsNullOrWhiteSpace(trimmedDeviceToken))
			{
				trimmedDeviceToken = trimmedDeviceToken.Trim('<');
				trimmedDeviceToken = trimmedDeviceToken.Trim('>');
			}
			DeviceToken = trimmedDeviceToken;

			//MobileService.GetTable<Device>().InsertAsync (new Device(){DeviceType="iOS", DeviceToken = DeviceToken.Trim().Replace(" ","")});
		}

		#region unused
		public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
		{
			Debug.WriteLine(userInfo.ToString());
			NSObject inAppMessage;

			bool success = userInfo.TryGetValue(new NSString("inAppMessage"), out inAppMessage);
		}
		#endregion

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			CurrentPlatform.Init ();

			//UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge;
			//UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);

			#region unused
			// screen subscribes to the location changed event
			//			UIApplication.Notifications.ObserveDidBecomeActive ((sender, args) => {
			//
			//			});
			//
			//			// whenever the app enters the background state, we unsubscribe from the event 
			//			// so we no longer perform foreground updates
			//			UIApplication.Notifications.ObserveDidEnterBackground ((sender, args) => {
			////				NSTimer.CreateRepeatingScheduledTimer (10, delegate {
			////				
			////				});
			//			});
			#endregion

			InitClientId ();

			isTaxi = true;
			Test = true;
			Order = new Order ();

			Manager = new LocationManager();
			if (Test) {
				Manager.LocationUpdated += HandleLocationChanged;
			}
			Manager.StartLocationUpdates();

			MapServices.ProvideAPIKey (MapsApiKey);

			if (Test) {
				AppDelegate.API.Clients.Connect (AppDelegate.ClientId.ToString ()); 
//				OrderId = AppDelegate.API.Orders.Create (new Order {
//					ClientId = AppDelegate.ClientId,
//					FromAddress = AppDelegate.Order.FromAddress,
//					ToAddress = AppDelegate.Order.ToAddress,
//					FromLocation = "52.123124124, 75.123124124",
//					ToLocation = "52.123124124, 75.123124124",
//					Comment = AppDelegate.Order.Comment,
//					Minutes = AppDelegate.Order.Minutes,
//					CityId = "447055bf-db72-4313-af71-e7a84ae2ccd3"
//				});
			}

			window = new UIWindow (UIScreen.MainScreen.Bounds);

			initialViewController = Storyboard.InstantiateInitialViewController () as UIViewController;
			window.RootViewController = initialViewController;
			window.MakeKeyAndVisible ();
			return true;
		}

		public void HandleLocationChanged (object sender, LocationUpdatedEventArgs e)
		{
			MyLocation = e.Location;

			if (!string.IsNullOrEmpty(APIHelper.taxiId)) {

//				if (!Flag) {
//					Console.WriteLine ("I'm here at " + DateTime.Now.ToString ());
//					AppDelegate.API.Taxi.SetOnline ("55.123124124" + ", " + "70.123124124");
//

//
//					Flag = true;
//				}

				if (DateTime.Now.Second % 10 == 0) {

					if (!AppDelegate.isTaxi) {
						//if (!string.IsNullOrEmpty (OrderId)) {
							Console.WriteLine ("Processing orders " + DateTime.Now.ToString ());
							//AppDelegate.Drivers = AppDelegate.API.Orders.Processing (OrderId, "447055bf-db72-4313-af71-e7a84ae2ccd3");
							
						AppDelegate.Drivers = new List<Taxi> {
							new Taxi{TaxiId="1", TaxiLocation="53.218316, 63.630535", TaxiLastname="Пришвин",TaxtFirstname ="Сергей", RatingCount = 5, Rating = 5, TaxiMarka="KIA", TaxiModel = "Sorento", TaxiCarnumber = "123AAA02", TaxiColor="Серебристый", TaxiPhoto="http://avtomasta.ru/wp-content/uploads/2013/12/1.jpg"},
							new Taxi{TaxiId="2",TaxiLocation="53.223249, 63.643839", TaxiLastname="Пришвин",TaxtFirstname ="Сергей", RatingCount = 5, Rating = 5, TaxiMarka="KIA", TaxiModel = "Sorento", TaxiCarnumber = "123AAA02", TaxiColor="Серебристый", TaxiPhoto="http://avtomasta.ru/wp-content/uploads/2013/12/1.jpg"},
							new Taxi{TaxiId="3",TaxiLocation="53.212508, 63.615343", TaxiLastname="Пришвин",TaxtFirstname ="Сергей", RatingCount = 5, Rating = 5, TaxiMarka="KIA", TaxiModel = "Sorento", TaxiCarnumber = "123AAA02", TaxiColor="Серебристый", TaxiPhoto="http://avtomasta.ru/wp-content/uploads/2013/12/1.jpg"},
						};

						if (currentViewController.GetType () == typeof(ChooseTaxiViewController)) {
							(currentViewController as ChooseTaxiViewController).ShowDrivers ();
						}


//							if (drivers.Count > 0) {
//								Console.WriteLine ("Found " + drivers.Count + " drivers");
//								var driverWithPrice = drivers.FirstOrDefault (a => a.price > 0);
//								if (driverWithPrice != null && Flag2) {
//									Console.WriteLine ("Accepting 1 order at: " + DateTime.Now.ToString ());
//									AppDelegate.API.Clients.Accept (OrderId, driverWithPrice.TaxiId, "77713241546", 1);
//								}
//							} 
						//}
					}

					if (AppDelegate.isTaxi) {
						Console.WriteLine ("Get my orders at " + DateTime.Now.ToString ());
						AppDelegate.Orders = AppDelegate.API.Taxi.GetMyOrders ();

//						var count = orders.Count;
//						if (count > 0) {
//							Console.WriteLine ("Found " + count + " orders");
//							if (!Flag2) {
//								var order = orders.FirstOrDefault ();
//								AppDelegate.API.Taxi.SetPrice (order.OrderId, 500);
//								Console.WriteLine ("Set price for order at: " + DateTime.Now.ToString ());
//
//								//AppDelegate.API.Taxi.CancelOrder (order.OrderId);
//								//Console.WriteLine ("Cancelled order at: " + DateTime.Now.ToString());
//								Flag2 = true;
//							}
//						} 
					}
				}
				if (DateTime.Now.Second % 30 == 0) {
					if (AppDelegate.isTaxi) {
						Console.WriteLine ("I'm here at " + DateTime.Now.ToString ());
						//AppDelegate.API.Taxi.SetOnline (location.Coordinate.Latitude.ToString().Replace(",",".") + ", " + location.Coordinate.Longitude.ToString().Replace(",","."));
						AppDelegate.API.Taxi.SetOnline ("55.123124124" + ", " + "70.123124124");
					}
				}
			}
		}

		//move to helper class
		public static void AddGestureRecognizer(UIView v){
			UITapGestureRecognizer gestureRecognizer = new UITapGestureRecognizer ();
			gestureRecognizer.AddTarget (() => v.EndEditing (true));
			gestureRecognizer.CancelsTouchesInView = true;
			v.AddGestureRecognizer (gestureRecognizer);
		}

		public void InitClientId(){
			if (!string.IsNullOrEmpty (AppDelegate.AppSettingGet (CLIENT_ID_KEY))) {
				ClientId = AppDelegate.AppSettingGet (CLIENT_ID_KEY);
			} else {
				var newGuid = Guid.NewGuid ();
				ClientId = newGuid.ToString();
				AppDelegate.AppSettingSet (CLIENT_ID_KEY, ClientId);
			}
		}

		public static string AppSettingGet(string key){
			string value = NSUserDefaults.StandardUserDefaults.StringForKey(key); 
			if (value == null)
				return "";
			else
				return value;
		}

		public static void AppSettingSet(string key, string value){
			NSUserDefaults.StandardUserDefaults.SetString(value.ToString (), key); 
			NSUserDefaults.StandardUserDefaults.Synchronize ();
		}
	
		public override void OnActivated (UIApplication application)
		{
			Console.WriteLine ("App is becoming active");
		}

		public override void OnResignActivation (UIApplication application)
		{
			Console.WriteLine ("App moving to inactive state.");
		}

		public override void DidEnterBackground (UIApplication application)
		{
			Console.WriteLine ("App entering background state.");
			Console.WriteLine ("Now receiving location updates in the background");
		}

		public override void WillEnterForeground (UIApplication application)
		{
			Console.WriteLine ("App will enter foreground");
		}
	
		#region old parse
		//		public async override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		//		{
		//			await CreateUserAsync ();
		//
		//			try {
		//				var client = new RestClient ("https://api.parse.com");
		//
		//				var request = new RestRequest ("1/installations/", Method.POST);
		//
		//				request.AddHeader ("Accept", "application/json");
		//				request.AddHeader ("X-Parse-Application-Id", "xuVvtLuQYjCtqBwtSZCDrVbeyDbQJA6pCKBaetfp");
		//				request.AddHeader ("X-Parse-REST-API-Key", "Z2No9yfa7CqmwSL6IyYANutXpQt1RUNZahturbpk");
		//				request.Credentials = new NetworkCredential ("xuVvtLuQYjCtqBwtSZCDrVbeyDbQJA6pCKBaetfp", "sOkNzFs4pFLwrpPMPGODFpZEi2dPcxmhNf4dUsvI");
		//
		//				request.Parameters.Clear ();
		//
		//				string strJSONContent = "{\"owner\":\""+ParseUser.CurrentUser.ObjectId +"\",\"deviceType\":\"ios\",\"deviceToken\":\"" + deviceToken.Description.Replace ("<", "").Replace (">", "").Replace (" ", "") + "\"}";
		//
		//				request.AddParameter ("application/json", strJSONContent, ParameterType.RequestBody);
		//
		//
		//				client.ExecuteAsync (request, response => {
		//					Console.WriteLine (response.Content);
		//				});
		//			} catch (Exception  ex) {
		//				Console.WriteLine (ex.Message);
		//			}
		//
		//		}

		//		public async Task CreateUserAsync ()
		//		{
		//			var user = new ParseUser ()
		//			{
		//				Username = "my name",
		//				Password = "my pass",
		//				Email = "email@example.com"
		//			};
		//
		//			// other fields can be set just like with ParseObject
		//			user ["phone"] = "415-392-0202";
		//
		//			//await user.SignUpAsync ();
		//		}
		#endregion

	}
}

