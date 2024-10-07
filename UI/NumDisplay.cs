using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSTag3000.UI;

namespace TSTag3000 {
	public partial class NumDisplay : UserControl {
		bool FileMissing = false;
		public NumDisplay() {
			InitializeComponent();

			/*load the images of the digits*/
			for(int i = 0; i < 10; i++) {
				if(!System.IO.File.Exists(digitsPath + i + ".png")) {
					FileMissing = true;
					continue;
				}
				digitImages[i] = new Bitmap(digitsPath + i + ".png");
			}

			this.DoubleBuffered = true;
		}
		public int digitHeight = 82;
		public int digitWidth = 37;
		public int digitSpacing = 0;

		public int numberToDisplay { get; set; } = -1;
		public string digitsPath = "./gfx/digits/"; //the images of the digits are stored in this folder, named 0.png, 1.png, 2.png, etc.
		Bitmap[] digitImages = new Bitmap[10]; //array to store the images of the digits
		protected override void OnPaint(PaintEventArgs e) {
			if(numberToDisplay < 0) numberToDisplay = 1234567890;
			//check if in design mode
			if(this.IsAncestorSiteInDesignMode || this.DesignMode || this.IsInDesignMode()) {
				e.Graphics.FillRectangle(Brushes.White, this.ClientRectangle);
				e.Graphics.DrawString("NumDisplay [UNAVAILABLE]", this.Font, Brushes.Black, 0, 0);
				return;
			}
			/*draw the number using the images of the digits, centered in the control*/
			string number = numberToDisplay.ToString();
			int totalWidth = number.Length * digitWidth + (number.Length - 1) * digitSpacing;
			int x = (this.Width - totalWidth) / 2;
			int y = (this.Height - digitHeight) / 2;

			foreach(char c in number) {
				int digit = int.Parse(c.ToString());
				e.Graphics.DrawImage(digitImages[digit], x, y, digitWidth, digitHeight);
				x += digitWidth + digitSpacing;
			}


		}
	}
}
