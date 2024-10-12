using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSTag3000.UI
{
    public partial class LabelShadow : Label
    {
        public int shadowOffset { get; set; }
        public int shadowOpacity { get; set; }
        public Color shadowColour { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            //draw the shadow as text with offset, then draw the text on top
            e.Graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(shadowOpacity, shadowColour)), new RectangleF(Location.X + shadowOffset, Location.Y + shadowOffset, Width, Height));
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), new RectangleF(Location.X, Location.Y, Width, Height));

        }
    }
}
