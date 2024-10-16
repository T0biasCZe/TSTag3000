using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

public static class ShellContextMenuUtil {
	// Shows the context menu for a given file path at the specified screen location
	public static void ShowContextMenu(Control parent, string filePath, Point location) {
		IntPtr pidl = ILCreateFromPathW(filePath);
		if(pidl != IntPtr.Zero) {
			// Create the context menu
			IContextMenu contextMenu;
			if(SHCreateDefaultContextMenu(ref pidl, out contextMenu) == 0) { // 0 means S_OK
																			// Create a popup menu
				IntPtr hMenu = CreatePopupMenu();
				if(hMenu != IntPtr.Zero) {
					// Add context menu items
					contextMenu.QueryContextMenu(hMenu, 0, 1, 0x7FFF, CMF_NORMAL);

					// Display the context menu at the specified screen location
					uint selectedCommand = TrackPopupMenuEx(hMenu, TPM_RETURNCMD, location.X, location.Y, parent.Handle, IntPtr.Zero);

					// If a command is selected, invoke it
					if(selectedCommand != 0) {
						CMINVOKECOMMANDINFOEX invoke = new CMINVOKECOMMANDINFOEX {
							cbSize = Marshal.SizeOf(typeof(CMINVOKECOMMANDINFOEX)),
							lpVerb = (IntPtr)(selectedCommand - 1),
							fMask = (int)CMIC_MASK_UNICODE,
							hwnd = parent.Handle
						};
						contextMenu.InvokeCommand(ref invoke);
					}

					// Destroy the popup menu
					DestroyMenu(hMenu);
				}
			}

			Marshal.FreeCoTaskMem(pidl);
		}
	}

	#region P/Invoke Declarations

	[DllImport("shell32.dll", CharSet = CharSet.Unicode)]
	private static extern IntPtr ILCreateFromPathW(string path);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr CreatePopupMenu();

	[DllImport("user32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool DestroyMenu(IntPtr hMenu);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern uint TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);

	[DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
	private static extern int SHCreateDefaultContextMenu(ref IntPtr pidl, out IContextMenu contextMenu);

	private const uint CMF_NORMAL = 0x00000000;
	private const uint CMIC_MASK_UNICODE = 0x00004000;
	private const uint TPM_RETURNCMD = 0x0100;

	[StructLayout(LayoutKind.Sequential)]
	private struct CMINVOKECOMMANDINFOEX {
		public int cbSize;
		public int fMask;
		public IntPtr hwnd;
		public IntPtr lpVerb;
		public IntPtr lpParameters;
		public IntPtr lpDirectory;
		public int nShow;
		public int dwHotKey;
		public IntPtr hIcon;
	}

	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("000214E4-0000-0000-C000-000000000046")]
	private interface IContextMenu {
		[PreserveSig()]
		int QueryContextMenu(IntPtr hMenu, uint indexMenu, uint idCmdFirst, uint idCmdLast, uint uFlags);

		[PreserveSig()]
		int InvokeCommand(ref CMINVOKECOMMANDINFOEX pici);

		[PreserveSig()]
		int GetCommandString(uint idCmd, uint uFlags, IntPtr reserved, IntPtr commandString, int cch);
	}

	#endregion
}
