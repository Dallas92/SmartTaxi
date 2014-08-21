using System;
using MonoTouch.UIKit;

namespace SmartTaxi.iOS
{
	public class UIButtonInitializer
	{
		public static UIButton Init(string text){
			UIButton btn = new UIButton () {
				BackgroundColor = UIColor.White,
			};
			btn.SetTitleColor (UIColor.FromRGB(50,50,50), UIControlState.Normal);
			btn.SetTitleColor (UIColor.FromRGB(160,160,160), UIControlState.Highlighted);
			btn.SetTitle (text, UIControlState.Normal);
			btn.Layer.BorderColor = UIColor.FromRGB (255,216,0).CGColor;
			btn.Layer.BorderWidth = 2f;

			return btn;
		}
	}
}

