// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SmartTaxi.Models;
using SDWebImage;
using System.Drawing;

namespace SmartTaxi.iOS
{
	public partial class TaxiInfoViewController : UIViewController
	{
		public static Taxi taxi;
		public float CurOffset;

		public TaxiInfoViewController (IntPtr handle) : base (handle)
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


			_previewImg.Image = UIImage.FromBundle ("Menu/id.png");
			_headerLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,25f);
			_backButton.SetImage (UIImage.FromBundle ("Common/back.png"), UIControlState.Normal);
			_backButton.TouchUpInside += (sender, e) => {
				this.NavigationController.PopViewControllerAnimated(true);
			};
			_headerLabel.Text = "О ВОДИТЕЛЕ";

			_fioLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,24f);
			//_fioLabel.Text = AppDelegate.Taxi.TaxiLastname + " " + AppDelegate.Taxi.TaxtFirstname;

			_ratedLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);
			//_ratedLabel.Text = "ПРОГОЛОСОВАЛО " + AppDelegate.Taxi.RatingCount;


			_starImageView.Image = UIImage.FromBundle ("Common/star.png");
			_star2ImageView.Image = UIImage.FromBundle ("Common/star.png");
			_star3ImageView.Image = UIImage.FromBundle ("Common/star.png");
			//_star4ImageView.Image = UIImage.FromBundle ("Common/star.png");
			_4star.Image = UIImage.FromBundle ("Common/star.png");
			_star5ImageView.Image = UIImage.FromBundle ("Common/star.png");

			_carImage.Image = UIImage.FromBundle ("ribaphoto.png");

			_modelHeaderLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);

			_modelValueLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			//_modelValueLabel.Text = AppDelegate.Taxi.TaxiModel;

			_markaHeader.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);
			_markaValueLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			//_markaValueLabel.Text = AppDelegate.Taxi.TaxiMarka;

			_numberHeaderLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);
			_numberValueLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			//_numberValueLabel.Text = AppDelegate.Taxi.TaxiCarnumber;

			_colorHeaderLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);
			_colorValueLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			//_colorValueLabel.Text = AppDelegate.Taxi.TaxiColor;

			_carImage.BackgroundColor = UIColor.Gray;

			_phoneValueTF.Text = AppDelegate.AppSettingGet(AppDelegate.CLIENT_PHONE_KEY);

			_rememberButton.Layer.BackgroundColor = UIColor.Clear.CGColor;
			_rememberButton.Layer.BorderWidth = 2;
			_rememberButton.Layer.BorderColor = AppDelegate.AppColorYellow.CGColor;
			_rememberButton.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);
			_rememberButton.TouchUpInside += (sender, e) => {
				AppDelegate.AppSettingSet(AppDelegate.CLIENT_PHONE_KEY, _phoneValueTF.Text);
			};

			_phoneLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,18f);

			_phoneValueTF.Layer.BackgroundColor = AppDelegate.AppColorHalfYellow.CGColor;
			_phoneValueTF.Layer.BorderWidth = 2;
			_phoneValueTF.Layer.BorderColor = AppDelegate.AppColorYellow.CGColor;
			_phoneValueTF.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			//_phoneValueTF.Enabled = false;
			//_phoneValueTF.Text = AppDelegate.Taxi.TaxiPhone;

			_phoneValueTF.ShouldReturn = t => {
				_phoneValueTF.ResignFirstResponder();
				return true;
			};
			_phoneValueTF.ShouldBeginEditing = t => {
				CurOffset = _scrollView.ContentOffset.Y;
				this._scrollView.SetContentOffset (new PointF (0, 350), true);
				return true;
			};

			_phoneValueTF.ShouldEndEditing = t => {
				this._scrollView.SetContentOffset (new PointF (0, CurOffset), true);
				return true;
			};

			_phoneValueTF.Ended += (sender, e) => {
				this._scrollView.SetContentOffset (new PointF (0, CurOffset), true);
			};

			_okButton.SetImage (UIImage.FromBundle ("Common/ok.png"), UIControlState.Normal);
			_okButton.TouchUpInside += (sender, e) => {
				Console.WriteLine ("Accepting 1 order at: " + DateTime.Now.ToString ());
				//int status = AppDelegate.API.Clients.Accept (AppDelegate.Order.OrderId, taxi.TaxiId, _phoneValueTF.Text, 1);
				int status = 200;
				if(status==200){
					var vController = (AppDelegate.Storyboard.InstantiateViewController ("TrackingViewController") as TrackingViewController);
					vController.Mode = 2;
					this.NavigationController.PushViewController (vController, true);
				}
			};

			_fioLabel.Text = taxi.TaxiLastname + " " + taxi.TaxtFirstname;
			_ratedLabel.Text = "ПРОГОЛОСОВАЛО " + taxi.RatingCount;
			_markaValueLabel.Text = taxi.TaxiMarka;
			_modelValueLabel.Text = taxi.TaxiModel;
			_numberValueLabel.Text = taxi.TaxiCarnumber;
			_colorValueLabel.Text = taxi.TaxiColor;

			_carImage.SetImage (
				url: new NSUrl (taxi.TaxiPhoto), 
				placeholder: UIImage.FromBundle ("ribaphoto.png"),
				completedHandler: (image, error, cacheType) => {
					// Handle download completed...
				});
		}
	}
}
