using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSTag3000.db;

namespace TSTag3000.UI.controls {
	public class ListBoxColour : ListBox {
		public ListBoxColour() {
			DrawMode = DrawMode.OwnerDrawFixed;
		}
		protected override void OnDrawItem(DrawItemEventArgs e) {
			ListBoxColourItem item = this.Items[e.Index] as ListBoxColourItem; // Get the current item and cast it to MyListBoxItem
			if(item != null) {
				e.Graphics.DrawString( // Draw the appropriate text in the ListBox
					item.Message, // The message linked to the item
				this.Font, // Take the font from the listbox
					new SolidBrush(item.ItemColour), // Set the color 
				0, // X pixel coordinate
				e.Index * this.ItemHeight // Y pixel coordinate.  Multiply the index by the ItemHeight defined in the listbox.
				);
			}
			else {
				e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, new SolidBrush(Color.Black), 0, e.Index * this.ItemHeight);
			}
		}
	}
	public class ListBoxColourItem {
		public ListBoxColourItem(Color c, string m) {
			ItemColour = c;
			Message = m;
		}
		public Color ItemColour { get; set; }
		public string Message { get; set; }
	}
}
