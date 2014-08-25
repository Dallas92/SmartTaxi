// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SmartTaxi.iOS
{
	public partial class RetryCodeViewController : UIViewController
	{
		public RetryCodeViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			AppDelegate.AddGestureRecognizer (this.View);

			_img1.Image = UIImage.FromBundle ("Menu/attention.png");
			_text1.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,25f);

			_enterSmsLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);

			_enterSmsTextField.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			_enterSmsTextField.Layer.BackgroundColor = AppDelegate.AppColorHalfYellow.CGColor;
			_enterSmsTextField.Layer.BorderWidth = 2;
			_enterSmsTextField.Layer.BorderColor = UIColor.FromRGB (255,216,0).CGColor;

			_activateButton.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			_activateButton.Layer.BackgroundColor = UIColor.Clear.CGColor;
			_activateButton.Layer.BorderWidth = 2;
			_activateButton.Layer.BorderColor = AppDelegate.AppColorYellow.CGColor;
			_activateButton.TouchUpInside += (sender, e) => {
				var vController = (AppDelegate.Storyboard.InstantiateViewController ("TaxistsViewController") as UIViewController); 
				NavigationController.PushViewController (vController, true);
			};

			_infoLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,16f);

			_retryButton.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			_retryButton.Layer.BackgroundColor = UIColor.Clear.CGColor;
			_retryButton.Layer.BorderWidth = 2;
			_retryButton.Layer.BorderColor = AppDelegate.AppColorYellow.CGColor;
			_retryButton.TouchUpInside += (sender, e) => {

			};
		}
	}
}
