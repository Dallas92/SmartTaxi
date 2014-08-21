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
		public UIWindow window;
		public static UIStoryboard Storyboard = UIStoryboard.FromName ("MainStoryboard", null);
		public static UIViewController initialViewController;

		//Setting Keys
		public const string CLIENT_ID_KEY = "CLIENT_ID";

		//Services Keys
		public const string MapsApiKey = "AIzaSyBEBbO1m-vDH7cEUP5cqH04HdyXbQKZCIQ";

		//Global Fonts
		public static string FontRobotoCondensedLight = "RobotoCondensed-Light";

		//In memory Data
		public static MobileServiceClient MobileService = new MobileServiceClient(
			"https://smarttaxi.azure-mobile.net/",
			"TePRzrBubdDeznZltpRKkPKRLQqLdD22"
		);
		public string DeviceToken { get; set; }

		public static APIHelper API = new APIHelper ();
		public static string ClientId;
		public static string TaxiId{ get; set; }
		public static bool Flag {get;set;}


		public static UIColor AppColorYellow = UIColor.FromRGB (255, 216, 0);
		public static UIColor AppColorHalfYellow = UIColor.FromRGB (255, 247, 204);

		public Taxi taxi = new Taxi {
			TaxtFirstname = "Максим",
			TaxiLastname = "Чужой",
			TaxiPhone = "77713241540",
			TaxiPassword = "пароль",
			TaxiMarka = "Audi",
			TaxiModel = "A6",
			TaxiCarnumber = "x666ASP",
			TaxiColor = "4",
			City = new City{ CityId = "447055bf-db72-4313-af71-e7a84ae2ccd3", CityName = "Костанай" }
		};

		public static LocationManager Manager { get; set;}


		public AppDelegate(){
			//ParseClient.Initialize("xuVvtLuQYjCtqBwtSZCDrVbeyDbQJA6pCKBaetfp", "Z2No9yfa7CqmwSL6IyYANutXpQt1RUNZahturbpk");
		}


		public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
		{
			string trimmedDeviceToken = deviceToken.Description;
			if (!string.IsNullOrWhiteSpace(trimmedDeviceToken))
			{
				trimmedDeviceToken = trimmedDeviceToken.Trim('<');
				trimmedDeviceToken = trimmedDeviceToken.Trim('>');
			}
			DeviceToken = trimmedDeviceToken;


			var tb = MobileService.GetTable<Device>();
			tb.InsertAsync (new Device(){DeviceType="iOS", DeviceToken = ((AppDelegate)UIApplication.SharedApplication.Delegate).DeviceToken.Trim()});
		}

		public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
		{
			Debug.WriteLine(userInfo.ToString());
			NSObject inAppMessage;

			bool success = userInfo.TryGetValue(new NSString("inAppMessage"), out inAppMessage);

			if (success)
			{
				var alert = new UIAlertView("Got push notification", inAppMessage.ToString(), null, "OK", null);
				alert.Show();
			}
		}

		public override void FailedToRegisterForRemoteNotifications (UIApplication application , NSError error)
		{
			new UIAlertView("Error registering push notifications", error.LocalizedDescription, null, "OK", null).Show();
		}

		public override void DidReceiveRemoteNotification (UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
		{
			Console.WriteLine ("PUSH" + userInfo.ToString());
		}

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			CurrentPlatform.Init ();


			UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge;
			UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);



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

			Manager = new LocationManager();
			Manager.LocationUpdated += HandleLocationChanged;
			Manager.StartLocationUpdates();

			MapServices.ProvideAPIKey (MapsApiKey);

			string name = AppDelegate.API.Cities.GetCityNameByLocation ("53.209563", "63.625946");

			Flag = false;
//			AppDelegate.API.Clients.Connect (AppDelegate.ClientId.ToString()); // connect client
//			string id = AppDelegate.API.Orders.Create (new Order {
//				ClientId = AppDelegate.ClientId,
//				FromAddress = "Откуда",
//				ToAddress = "Куда",
//				FromLocation = "52.123124124, 75.123124124",
//				ToLocation = "52.123124124, 75.123124124",
//				Comment = "Голова болит помАгите",
//				Minutes = "60",
//				CityId = AppDelegate.API.Cities.GetCityByName (name)
//			});
//			AppDelegate.API.Taxi.Login (taxi.TaxiPhone, taxi.TaxiPassword); //login taxist
			//AppDelegate.API.Taxi.SetOnline (location.Coordinate.Latitude + "," + location.Coordinate.Longitude);

			window = new UIWindow (UIScreen.MainScreen.Bounds);

			initialViewController = Storyboard.InstantiateInitialViewController () as UIViewController;

			window.RootViewController = initialViewController;
			window.MakeKeyAndVisible ();

			return true;
		}

		public void HandleLocationChanged (object sender, LocationUpdatedEventArgs e)
		{
			// Handle foreground updates
//			CLLocation location = e.Location;
//
//			DateTime dt = DateTime.Now;
//
//			if (!string.IsNullOrEmpty(APIHelper.taxiId)) {
//
//				if (!Flag) {
//					Console.WriteLine ("I'm here at " + dt.ToString ());
//					AppDelegate.API.Taxi.SetOnline (location.Coordinate.Latitude + "," + location.Coordinate.Longitude);
//					Flag = true;
//				}
//
//				string name = AppDelegate.API.Cities.GetCityNameByLocation ("53.209563", "63.625946");
//
//				if (dt.Second % 5 == 0) {
//					Console.WriteLine ("Get my orders at " + dt.ToString ());
//					var orders = AppDelegate.API.Taxi.GetMyOrders (0);
//					var count = orders.Count;
//					if (count > 0) {
//						Console.WriteLine ("Found " + count + " orders");
//					} else {
//					}
//				}
//				else if (dt.Second % 29 == 0) {
//					Console.WriteLine ("I'm here at " + dt.ToString ());
//					AppDelegate.API.Taxi.SetOnline (location.Coordinate.Latitude + "," + location.Coordinate.Longitude);
//				}
//			}
		}

		//move to helper class
		public static void AddGestureRecognizer(UIView v){
			UITapGestureRecognizer gestureRecognizer = new UITapGestureRecognizer ();
			gestureRecognizer.AddTarget (() => v.EndEditing (true));
			gestureRecognizer.CancelsTouchesInView = true;
			v.AddGestureRecognizer (gestureRecognizer);
		}

		public static void InitClientId(){
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
	
		#region unused
		public override void WillEnterForeground (UIApplication application)
		{
			Console.WriteLine ("App will enter foreground");
		}

		// Runs when the activation transitions from running in the background to
		// being the foreground application.
		// Also gets hit on app startup
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
		#endregion
	
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

