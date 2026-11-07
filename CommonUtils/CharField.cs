using System.IO;
using System.Runtime.InteropServices;

namespace CommonUtils;

[StructLayout(LayoutKind.Explicit)]
public struct CharField
{
	[FieldOffset(0)]
	public char CharVal;

	[FieldOffset(0)]
	public byte Byte1;

	[FieldOffset(1)]
	public byte Byte2;

	public CharField(char value)
	{
		Byte1 = (Byte2 = 0);
		CharVal = value;
	}

	public CharField(byte[] bs, int offset)
	{
		CharVal = '0';
		Byte1 = bs[offset];
		Byte2 = bs[offset + 1];
	}

	public CharField(Stream stream, int offset)
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

	public static implicit operator char(CharField value)
	{
		return value.CharVal;
	}

	public static implicit operator CharField(char value)
	{
		return new CharField(value);
	}
}
