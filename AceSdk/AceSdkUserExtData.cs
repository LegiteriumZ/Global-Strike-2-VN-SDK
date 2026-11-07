using System.Runtime.InteropServices;

namespace AceSdk;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AceSdkUserExtData
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string user_ext_data_;

	[MarshalAs(UnmanagedType.U4)]
	public uint ext_data_len_;
}
