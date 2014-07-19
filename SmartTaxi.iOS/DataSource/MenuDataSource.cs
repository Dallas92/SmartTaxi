using System;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace SmartTaxi.iOS
{
	public class MenuDataSource : UITableViewSource {
		private List<MenuItem> tableItems;
		private string cellIdentifier = "MenuCell";
		private int rowHeight = 92;
		public static bool isTabActive = false;

		public MenuDataSource (List<MenuItem> items)
		{
			tableItems = items;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return tableItems.Count;
		}

		public override float GetHeightForRow (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			return rowHeight;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			MenuCell cell = tableView.DequeueReusableCell (cellIdentifier) as MenuCell;
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new MenuCell (new MonoTouch.Foundation.NSString(cellIdentifier));
			cell.Update (tableItems[indexPath.Row]);
			cell.SelectedBackgroundView.BackgroundColor = UIColor.Clear;
			return cell;
		}

		public override void RowSelected (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			MenuCell cell = tableView.CellAt (indexPath) as MenuCell;
			UIView selectionView = new UIView ();
			selectionView.BackgroundColor = UIColor.Clear;
			cell.SelectedBackgroundView = selectionView;
			cell.ShowDetails ();

		}
	}

}

