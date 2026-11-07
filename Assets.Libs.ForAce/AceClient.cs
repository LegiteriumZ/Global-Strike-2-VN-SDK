using System;
using System.Runtime.InteropServices;
using SSJJBase.Singleton;

namespace Assets.Libs.ForAce;

public class AceClient : SingletonInstance<AceClient>
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct TssAntiData
	{
		public uint data_len;

		public IntPtr data;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct TokenData
	{
		public uint data_len;

		public IntPtr datas;
	}

	private int data_buf_size_ = 65536;

	private IntPtr _data_buf = IntPtr.Zero;

	public TokenData GetTokenData(byte[] data)
	{
		TokenData result = default(TokenData);
		result.data_len = (uint)data.Length;
		IntPtr data_buff = get_data_buff();
		Marshal.Copy(data, 0, data_buff, data.Length);
		result.datas = data_buff;
		return result;
	}

	public TssAntiData GetAutiData(byte[] data)
	{
		IntPtr data_buff = get_data_buff();
		Marshal.Copy(data, 0, data_buff, data.Length);
		TssAntiData result = default(TssAntiData);
		result.data = data_buff;
		result.data_len = (uint)data.Length;
		return result;
	}

	private IntPtr get_data_buff()
	{
		if (_data_buf == IntPtr.Zero)
		{
			_data_buf = Marshal.AllocHGlobal(data_buf_size_);
		}
		return _data_buf;
	}
}
