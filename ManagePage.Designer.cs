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
			button_addAlbum = new Button();
			treeView_directories = new TreeView();
			toolStrip1 = new ToolStrip();
			toolStripButton1 = new ToolStripButton();
			toolStripButton2 = new ToolStripButton();
			toolStripButton3 = new ToolStripButton();
			imageList1 = new ImageList(components);
			listView_images = new ListView();
			panel_left.SuspendLayout();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// panel_left
			// 
			panel_left.BackColor = Color.Red;
			panel_left.Controls.Add(button_addAlbum);
			panel_left.Controls.Add(treeView_directories);
			panel_left.Location = new Point(0, 64);
			panel_left.Name = "panel_left";
			panel_left.Size = new Size(192, 616);
			panel_left.TabIndex = 0;
			// 
			// button_addAlbum
			// 
			button_addAlbum.Location = new Point(8, 588);
			button_addAlbum.Name = "button_addAlbum";
			button_addAlbum.Size = new Size(96, 23);
			button_addAlbum.TabIndex = 1;
			button_addAlbum.Text = "Add album";
			button_addAlbum.UseVisualStyleBackColor = true;
			// 
			// treeView_directories
			// 
			treeView_directories.Location = new Point(8, 8);
			treeView_directories.Name = "treeView_directories";
			treeView_directories.Size = new Size(176, 576);
			treeView_directories.TabIndex = 0;
			// 
			// toolStrip1
			// 
			toolStrip1.AutoSize = false;
			toolStrip1.ImageScalingSize = new Size(40, 40);
			toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3 });
			toolStrip1.Location = new Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(1120, 60);
			toolStrip1.TabIndex = 1;
			toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			toolStripButton1.AutoSize = false;
			toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
			toolStripButton1.ImageAlign = ContentAlignment.TopCenter;
			toolStripButton1.ImageTransparentColor = Color.Magenta;
			toolStripButton1.Name = "toolStripButton1";
			toolStripButton1.Size = new Size(40, 40);
			toolStripButton1.Text = "Woomy";
			toolStripButton1.TextImageRelation = TextImageRelation.ImageAboveText;
			// 
			// toolStripButton2
			// 
			toolStripButton2.AutoSize = false;
			toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
			toolStripButton2.ImageAlign = ContentAlignment.TopCenter;
			toolStripButton2.ImageTransparentColor = Color.Magenta;
			toolStripButton2.Name = "toolStripButton2";
			toolStripButton2.Size = new Size(40, 40);
			toolStripButton2.Text = "Woomy";
			toolStripButton2.TextImageRelation = TextImageRelation.ImageAboveText;
			// 
			// toolStripButton3
			// 
			toolStripButton3.AutoSize = false;
			toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
			toolStripButton3.ImageAlign = ContentAlignment.TopCenter;
			toolStripButton3.ImageTransparentColor = Color.Magenta;
			toolStripButton3.Name = "toolStripButton3";
			toolStripButton3.Size = new Size(40, 40);
			toolStripButton3.Text = "Woomy";
			toolStripButton3.TextImageRelation = TextImageRelation.ImageAboveText;
			// 
			// imageList1
			// 
			imageList1.ColorDepth = ColorDepth.Depth32Bit;
			imageList1.ImageSize = new Size(16, 16);
			imageList1.TransparentColor = Color.Transparent;
			// 
			// listView_images
			// 
			listView_images.Location = new Point(200, 216);
			listView_images.Name = "listView_images";
			listView_images.Size = new Size(912, 456);
			listView_images.TabIndex = 2;
			listView_images.UseCompatibleStateImageBehavior = false;
			// 
			// ManagePage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(listView_images);
			Controls.Add(toolStrip1);
			Controls.Add(panel_left);
			Name = "ManagePage";
			Size = new Size(1120, 680);
			Resize += ManagePage_Resize;
			panel_left.ResumeLayout(false);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel_left;
		private ToolStrip toolStrip1;
		private ToolStripButton toolStripButton1;
		private ToolStripButton toolStripButton2;
		private ToolStripButton toolStripButton3;
		private TreeView treeView_directories;
		private ImageList imageList1;
		private ListView listView_images;
		private Button button_addAlbum;
	}
}
