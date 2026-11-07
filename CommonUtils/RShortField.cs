using System.IO;
using System.Runtime.InteropServices;

namespace CommonUtils;

[StructLayout(LayoutKind.Explicit)]
public struct RShortField
{
	[FieldOffset(0)]
	public short ShortVal;

	[FieldOffset(1)]
	public byte Byte1;

	[FieldOffset(0)]
	public byte Byte2;

	public RShortField(short value)
	{
		Byte1 = (Byte2 = 0);
		ShortVal = value;
	}

	public RShortField(byte[] bs, int offset)
	{
		ShortVal = 0;
		Byte1 = bs[offset];
		Byte2 = bs[offset + 1];
	}

	public RShortField(Stream stream, int offset)
	{
		ShortVal = 0;
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

	public static implicit operator short(RShortField value)
	{
		return value.ShortVal;
	}

	public static implicit operator RShortField(short value)
	{
		return new RShortField(value);
	}
}
