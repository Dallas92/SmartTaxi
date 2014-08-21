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
	[Register ("CommentViewController")]
	partial class CommentViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextView _commentTextView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField _headerLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton _okBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView _previewImg { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_previewImg != null) {
				_previewImg.Dispose ();
				_previewImg = null;
			}

			if (_headerLabel != null) {
				_headerLabel.Dispose ();
				_headerLabel = null;
			}

			if (_okBtn != null) {
				_okBtn.Dispose ();
				_okBtn = null;
			}

			if (_commentTextView != null) {
				_commentTextView.Dispose ();
				_commentTextView = null;
			}
		}
	}
}
