// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SmartTaxi.iOS
{
	public partial class MenuCell : UITableViewCell
	{
		private MenuItem menuItem;
		private float offset;

		public MenuCell(IntPtr handle) : base(handle){}

		public MenuCell (NSString cellId) 
			: base (UITableViewCellStyle.Default, cellId)
		{
			this.SelectionStyle = UITableViewCellSelectionStyle.None;
		}

//		public void Update(MenuItem _menuItem){
//
//			this.menuItem = _menuItem;
//
//			this.txt_Name.Text = this.menuItem.Name;
//			this.img_Icon.Image = UIImage.FromBundle ("Menu/" + this.menuItem.ImageName);
//			this.BackgroundColor = this.menuItem.Color;
//
//			this.txt_Name.ShouldReturn += txt => {
//				MenuDataSource.isTabActive = false;
//				this.txt_Name.ResignFirstResponder();
//				this.txt_Name.Enabled=false;
//				this.Frame = new System.Drawing.RectangleF(0,this.offset,this.Frame.Width,92);
//				this.offset = this.Frame.Top;
//				return true;
//			};
//		}
//
//		public void ShowDetails(){
//			MenuDataSource.isTabActive = true;
//			this.offset = this.Frame.Top;
//			this.Frame = new System.Drawing.RectangleF(0,0,this.Frame.Width,AppDelegate.initialViewController.View.Frame.Height);
//			this.txt_Name.Enabled = true;
//		}
	}
}
