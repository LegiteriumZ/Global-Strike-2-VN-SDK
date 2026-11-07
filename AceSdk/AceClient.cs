using System;
using System.Runtime.InteropServices;

namespace AceSdk;

internal class AceClient
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate AntiCheatExpertResult InitAceClient4Routine(ref ClientInitInfo info, uint v, out IntPtr client);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate AntiCheatExpertResult LogOnRoutine(IntPtr ace, ref AceAccountInfo acc);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate void TickRoutine(IntPtr ace);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate void LogOffRoutine(IntPtr ace);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate void ExitProcessRoutine(IntPtr ace);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate IntPtr GetOptRoutine(IntPtr ace);

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct WrapperAceClient
	{
		public IntPtr ace_client;

		public LogOnRoutine log_on;

		public TickRoutine tick;

		public LogOffRoutine log_off;

		public ExitProcessRoutine exit_process;

		public GetOptRoutine get_optional_interface;
	}

	private WrapperAceClient ace_;

	private ClientOptional opt_;

	public static AntiCheatExpertResult init(ref ClientInitInfo init_info, string ace_base_path, out AceClient ace_client)
	{
		if (ace_base_path == null)
		{
			ace_base_path = ((IntPtr.Size != 8) ? "AntiCheatExpert\\InGame\\x86\\ACE-Base32.dll" : "AntiCheatExpert\\InGame\\x64\\ACE-Base64.dll");
		}
		ace_client = null;
		IntPtr intPtr = LoadLibrary(ace_base_path);
		if (intPtr == IntPtr.Zero)
		{
			return AntiCheatExpertResult.ACE_DEPLOYMENT_ERROR;
		}
		IntPtr procAddress = GetProcAddress(intPtr, "InitAceClient4");
		if (procAddress == IntPtr.Zero)
		{
			return AntiCheatExpertResult.ACE_DEPLOYMENT_ERROR;
		}
		IntPtr client;
		AntiCheatExpertResult num = ((InitAceClient4Routine)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(InitAceClient4Routine)))(ref init_info, 5u, out client);
		if (num == AntiCheatExpertResult.ACE_OK)
		{
			ace_client = new AceClient(client);
		}
		return num;
	}

	public AntiCheatExpertResult log_on(ref AceAccountInfo acc)
	{
		return ace_.log_on(ace_.ace_client, ref acc);
	}

	public void tick()
	{
		ace_.tick(ace_.ace_client);
	}

	public void log_off()
	{
		ace_.log_off(ace_.ace_client);
	}

	public void exit_process()
	{
		ace_.exit_process(ace_.ace_client);
	}

	public ClientOptional get_optional_interface()
	{
		return opt_;
	}

	private AceClient(IntPtr ace_ptr)
	{
		ace_ = (WrapperAceClient)Marshal.PtrToStructure(ace_ptr, typeof(WrapperAceClient));
		opt_ = new ClientOptional(ace_.get_optional_interface(ace_.ace_client));
	}

	[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "LoadLibraryW")]
	private static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPWStr)] string lpLibFileName);

	[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
	private static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string lpProcName);
}
