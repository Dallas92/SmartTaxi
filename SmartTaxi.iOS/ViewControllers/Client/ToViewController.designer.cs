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
	[Register ("ToViewController")]
	partial class ToViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView _previewImg { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView _txtView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_txtView != null) {
				_txtView.Dispose ();
				_txtView = null;
			}

			if (_previewImg != null) {
				_previewImg.Dispose ();
				_previewImg = null;
			}
		}
	}
}
