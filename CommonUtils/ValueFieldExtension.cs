using System;
using System.IO;

namespace CommonUtils;

public static class ValueFieldExtension
{
	private unsafe static void Swap(byte* bs, int offset)
	{
		byte b = bs[offset];
		byte b2 = *bs;
		bs[offset] = b2;
		*bs = b;
	}

	public unsafe static void Reverse2(char* value)
	{
		Swap((byte*)value, 1);
	}

	public unsafe static void Reverse2(ushort* value)
	{
		Swap((byte*)value, 1);
	}

	public unsafe static void Reverse2(short* value)
	{
		Swap((byte*)value, 1);
	}

	public unsafe static void Reverse4(int* value)
	{
		Swap((byte*)value, 3);
		Swap((byte*)value + 1, 1);
	}

	public unsafe static void Reverse4(uint* value)
	{
		Swap((byte*)value, 3);
		Swap((byte*)value + 1, 1);
	}

	public unsafe static void Reverse4(float* value)
	{
		Swap((byte*)value, 3);
		Swap((byte*)value + 1, 1);
	}

	public unsafe static void Reverse8(long* value)
	{
		Swap((byte*)value, 7);
		Swap((byte*)value + 1, 5);
		Swap((byte*)value + 2, 3);
		Swap((byte*)value + 3, 1);
	}

	public unsafe static void Reverse8(ulong* value)
	{
		Swap((byte*)value, 7);
		Swap((byte*)value + 1, 5);
		Swap((byte*)value + 2, 3);
		Swap((byte*)value + 3, 1);
	}

	public unsafe static void Reverse8(double* value)
	{
		Swap((byte*)value, 7);
		Swap((byte*)value + 1, 5);
		Swap((byte*)value + 2, 3);
		Swap((byte*)value + 3, 1);
	}

	public static void Reverse<T>(T[] array, int offset, int len)
	{
		int num = offset + len - 1;
		int num2 = len / 2;
		for (int i = 0; i < num2; i++)
		{
			T val = array[offset + i];
			array[offset + i] = array[num - i];
			array[num - i] = val;
		}
	}

	public unsafe static void WriteStreamInt(this Stream stream, int offset, int value, bool little)
	{
		byte[] array = new byte[4];
		fixed (byte* ptr = array)
		{
			int* ptr2 = (int*)ptr;
			*ptr2 = value;
			if (BitConverter.IsLittleEndian != little)
			{
				Reverse4(ptr2);
			}
		}
		stream.Position = offset;
		stream.Write(array, 0, array.Length);
	}

	public unsafe static void WriteStreamUInt(this Stream stream, int offset, uint value, bool little)
	{
		byte[] array = new byte[4];
		fixed (byte* ptr = array)
		{
			uint* ptr2 = (uint*)ptr;
			*ptr2 = value;
			if (BitConverter.IsLittleEndian != little)
			{
				Reverse4(ptr2);
			}
		}
		stream.Position = offset;
		stream.Write(array, 0, array.Length);
	}

	public unsafe static void WriteStreamShort(this Stream stream, int offset, short value, bool little)
	{
		byte[] array = new byte[2];
		fixed (byte* ptr = array)
		{
			short* ptr2 = (short*)ptr;
			*ptr2 = value;
			if (BitConverter.IsLittleEndian != little)
			{
				Reverse2(ptr2);
			}
		}
		stream.Position = offset;
		stream.Write(array, 0, array.Length);
	}

	public static void WriteStreamBytes(this Stream stream, int offset, byte[] value, bool little)
	{
		stream.WriteStreamLong(offset, value.Length, little);
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(value, 0, value.Length);
		}
		stream.Position = offset + 8;
		stream.Write(value, 0, value.Length);
	}

	public unsafe static void WriteStreamUShort(this Stream stream, int offset, ushort value, bool little)
	{
		byte[] array = new byte[2];
		fixed (byte* ptr = array)
		{
			ushort* ptr2 = (ushort*)ptr;
			*ptr2 = value;
			if (BitConverter.IsLittleEndian != little)
			{
				Reverse2(ptr2);
			}
		}
		stream.Position = offset;
		stream.Write(array, 0, array.Length);
	}

	public unsafe static void WriteStreamLong(this Stream stream, int offset, long value, bool little)
	{
		byte[] array = new byte[8];
		fixed (byte* ptr = array)
		{
			long* ptr2 = (long*)ptr;
			*ptr2 = value;
			if (BitConverter.IsLittleEndian != little)
			{
				Reverse8(ptr2);
			}
		}
		stream.Position = offset;
		stream.Write(array, 0, array.Length);
	}

	public unsafe static void WriteStreamULong(this Stream stream, int offset, ulong value, bool little)
	{
		byte[] array = new byte[8];
		fixed (byte* ptr = array)
		{
			ulong* ptr2 = (ulong*)ptr;
			*ptr2 = value;
			if (BitConverter.IsLittleEndian != little)
			{
				Reverse8(ptr2);
			}
		}
		stream.Position = offset;
		stream.Write(array, 0, array.Length);
	}

	public unsafe static void WriteStreamFloat(this Stream stream, int offset, float value, bool little)
	{
		byte[] array = new byte[4];
		fixed (byte* ptr = array)
		{
			float* ptr2 = (float*)ptr;
			*ptr2 = value;
			if (BitConverter.IsLittleEndian != little)
			{
				Reverse4(ptr2);
			}
		}
		stream.Position = offset;
		stream.Write(array, 0, array.Length);
	}

	public unsafe static void WriteStreamDouble(this Stream stream, int offset, double value, bool little)
	{
		byte[] array = new byte[8];
		fixed (byte* ptr = array)
		{
			double* ptr2 = (double*)ptr;
			*ptr2 = value;
			if (BitConverter.IsLittleEndian != little)
			{
				Reverse8(ptr2);
			}
		}
		stream.Position = offset;
		stream.Write(array, 0, array.Length);
	}

	public unsafe static void WriteStreamChar(this Stream stream, int offset, char value, bool little)
	{
		byte[] array = new byte[2];
		fixed (byte* ptr = array)
		{
			char* ptr2 = (char*)ptr;
			*ptr2 = value;
			if (BitConverter.IsLittleEndian != little)
			{
				Reverse2(ptr2);
			}
		}
		stream.Position = offset;
		stream.Write(array, 0, array.Length);
	}

	public unsafe static void WriteStreamString(this Stream stream, int offset, string value, bool little)
	{
		stream.WriteStreamInt(offset, value.Length, little);
		byte[] array = new byte[value.Length * 2];
		fixed (byte* ptr = array)
		{
			char* ptr2 = (char*)ptr;
			fixed (char* ptr3 = value)
			{
				for (int i = 0; i < value.Length; i++)
				{
					char* ptr4 = ptr3 + i;
					if (BitConverter.IsLittleEndian != little)
					{
						Reverse2(ptr4);
					}
					ptr2[i] = *ptr4;
				}
			}
		}
		stream.Write(array, 0, array.Length);
	}

	public static void WriteStreamByte(this Stream stream, int offset, byte value)
	{
		stream.Position = offset;
		stream.WriteByte(value);
	}

	public static void WriteStreamSByte(this Stream stream, int offset, sbyte value)
	{
		stream.Position = offset;
		int num = value + 128;
		stream.WriteByte((byte)num);
	}

	public static void WriteStreamBool(this Stream stream, int offset, bool value)
	{
		stream.Position = offset;
		stream.WriteByte((byte)(value ? 1 : 0));
	}

	public static void WriteStreamBytes(this Stream stream, int offset, byte[] bytes)
	{
		if (bytes != null)
		{
			stream.Position = offset;
			stream.Write(bytes, 0, bytes.Length);
		}
	}

	public static byte[] ReadAllBytes(this Stream stream)
	{
		long position = stream.Position;
		stream.Seek(0L, SeekOrigin.Begin);
		byte[] array = new byte[stream.Length];
		stream.Read(array, 0, array.Length);
		stream.Position = position;
		return array;
	}

	public static byte[] ReadBytes(this Stream stream, int offset, int len)
	{
		long position = stream.Position;
		stream.Seek(offset, SeekOrigin.Begin);
		byte[] array = new byte[len];
		stream.Read(array, 0, array.Length);
		stream.Position = position;
		return array;
	}

	public static byte[] ReadStreamBytes(this Stream stream, int offset, bool little)
	{
		byte[] array = new byte[stream.ReadStreamLong(offset, little)];
		stream.Position = offset + 8;
		stream.Read(array, 0, array.Length);
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(array, 0, array.Length);
		}
		return array;
	}

	public static byte ReadStreamByte(this Stream stream, int offset)
	{
		stream.Position = offset;
		return (byte)stream.ReadByte();
	}

	public static sbyte ReadStreamSByte(this Stream stream, int offset)
	{
		stream.Position = offset;
		return (sbyte)(stream.ReadByte() - 128);
	}

	public static bool ReadStreamBool(this Stream stream, int offset)
	{
		stream.Position = offset;
		return stream.ReadByte() == 1;
	}

	public unsafe static int ReadStreamInt(this Stream stream, int offset, bool little)
	{
		byte[] array = new byte[4];
		stream.Position = offset;
		stream.Read(array, 0, array.Length);
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(array, 0, array.Length);
		}
		fixed (byte* ptr = array)
		{
			int* ptr2 = (int*)ptr;
			return *ptr2;
		}
	}

	public unsafe static uint ReadStreamUInt(this Stream stream, int offset, bool little)
	{
		byte[] array = new byte[4];
		stream.Position = offset;
		stream.Read(array, 0, array.Length);
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(array, 0, array.Length);
		}
		fixed (byte* ptr = array)
		{
			uint* ptr2 = (uint*)ptr;
			return *ptr2;
		}
	}

	public unsafe static short ReadStreamShort(this Stream stream, int offset, bool little)
	{
		byte[] array = new byte[2];
		stream.Position = offset;
		stream.Read(array, 0, array.Length);
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(array, 0, array.Length);
		}
		fixed (byte* ptr = array)
		{
			short* ptr2 = (short*)ptr;
			return *ptr2;
		}
	}

	public unsafe static ushort ReadStreamUShort(this Stream stream, int offset, bool little)
	{
		byte[] array = new byte[2];
		stream.Position = offset;
		stream.Read(array, 0, array.Length);
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(array, 0, array.Length);
		}
		fixed (byte* ptr = array)
		{
			ushort* ptr2 = (ushort*)ptr;
			return *ptr2;
		}
	}

	public unsafe static long ReadStreamLong(this Stream stream, int offset, bool little)
	{
		byte[] array = new byte[8];
		stream.Position = offset;
		stream.Read(array, 0, array.Length);
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(array, 0, array.Length);
		}
		fixed (byte* ptr = array)
		{
			long* ptr2 = (long*)ptr;
			return *ptr2;
		}
	}

	public unsafe static ulong ReadStreamULong(this Stream stream, int offset, bool little)
	{
		byte[] array = new byte[8];
		stream.Position = offset;
		stream.Read(array, 0, array.Length);
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(array, 0, array.Length);
		}
		fixed (byte* ptr = array)
		{
			uint* ptr2 = (uint*)ptr;
			return *ptr2;
		}
	}

	public unsafe static char ReadStreamChar(this Stream stream, int offset, bool little)
	{
		byte[] array = new byte[2];
		stream.Position = offset;
		stream.Read(array, 0, array.Length);
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(array, 0, array.Length);
		}
		fixed (byte* ptr = array)
		{
			char* ptr2 = (char*)ptr;
			return *ptr2;
		}
	}

	public unsafe static float ReadStreamFloat(this Stream stream, int offset, bool little)
	{
		byte[] array = new byte[4];
		stream.Position = offset;
		stream.Read(array, 0, array.Length);
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(array, 0, array.Length);
		}
		fixed (byte* ptr = array)
		{
			float* ptr2 = (float*)ptr;
			return *ptr2;
		}
	}

	public unsafe static double ReadStreamDouble(this Stream stream, int offset, bool little)
	{
		byte[] array = new byte[8];
		stream.Position = offset;
		stream.Read(array, 0, array.Length);
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(array, 0, array.Length);
		}
		fixed (byte* ptr = array)
		{
			double* ptr2 = (double*)ptr;
			return *ptr2;
		}
	}

	public unsafe static string ReadStreamString(this Stream stream, int offset, bool little)
	{
		int num = stream.ReadStreamInt(offset, little);
		byte[] array = new byte[num * 2];
		stream.Read(array, 0, array.Length);
		string result;
		if (BitConverter.IsLittleEndian != little)
		{
			char[] array2 = new char[num];
			fixed (byte* ptr = array)
			{
				char* ptr2 = (char*)ptr;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = ptr2[i];
				}
			}
			fixed (char* value = array2)
			{
				result = new string(value, 0, num);
			}
		}
		else
		{
			fixed (byte* ptr3 = array)
			{
				char* value2 = (char*)(ptr3 + offset);
				result = new string(value2, 0, num);
			}
		}
		return result;
	}

	public unsafe static void WriteInt(this byte[] arr, int offset, int value, bool little)
	{
		fixed (byte* ptr = arr)
		{
			int* ptr2 = (int*)(ptr + offset);
			*ptr2 = value;
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(arr, offset, 4);
		}
	}

	public unsafe static void WriteUInt(this byte[] arr, int offset, uint value, bool little)
	{
		fixed (byte* ptr = arr)
		{
			uint* ptr2 = (uint*)(ptr + offset);
			*ptr2 = value;
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(arr, offset, 4);
		}
	}

	public unsafe static void WriteShort(this byte[] arr, int offset, short value, bool little)
	{
		fixed (byte* ptr = arr)
		{
			short* ptr2 = (short*)(ptr + offset);
			*ptr2 = value;
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(arr, offset, 2);
		}
	}

	public unsafe static void WriteUShort(this byte[] arr, int offset, ushort value, bool little)
	{
		fixed (byte* ptr = arr)
		{
			ushort* ptr2 = (ushort*)(ptr + offset);
			*ptr2 = value;
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(arr, offset, 2);
		}
	}

	public unsafe static void WriteLong(this byte[] arr, int offset, long value, bool little)
	{
		fixed (byte* ptr = arr)
		{
			long* ptr2 = (long*)(ptr + offset);
			*ptr2 = value;
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(arr, offset, 8);
		}
	}

	public unsafe static void WriteULong(this byte[] arr, int offset, ulong value, bool little)
	{
		fixed (byte* ptr = arr)
		{
			ulong* ptr2 = (ulong*)(ptr + offset);
			*ptr2 = value;
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(arr, offset, 8);
		}
	}

	public unsafe static void WriteFloat(this byte[] arr, int offset, float value, bool little)
	{
		fixed (byte* ptr = arr)
		{
			float* ptr2 = (float*)(ptr + offset);
			*ptr2 = value;
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(arr, offset, 4);
		}
	}

	public unsafe static void WriteDouble(this byte[] arr, int offset, double value, bool little)
	{
		fixed (byte* ptr = arr)
		{
			double* ptr2 = (double*)(ptr + offset);
			*ptr2 = value;
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(arr, offset, 8);
		}
	}

	public unsafe static void WriteChar(this byte[] arr, int offset, char value, bool little)
	{
		fixed (byte* ptr = arr)
		{
			char* ptr2 = (char*)(ptr + offset);
			*ptr2 = value;
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse(arr, offset, 2);
		}
	}

	public unsafe static void WriteString(this byte[] arr, int offset, string value, bool little)
	{
		int length = value.Length;
		arr.WriteInt(offset, length, little);
		fixed (byte* ptr = arr)
		{
			char* ptr2 = (char*)(ptr + offset + 4);
			fixed (char* ptr3 = value)
			{
				char* ptr4 = ptr3;
				for (int i = 0; i < length; i++)
				{
					char* value2 = ptr4 + i;
					if (BitConverter.IsLittleEndian != little)
					{
						Reverse2(value2);
					}
					ptr2[i] = ptr4[i];
				}
			}
		}
	}

	public static void WriteByte(this byte[] arr, int offset, byte value)
	{
		arr[offset] = value;
	}

	public static void WriteSByte(this byte[] arr, int offset, sbyte value)
	{
		int num = value + 128;
		arr[offset] = (byte)num;
	}

	public static void WriteBool(this byte[] arr, int offset, bool value)
	{
		arr[offset] = (byte)(value ? 1 : 0);
	}

	public static byte ReadByte(this byte[] arr, int offset)
	{
		return arr[offset];
	}

	public static sbyte ReadSByte(this byte[] arr, int offset)
	{
		return (sbyte)(arr[offset] - 128);
	}

	public static bool ReadBool(this byte[] arr, int offset)
	{
		return arr[offset] == 1;
	}

	public unsafe static string ReadString(this byte[] arr, int offset, bool little)
	{
		int num = arr.ReadInt(offset, little);
		string result;
		if (BitConverter.IsLittleEndian != little)
		{
			char[] array = new char[num];
			fixed (byte* ptr = arr)
			{
				char* ptr2 = (char*)(ptr + offset + 4);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = ptr2[i];
				}
			}
			fixed (char* value = array)
			{
				result = new string(value, 0, num);
			}
		}
		else
		{
			fixed (byte* ptr3 = arr)
			{
				char* value2 = (char*)(ptr3 + offset + 4);
				result = new string(value2, 0, num);
			}
		}
		return result;
	}

	public unsafe static int ReadInt(this byte[] arr, int offset, bool little)
	{
		int result;
		fixed (byte* ptr = arr)
		{
			int* ptr2 = (int*)(ptr + offset);
			result = *ptr2;
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse4(&result);
		}
		return result;
	}

	public unsafe static uint ReadUInt(this byte[] arr, int offset, bool little)
	{
		uint result;
		fixed (byte* ptr = arr)
		{
			result = *(uint*)(ptr + offset);
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse4(&result);
		}
		return result;
	}

	public unsafe static short ReadShort(this byte[] arr, int offset, bool little)
	{
		short result;
		fixed (byte* ptr = arr)
		{
			result = *(short*)(ptr + offset);
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse2(&result);
		}
		return result;
	}

	public unsafe static ushort ReadUShort(this byte[] arr, int offset, bool little)
	{
		ushort result;
		fixed (byte* ptr = arr)
		{
			result = *(ushort*)(ptr + offset);
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse2(&result);
		}
		return result;
	}

	public unsafe static long ReadLong(this byte[] arr, int offset, bool little)
	{
		long result;
		fixed (byte* ptr = arr)
		{
			result = *(long*)(ptr + offset);
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse8(&result);
		}
		return result;
	}

	public unsafe static ulong ReadULong(this byte[] arr, int offset, bool little)
	{
		ulong result;
		fixed (byte* ptr = arr)
		{
			result = *(ulong*)(ptr + offset);
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse8(&result);
		}
		return result;
	}

	public unsafe static char ReadChar(this byte[] arr, int offset, bool little)
	{
		char result;
		fixed (byte* ptr = arr)
		{
			char* ptr2 = (char*)(ptr + offset);
			result = *ptr2;
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse2(&result);
		}
		return result;
	}

	public unsafe static float ReadFloat(this byte[] arr, int offset, bool little)
	{
		float result;
		fixed (byte* ptr = arr)
		{
			result = *(float*)(ptr + offset);
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse4(&result);
		}
		return result;
	}

	public unsafe static double ReadDouble(this byte[] arr, int offset, bool little)
	{
		double result;
		fixed (byte* ptr = arr)
		{
			result = *(double*)(ptr + offset);
		}
		if (BitConverter.IsLittleEndian != little)
		{
			Reverse8(&result);
		}
		return result;
	}
}
