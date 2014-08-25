using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace SmartTaxi.iOS
{
	public class TextViewDelegate:UITextViewDelegate{
		string placeholder;

		public TextViewDelegate(string _placeholder){
			this.placeholder = _placeholder;
		}

		public override bool ShouldChangeText (UITextView textView, NSRange range, string text)
		{
			textView.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,16f);


			if (text.Equals ("\n")) {
				textView.ResignFirstResponder ();
				return false;
			}
			return true;
		}

		public override bool ShouldBeginEditing (UITextView textView)
		{
			if (textView.Text.Equals (this.placeholder)) {
				textView.Text = "";
			} else {

			}
			return true;
		}

		public override bool ShouldEndEditing (UITextView textView)
		{
			if (textView.Text.Length == 0) {
				textView.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,25f);
				textView.Text = this.placeholder;
			} else {
				if (textView.Text == this.placeholder) {
					textView.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,25f);
				} else {
					textView.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight, 16f);
				}
			}
			return true;
		}
	}
}

