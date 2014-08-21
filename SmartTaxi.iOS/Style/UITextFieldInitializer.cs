using System;
using MonoTouch.UIKit;

namespace SmartTaxi.iOS
{
	public class UITextFieldInitializer
	{
		public static UITextField Init(bool isSecure = false){
			UITextField txtField = new UITextField {
				BackgroundColor = UIColor.FromRGB(255,251,229),
				TextAlignment = UITextAlignment.Center,
				Font = UIFont.FromName("Avenir",18f),
				TextColor = UIColor.FromRGB(50,50,50)
			};
			txtField.Layer.BorderColor = UIColor.FromRGB (255,216,0).CGColor;
			txtField.Layer.BorderWidth = 2f;
			return txtField;
		}
	}
}

