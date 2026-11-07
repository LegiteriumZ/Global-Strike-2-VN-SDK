using System.IO;
using System.Runtime.InteropServices;

namespace CommonUtils;

[StructLayout(LayoutKind.Explicit)]
public struct RUShortField
{
	[FieldOffset(0)]
	public ushort UShortVal;

	[FieldOffset(1)]
	public byte Byte1;

	[FieldOffset(0)]
	public byte Byte2;

	public RUShortField(ushort value)
	{
		Byte1 = (Byte2 = 0);
		UShortVal = value;
	}

	public RUShortField(byte[] bs, int offset)
	{
		UShortVal = 0;
		Byte1 = bs[offset];
		Byte2 = bs[offset + 1];
	}

	public RUShortField(Stream stream, int offset)
	{
		UShortVal = 0;
		stream.Position = offset;
		Byte1 = (byte)stream.ReadByte();
		Byte2 = (byte)stream.ReadByte();
	}

	public void Fill(byte[] bs, int offset)
	{
		bs[offset] = Byte1;
		bs[offset + 1] = Byte2;
	}

	public void Fill(Stream stream, int offset)
	{
		stream.Position = offset;
		stream.WriteByte(Byte1);
		stream.WriteByte(Byte2);
	}

	public static implicit operator ushort(RUShortField value)
	{
		return value.UShortVal;
	}

	public static implicit operator RUShortField(ushort value)
	{
		return new RUShortField(value);
	}
}
