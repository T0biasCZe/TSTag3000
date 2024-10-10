using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTag3000.UI {
	internal class ToolStripButtonNoAA : ToolStripButton {
		public string TextNoAA { get; set; }
		public int YOffset { get; set; }
		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			Graphics g = e.Graphics;
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
			//get width of the button and width of the text
			int width = (int)g.MeasureString(TextNoAA, Font).Width;
			int widthButton = Width;
			//center the text
			int x = (widthButton - width) / 2;
			g.DrawString(TextNoAA, Font, new SolidBrush(Color.FromArgb(20, 20, 20)), x + 1, YOffset + 1);
			g.DrawString(TextNoAA, Font, new SolidBrush(ForeColor), x, YOffset);

		}
	}
}
