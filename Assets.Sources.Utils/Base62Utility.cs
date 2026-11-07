using System.Collections.Generic;
using System.Text;

namespace Assets.Sources.Utils;

public class Base62Utility
{
	private const string CODES = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

	private const char CODEFLAG = '9';

	private static StringBuilder outStr = new StringBuilder();

	private static Dictionary<char, int> CODEMAP = new Dictionary<char, int>();

	private static void Append(int b)
	{
		if (b < 61)
		{
			outStr.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[b]);
			return;
		}
		outStr.Append('9');
		outStr.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[b - 61]);
	}

	public static string base62Encode(byte[] inBytes)
	{
		outStr.Length = 0;
		for (int i = 0; i < inBytes.Length; i += 3)
		{
			int b = (inBytes[i] & 0xFC) >> 2;
			Append(b);
			b = (inBytes[i] & 3) << 4;
			if (i + 1 < inBytes.Length)
			{
				b |= (inBytes[i + 1] & 0xF0) >> 4;
				Append(b);
				b = (inBytes[i + 1] & 0xF) << 2;
				if (i + 2 < inBytes.Length)
				{
					b |= (inBytes[i + 2] & 0xC0) >> 6;
					Append(b);
					b = inBytes[i + 2] & 0x3F;
					Append(b);
				}
				else
				{
					Append(b);
				}
			}
			else
			{
				Append(b);
			}
		}
		return outStr.ToString();
	}

	public static byte[] base62Decode(char[] inChars)
	{
		CODEMAP['A'] = 61;
		CODEMAP['B'] = 62;
		CODEMAP['C'] = 63;
		List<byte> list = new List<byte>();
		int[] array = new int[4];
		int num = inChars.Length;
		int num2 = 0;
		int num3 = 0;
		char c = '\0';
		char c2 = '\0';
		byte b = 0;
		while (num2 < num)
		{
			c = inChars[num2];
			if (c != '9')
			{
				array[num3] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".IndexOf(c);
				num3++;
				num2++;
			}
			else
			{
				num2++;
				if (num2 < num)
				{
					c2 = inChars[num2];
					if (c2 != '9')
					{
						array[num3] = CODEMAP[c2];
						num3++;
						num2++;
					}
				}
			}
			if (num3 == 4)
			{
				b = (byte)((array[0] << 2) | (array[1] >> 4));
				list.Add(b);
				b = (byte)((array[1] << 4) | (array[2] >> 2));
				list.Add(b);
				b = (byte)((array[2] << 6) | array[3]);
				list.Add(b);
				num3 = 0;
			}
		}
		switch (num3)
		{
		case 1:
			b = (byte)(array[0] << 2);
			list.Add(b);
			break;
		case 2:
			b = (byte)((array[0] << 2) | (array[1] >> 4));
			list.Add(b);
			break;
		case 3:
			b = (byte)((array[0] << 2) | (array[1] >> 4));
			list.Add(b);
			b = (byte)((array[1] << 4) | (array[2] >> 2));
			list.Add(b);
			break;
		}
		return list.ToArray();
	}
}
