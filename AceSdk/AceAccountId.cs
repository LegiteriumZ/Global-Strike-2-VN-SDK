using System.Runtime.InteropServices;

namespace AceSdk;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AceAccountId
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65)]
	public string account_;

	[MarshalAs(UnmanagedType.U2)]
	public ushort account_type_;
}
