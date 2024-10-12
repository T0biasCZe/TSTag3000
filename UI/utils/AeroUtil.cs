using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTag3000.UI {
	using System;
	using System.Runtime.InteropServices;

	public static class AeroUtil {
		[DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMargins);

		public struct MARGINS {
			public int leftWidth;
			public int rightWidth;
			public int topHeight;
			public int bottomHeight;
		}
		public static void ApplyBlurEffect(IntPtr handle) {
			MARGINS margins = new MARGINS {
				leftWidth = 0,
				rightWidth = 0,
				topHeight = 88,
				bottomHeight = 0 // Adjust based on how much of the form you want to blur
			};

			IntPtr hwnd = handle;
			int result = DwmExtendFrameIntoClientArea(hwnd, ref margins);
			if(result < 0) {
				MessageBox.Show("Error applying blur.");
			}
		}
	}
}
