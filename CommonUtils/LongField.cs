using System.IO;
using System.Runtime.InteropServices;

namespace CommonUtils;

[StructLayout(LayoutKind.Explicit)]
public struct LongField
{
	[FieldOffset(0)]
	public long LongVal;

	[FieldOffset(0)]
	public byte Byte1;

	[FieldOffset(1)]
	public byte Byte2;

	[FieldOffset(2)]
	public byte Byte3;

	[FieldOffset(3)]
	public byte Byte4;

	[FieldOffset(4)]
	public byte Byte5;

	[FieldOffset(5)]
	public byte Byte6;

	[FieldOffset(6)]
	public byte Byte7;

	[FieldOffset(7)]
	public byte Byte8;

	public LongField(long value)
	{
		Byte1 = (Byte2 = (Byte3 = (Byte4 = 0)));
		Byte5 = (Byte6 = (Byte7 = (Byte8 = 0)));
		LongVal = value;
	}

	public LongField(byte[] bs, int offset)
	{
		LongVal = 0L;
		Byte1 = bs[offset];
		Byte2 = bs[offset + 1];
		Byte3 = bs[offset + 2];
		Byte4 = bs[offset + 3];
		Byte5 = bs[offset + 4];
		Byte6 = bs[offset + 5];
		Byte7 = bs[offset + 6];
		Byte8 = bs[offset + 7];
	}

	public LongField(Stream stream, int offset)
	{
		LongVal = 0L;
		stream.Position = offset;
		Byte1 = (byte)stream.ReadByte();
		Byte2 = (byte)stream.ReadByte();
		Byte3 = (byte)stream.ReadByte();
		Byte4 = (byte)stream.ReadByte();
		Byte5 = (byte)stream.ReadByte();
		Byte6 = (byte)stream.ReadByte();
		Byte7 = (byte)stream.ReadByte();
		Byte8 = (byte)stream.ReadByte();
	}

	public void Fill(byte[] bs, int offset)
	{
		bs[offset] = Byte1;
		bs[offset + 1] = Byte2;
		bs[offset + 2] = Byte3;
		bs[offset + 3] = Byte4;
		bs[offset + 4] = Byte5;
		bs[offset + 5] = Byte6;
		bs[offset + 6] = Byte7;
		bs[offset + 7] = Byte8;
	}

	public void Fill(Stream stream, int offset)
	{
		stream.Position = offset;
		stream.WriteByte(Byte1);
		stream.WriteByte(Byte2);
		stream.WriteByte(Byte3);
		stream.WriteByte(Byte4);
		stream.WriteByte(Byte5);
		stream.WriteByte(Byte6);
		stream.WriteByte(Byte7);
		stream.WriteByte(Byte8);
	}

	public static implicit operator long(LongField value)
	{
		return value.LongVal;
	}

	public static implicit operator LongField(long value)
	{
		return new LongField(value);
	}
}
