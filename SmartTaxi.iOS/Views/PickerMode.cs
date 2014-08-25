using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using SmartTaxi.Models;
using System.Drawing;

namespace SmartTaxi.iOS
{
	public class PickerModel : UIPickerViewModel
	{
		private readonly IList<PickerModelItem> values;

		public event EventHandler<PickerChangedEventArgs> PickerChanged;

		public PickerModel(IList<PickerModelItem> values)
		{
			this.values = values;
		}

		public override int GetComponentCount (UIPickerView picker)
		{
			return 1;
		}


		public override int GetRowsInComponent (UIPickerView picker, int component)
		{
			return values.Count;
		}

		/*
		public override string GetTitle (UIPickerView picker, int row, int component)
		{
			return values[row];
		}
		*/

		public override float GetRowHeight (UIPickerView picker, int component)
		{
			return 40f;
		}

		public override void Selected (UIPickerView picker, int row, int component)
		{
			if (this.PickerChanged != null)
			{
				this.PickerChanged(this, new PickerChangedEventArgs{SelectedValue = values[row]}); 
			}
		}

		public override UIView GetView (UIPickerView picker, int row, int component, UIView view)
		{
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events
			UILabel label = new UILabel (new RectangleF (0, 0, picker.Bounds.Width, 40f));
			label.BackgroundColor = UIColor.Clear;
			label.TextAlignment = UITextAlignment.Center;
			label.TextColor = UIColor.FromRGB (50, 50, 50);
			label.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight, 18f);
			label.Text = values [row].Name;

			return label;
		}
	}


	public class PickerChangedEventArgs : EventArgs
	{
		public PickerModelItem SelectedValue {get; set;}
	}
}

