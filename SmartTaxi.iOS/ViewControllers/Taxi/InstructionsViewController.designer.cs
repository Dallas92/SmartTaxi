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
	[Register ("InstructionsViewController")]
	partial class InstructionsViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton _btn2 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView _img1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel _text1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIPageControl pager { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView scroll { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_btn2 != null) {
				_btn2.Dispose ();
				_btn2 = null;
			}

			if (_img1 != null) {
				_img1.Dispose ();
				_img1 = null;
			}

			if (_text1 != null) {
				_text1.Dispose ();
				_text1 = null;
			}

			if (pager != null) {
				pager.Dispose ();
				pager = null;
			}

			if (scroll != null) {
				scroll.Dispose ();
				scroll = null;
			}
		}
	}
}
