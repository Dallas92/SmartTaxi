using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace SmartTaxi.iOS
{
	public class RegistrationView:UIView
	{
		private UIScrollView scroll;

		private UILabel lblExtra;

		private UILabel lblName;
		private UITextField txtName;

		private UILabel lblSurname;
		private UITextField txtSurname;

		private UILabel lblPhone;
		private UITextField txtPhone;

		private UILabel lblPassword;
		private UITextField txtPassword;

		private UILabel lblPasswordRetry;
		private UITextField txtPasswordRetry;

		private UILabel lblCity;
		private UITextField txtCity;

		private UIButton btnOther;

		private UILabel lblMarka;
		private UITextField txtMarka;

		private UILabel lblModel;
		private UITextField txtMode;

		private UILabel lblAutoNumber;
		private UITextField txtAutoNumber;

		private UILabel lblColor;
		private UITextField txtColor;


		private UILabel lblImage;
		private UIImageView imgPreview;
		private UIButton btnUpload;

		private UILabel lblAgreement;
		private UIButton btnRead;
		private UIButton btnAgree;

		public UIButton btnOk;

		public RegistrationView (RectangleF frame)
		{
			this.Frame = frame;
			this.BackgroundColor = UIColor.White;

			this.scroll	= new UIScrollView (){
			};

			this.lblExtra = new UILabel {
				Text = "ВСЕ ПОЛЯ ОБЯЗАТЕЛЬНЫ ДЛЯ ЗАПОЛНЕНИЯ",
				TextAlignment = UITextAlignment.Center,
				Font = UIFont.FromName("Avenir",12f),
				TextColor = UIColor.Gray,
			};

			this.lblName = UILabelInitializer.Init("ИМЯ");
			this.txtName = UITextFieldInitializer.Init ();

			this.lblSurname = UILabelInitializer.Init ("ФАМИЛИЯ");
			this.txtSurname = UITextFieldInitializer.Init ();

			this.lblPhone = UILabelInitializer.Init ("НОМЕР СОТОВОГО ТЕЛЕФОНА");
			this.txtPhone = UITextFieldInitializer.Init ();

			this.lblPassword = UILabelInitializer.Init ("ВВЕДИТЕ ПАРОЛЬ");
			this.txtPassword = UITextFieldInitializer.Init ();

			this.lblPasswordRetry = UILabelInitializer.Init ("ПОВТОРИТЕ ПАРОЛЬ");
			this.txtPasswordRetry = UITextFieldInitializer.Init ();

			this.lblCity = UILabelInitializer.Init ("ГОРОД");
			this.txtCity = UITextFieldInitializer.Init ();
			this.btnOther = UIButtonInitializer.Init ("ДРУГОЙ");

			this.lblMarka = UILabelInitializer.Init ("МАРКА");
			this.txtMarka = UITextFieldInitializer.Init ();

			this.lblModel = UILabelInitializer.Init ("МОДЕЛЬ");
			this.txtMode = UITextFieldInitializer.Init ();

			this.lblAutoNumber = UILabelInitializer.Init ("НОМЕР АВТОМОБИЛЯ");
			this.txtAutoNumber = UITextFieldInitializer.Init ();

			this.lblColor = UILabelInitializer.Init ("ЦВЕТ АВТОМОБИЛЯ");
			this.txtColor = UITextFieldInitializer.Init ();



			this.lblImage = UILabelInitializer.Init ("ФОТО АВТОМОБИЛЯ");
			this.imgPreview = new UIImageView () {
				Image = UIImage.FromBundle("car.jpg"),
			};

			this.btnUpload = UIButtonInitializer.Init ("ЗАГРУЗИТЬ");

			this.lblAgreement = UILabelInitializer.Init ("ПОЛЬЗОВАТЕЛЬСКОЕ СОГЛАШЕНИЕ");

			this.btnRead = UIButtonInitializer.Init ("ПРОЧИТАТЬ");
			this.btnAgree = UIButtonInitializer.Init ("СОГЛАСЕН");

			this.btnOk = UIButton.FromType (UIButtonType.Custom);
			this.btnOk.SetImage (UIImage.FromBundle ("Common/ok.png"), UIControlState.Normal);

			SetPositions ();
		}

		private void SetPositions(){



			float width = this.Frame.Width;
			int offset = 0;
			int elHeight = 0;


			offset += elHeight + 15; elHeight = 25;
			this.lblExtra.Frame = new RectangleF (0,offset,width,elHeight);
			this.scroll.AddSubview (this.lblExtra);



			offset += elHeight + 10; elHeight = 25;
			this.lblName.Frame = new RectangleF (0,offset,width,elHeight); 
			this.scroll.AddSubview (this.lblName);

			offset += elHeight + 5; elHeight = 40;
			this.txtName.Frame = new RectangleF (-2,offset,width+4,elHeight);
			this.scroll.AddSubview (this.txtName);



			offset += elHeight + 10; elHeight = 25;
			this.lblSurname.Frame = new RectangleF (0,offset,width,elHeight); 
			this.scroll.AddSubview (this.lblSurname);

			offset += elHeight + 5; elHeight = 40;
			this.txtSurname.Frame = new RectangleF (-2,offset,width+4,elHeight);
			this.scroll.AddSubview (this.txtSurname);



			offset += elHeight + 10; elHeight = 25;
			this.lblPhone.Frame = new RectangleF (0,offset,width,elHeight); 
			this.scroll.AddSubview (this.lblPhone);

			offset += elHeight + 5; elHeight = 40;
			this.txtPhone.Frame = new RectangleF (-2,offset,width+4,elHeight);
			this.scroll.AddSubview (this.txtPhone);



			offset += elHeight + 10; elHeight = 25;
			this.lblPassword.Frame = new RectangleF (0,offset,width,elHeight); 
			this.scroll.AddSubview (this.lblPassword);

			offset += elHeight + 5; elHeight = 40;
			this.txtPassword.Frame = new RectangleF (-2,offset,width+4,elHeight);
			this.scroll.AddSubview (this.txtPassword);



			offset += elHeight + 10; elHeight = 25;
			this.lblPasswordRetry.Frame = new RectangleF (0,offset,width,elHeight); 
			this.scroll.AddSubview (this.lblPasswordRetry);

			offset += elHeight + 5; elHeight = 40;
			this.txtPasswordRetry.Frame = new RectangleF (-2,offset,width+4,elHeight);
			this.scroll.AddSubview (this.txtPasswordRetry);



			offset += elHeight + 10; elHeight = 25;
			this.lblCity.Frame = new RectangleF (0,offset,width,elHeight); 
			this.scroll.AddSubview (this.lblCity);

			offset += elHeight + 5; elHeight = 40;
			this.txtCity.Frame = new RectangleF (-2,offset,width+4,elHeight);
			this.scroll.AddSubview (this.txtCity);

			offset += elHeight + 15; elHeight = 40;
			this.btnOther.Frame = new RectangleF (30,offset,width-60,elHeight);
			this.scroll.AddSubview (this.btnOther);







			offset += elHeight + 10; elHeight = 25;
			this.lblMarka.Frame = new RectangleF (0,offset,width,elHeight); 
			this.scroll.AddSubview (this.lblMarka);

			offset += elHeight + 5; elHeight = 40;
			this.txtMarka.Frame = new RectangleF (-2,offset,width+4,elHeight);
			this.scroll.AddSubview (this.txtMarka);

			offset += elHeight + 10; elHeight = 25;
			this.lblModel.Frame = new RectangleF (0,offset,width,elHeight); 
			this.scroll.AddSubview (this.lblModel);

			offset += elHeight + 5; elHeight = 40;
			this.txtMode.Frame = new RectangleF (-2,offset,width+4,elHeight);
			this.scroll.AddSubview (this.txtMode);


			offset += elHeight + 10; elHeight = 25;
			this.lblAutoNumber.Frame = new RectangleF (0,offset,width,elHeight); 
			this.scroll.AddSubview (this.lblAutoNumber);

			offset += elHeight + 5; elHeight = 40;
			this.txtAutoNumber.Frame = new RectangleF (-2,offset,width+4,elHeight);
			this.scroll.AddSubview (this.txtAutoNumber);


			offset += elHeight + 10; elHeight = 25;
			this.lblColor.Frame = new RectangleF (0,offset,width,elHeight); 
			this.scroll.AddSubview (this.lblColor);

			offset += elHeight + 5; elHeight = 40;
			this.txtColor.Frame = new RectangleF (-2,offset,width+4,elHeight);
			this.scroll.AddSubview (this.txtColor);


			offset += elHeight + 10; elHeight = 25;
			this.lblImage.Frame = new RectangleF (0,offset,width,elHeight); 
			this.scroll.AddSubview (this.lblImage);

			offset += elHeight + 10; elHeight = 180;
			this.imgPreview.Frame = new RectangleF (0,offset,width,elHeight); 
			this.scroll.AddSubview (this.imgPreview);



			offset += elHeight + 20; elHeight = 40;
			this.btnUpload.Frame = new RectangleF (30,offset,width-60,elHeight);
			this.scroll.AddSubview (this.btnUpload);

			offset += elHeight + 10; elHeight = 25;
			this.lblAgreement.Frame = new RectangleF (0,offset,width,elHeight); 
			this.scroll.AddSubview (this.lblAgreement);

			offset += elHeight + 5; elHeight = 40;
			this.btnRead.Frame = new RectangleF (30,offset,width-60,elHeight);
			this.scroll.AddSubview (this.btnRead);

			offset += elHeight + 10; elHeight = 40;
			this.btnAgree.Frame = new RectangleF (30,offset,width-60,elHeight);
			this.scroll.AddSubview (this.btnAgree);

			offset += elHeight + 20; elHeight = 60;
			this.btnOk.Frame = new RectangleF ((width - elHeight)/2, offset,elHeight,elHeight);
			this.scroll.AddSubview (this.btnOk);

			offset += elHeight;
			this.scroll.Frame = new RectangleF (0, 0, Frame.Width, Frame.Height);
			this.scroll.ContentSize = new SizeF (this.Frame.Width, offset + 20);

			this.AddSubview (this.scroll);
		}
			
	}
}

