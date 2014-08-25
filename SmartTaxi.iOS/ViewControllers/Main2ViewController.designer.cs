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
	[Register ("Main2ViewController")]
	partial class Main2ViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton _okButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView _scrollView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_okButton != null) {
				_okButton.Dispose ();
				_okButton = null;
			}

			if (_scrollView != null) {
				_scrollView.Dispose ();
				_scrollView = null;
			}
		}
	}
}
