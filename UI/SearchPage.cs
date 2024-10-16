using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TSTag3000.UI {
	public partial class SearchPage : UserControl {
		public SearchPage() {
			InitializeComponent();
			InitializeListView();
		}
		private void InitializeListView() {
			listView.View = View.LargeIcon;
			listView.LargeImageList = new ImageList();
			listView.LargeImageList.ImageSize = new Size(64, 64);

			// Add some images to the ListView for demonstration
			listView.LargeImageList.Images.Add("image1", Image.FromFile(@"C:\tstagtestimages\carrey.png"));
			listView.Items.Add(new ListViewItem("Item 1", "image1"));

			listView.MouseClick += ListView_MouseClick;
			listView.Dock = DockStyle.Fill;

			this.Controls.Add(listView);
		}

		private void ListView_MouseClick(object sender, MouseEventArgs e) {
			if(e.Button == MouseButtons.Right) {
				var item = listView.GetItemAt(e.X, e.Y);
				if(item != null) {
					// Get the file path of the item (replace with the correct path)
					string filePath = @"C:\tstagtestimages\carrey.png"; // Replace with actual path

					// Show context menu using the utility method
					ShellContextMenuUtil.ShowContextMenu(this, filePath, listView.PointToScreen(e.Location));
				}
			}
		}
	}
}
