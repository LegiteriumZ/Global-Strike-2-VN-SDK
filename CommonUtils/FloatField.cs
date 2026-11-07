using System.IO;
using System.Runtime.InteropServices;

namespace CommonUtils;

[StructLayout(LayoutKind.Explicit)]
public struct FloatField
{
	[FieldOffset(0)]
	public float FloatVal;

	[FieldOffset(0)]
	public byte Byte1;

	[FieldOffset(1)]
	public byte Byte2;

	[FieldOffset(2)]
	public byte Byte3;

	[FieldOffset(3)]
	public byte Byte4;

	public FloatField(float value)
	{
		Byte1 = (Byte2 = (Byte3 = (Byte4 = 0)));
		FloatVal = value;
	}

	public FloatField(byte[] bs, int offset)
	{
		FloatVal = 0f;
		Byte1 = bs[offset];
		Byte2 = bs[offset + 1];
		Byte3 = bs[offset + 2];
		Byte4 = bs[offset + 3];
	}

	public FloatField(Stream stream, int offset)
	{
		FloatVal = 0f;
		stream.Position = offset;
		Byte1 = (byte)stream.ReadByte();
		Byte2 = (byte)stream.ReadByte();
		Byte3 = (byte)stream.ReadByte();
		Byte4 = (byte)stream.ReadByte();
	}

	public void Fill(byte[] bs, int offset)
	{
		bs[offset] = Byte1;
		bs[offset + 1] = Byte2;
		bs[offset + 2] = Byte3;
		bs[offset + 3] = Byte4;
	}

	public void Fill(Stream stream, int offset)
	{
		stream.Position = offset;
		stream.WriteByte(Byte1);
		stream.WriteByte(Byte2);
		stream.WriteByte(Byte3);
		stream.WriteByte(Byte4);
	}

	public static implicit operator float(FloatField value)
	{
		return value.FloatVal;
	}

	public static implicit operator FloatField(float value)
	{
		return new FloatField(value);
	}
}
