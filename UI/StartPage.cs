using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSTag3000 {
	public partial class StartPage : UserControl {
		public static Bitmap cachedFormBitmap = null;
		public static bool bitmapBeingRead = false;
		public static bool bitmapBeingWritten = false;
		public StartPage() {
			InitializeComponent();
			timer_bitmap_Tick(null, null);

			this.DoubleBuffered = true;
		}
		int gcCount = 0;
		private void timer_gc_Tick(object sender, EventArgs e) {
			GC.Collect();
			gcCount++;
			label5.Text = "GC " + gcCount;

		}
		int counter1 = 0;
		int counter2 = 0;
		bool saving = false;
		List<BlurPanel> blurPanels = new List<BlurPanel>();
		Stopwatch stopwatch1 = new Stopwatch();
		Stopwatch stopwatch2 = new Stopwatch();
		Queue<int> queue1 = new Queue<int>();
		Queue<int> queue2 = new Queue<int>();

		private void timer_bitmap_Tick(object sender, EventArgs e) {
			if(bitmapBeingRead || saving) {
				timer_bitmap.Interval = 10;
				counter2++;
				label3.Text = "SCBM " + counter2;
				return;
			}
			saving = true;
			if(blurPanels.Count == 0) {
				foreach(Control control in this.Controls) {
					if(control is BlurPanel) {
						blurPanels.Add((BlurPanel)control);
					}
				}
			}
			stopwatch1.Restart();
			counter1 += 1;
			label4.Text = "CBM " + counter1;
			timer_bitmap.Interval = 10;
			Bitmap bitmap = new Bitmap(this.Width, this.Height);

			foreach(BlurPanel blurPanel in blurPanels) {
				blurPanel.Visible = false;
			}

			stopwatch2.Restart();
			this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));
			stopwatch2.Stop();
			foreach(BlurPanel blurPanel in blurPanels) {
				blurPanel.Visible = true;
			}
			bitmapBeingWritten = true;
			cachedFormBitmap = bitmap;
			bitmapBeingWritten = false;
			saving = false;
			stopwatch1.Stop();

			queue1.Enqueue((int)stopwatch1.ElapsedMilliseconds);
			queue2.Enqueue((int)stopwatch2.ElapsedMilliseconds);
			if(queue1.Count > 40) {
				queue1.Dequeue();
				queue2.Dequeue();
			}
			label1.Text = queue1.Count().ToString();
			label3.Text = "SW2 " + (int)queue2.Average() + " SW1 " + (int)queue1.Average();
		}

		private void numDisplay1_Load(object sender, EventArgs e) {

		}

		private void button_manage_Click(object sender, EventArgs e) {
			Form1.LoadManagePage();
		}
	}
}
