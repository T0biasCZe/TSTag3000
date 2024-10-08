using TSTag3000.UI;

namespace TSTag3000
{
    partial class StartPage {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPage));
			button_manage = new Button();
			button_Search = new Button();
			textBox1 = new TextBox();
			label2 = new Label();
			pictureBox1 = new PictureBox();
			label1 = new Label();
			label3 = new Label();
			label4 = new Label();
			timer2 = new System.Windows.Forms.Timer(components);
			timer_gc = new System.Windows.Forms.Timer(components);
			label5 = new Label();
			blurPanel1 = new BlurPanel();
			blurPanel3 = new BlurPanel();
			label6 = new LabelShadow();
			blurPanel2 = new BlurPanel();
			numDisplay1 = new NumDisplay();
			timer_bitmap = new System.Windows.Forms.Timer(components);
			button2 = new Button();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			blurPanel1.SuspendLayout();
			blurPanel3.SuspendLayout();
			blurPanel2.SuspendLayout();
			SuspendLayout();
			// 
			// button_manage
			// 
			button_manage.Location = new Point(242, 111);
			button_manage.Name = "button_manage";
			button_manage.Size = new Size(96, 23);
			button_manage.TabIndex = 3;
			button_manage.Text = "Manage files";
			button_manage.UseVisualStyleBackColor = true;
			button_manage.Click += button_manage_Click;
			// 
			// button_Search
			// 
			button_Search.Location = new Point(157, 111);
			button_Search.Name = "button_Search";
			button_Search.Size = new Size(80, 23);
			button_Search.TabIndex = 2;
			button_Search.Text = "Search";
			button_Search.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			textBox1.BorderStyle = BorderStyle.None;
			textBox1.Font = new Font("Segoe UI", 10F);
			textBox1.Location = new Point(120, 92);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(240, 18);
			textBox1.TabIndex = 1;
			// 
			// label2
			// 
			label2.BackColor = Color.Transparent;
			label2.Font = new Font("Xolonium", 50.2499924F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.FromArgb(192, 255, 192);
			label2.Location = new Point(0, 8);
			label2.Name = "label2";
			label2.Size = new Size(480, 74);
			label2.TabIndex = 0;
			label2.Text = "T126";
			label2.TextAlign = ContentAlignment.TopCenter;
			// 
			// pictureBox1
			// 
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(232, 8);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(424, 296);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(232, 648);
			label1.Name = "label1";
			label1.Size = new Size(38, 15);
			label1.TabIndex = 2;
			label1.Text = "label1";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(80, 648);
			label3.Name = "label3";
			label3.Size = new Size(38, 15);
			label3.TabIndex = 9;
			label3.Text = "label3";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(8, 648);
			label4.Name = "label4";
			label4.Size = new Size(38, 15);
			label4.TabIndex = 10;
			label4.Text = "label4";
			// 
			// timer_gc
			// 
			timer_gc.Enabled = true;
			timer_gc.Interval = 5000;
			timer_gc.Tick += timer_gc_Tick;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(152, 648);
			label5.Name = "label5";
			label5.Size = new Size(32, 15);
			label5.TabIndex = 12;
			label5.Text = "GC 0";
			// 
			// blurPanel1
			// 
			blurPanel1.BackColor = Color.Transparent;
			blurPanel1.BackgroundImageLayout = ImageLayout.Stretch;
			blurPanel1.blurAmount = 0;
			blurPanel1.Controls.Add(button_manage);
			blurPanel1.Controls.Add(label2);
			blurPanel1.Controls.Add(button_Search);
			blurPanel1.Controls.Add(textBox1);
			blurPanel1.downsizeAmount = 8;
			blurPanel1.Location = new Point(208, 184);
			blurPanel1.minElapsedMs = 300;
			blurPanel1.Name = "blurPanel1";
			blurPanel1.refreshInterval = 310;
			blurPanel1.roundCorners = 0;
			blurPanel1.Size = new Size(480, 152);
			blurPanel1.skipPaint = false;
			blurPanel1.TabIndex = 13;
			// 
			// blurPanel3
			// 
			blurPanel3.BackColor = Color.Transparent;
			blurPanel3.BackgroundImageLayout = ImageLayout.Stretch;
			blurPanel3.blurAmount = 1;
			blurPanel3.Controls.Add(label6);
			blurPanel3.downsizeAmount = 8;
			blurPanel3.Location = new Point(208, 442);
			blurPanel3.minElapsedMs = 100;
			blurPanel3.Name = "blurPanel3";
			blurPanel3.refreshInterval = 200;
			blurPanel3.roundCorners = 5;
			blurPanel3.Size = new Size(480, 94);
			blurPanel3.skipPaint = false;
			blurPanel3.TabIndex = 1;
			// 
			// label6
			// 
			label6.BackColor = Color.Transparent;
			label6.FlatStyle = FlatStyle.Flat;
			label6.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label6.ForeColor = Color.White;
			label6.Location = new Point(8, 8);
			label6.Name = "label6";
			label6.shadowColour = Color.Black;
			label6.shadowOffset = 2;
			label6.shadowOpacity = 200;
			label6.Size = new Size(464, 88);
			label6.TabIndex = 0;
			label6.Text = resources.GetString("label6.Text");
			// 
			// blurPanel2
			// 
			blurPanel2.BackColor = Color.Transparent;
			blurPanel2.BackgroundImageLayout = ImageLayout.Stretch;
			blurPanel2.blurAmount = 0;
			blurPanel2.Controls.Add(numDisplay1);
			blurPanel2.downsizeAmount = 8;
			blurPanel2.Location = new Point(208, 344);
			blurPanel2.minElapsedMs = 3000;
			blurPanel2.Name = "blurPanel2";
			blurPanel2.refreshInterval = 3010;
			blurPanel2.roundCorners = 0;
			blurPanel2.Size = new Size(480, 86);
			blurPanel2.skipPaint = false;
			blurPanel2.TabIndex = 0;
			// 
			// numDisplay1
			// 
			numDisplay1.BackColor = Color.Transparent;
			numDisplay1.Location = new Point(0, 0);
			numDisplay1.Name = "numDisplay1";
			numDisplay1.numberToDisplay = 1234567890;
			numDisplay1.Size = new Size(480, 82);
			numDisplay1.TabIndex = 14;
			numDisplay1.Load += numDisplay1_Load;
			// 
			// timer_bitmap
			// 
			timer_bitmap.Enabled = true;
			timer_bitmap.Interval = 10;
			timer_bitmap.Tick += timer_bitmap_Tick;
			// 
			// button2
			// 
			button2.Location = new Point(800, 640);
			button2.Name = "button2";
			button2.Size = new Size(96, 23);
			button2.TabIndex = 4;
			button2.Text = "Change theme";
			button2.UseVisualStyleBackColor = true;
			// 
			// StartPage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Transparent;
			BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout = ImageLayout.Stretch;
			Controls.Add(button2);
			Controls.Add(blurPanel3);
			Controls.Add(blurPanel2);
			Controls.Add(blurPanel1);
			Controls.Add(label5);
			Controls.Add(label1);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(pictureBox1);
			Name = "StartPage";
			Size = new Size(900, 672);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			blurPanel1.ResumeLayout(false);
			blurPanel1.PerformLayout();
			blurPanel3.ResumeLayout(false);
			blurPanel2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private PictureBox pictureBox1;
		private Label label1;
		private Label label2;
		private Button button_Search;
		private TextBox textBox1;
		private Button button_manage;
		private Label label3;
		private Label label4;
		private System.Windows.Forms.Timer timer2;
		private System.Windows.Forms.Timer timer_gc;
		private Label label5;
		private BlurPanel blurPanel1;
		private BlurPanel blurPanel3;
		private LabelShadow label6;
		private BlurPanel blurPanel2;
		private System.Windows.Forms.Timer timer_bitmap;
		private NumDisplay numDisplay1;
		private Button button2;
	}
}
