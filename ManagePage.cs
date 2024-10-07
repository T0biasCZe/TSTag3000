using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSTag3000 {
	public partial class ManagePage : UserControl {
		public ManagePage() {
			InitializeComponent();

			ManagePage_Resize(null, null);
		}

		private void ManagePage_Resize(object sender, EventArgs e) {
			panel_left.Height = this.Height - toolStrip1.Height;
			treeView_directories.Height = panel_left.Height - 40;

			button_addAlbum.Top = panel_left.Height - 30;
		}



	}
}
