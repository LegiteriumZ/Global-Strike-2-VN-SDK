using System;
using System.Runtime.InteropServices;

namespace AceSdk;

internal class TssAntibot
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate void DeprecatedRoutine(IntPtr antibot, IntPtr arg1);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate IntPtr GetReportAntiDataRoutine(IntPtr antibot);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate void DelReportAntiDataRoutine(IntPtr antibot, IntPtr data);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate void OnRecvAntiDataRoutine(IntPtr antibot, ref TssAntiData data);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate void DeprecatedRoutine2(IntPtr antibot);

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct WrappedTssAntibot
	{
		public IntPtr antibot;

		public DeprecatedRoutine deprecated;

		public GetReportAntiDataRoutine get_report_anti_data;

		public DelReportAntiDataRoutine del_report_anti_data;

		public OnRecvAntiDataRoutine on_recv_anti_data;

		public DeprecatedRoutine2 deprecated2;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct TssAntiData
	{
		public uint data_len;

		public IntPtr data;
	}

	private WrappedTssAntibot antibot_;

	[ThreadStatic]
	private IntPtr data_buf_;

	private const int data_buf_size_ = 65536;

	public TssAntibot(IntPtr ptr)
	{
		antibot_ = (WrappedTssAntibot)Marshal.PtrToStructure(ptr, typeof(WrappedTssAntibot));
	}

	public byte[] GetReportData()
	{
		IntPtr intPtr = antibot_.get_report_anti_data(antibot_.antibot);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		TssAntiData tssAntiData = (TssAntiData)Marshal.PtrToStructure(intPtr, typeof(TssAntiData));
		if (tssAntiData.data_len == 0 || tssAntiData.data == IntPtr.Zero)
		{
			return null;
		}
		byte[] array = new byte[tssAntiData.data_len];
		Marshal.Copy(tssAntiData.data, array, 0, (int)tssAntiData.data_len);
		antibot_.del_report_anti_data(antibot_.antibot, intPtr);
		return array;
	}

	public void OnRecvAntiData(byte[] data)
	{
		if (data.Length <= 65536)
		{
			IntPtr data_buff = get_data_buff();
			Marshal.Copy(data, 0, data_buff, data.Length);
			TssAntiData data2 = default(TssAntiData);
			data2.data = data_buff;
			data2.data_len = (uint)data.Length;
			antibot_.on_recv_anti_data(antibot_.antibot, ref data2);
		}
	}

	public void Release()
	{
	}

	private IntPtr get_data_buff()
	{
		if (data_buf_ == IntPtr.Zero)
		{
			data_buf_ = Marshal.AllocHGlobal(65536);
		}
		return data_buf_;
	}
}
