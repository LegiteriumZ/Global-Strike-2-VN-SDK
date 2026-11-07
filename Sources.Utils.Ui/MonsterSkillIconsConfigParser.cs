using System.Collections;
using System.Collections.Generic;
using System.Xml;
using SSJJAsset.Asset;
using SSJJAsset.AssetManager;
using SSJJBase.Singleton;
using UnityEngine;

namespace Sources.Utils.Ui;

public class MonsterSkillIconsConfigParser : SingletonInstance<MonsterSkillIconsConfigParser>
{
	private Dictionary<int, string> _dictionary = new Dictionary<int, string>();

	public Dictionary<int, string> GetConfig()
	{
		if (_dictionary == null)
		{
			return null;
		}
		return _dictionary;
	}

	public IEnumerator LoadConfig()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync(new AssetInfo("ui/halfloadedres/monsterSkillIcons", "skillIconConfig"));
		if (loader.Result != null)
		{
			string text = loader.Result.text;
			_dictionary = ParseConfig(text);
			Resources.UnloadAsset(loader.Result);
		}
	}

	private Dictionary<int, string> ParseConfig(string xml)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		XmlNode documentElement = xmlDocument.DocumentElement;
		if (documentElement != null)
		{
			foreach (XmlNode childNode in documentElement.ChildNodes)
			{
				dictionary.Add(int.Parse(childNode.Attributes["playerStatusId"].Value), childNode.Attributes["icon"].Value);
			}
		}
		return dictionary;
	}
}
