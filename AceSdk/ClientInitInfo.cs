using System.Runtime.InteropServices;

namespace AceSdk;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct ClientInitInfo
{
	public int first_process_pid;

	public int current_process_role_id;

	[MarshalAs(UnmanagedType.LPWStr)]
	public string base_dat_path;
}
