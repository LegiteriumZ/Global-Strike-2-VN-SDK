using System;
using System.IO;
using NetData;
using SSJJBase.Utility;

public class NetTableBase
{
	public const int plusFlag = 16384;

	public const int minusFlag = 32768;

	public const int hasFlag = 49152;

	public static float readAngle(MemoryStream stream)
	{
		byte[] array = new byte[2];
		stream.Read(array, 0, 2);
		if (BitConverter.IsLittleEndian)
		{
			BinaryDataWriter.ReverseArray(array, 0, array.Length - 1);
		}
		return (float)((double)(int)BitConverter.ToUInt16(array, 0) / 180.0 - 180.0);
	}

	public static float readDeltaFloat(MemoryStream stream, float baseNumber)
	{
		byte[] array = new byte[2];
		stream.Read(array, 0, 2);
		if (BitConverter.IsLittleEndian)
		{
			BinaryDataWriter.ReverseArray(array, 0, array.Length - 1);
		}
		ushort num = BitConverter.ToUInt16(array, 0);
		int num2 = num & 0xC000;
		num = (ushort)(num & 0x3FFFu);
		int num3 = (int)((double)baseNumber * (1.0 / 64.0));
		double num4 = 0.0;
		switch (num2)
		{
		case 0:
			num4 = (double)(num - 8192) / 128.0 + (double)(num3 * 64);
			break;
		case 16384:
			num3 = (int)((double)baseNumber * (1.0 / 64.0));
			num4 = (double)(num - 8192) / 128.0 + (double)((num3 + 1) * 64);
			break;
		case 32768:
			num3 = (int)((double)baseNumber * (1.0 / 64.0));
			num4 = (double)(num - 8192) / 128.0 + (double)((num3 - 1) * 64);
			break;
		case 49152:
		{
			int num5 = readSInt64(stream);
			num4 = (double)(num - 8192) / 128.0 + (double)(num5 * 64);
			break;
		}
		}
		return (float)num4;
	}

	public static float readWholeFloat(MemoryStream stream)
	{
		byte[] array = new byte[2];
		stream.Read(array, 0, 2);
		if (BitConverter.IsLittleEndian)
		{
			BinaryDataWriter.ReverseArray(array, 0, array.Length - 1);
		}
		ushort num = (ushort)(BitConverter.ToUInt16(array, 0) & 0x3FFF);
		int num2 = readSInt64(stream);
		return (float)((double)(num - 8192) / 128.0 + (double)(num2 * 64));
	}

	public static int readPlayerBooleanField(MemoryStream stream, PlayerEntityData playerEntityData)
	{
		int num = stream.ReadByte();
		if ((num & 0x80) > 0)
		{
			if ((num & 8) > 0)
			{
				playerEntityData.IsDead = true;
			}
			else
			{
				playerEntityData.IsDead = false;
			}
		}
		_ = num & 0x40;
		_ = 0;
		if ((num & 0x20) > 0)
		{
			if ((num & 2) > 0)
			{
				playerEntityData.OnGround = true;
			}
			else
			{
				playerEntityData.OnGround = false;
			}
		}
		if ((num & 0x10) > 0)
		{
			if ((num & 1) > 0)
			{
				playerEntityData.Moving = true;
			}
			else
			{
				playerEntityData.Moving = false;
			}
		}
		return num;
	}

	public static int readVarint64(MemoryStream stream)
	{
		int i = 0;
		ulong num = 0uL;
		for (; i < 64; i += 7)
		{
			int num2 = stream.ReadByte();
			num |= (ulong)((long)(num2 & 0x7F) << i);
			if ((num2 & 0x80) == 0)
			{
				return (int)num;
			}
		}
		return (int)num;
	}

	public static int readSInt64(MemoryStream stream)
	{
		return (int)DecodeZigZag64((ulong)readVarint64(stream));
	}

	public static long DecodeZigZag64(ulong n)
	{
		return (long)((n >> 1) ^ (0L - (n & 1)));
	}
}
