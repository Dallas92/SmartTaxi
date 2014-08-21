using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace SmartTaxi.iOS
{
	public class AuthLoginView:UIView
	{
		private UILabel lblPhone;
		private UILabel lblPassword;

		private UITextField txtPhone;
		private UITextField txtPassword;

		public UIButton btnOk;
		public UIViewController ctrl;

		public AuthLoginView (RectangleF frame, UIViewController _ctrl)
		{
			this.Frame = frame;
			this.BackgroundColor = UIColor.White;
			this.ctrl = _ctrl;


			this.lblPhone = UILabelInitializer.Init ("ВАШ НОМЕР ТЕЛЕФОНА");
			this.lblPassword = UILabelInitializer.Init ("ПАРОЛЬ");
			this.txtPhone = UITextFieldInitializer.Init ();
			this.txtPassword = UITextFieldInitializer.Init ();

			/*this.imgOk = new UIImageView {
				Image = UIImage.FromBundle("Common/ok.png"),
				ContentMode = UIViewContentMode.ScaleAspectFit
			};*/

			this.btnOk = UIButton.FromType (UIButtonType.Custom);
			this.btnOk.SetImage (UIImage.FromBundle ("Common/ok.png"), UIControlState.Normal);
			this.btnOk.TouchUpInside += (sender, e) => {
				var vController = (AppDelegate.Storyboard.InstantiateViewController ("TaxistsViewController") as TaxistsViewController);
				this.ctrl.NavigationController.PushViewController (vController, true);
			};

			SetPositions ();
		}

		private void SetPositions(){

			float width = this.Frame.Width;
			int offset = 0;
			int elHeight = 0;

			offset += 25; elHeight = 25;
			this.lblPhone.Frame = new RectangleF (0,offset,width,elHeight); 

			offset += elHeight + 5; elHeight = 40;
			this.txtPhone.Frame = new RectangleF (-2,offset,width+4,elHeight);

			offset += elHeight + 15; elHeight = 25;
			this.lblPassword.Frame = new RectangleF (0,offset,width,elHeight);

			offset += elHeight + 5; elHeight = 40;
			this.txtPassword.Frame = new RectangleF (-2,offset,width+4,elHeight);

			offset += elHeight + 15; elHeight = 60;
			//this.imgOk.Frame = new RectangleF ((width - elHeight)/2, offset,elHeight,elHeight);
			this.btnOk.Frame = new RectangleF ((width - elHeight)/2, offset,elHeight,elHeight);

			offset += elHeight + 20;
			this.Frame = new RectangleF(0,this.Frame.Top,this.Frame.Width, (float)offset);


			this.AddSubview (this.lblPhone);
			this.AddSubview (this.lblPassword);
			this.AddSubview (this.txtPhone);
			this.AddSubview (this.txtPassword);
			//this.AddSubview (this.imgOk);
			this.AddSubview (this.btnOk);
		}
	}
}
