using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Utils.Ui;

public static class TextUtils
{
	public static string StripLengthWithSuffix(string input, Text text, string suffix, int suffixLength, int maxWidth = 460)
	{
		if (CalculateLengthOfText(input, text) > maxWidth)
		{
			return StripLength(input, text, maxWidth - suffixLength) + suffix;
		}
		return input;
	}

	public static string StripLength(string input, Text text, int maxWidth = 460)
	{
		int num = 0;
		Font font = text.font;
		font.RequestCharactersInTexture(input, text.fontSize, text.fontStyle);
		CharacterInfo info = default(CharacterInfo);
		char[] array = input.ToCharArray();
		int num2 = 0;
		char[] array2 = array;
		foreach (char ch in array2)
		{
			font.GetCharacterInfo(ch, out info, text.fontSize);
			int num3 = num + info.advance;
			if (num3 > maxWidth)
			{
				Debug.LogFormat("new length: {0} - total length: {1}", num3, num);
				if (Mathf.Abs(num3 - maxWidth) <= Mathf.Abs(maxWidth - num))
				{
					num = num3;
					num2++;
				}
				break;
			}
			num += info.advance;
			num2++;
		}
		Debug.LogFormat("total length: {0}", num);
		return input.Substring(0, num2);
	}

	public static int CalculateLengthOfText(string message, Text text)
	{
		int num = 0;
		Font font = text.font;
		font.RequestCharactersInTexture(message, text.fontSize, text.fontStyle);
		CharacterInfo info = default(CharacterInfo);
		char[] array = message.ToCharArray();
		foreach (char ch in array)
		{
			font.GetCharacterInfo(ch, out info, text.fontSize);
			num += info.advance;
		}
		return num;
	}
}
