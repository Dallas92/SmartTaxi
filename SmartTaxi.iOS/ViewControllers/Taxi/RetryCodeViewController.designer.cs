// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace SmartTaxi.iOS
{
	[Register ("RetryCodeViewController")]
	partial class RetryCodeViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton _activateButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel _enterSmsLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField _enterSmsTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView _img1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel _infoLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton _retryButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField _text1 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_img1 != null) {
				_img1.Dispose ();
				_img1 = null;
			}

			if (_text1 != null) {
				_text1.Dispose ();
				_text1 = null;
			}

			if (_enterSmsLabel != null) {
				_enterSmsLabel.Dispose ();
				_enterSmsLabel = null;
			}

			if (_enterSmsTextField != null) {
				_enterSmsTextField.Dispose ();
				_enterSmsTextField = null;
			}

			if (_infoLabel != null) {
				_infoLabel.Dispose ();
				_infoLabel = null;
			}

			if (_retryButton != null) {
				_retryButton.Dispose ();
				_retryButton = null;
			}

			if (_activateButton != null) {
				_activateButton.Dispose ();
				_activateButton = null;
			}
		}
	}
}
