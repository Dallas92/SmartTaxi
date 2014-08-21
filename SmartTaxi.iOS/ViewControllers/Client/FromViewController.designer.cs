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
		MonoTouch.UIKit.UITextField _fromTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView _previewImg { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_fromTextField != null) {
				_fromTextField.Dispose ();
				_fromTextField = null;
			}

			if (_previewImg != null) {
				_previewImg.Dispose ();
				_previewImg = null;
			}
		}
	}
}
