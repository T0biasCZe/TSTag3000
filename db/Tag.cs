using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TSTag3000.db {
	public class Tag {
		public int ID;
		public string name;
		public string type;

		//tag colour mapping:
		//meta tag - blue
		//copyright tag - green
		//character tag - aqua
		//artist tag - red
		//general tag - yellow
		//other tag - black
		public static Color GetColour(string type) {
			Color colour = Color.White;
			if(type == "meta") {
				colour = Color.Blue;
			}
			else if(type == "copyright") {
				colour = Color.Green;
			}
			else if(type == "character") {
				colour = Color.DeepSkyBlue;
			}
			else if(type == "artist") {
				colour = Color.Red;
			}
			else if(type == "general") {
				colour = Color.Orange;
			}
			return colour;
		}
		public static List<string> tagOrder = new List<string> { "copyright", "character", "artist", "general", "meta" };
		public static List<Tag> SortTags(List<Tag> tags) {
			return tags.OrderBy(t => tagOrder.IndexOf(t.type)).ToList();
		}
	}
}
