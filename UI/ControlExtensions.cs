using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TSTag3000.UI {
	public static class ControlExtensions {
		public static bool IsInDesignMode(this Control control) {
			return ResolveDesignMode(control);
		}

		private static bool ResolveDesignMode(Control control) {
			PropertyInfo designModeProperty = control.GetType().GetProperty("DesignMode", BindingFlags.Instance | BindingFlags.NonPublic);
			bool designMode = (bool)designModeProperty.GetValue(control, null);

			if(control.Parent != null) {
				designMode |= ResolveDesignMode(control.Parent);
			}

			return designMode;
		}

	}
}
