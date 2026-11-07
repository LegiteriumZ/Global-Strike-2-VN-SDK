using System.Runtime.InteropServices;

namespace AceSdk;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AceAccountInfo
{
	[MarshalAs(UnmanagedType.Struct)]
	public AceAccountId account_id_;

	[MarshalAs(UnmanagedType.U2)]
	public ushort plat_id_;

	[MarshalAs(UnmanagedType.U4)]
	public uint game_id_;

	[MarshalAs(UnmanagedType.U4)]
	public uint world_id_;

	[MarshalAs(UnmanagedType.U4)]
	public uint channel_id_;

	[MarshalAs(UnmanagedType.U8)]
	public ulong role_id_;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
	public string reserve_buf_;
}
