using TSTag3000.UI;

namespace TSTag3000 {
	partial class ManagePage {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagePage));
			panel_left = new Panel();
			button1 = new Button();
			listBox_albums = new ListBox();
			button_addAlbum = new Button();
			toolStrip1 = new ToolStrip();
			toolStripButton_ffmpegTag = new ToolStripButton();
			toolStripButton_addToAlbum = new ToolStripButton();
			toolStripButton_generateThumbnail = new ToolStripButton();
			toolStripButton_batchGenerateThumbnail = new ToolStripButton();
			imageList1 = new ImageList(components);
			listBox1 = new ListBox();
			toolTip1 = new ToolTip(components);
			comboBox1 = new ComboBox();
			textBox_explorerPath = new TextBox();
			panel_info = new Panel();
			label1 = new Label();
			animationBox1 = new AnimationBox();
			explorerBrowser1 = new Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser();
			panel_left.SuspendLayout();
			toolStrip1.SuspendLayout();
			panel_info.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)animationBox1).BeginInit();
			SuspendLayout();
			// 
			// panel_left
			// 
			panel_left.BackColor = SystemColors.Control;
			panel_left.Controls.Add(button1);
			panel_left.Controls.Add(listBox_albums);
			panel_left.Controls.Add(button_addAlbum);
			panel_left.Location = new Point(0, 88);
			panel_left.Name = "panel_left";
			panel_left.Size = new Size(192, 592);
			panel_left.TabIndex = 0;
			// 
			// button1
			// 
			button1.BackColor = Color.Transparent;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = FlatStyle.Flat;
			button1.Image = (Image)resources.GetObject("button1.Image");
			button1.Location = new Point(120, 558);
			button1.Name = "button1";
			button1.Size = new Size(24, 24);
			button1.TabIndex = 3;
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			// 
			// listBox_albums
			// 
			listBox_albums.FormattingEnabled = true;
			listBox_albums.ItemHeight = 15;
			listBox_albums.Location = new Point(8, 8);
			listBox_albums.Name = "listBox_albums";
			listBox_albums.Size = new Size(176, 544);
			listBox_albums.TabIndex = 2;
			// 
			// button_addAlbum
			// 
			button_addAlbum.Location = new Point(8, 560);
			button_addAlbum.Name = "button_addAlbum";
			button_addAlbum.Size = new Size(104, 23);
			button_addAlbum.TabIndex = 1;
			button_addAlbum.Text = "Add new album";
			button_addAlbum.UseVisualStyleBackColor = true;
			// 
			// toolStrip1
			// 
			toolStrip1.AutoSize = false;
			toolStrip1.BackColor = Color.Transparent;
			toolStrip1.Dock = DockStyle.None;
			toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip1.ImageScalingSize = new Size(60, 60);
			toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton_ffmpegTag, toolStripButton_addToAlbum, toolStripButton_generateThumbnail, toolStripButton_batchGenerateThumbnail });
			toolStrip1.Location = new Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(1128, 88);
			toolStrip1.TabIndex = 1;
			toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton_ffmpegTag
			// 
			toolStripButton_ffmpegTag.AutoSize = false;
			toolStripButton_ffmpegTag.ForeColor = SystemColors.ControlLightLight;
			toolStripButton_ffmpegTag.Image = Properties.Resources.ffmpeg;
			toolStripButton_ffmpegTag.ImageTransparentColor = Color.Magenta;
			toolStripButton_ffmpegTag.Margin = new Padding(20, 1, 0, 2);
			toolStripButton_ffmpegTag.Name = "toolStripButton_ffmpegTag";
			toolStripButton_ffmpegTag.Size = new Size(64, 85);
			toolStripButton_ffmpegTag.Text = "FFTag";
			toolStripButton_ffmpegTag.TextAlign = ContentAlignment.BottomCenter;
			toolStripButton_ffmpegTag.TextImageRelation = TextImageRelation.ImageAboveText;
			toolStripButton_ffmpegTag.ToolTipText = "Automatically tag videos and gifs as animated, and videos with sound with sound tag";
			toolStripButton_ffmpegTag.Click += toolStripButton_ffmpegTag_Click;
			// 
			// toolStripButton_addToAlbum
			// 
			toolStripButton_addToAlbum.AutoSize = false;
			toolStripButton_addToAlbum.ForeColor = SystemColors.ControlLightLight;
			toolStripButton_addToAlbum.Image = Properties.Resources.addToAlbum;
			toolStripButton_addToAlbum.ImageTransparentColor = Color.Magenta;
			toolStripButton_addToAlbum.Name = "toolStripButton_addToAlbum";
			toolStripButton_addToAlbum.Size = new Size(86, 85);
			toolStripButton_addToAlbum.Text = "Add to Album";
			toolStripButton_addToAlbum.TextAlign = ContentAlignment.BottomCenter;
			toolStripButton_addToAlbum.TextImageRelation = TextImageRelation.ImageAboveText;
			toolStripButton_addToAlbum.ToolTipText = "Automatically tag videos and gifs as animated, and videos with sound with sound tag";
			toolStripButton_addToAlbum.Click += toolStripButton_addToAlbum_Click;
			// 
			// toolStripButton_generateThumbnail
			// 
			toolStripButton_generateThumbnail.AutoSize = false;
			toolStripButton_generateThumbnail.ForeColor = SystemColors.ControlLightLight;
			toolStripButton_generateThumbnail.Image = Properties.Resources.generate_thumbnail2;
			toolStripButton_generateThumbnail.ImageTransparentColor = Color.Magenta;
			toolStripButton_generateThumbnail.Name = "toolStripButton_generateThumbnail";
			toolStripButton_generateThumbnail.Size = new Size(76, 85);
			toolStripButton_generateThumbnail.Text = "Gen thumbs";
			toolStripButton_generateThumbnail.TextAlign = ContentAlignment.BottomCenter;
			toolStripButton_generateThumbnail.TextImageRelation = TextImageRelation.ImageAboveText;
			toolStripButton_generateThumbnail.ToolTipText = "Generate thumbnails for the selected pictures";
			toolStripButton_generateThumbnail.Click += toolStripButton_generateThumbnail_Click;
			// 
			// toolStripButton_batchGenerateThumbnail
			// 
			toolStripButton_batchGenerateThumbnail.AutoSize = false;
			toolStripButton_batchGenerateThumbnail.BackColor = Color.Transparent;
			toolStripButton_batchGenerateThumbnail.ForeColor = SystemColors.ControlLightLight;
			toolStripButton_batchGenerateThumbnail.Image = Properties.Resources.batch_generate_thumbnails;
			toolStripButton_batchGenerateThumbnail.ImageTransparentColor = Color.Magenta;
			toolStripButton_batchGenerateThumbnail.Name = "toolStripButton_batchGenerateThumbnail";
			toolStripButton_batchGenerateThumbnail.Size = new Size(85, 85);
			toolStripButton_batchGenerateThumbnail.Text = "Batch thumbs";
			toolStripButton_batchGenerateThumbnail.TextAlign = ContentAlignment.BottomCenter;
			toolStripButton_batchGenerateThumbnail.TextImageRelation = TextImageRelation.ImageAboveText;
			toolStripButton_batchGenerateThumbnail.ToolTipText = "Batch generate thumbnails for all images that are already tagged";
			toolStripButton_batchGenerateThumbnail.Click += toolStripButton_batchGenerateThumbnail_Click;
			// 
			// imageList1
			// 
			imageList1.ColorDepth = ColorDepth.Depth32Bit;
			imageList1.ImageSize = new Size(16, 16);
			imageList1.TransparentColor = Color.Transparent;
			// 
			// listBox1
			// 
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 15;
			listBox1.Location = new Point(936, 158);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(176, 514);
			listBox1.TabIndex = 3;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(936, 128);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(144, 23);
			comboBox1.TabIndex = 4;
			// 
			// textBox_explorerPath
			// 
			textBox_explorerPath.Location = new Point(200, 96);
			textBox_explorerPath.Name = "textBox_explorerPath";
			textBox_explorerPath.Size = new Size(456, 23);
			textBox_explorerPath.TabIndex = 5;
			// 
			// panel_info
			// 
			panel_info.BackColor = Color.Transparent;
			panel_info.Controls.Add(label1);
			panel_info.Controls.Add(animationBox1);
			panel_info.Location = new Point(888, 88);
			panel_info.Name = "panel_info";
			panel_info.Size = new Size(232, 40);
			panel_info.TabIndex = 6;
			panel_info.Visible = false;
			// 
			// label1
			// 
			label1.Location = new Point(0, 0);
			label1.Name = "label1";
			label1.Size = new Size(208, 40);
			label1.TabIndex = 1;
			label1.Text = "label1";
			label1.TextAlign = ContentAlignment.TopRight;
			// 
			// animationBox1
			// 
			animationBox1.Image = (Image)resources.GetObject("animationBox1.Image");
			animationBox1.Location = new Point(208, 0);
			animationBox1.msPerFrame = 100;
			animationBox1.Name = "animationBox1";
			animationBox1.Size = new Size(24, 24);
			animationBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			animationBox1.TabIndex = 0;
			animationBox1.TabStop = false;
			// 
			// explorerBrowser1
			// 
			explorerBrowser1.Location = new Point(200, 128);
			explorerBrowser1.Name = "explorerBrowser1";
			explorerBrowser1.PropertyBagName = "Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser";
			explorerBrowser1.Size = new Size(728, 544);
			explorerBrowser1.TabIndex = 7;
			explorerBrowser1.SelectionChanged += explorerBrowser1_SelectionChanged;
			explorerBrowser1.Load += explorerBrowser1_Load;
			// 
			// ManagePage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Control;
			Controls.Add(explorerBrowser1);
			Controls.Add(panel_info);
			Controls.Add(textBox_explorerPath);
			Controls.Add(comboBox1);
			Controls.Add(listBox1);
			Controls.Add(toolStrip1);
			Controls.Add(panel_left);
			Name = "ManagePage";
			Size = new Size(1120, 680);
			Load += ManagePage_Load;
			Resize += ManagePage_Resize;
			panel_left.ResumeLayout(false);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			panel_info.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)animationBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Panel panel_left;
		private ToolStrip toolStrip1;
		private ImageList imageList1;
		private Button button_addAlbum;
		private ToolStripButton toolStripButton_addToAlbum;
		private ListBox listBox1;
		private ToolTip toolTip1;
		private ComboBox comboBox1;
		private ToolStripButton toolStripButton_ffmpegTag;
		private TextBox textBox_explorerPath;
		private AnimationBox pictureBox1;
		private Panel panel_info;
		private AnimationBox animationBox1;
		private ListBox listBox_albums;
		private Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser explorerBrowser1;
		private Button button1;
		private ToolStripButton toolStripButton_generateThumbnail;
		private ToolStripButton toolStripButton_batchGenerateThumbnail;
		private Label label1;
	}
}
