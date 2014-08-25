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
	[Register ("TaxistsViewController")]
	partial class TaxistsViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIView _block1View { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView _block2View { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView _block3View { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView _ordersTableView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView scrollView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_block1View != null) {
				_block1View.Dispose ();
				_block1View = null;
			}

			if (_block2View != null) {
				_block2View.Dispose ();
				_block2View = null;
			}

			if (_block3View != null) {
				_block3View.Dispose ();
				_block3View = null;
			}

			if (_ordersTableView != null) {
				_ordersTableView.Dispose ();
				_ordersTableView = null;
			}

			if (scrollView != null) {
				scrollView.Dispose ();
				scrollView = null;
			}
		}
	}
}
