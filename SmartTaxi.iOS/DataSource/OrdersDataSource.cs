using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using SmartTaxi.Models;
using MonoTouch.Foundation;

namespace SmartTaxi.iOS
{
	public class OrdersDataSource : UITableViewSource {
		//private List<Order> items;
		private string cellIdentifier = "OrderCell";
		private int rowHeight = 94;
		//public static bool isTabActive = false;
		public UINavigationController ctrl;

		public OrdersDataSource (UITableView table, List<Order> _items, UINavigationController ctrl)
		{
			this.ctrl = ctrl;
			table.SeparatorInset = new UIEdgeInsets (0, 0, 0, 0);
			table.SeparatorColor = AppDelegate.AppColorYellow;
			table.BackgroundColor = UIColor.White;

			AppDelegate.Orders = new List<Order> {
				new Order{FromAddress="Фурманова, Шевченко", ToAddress="Аль-Фараби, Навои", Status=0, Minutes = 60, Comment="2 человека, не считая собаки", FromLocation="53.218316, 63.630535",ToLocation="53.212508, 63.615343"},
				new Order{FromAddress="Достык, Сатпаева", ToAddress="Розыбакиева, 151", Status=1, Minutes = 90},
				new Order{FromAddress="Абая, Алтынсарина", ToAddress="ТРЦ Мега", Status=2, Minutes = 55},
				new Order{FromAddress="Аблайхана, 76", ToAddress="Розыбакиева, Навои", Status=3, Minutes = 75},
			};
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return AppDelegate.Orders.Count;
		}

		public override float GetHeightForRow (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			return rowHeight;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			OrderCell cell = tableView.DequeueReusableCell (cellIdentifier) as OrderCell;
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new OrderCell (new MonoTouch.Foundation.NSString(cellIdentifier));
			cell.Update (AppDelegate.Orders[indexPath.Row]);
			//cell.SelectedBackgroundView.BackgroundColor = UIColor.Clear;
			return cell;
		}

		public override void RowSelected (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			OrderCell cell = tableView.CellAt (indexPath) as OrderCell;
			//UIView selectionView = new UIView ();
			//selectionView.BackgroundColor = UIColor.Clear;
			//cell.SelectedBackgroundView = selectionView;
			//cell.ShowDetails ();

			var vController = (AppDelegate.Storyboard.InstantiateViewController ("OrderInfoViewController") as OrderInfoViewController);
			vController.order = cell.Order;
			this.ctrl.PushViewController (vController, true);
		}
	}

	public class OrderCell:UITableViewCell{

		public Order Order;
		public UILabel PointALabel;
		public UILabel PointBLabel;
		public UIImageView StatusImageView;

		public OrderCell(IntPtr handle) : base(handle){}

		public OrderCell (NSString cellId) 
			: base (UITableViewCellStyle.Default, cellId)
		{
			this.SelectionStyle = UITableViewCellSelectionStyle.None;
			this.BackgroundColor = UIColor.White;

			PointALabel = new UILabel ();
			PointALabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,22f);
			PointALabel.TextColor = UIColor.FromRGB (50, 50, 50);
			PointALabel.Frame = new System.Drawing.RectangleF (15, 20, 240, 23);
			this.AddSubview (PointALabel);

			PointBLabel = new UILabel ();
			PointBLabel.Font = UIFont.FromName (AppDelegate.FontRobotoCondensedLight,23f);
			PointBLabel.TextColor = UIColor.FromRGB (50, 50, 50);
			PointBLabel.Frame = new System.Drawing.RectangleF (15, 47, 240, 23);
			this.AddSubview (PointBLabel);

			StatusImageView = new UIImageView ();
			StatusImageView.Frame = new System.Drawing.RectangleF (270, 29, 36, 36);
			StatusImageView.ContentMode = UIViewContentMode.ScaleToFill;
			this.AddSubview (StatusImageView);
		}

		public void Update(Order order){
			this.Order = order;

			PointALabel.Text = "А: " + this.Order.FromAddress;
			PointBLabel.Text = "Б: " + this.Order.ToAddress;

			switch (this.Order.Status) {
			case 0:
				StatusImageView.Image = UIImage.FromBundle ("Menu/order-new.png");
				break;
			case 1:
				StatusImageView.Image = UIImage.FromBundle ("Menu/order-waiting.png");
				break;
			case 2:
				StatusImageView.Image = UIImage.FromBundle ("Menu/order-accepted.png");
				break;
			case 3:
				StatusImageView.Image = UIImage.FromBundle ("Menu/order-cancel.png");
				break;
			}
		}
	}

}

