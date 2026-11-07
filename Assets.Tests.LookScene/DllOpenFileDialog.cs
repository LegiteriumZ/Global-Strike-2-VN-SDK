using System;
using System.Runtime.InteropServices;

namespace Assets.Tests.LookScene;

public class DllOpenFileDialog
{
	[DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true, ThrowOnUnmappableChar = true)]
	public static extern IntPtr SHBrowseForFolder([In][Out] OpenDialogDir ofn);

	[DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true, ThrowOnUnmappableChar = true)]
	public static extern bool SHGetPathFromIDList([In] IntPtr pidl, [In][Out] char[] fileName);
}
