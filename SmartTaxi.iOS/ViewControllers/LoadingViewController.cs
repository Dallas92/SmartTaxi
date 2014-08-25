// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SmartTaxi.iOS
{
	public partial class LoadingViewController : UIViewController
	{
		public LoadingViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			this.NavigationController.NavigationBar.Hidden = true;
			this._logoImage.Image = ScreenResolutionUtil.FromBundle16x9("Default.png");



		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (Reachability.CheckInternetConnection ()) {
				System.Threading.Thread.Sleep (200);

				var vController = (AppDelegate.Storyboard.InstantiateViewController ("MainViewController") as UIViewController);
				//var vController = (AppDelegate.Storyboard.InstantiateViewController ("TaxistsViewController") as UIViewController);
				this.NavigationController.PushViewController (vController, false);
			} else {
				new UIAlertView("Уведомление", "Пожалуйста подключитесь к интернету и перезапустите приложение", null," Oк", null).Show();
			}
		}
	}
}
