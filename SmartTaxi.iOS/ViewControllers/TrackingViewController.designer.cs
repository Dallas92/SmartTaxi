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
	[Register ("TrackingViewController")]
	partial class TrackingViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton _btn1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView _img1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView _statusImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView _statusLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel _statusLB { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel _txt1 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_statusLB != null) {
				_statusLB.Dispose ();
				_statusLB = null;
			}

			if (_btn1 != null) {
				_btn1.Dispose ();
				_btn1 = null;
			}

			if (_img1 != null) {
				_img1.Dispose ();
				_img1 = null;
			}

			if (_statusImage != null) {
				_statusImage.Dispose ();
				_statusImage = null;
			}

			if (_statusLabel != null) {
				_statusLabel.Dispose ();
				_statusLabel = null;
			}

			if (_txt1 != null) {
				_txt1.Dispose ();
				_txt1 = null;
			}
		}
	}
}
