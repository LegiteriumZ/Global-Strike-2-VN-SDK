using System.Collections;
using System.Collections.Generic;
using System.Xml;
using SSJJAsset.AssetManager;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Utils.Effect;

public class ParticleEffectVisibleConfig : SingletonInstance<ParticleEffectVisibleConfig>
{
	private Dictionary<string, int> _particleEffectVisibleConfig = new Dictionary<string, int>();

	public int GetLevel(string weaponSkillName, string codeName = "", string type = "")
	{
		if (!string.IsNullOrEmpty(codeName))
		{
			string key = $"{codeName}/effect/{weaponSkillName}";
			if (_particleEffectVisibleConfig.ContainsKey(key))
			{
				return _particleEffectVisibleConfig[key];
			}
		}
		if (_particleEffectVisibleConfig.ContainsKey(weaponSkillName))
		{
			return _particleEffectVisibleConfig[weaponSkillName];
		}
		return 2;
	}

	public IEnumerator LoadConfig()
	{
		AssetAsyncLoader<TextAsset> xmlLoader = new AssetAsyncLoader<TextAsset>();
		yield return xmlLoader.LoadAsync("effect/other", "particleEffectVisibleConfig_unity.xml");
		string text = xmlLoader.Result.text;
		ParseEffectLevel(text);
	}

	private void ParseEffectLevel(string text)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		XmlNode xmlNode = null;
		foreach (XmlNode childNode in xmlDocument.ChildNodes)
		{
			if (childNode.Name.Equals("particleEffectViewConfig"))
			{
				xmlNode = childNode;
				break;
			}
		}
		if (xmlNode == null)
		{
			return;
		}
		foreach (XmlElement item in xmlNode)
		{
			string key = item.Read("name").Replace(".uf3d", "");
			int value = int.Parse(item.Read("level"));
			if (!_particleEffectVisibleConfig.ContainsKey(key))
			{
				_particleEffectVisibleConfig.Add(key, value);
			}
		}
	}
}
