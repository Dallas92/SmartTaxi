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
	[Register ("FromViewController")]
	partial class FromViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView _img1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView _txtView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_txtView != null) {
				_txtView.Dispose ();
				_txtView = null;
			}

			if (_img1 != null) {
				_img1.Dispose ();
				_img1 = null;
			}
		}
	}
}
