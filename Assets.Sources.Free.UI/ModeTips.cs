using System.Collections.Generic;
using Assets.Sources.Free.Data;

namespace Assets.Sources.Free.UI;

public class ModeTips
{
	private static Dictionary<string, List<string>> tipMap = new Dictionary<string, List<string>>();

	private static Dictionary<string, string> descMap = new Dictionary<string, string>();

	public static string currentLang = "default";

	public static void SetDesc(string lang, string free, string desc)
	{
		string key = GetKey(lang, free);
		descMap[key] = desc;
	}

	public static string GetDesc()
	{
		string key = GetKey(currentLang, GameModelLocator.GetInstance().GameModel.RoomData.FreeType);
		if (descMap.ContainsKey(key))
		{
			return descMap[key];
		}
		return "";
	}

	private static string GetKey(string lang, string free)
	{
		return lang + free;
	}

	public static void AddTip(string lang, string free, List<string> tips)
	{
		string key = GetKey(lang, free);
		tipMap[key] = tips;
	}

	public static List<string> GetTip()
	{
		string key = GetKey(currentLang, GameModelLocator.GetInstance().GameModel.RoomData.FreeType);
		if (tipMap.ContainsKey(key))
		{
			return tipMap[key];
		}
		return new List<string>();
	}
}
