using System;
using MonoTouch.UIKit;

namespace SmartTaxi.iOS
{
	public class UILabelInitializer
	{
		public static UILabel Init(string text){
			return new UILabel {
				Text = text,
				TextAlignment = UITextAlignment.Center,
				Font = UIFont.FromName("Avenir",14f),
				TextColor = UIColor.FromRGB(50,50,50)
			};
		}
	}


}

