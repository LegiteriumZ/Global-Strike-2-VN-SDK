using System.IO;
using System.Runtime.InteropServices;

namespace CommonUtils;

[StructLayout(LayoutKind.Explicit)]
public struct RCharField
{
	[FieldOffset(0)]
	public char CharVal;

	[FieldOffset(1)]
	public byte Byte1;

	[FieldOffset(0)]
	public byte Byte2;

	public RCharField(char value)
	{
		Byte1 = (Byte2 = 0);
		CharVal = value;
	}

	public RCharField(byte[] bs, int offset)
	{
		CharVal = '0';
		Byte1 = bs[offset];
		Byte2 = bs[offset + 1];
	}

	public RCharField(Stream stream, int offset)
	{
		CharVal = '0';
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

	public static implicit operator char(RCharField value)
	{
		return value.CharVal;
	}

	public static implicit operator RCharField(char value)
	{
		return new RCharField(value);
	}
}
