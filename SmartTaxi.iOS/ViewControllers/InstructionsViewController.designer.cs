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
		MonoTouch.UIKit.UIPageControl pager { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView scroll { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (scroll != null) {
				scroll.Dispose ();
				scroll = null;
			}

			if (pager != null) {
				pager.Dispose ();
				pager = null;
			}
		}
	}
}
