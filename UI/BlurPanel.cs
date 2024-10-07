using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection.Emit;
using Timer = System.Windows.Forms.Timer;
using System.Drawing.Imaging;
using Label = System.Windows.Forms.Label;
using System.Reflection;
using TSTag3000.UI;

namespace TSTag3000
{
    public partial class BlurPanel : Panel {
		Label debugLabel = new Label();
		public BlurPanel() {
			InitializeComponent();
			if(refreshInterval == 0) refreshInterval = 10000;
			if(downsizeAmount == 0) downsizeAmount = 1;
			if(minElapsedMs == 0) minElapsedMs = 1000;

			BackColor = Color.Transparent;
			//BorderStyle = BorderStyle.None;
			timer.Tick += timer_Tick;
			timer.Interval = 1;
			timer.Start();

			//add debug label to the panel
			debugLabel.AutoSize = true;
			debugLabel.BackColor = Color.Transparent;
			//Controls.Add(debugLabel);

			this.DoubleBuffered = true;
		}
		[Category("Data"), Description("How many times downscale the image before blur to speed up processing. 4 recommended.")]
		public bool skipPaint { get; set; }

		[Category("Data"), Description("How many times downscale the image before blur to speed up processing. 4 recommended.")]
		public int downsizeAmount { get; set; }
		[Category("Data"), Description("Minimal time between refresh.")]
		public int minElapsedMs { get; set; }
		[Category("Data"), Description("How often to refresh in ms.")]
		public int refreshInterval { get; set; }
		[Category("Data"), Description("Blur amount.")]
		public int blurAmount { get; set; }
		[Category("Data"), Description("Round border amount (0 to disable).")]
		public int roundCorners { get; set; }
		Timer timer = new Timer();

		private void timer_Tick(object? sender, EventArgs e) {
			this.Refresh();
			if(refreshInterval > 10) timer.Interval = refreshInterval;
			else timer.Interval = 1000;
		}

		Stopwatch stopwatch = new Stopwatch();
		bool stillRunning = false;
		int abortedCount = 0;

		Queue<long> timeTaken = new Queue<long>();
		bool firstRun = true;
		Bitmap bmp;
		bool quickoverride = false;
		protected override void OnPaint(PaintEventArgs e) {
			if(skipPaint) {
				base.OnPaint(e);
				return;
			}
			/*if in design mode, do not run the code*/
			if(DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) {
				base.OnPaint(e);
				return;
			}

			if(stillRunning) {
				abortedCount++;
				return;
			}
			if(!stopwatch.IsRunning || stopwatch.ElapsedMilliseconds > minElapsedMs || quickoverride) {
				if(!stopwatch.IsRunning) {
					stopwatch.Start();
				}
				stillRunning = true;
				stopwatch.Restart();

				Rectangle cropRectangle = new Rectangle(this.Left - downsizeAmount, this.Top - downsizeAmount, this.Width + downsizeAmount, this.Height + downsizeAmount);
				debugLabel.Text = DateTime.Now.ToString("HH:mm:ss.fff") + " " + cropRectangle.ToString();

				StartPage.bitmapBeingRead = true;
				if(StartPage.bitmapBeingWritten || StartPage.cachedFormBitmap == null) {
					quickoverride = true;
					StartPage.bitmapBeingRead = false;
					debugLabel.Text += " abort image written";
					stillRunning = false;
					return;
				}
				else {
					quickoverride = false;
				}

				bmp = (Bitmap)StartPage.cachedFormBitmap.Clone(cropRectangle, PixelFormat.Format32bppArgb);

				if(this.Name == "blurPanel3") {
					bmp.Save("panel3.png", ImageFormat.Png);
				}
				StartPage.bitmapBeingRead = false;

				// Offload image processing to a background thread
				Task.Run(() => {

					if(blurAmount > 1) {
						if(downsizeAmount > 1) {
							//blur is enabled and so is downscaling
							bmp = new Bitmap(BlurUtil.Blur(new Bitmap(bmp, new Size(bmp.Width / downsizeAmount, bmp.Height / downsizeAmount)), blurAmount), new Size(cropRectangle.Width, cropRectangle.Height));
						}
						else {
							//blur but no downscaling
							bmp = BlurUtil.Blur(bmp, blurAmount);
						}

					}
					else {
						if(downsizeAmount > 1) {
							//no blur but downscaling
							bmp = new Bitmap(bmp, new Size(bmp.Width / downsizeAmount, bmp.Height / downsizeAmount));
						}
						//else no blur and no downscaling, so no processing needed
					}

					/*if(roundCorners > 1) {
						Bitmap mask = new Bitmap(finalBmp.Width, finalBmp.Height);
						using(Graphics maskg = Graphics.FromImage(mask)) {
							maskg.Clear(Color.Black);
							maskg.DrawRoundedRectangle(new Pen(Color.White, 1), 0, 0, mask.Width, mask.Height, roundCorners);
							maskg.FillRoundedRectangle(new SolidBrush(Color.White), 0, 0, mask.Width, mask.Height, roundCorners);
						}

						BitmapData croppedData = croppedBmp.LockBits(new Rectangle(0, 0, croppedBmpNoOffset.Width, croppedBmpNoOffset.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
						BitmapData finalData = finalBmp.LockBits(new Rectangle(0, 0, finalBmp.Width, finalBmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
						BitmapData maskData = mask.LockBits(new Rectangle(0, 0, mask.Width, mask.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

						int bytesPerPixel = 4;
						int height = finalBmp.Height;
						int width = finalBmp.Width;

						unsafe {
							byte* croppedPtr = (byte*)croppedData.Scan0;
							byte* finalPtr = (byte*)finalData.Scan0;
							byte* maskPtr = (byte*)maskData.Scan0;

							for(int y = 0; y < height; y++) {
								for(int x = 0; x < width; x++) {
									int index = (y * croppedData.Stride) + (x * bytesPerPixel);
									if(maskPtr[index] < 250) { // Check if the mask pixel is white
										finalPtr[index] = croppedPtr[index];       // Blue
										finalPtr[index + 1] = croppedPtr[index + 1]; // Green
										finalPtr[index + 2] = croppedPtr[index + 2]; // Red
										finalPtr[index + 3] = croppedPtr[index + 3]; // Alpha
									}
								}
							}
						}

						//Unlock the bits
						croppedBmpNoOffset.UnlockBits(croppedData);
						finalBmp.UnlockBits(finalData);
						mask.UnlockBits(maskData);
					}*/



					// Once the processing is done, update the UI on the main thread
					this.Invoke((Action)(() => {
						if(!firstRun) timeTaken.Enqueue(stopwatch.ElapsedMilliseconds);
						if(timeTaken.Count > 30) timeTaken.Dequeue();
						long average = timeTaken.Count > 0 ? (long)timeTaken.Average() : 0;
						debugLabel.Text += "  " + stopwatch.ElapsedMilliseconds + " " + average + " " + timeTaken.Count;

						//Graphics g = this.CreateGraphics();
						//g.DrawImage(bmp, new Rectangle(0, 0, this.Width + downsizeAmount, this.Height + downsizeAmount));
						this.BackgroundImage = bmp;

						stillRunning = false;
						firstRun = false;
						GC.Collect();

						/*invalidate children*/
						foreach(Control c in Controls) {
							c.Refresh();
						}
					}));
				});
			}
		}
	}
}
