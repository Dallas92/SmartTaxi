// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Google.Maps;
using System.Drawing;

namespace SmartTaxi.iOS
{
	public partial class CommentViewController : UIViewController
	{
		public CommentViewController (IntPtr handle) : base (handle)
		{
			UITapGestureRecognizer gestureRecognizer = new UITapGestureRecognizer ();
			gestureRecognizer.AddTarget (() => this.View.EndEditing (true));
			gestureRecognizer.CancelsTouchesInView = true;
			this.View.AddGestureRecognizer (gestureRecognizer);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			AppDelegate.AddGestureRecognizer (this.View);

			_previewImg.Image = UIImage.FromBundle ("Menu/pen.png");
			_okBtn.SetImage (UIImage.FromBundle ("Common/ok.png"), UIControlState.Normal);

			_headerLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,25f);

			_commentTextView.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,16f);

			_commentTextView.Layer.BorderWidth = 2;
			_commentTextView.Layer.BorderColor = UIColor.FromRGB (255,216,0).CGColor;
			_commentTextView.TextContainerInset = new UIEdgeInsets (15, 16, 15, 16);
		}
	}
}