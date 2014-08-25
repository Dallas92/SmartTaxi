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
	[Register ("LoadingViewController")]
	partial class LoadingViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView _logoImage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_logoImage != null) {
				_logoImage.Dispose ();
				_logoImage = null;
			}
		}
	}
}
