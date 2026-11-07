using System.Collections.Generic;
using System.Xml;
using SSJJBase.Logger;

namespace Assets.Sources.Utils.Weapon;

public static class HeroWeaponPaser
{
	private static LoggerAdapter _logger = new LoggerAdapter(typeof(HeroWeaponPaser));

	public static Dictionary<int, Dictionary<string, HeroWeaponConfig>> ParseConfig(string xml)
	{
		Dictionary<int, Dictionary<string, HeroWeaponConfig>> dictionary = new Dictionary<int, Dictionary<string, HeroWeaponConfig>>();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		XmlNode documentElement = xmlDocument.DocumentElement;
		if (documentElement != null)
		{
			foreach (XmlNode item in documentElement)
			{
				int key = int.Parse(item.Attributes["raceType"].Value);
				Dictionary<string, HeroWeaponConfig> dictionary2 = new Dictionary<string, HeroWeaponConfig>();
				foreach (XmlNode item2 in item)
				{
					string value = item2.Attributes["name"].Value;
					HeroWeaponConfig heroWeaponConfig = new HeroWeaponConfig();
					foreach (XmlNode item3 in item2)
					{
						heroWeaponConfig.Values.Add(item3.Attributes["type"].Value, item3.Attributes["value"].Value);
					}
					heroWeaponConfig.Inited = true;
					dictionary2.Add(value, heroWeaponConfig);
				}
				dictionary.Add(key, dictionary2);
			}
		}
		return dictionary;
	}
}
