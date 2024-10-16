namespace TSTag3000.UI {
	partial class SearchPage {
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
			listView = new ListView();
			SuspendLayout();
			// 
			// listView
			// 
			listView.Location = new Point(112, 112);
			listView.Name = "listView";
			listView.Size = new Size(488, 344);
			listView.TabIndex = 1;
			listView.UseCompatibleStateImageBehavior = false;
			// 
			// SearchPage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(listView);
			Name = "SearchPage";
			Size = new Size(1120, 680);
			ResumeLayout(false);
		}

		#endregion
		private ListView listView;
	}
}
