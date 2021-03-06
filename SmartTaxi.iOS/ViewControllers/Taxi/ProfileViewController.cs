// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SmartTaxi.iOS
{
	public partial class ProfileViewController : UIViewController
	{
		public ProfileViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			_starView.Frame = new System.Drawing.RectangleF (_starView.Frame.X, _starView.Frame.Y, 0, 0);
			base.ViewWillAppear (animated);

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			AppDelegate.AddGestureRecognizer (this.View);

			//_scrollView.ScrollEnabled = true;
			//_scrollView.Frame = new System.Drawing.RectangleF (0, 0, this.View.Frame.Width, this.View.Frame.Height);
			//_scrollView.ContentSize = new System.Drawing.SizeF (0, 745);
			_previewImg.Image = UIImage.FromBundle ("Menu/id.png");
			_headerLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,25f);
			_backButton.SetImage (UIImage.FromBundle ("Common/back.png"), UIControlState.Normal);
			_backButton.TouchUpInside += (sender, e) => {
				this.NavigationController.PopViewControllerAnimated(true);
			};


			_fioLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,24f);
			_fioLabel.Text = AppDelegate.Taxi.TaxiLastname + " " + AppDelegate.Taxi.TaxtFirstname;

			_ratedLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);
			_ratedLabel.Text = "ПРОГОЛОСОВАЛО " + AppDelegate.Taxi.RatingCount;

			_carImage.Image = UIImage.FromBundle ("ribaphoto.png");

			_starImageView.Image = UIImage.FromBundle ("Common/star.png");
			_star2ImageView.Image = UIImage.FromBundle ("Common/star.png");
			_star3ImageView.Image = UIImage.FromBundle ("Common/star.png");
			_star4ImageView.Image = UIImage.FromBundle ("Common/star.png");
			_star5ImageView.Image = UIImage.FromBundle ("Common/star.png");


			_modelHeaderLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);

			_modelValueLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			_modelValueLabel.Text = AppDelegate.Taxi.TaxiModel;

			_markaHeader.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);
			_markaValueLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			_markaValueLabel.Text = AppDelegate.Taxi.TaxiMarka;

			_numberHeaderLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);
			_numberValueLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			_numberValueLabel.Text = AppDelegate.Taxi.TaxiCarnumber;

			_colorHeaderLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);
			_colorValueLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			_colorValueLabel.Text = AppDelegate.Taxi.TaxiColor;

			_carImage.BackgroundColor = UIColor.Gray;


			_instructionButton.Layer.BackgroundColor = UIColor.Clear.CGColor;
			_instructionButton.Layer.BorderWidth = 2;
			_instructionButton.Layer.BorderColor = AppDelegate.AppColorYellow.CGColor;
			_instructionButton.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);
			_instructionButton.TouchUpInside += (sender, e) => {
				var vController = (AppDelegate.Storyboard.InstantiateViewController ("InstructionsViewController") as UIViewController); 
				NavigationController.PushViewController (vController, true);
			};

			_identificatorLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);

			_identificatorTextField.Layer.BackgroundColor = AppDelegate.AppColorHalfYellow.CGColor;
			_identificatorTextField.Layer.BorderWidth = 2;
			_identificatorTextField.Layer.BorderColor = AppDelegate.AppColorHalfYellow.CGColor;
			_identificatorTextField.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			_identificatorTextField.Enabled = false;
			_identificatorTextField.Text = AppDelegate.Taxi.TaxiPhone;
		}
	}
}
