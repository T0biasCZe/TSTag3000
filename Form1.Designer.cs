namespace TSTag3000 {
	partial class Form1 {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			startPage1 = new StartPage();
			SuspendLayout();
			// 
			// startPage1
			// 
			startPage1.BackColor = Color.Transparent;
			startPage1.BackgroundImageLayout = ImageLayout.Stretch;
			startPage1.Location = new Point(0, 0);
			startPage1.Name = "startPage1";
			startPage1.Size = new Size(900, 672);
			startPage1.TabIndex = 0;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(900, 671);
			Controls.Add(startPage1);
			Name = "Form1";
			Text = "T126       TSTag System";
			Resize += Form1_Resize;
			ResumeLayout(false);
		}

		#endregion

		private StartPage startPage1;
	}
}
