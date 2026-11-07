using System;
using System.Runtime.InteropServices;

namespace AceSdk;

internal class ClientOptional
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate IntPtr GetTssAntibotRoutine(IntPtr opt);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate AntiCheatExpertResult SetExitingCallbackRoutine(IntPtr opt, ClientExitingCallback cb, IntPtr ctx);

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct WrappedOptional
	{
		public IntPtr opt;

		public GetTssAntibotRoutine get_tss_antibot;

		public SetExitingCallbackRoutine set_exiting_callback;
	}

	private WrappedOptional opt_;

	private TssAntibot antibot_;

	public ClientOptional(IntPtr ptr)
	{
		opt_ = (WrappedOptional)Marshal.PtrToStructure(ptr, typeof(WrappedOptional));
		antibot_ = new TssAntibot(opt_.get_tss_antibot(opt_.opt));
	}

	public TssAntibot get_tss_antibot()
	{
		return antibot_;
	}

	public void set_exiting_callback(ClientExitingCallback cb, IntPtr ctx)
	{
		opt_.set_exiting_callback(opt_.opt, cb, ctx);
	}
}
