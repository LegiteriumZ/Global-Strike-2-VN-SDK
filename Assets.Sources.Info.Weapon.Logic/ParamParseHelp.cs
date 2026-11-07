using System;

namespace Assets.Sources.Info.Weapon.Logic;

public class ParamParseHelp
{
	public static void ParseInt(out int[] restlts, string param, int length)
	{
		restlts = new int[length];
		string[] array = param.Split(',');
		if (array.Length != length)
		{
			throw new Exception($"param error:{param}");
		}
		for (int i = 0; i < array.Length; i++)
		{
			if (string.IsNullOrEmpty(array[i]) || !int.TryParse(array[i], out restlts[i]))
			{
				throw new Exception($"param error:{param}");
			}
		}
	}

	public static void ParseString(out string[] restlts, string param, int length)
	{
		restlts = new string[length];
		string[] array = param.Split(',');
		if (array.Length != length)
		{
			throw new Exception($"param error:{param}");
		}
		for (int i = 0; i < array.Length; i++)
		{
			if (string.IsNullOrEmpty(array[i]))
			{
				throw new Exception($"param error:{param}");
			}
			restlts[i] = array[i];
		}
	}

	public static void ParseFloat(out float[] restlts, string param, int length)
	{
		restlts = new float[length];
		string[] array = param.Split(',');
		if (array.Length != length)
		{
			throw new Exception($"param error:{param}");
		}
		for (int i = 0; i < array.Length; i++)
		{
			if (string.IsNullOrEmpty(array[i]) || !float.TryParse(array[i], out restlts[i]))
			{
				throw new Exception($"param error:{param}");
			}
		}
	}
}
