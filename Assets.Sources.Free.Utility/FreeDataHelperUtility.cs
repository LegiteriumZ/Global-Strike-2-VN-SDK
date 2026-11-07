using System;
using SSJJBase.Logger;

namespace Assets.Sources.Free.Utility;

public class FreeDataHelperUtility
{
	private static readonly LoggerAdapter Logger = new LoggerAdapter(typeof(FreeDataHelperUtility));

	public static bool GetStringArrayIdx<T>(string[] strings, int checkLength, ref T t)
	{
		if (strings.Length > checkLength)
		{
			if (t is int)
			{
				int.TryParse(strings[checkLength], out var result);
				t = (T)Convert.ChangeType(result, typeof(T));
				return true;
			}
			if (t is float)
			{
				float.TryParse(strings[checkLength], out var result2);
				t = (T)Convert.ChangeType(result2, typeof(T));
				return true;
			}
			if (t is double)
			{
				double.TryParse(strings[checkLength], out var result3);
				t = (T)Convert.ChangeType(result3, typeof(T));
				return true;
			}
			if (t is string)
			{
				string value = strings[checkLength];
				t = (T)Convert.ChangeType(value, typeof(T));
				return true;
			}
			if (t != null)
			{
				Logger.Error("Get Free Data Error : " + t.GetType());
			}
			else
			{
				Logger.Error("Get Free Data Error : t null value");
			}
		}
		return false;
	}

	public static bool EqualStringArrayIdx(string[] strings, int checkLength, string compareStr)
	{
		if (strings.Length > checkLength && strings[checkLength].Equals(compareStr))
		{
			return true;
		}
		return false;
	}

	public static bool ContainStringArrayIdx(string[] strings, int checkLength, string compareStr)
	{
		if (strings.Length > checkLength && strings[checkLength].Contains(compareStr))
		{
			return true;
		}
		return false;
	}
}
