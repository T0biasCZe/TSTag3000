using TSTag3000.UI.controls;

namespace TSTag3000
{
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
			button2 = new Button();
			listBox_categories = new ListBox();
			button_addCategory = new Button();
			button1 = new Button();
			listBox_albums = new ListBox();
			button_addAlbum = new Button();
			toolStrip1 = new ToolStrip();
			toolStripButton_ffmpegTag = new ToolStripButtonNoAA();
			toolStripButton_addToAlbum = new ToolStripButtonNoAA();
			toolStripButton_generateThumbnail = new ToolStripButtonNoAA();
			toolStripButton_batchGenerateThumbnail = new ToolStripButtonNoAA();
			imageList1 = new ImageList(components);
			listBox_tags = new ListBox();
			toolTip1 = new ToolTip(components);
			comboBox_addTag = new ComboBoxColour();
			textBox_explorerPath = new TextBox();
			panel_info = new Panel();
			label1 = new Label();
			explorerBrowser1 = new Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser();
			label2 = new Label();
			label_albumname = new Label();
			comboBox_tagCategory = new ComboBox();
			button_addtag = new Button();
			panel_left.SuspendLayout();
			toolStrip1.SuspendLayout();
			panel_info.SuspendLayout();
			SuspendLayout();
			// 
			// panel_left
			// 
			panel_left.BackColor = SystemColors.Control;
			panel_left.Controls.Add(button2);
			panel_left.Controls.Add(listBox_categories);
			panel_left.Controls.Add(button_addCategory);
			panel_left.Controls.Add(button1);
			panel_left.Controls.Add(listBox_albums);
			panel_left.Controls.Add(button_addAlbum);
			panel_left.Location = new Point(0, 88);
			panel_left.Name = "panel_left";
			panel_left.Size = new Size(192, 592);
			panel_left.TabIndex = 0;
			// 
			// button2
			// 
			button2.BackColor = Color.Transparent;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = FlatStyle.Flat;
			button2.Image = (Image)resources.GetObject("button2.Image");
			button2.Location = new Point(144, 552);
			button2.Name = "button2";
			button2.Size = new Size(24, 24);
			button2.TabIndex = 6;
			button2.UseVisualStyleBackColor = false;
			// 
			// listBox_categories
			// 
			listBox_categories.FormattingEnabled = true;
			listBox_categories.ItemHeight = 15;
			listBox_categories.Location = new Point(8, 296);
			listBox_categories.Name = "listBox_categories";
			listBox_categories.Size = new Size(176, 244);
			listBox_categories.TabIndex = 5;
			// 
			// button_addCategory
			// 
			button_addCategory.Location = new Point(8, 552);
			button_addCategory.Name = "button_addCategory";
			button_addCategory.Size = new Size(112, 23);
			button_addCategory.TabIndex = 4;
			button_addCategory.Text = "Add new category";
			button_addCategory.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			button1.BackColor = Color.Transparent;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = FlatStyle.Flat;
			button1.Image = (Image)resources.GetObject("button1.Image");
			button1.Location = new Point(144, 264);
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
			listBox_albums.Size = new Size(176, 244);
			listBox_albums.TabIndex = 2;
			// 
			// button_addAlbum
			// 
			button_addAlbum.Location = new Point(8, 264);
			button_addAlbum.Name = "button_addAlbum";
			button_addAlbum.Size = new Size(112, 23);
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
			toolStripButton_ffmpegTag.ForeColor = Color.White;
			toolStripButton_ffmpegTag.Image = Properties.Resources.ffmpeg;
			toolStripButton_ffmpegTag.ImageTransparentColor = Color.Magenta;
			toolStripButton_ffmpegTag.Margin = new Padding(20, 1, 0, 2);
			toolStripButton_ffmpegTag.Name = "toolStripButton_ffmpegTag";
			toolStripButton_ffmpegTag.Size = new Size(64, 85);
			toolStripButton_ffmpegTag.Text = " ";
			toolStripButton_ffmpegTag.TextAlign = ContentAlignment.BottomCenter;
			toolStripButton_ffmpegTag.TextImageRelation = TextImageRelation.ImageAboveText;
			toolStripButton_ffmpegTag.TextNoAA = "FFTag";
			toolStripButton_ffmpegTag.ToolTipText = "Automatically tag videos and gifs that as animated, and videos with sound with sound tag. Only processes files that already have some tag\r\n";
			toolStripButton_ffmpegTag.YOffset = 65;
			toolStripButton_ffmpegTag.Click += toolStripButton_ffmpegTag_Click;
			// 
			// toolStripButton_addToAlbum
			// 
			toolStripButton_addToAlbum.AutoSize = false;
			toolStripButton_addToAlbum.ForeColor = Color.White;
			toolStripButton_addToAlbum.Image = Properties.Resources.addToAlbum;
			toolStripButton_addToAlbum.ImageTransparentColor = Color.Magenta;
			toolStripButton_addToAlbum.Name = "toolStripButton_addToAlbum";
			toolStripButton_addToAlbum.Size = new Size(86, 85);
			toolStripButton_addToAlbum.Text = " ";
			toolStripButton_addToAlbum.TextAlign = ContentAlignment.BottomCenter;
			toolStripButton_addToAlbum.TextImageRelation = TextImageRelation.ImageAboveText;
			toolStripButton_addToAlbum.TextNoAA = "Add to Album";
			toolStripButton_addToAlbum.ToolTipText = "Automatically tag videos and gifs as animated, and videos with sound with sound tag";
			toolStripButton_addToAlbum.YOffset = 65;
			toolStripButton_addToAlbum.Click += toolStripButton_addToAlbum_Click;
			// 
			// toolStripButton_generateThumbnail
			// 
			toolStripButton_generateThumbnail.AutoSize = false;
			toolStripButton_generateThumbnail.ForeColor = Color.White;
			toolStripButton_generateThumbnail.Image = Properties.Resources.generate_thumbnail2;
			toolStripButton_generateThumbnail.ImageTransparentColor = Color.Magenta;
			toolStripButton_generateThumbnail.Name = "toolStripButton_generateThumbnail";
			toolStripButton_generateThumbnail.Size = new Size(76, 85);
			toolStripButton_generateThumbnail.Text = " ";
			toolStripButton_generateThumbnail.TextAlign = ContentAlignment.BottomCenter;
			toolStripButton_generateThumbnail.TextImageRelation = TextImageRelation.ImageAboveText;
			toolStripButton_generateThumbnail.TextNoAA = "Gen thumb";
			toolStripButton_generateThumbnail.ToolTipText = "Generate thumbnails for the selected pictures";
			toolStripButton_generateThumbnail.YOffset = 65;
			toolStripButton_generateThumbnail.Click += toolStripButton_generateThumbnail_Click;
			// 
			// toolStripButton_batchGenerateThumbnail
			// 
			toolStripButton_batchGenerateThumbnail.AutoSize = false;
			toolStripButton_batchGenerateThumbnail.BackColor = Color.Transparent;
			toolStripButton_batchGenerateThumbnail.ForeColor = Color.White;
			toolStripButton_batchGenerateThumbnail.Image = Properties.Resources.batch_generate_thumbnails;
			toolStripButton_batchGenerateThumbnail.ImageTransparentColor = Color.Magenta;
			toolStripButton_batchGenerateThumbnail.Name = "toolStripButton_batchGenerateThumbnail";
			toolStripButton_batchGenerateThumbnail.Size = new Size(85, 85);
			toolStripButton_batchGenerateThumbnail.Text = " ";
			toolStripButton_batchGenerateThumbnail.TextAlign = ContentAlignment.BottomCenter;
			toolStripButton_batchGenerateThumbnail.TextImageRelation = TextImageRelation.ImageAboveText;
			toolStripButton_batchGenerateThumbnail.TextNoAA = "Batch thumb";
			toolStripButton_batchGenerateThumbnail.ToolTipText = "Batch generate thumbnails for all images that are already tagged";
			toolStripButton_batchGenerateThumbnail.YOffset = 65;
			toolStripButton_batchGenerateThumbnail.Click += toolStripButton_batchGenerateThumbnail_Click;
			// 
			// imageList1
			// 
			imageList1.ColorDepth = ColorDepth.Depth32Bit;
			imageList1.ImageSize = new Size(16, 16);
			imageList1.TransparentColor = Color.Transparent;
			// 
			// listBox_tags
			// 
			listBox_tags.FormattingEnabled = true;
			listBox_tags.ItemHeight = 15;
			listBox_tags.Location = new Point(936, 223);
			listBox_tags.Name = "listBox_tags";
			listBox_tags.Size = new Size(176, 439);
			listBox_tags.TabIndex = 3;
			// 
			// comboBox_addTag
			// 
			comboBox_addTag.AutoCompleteMode = AutoCompleteMode.Suggest;
			comboBox_addTag.AutoCompleteSource = AutoCompleteSource.ListItems;
			comboBox_addTag.DrawMode = DrawMode.OwnerDrawFixed;
			comboBox_addTag.FormattingEnabled = true;
			comboBox_addTag.Location = new Point(936, 160);
			comboBox_addTag.Name = "comboBox_addTag";
			comboBox_addTag.Size = new Size(176, 24);
			comboBox_addTag.TabIndex = 4;
			comboBox_addTag.SelectedIndexChanged += comboBox_addTag_SelectedIndexChanged;
			comboBox_addTag.KeyDown += comboBox_addTag_KeyDown;
			// 
			// textBox_explorerPath
			// 
			textBox_explorerPath.Location = new Point(200, 96);
			textBox_explorerPath.Name = "textBox_explorerPath";
			textBox_explorerPath.Size = new Size(456, 23);
			textBox_explorerPath.TabIndex = 5;
			textBox_explorerPath.TextChanged += textBox_explorerPath_TextChanged;
			// 
			// panel_info
			// 
			panel_info.BackColor = Color.Transparent;
			panel_info.Controls.Add(label1);
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
			// explorerBrowser1
			// 
			explorerBrowser1.Location = new Point(200, 128);
			explorerBrowser1.Name = "explorerBrowser1";
			explorerBrowser1.PropertyBagName = "Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser";
			explorerBrowser1.Size = new Size(728, 544);
			explorerBrowser1.TabIndex = 7;
			explorerBrowser1.SelectionChanged += explorerBrowser1_SelectionChanged;
			explorerBrowser1.NavigationComplete += explorerBrowser1_NavigationComplete;
			explorerBrowser1.Load += explorerBrowser1_Load;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(712, 104);
			label2.Name = "label2";
			label2.Size = new Size(38, 15);
			label2.TabIndex = 8;
			label2.Text = "label2";
			// 
			// label_albumname
			// 
			label_albumname.AutoSize = true;
			label_albumname.Location = new Point(936, 128);
			label_albumname.Name = "label_albumname";
			label_albumname.Size = new Size(58, 30);
			label_albumname.TabIndex = 9;
			label_albumname.Text = "Album: \r\nCategory:\r\n";
			// 
			// comboBox_tagCategory
			// 
			comboBox_tagCategory.AutoCompleteMode = AutoCompleteMode.Suggest;
			comboBox_tagCategory.FormattingEnabled = true;
			comboBox_tagCategory.Items.AddRange(new object[] { "artist", "copyright", "character", "general", "meta" });
			comboBox_tagCategory.Location = new Point(936, 192);
			comboBox_tagCategory.Name = "comboBox_tagCategory";
			comboBox_tagCategory.Size = new Size(121, 23);
			comboBox_tagCategory.TabIndex = 10;
			// 
			// button_addtag
			// 
			button_addtag.Location = new Point(1064, 192);
			button_addtag.Name = "button_addtag";
			button_addtag.Size = new Size(48, 23);
			button_addtag.TabIndex = 11;
			button_addtag.Text = "Add";
			button_addtag.UseVisualStyleBackColor = true;
			button_addtag.Click += button_addtag_Click;
			// 
			// ManagePage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Control;
			Controls.Add(button_addtag);
			Controls.Add(comboBox_tagCategory);
			Controls.Add(label_albumname);
			Controls.Add(label2);
			Controls.Add(explorerBrowser1);
			Controls.Add(panel_info);
			Controls.Add(textBox_explorerPath);
			Controls.Add(comboBox_addTag);
			Controls.Add(listBox_tags);
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
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Panel panel_left;
		private ToolStrip toolStrip1;
		private ImageList imageList1;
		private Button button_addAlbum;
		private ToolStripButtonNoAA toolStripButton_addToAlbum;
		private ListBox listBox_tags;
		private ToolTip toolTip1;
		private ComboBoxColour comboBox_addTag;
		private ToolStripButtonNoAA toolStripButton_ffmpegTag;
		private TextBox textBox_explorerPath;
		private AnimationBox pictureBox1;
		private Panel panel_info;
		private AnimationBox animationBox1;
		private ListBox listBox_albums;
		private Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser explorerBrowser1;
		private Button button1;
		private ToolStripButtonNoAA toolStripButton_generateThumbnail;
		private ToolStripButtonNoAA toolStripButton_batchGenerateThumbnail;
		private Label label1;
		private Label label2;
		private Label label_albumname;
		private ComboBox comboBox_tagCategory;
		private Button button_addtag;
		private Button button2;
		private ListBox listBox_categories;
		private Button button_addCategory;
	}
}
