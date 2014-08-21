using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace SmartTaxi.iOS
{
	public class RestorePassView:UIView
	{
		private UILabel lblPhone;
		private UILabel lblExtra;

		private UITextField txtPhone;

		public UIButton btnOk;

		public RestorePassView (RectangleF frame)
		{
			this.Frame = frame;
			this.BackgroundColor = UIColor.White;

			this.lblPhone = UILabelInitializer.Init ("ВАШ НОМЕР ТЕЛЕФОНА");
			this.lblExtra = UILabelInitializer.Init ("МЫ ВЫШЛЕМ СМС С ВАШИМ ПАРОЛЕМ.");
			this.txtPhone = UITextFieldInitializer.Init ();


			this.btnOk = UIButton.FromType (UIButtonType.Custom);
			this.btnOk.SetImage (UIImage.FromBundle ("Common/ok.png"), UIControlState.Normal);

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
			this.lblExtra.Frame = new RectangleF (0,offset,width,elHeight);

			offset += elHeight + 15; elHeight = 60;
			//this.imgOk.Frame = new RectangleF ((width - elHeight)/2, offset,elHeight,elHeight);
			this.btnOk.Frame = new RectangleF ((width - elHeight)/2, offset,elHeight,elHeight);

			offset += elHeight + 20;
			this.Frame = new RectangleF(0,this.Frame.Top,this.Frame.Width, (float)offset);


			this.AddSubview (this.lblPhone);
			this.AddSubview (this.lblExtra);
			this.AddSubview (this.txtPhone);
			//this.AddSubview (this.imgOk);
			this.AddSubview (this.btnOk);
		}
	}
}

