using System;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace SmartTaxi.iOS
{
	public class PeriodPickerView: UIPickerViewModel
	{
		private UIViewController parentController;
		private List<string> hourstList;
		private List<string> minutesList;
		private List<string> hoursHeadList;
		private List<string> minutesHeadList;

		string hourSelected;
		string minuteSelected;
		string hourHeadSelected;
		string minuteHeadSelected;

		public PeriodPickerView (UIViewController controller) {
			this.parentController = controller;

			this.hourstList = new List<string>() { "0","1","2"};
			this.hoursHeadList = new List<string>() { "час" };
			this.minutesList = new List<string>() { };
			this.minutesHeadList = new List<string>() { "мин" };

			for (int i = 0; i < 60; i++) {
				this.minutesList.Add (string.Format("{0:00}",i));
			}

			this.hourSelected = this.hourstList[1];
			this.hourHeadSelected = this.hoursHeadList[0];
			this.minuteSelected = this.minutesList[29];
			this.minuteHeadSelected = this.minutesHeadList[0];
		}

		public override int GetComponentCount (UIPickerView picker) {
			return 4;
		}

		public override int GetRowsInComponent(UIPickerView picker,
			int component) {
			switch (component) {
			case 0:
				return this.hourstList.Count;
			case 1:
				return this.hoursHeadList.Count;
			case 2:
				return this.minutesList.Count;
			default:
				return this.minutesHeadList.Count;
			}
		}

		public override string GetTitle (UIPickerView picker, int row, int component) {
			switch (component) {
			case 0:
				return this.hourstList[row];
			case 1:
				return this.hoursHeadList[row];
			case 2:
				return this.minutesList[row];
			default:
				return this.minutesHeadList[row];
			}
		}

		public override void Selected (UIPickerView picker, int
			row, int component) {
			switch (component) {
			case 0:
				this.hourSelected = this.hourstList[row];
				break;
			case 1:
				this.minuteSelected = this.hoursHeadList[row];
				break;
			case 2:
				this.hourHeadSelected = this.minutesList[row];
				break;
			default:
				this.minuteHeadSelected = this.minutesHeadList[row];
				break;
			}
//			this.parentController.lblStatus.Text =
//				String.Format("Transport: {0}\nDistance: {1}{2}",
//					this.transportSelected, this.distanceSelected,
//					this.unitSelected);
		}

		public override UIView GetView (UIPickerView picker, int row, int component, UIView view)
		{
			UILabel lbl = view as UILabel;
			if (lbl==null) {
				lbl = new UILabel ();
				lbl.Frame = new System.Drawing.RectangleF (0, 0, 80, 20);
				lbl.TextAlignment = UITextAlignment.Center;
				lbl.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,20f);
			}

			switch (component) {
			case 0:
				lbl.Text = this.hourstList [row];
				break;
			case 1:
				lbl.Text = this.hoursHeadList [row];
				break;
			case 2:
				lbl.Text = this.minutesList [row];
				break;
			default:
				lbl.Text = this.minutesHeadList [row];
				break;
			}

			return lbl;
		}
	}
}

