using System;
using System.Runtime.InteropServices;

namespace Assets.Sources.Utils;

internal class WindowsDllAdaptercs
{
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr GetParent(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
}
