using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Assets.Scripts;
using Assets.Sources.Utils.AssetManager;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.Utils.Weapon;

public class ChampionWeaponAndSkillParser : SingletonInstance<ChampionWeaponAndSkillParser>
{
	private Dictionary<string, string> _championWeaponAndSkillConfig;

	public bool GetChampionWeaponAndSkillfig(string weaponSkillName)
	{
		return _championWeaponAndSkillConfig.ContainsKey(weaponSkillName);
	}

	public string GetChampionWeaponAndSkillfigName(string weaponSkillName)
	{
		if (_championWeaponAndSkillConfig.ContainsKey(weaponSkillName))
		{
			return _championWeaponAndSkillConfig[weaponSkillName];
		}
		return "";
	}

	public IEnumerator LoadConfig()
	{
		AssetInfo championWeaponAndSkillConfig = new AssetInfo("weapon/default", "Assets/Res/Assets/weapon/championWeaponAndSkillConfig.xml", typeof(TextAsset), optional: true);
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(championWeaponAndSkillConfig, BaseAsyncManager.Instance);
		yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(championWeaponAndSkillConfig);
		TextAsset textAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(championWeaponAndSkillConfig) as TextAsset;
		_championWeaponAndSkillConfig = ParseConfig(textAsset.text);
		Resources.UnloadAsset(textAsset);
		MonoBehaviourSingleton<GarbageDestoryer>.Instance.RemoveLinker(championWeaponAndSkillConfig);
	}

	private Dictionary<string, string> ParseConfig(string xml)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		XmlNode documentElement = xmlDocument.DocumentElement;
		if (documentElement != null)
		{
			foreach (XmlNode childNode in documentElement.ChildNodes)
			{
				string key = ((childNode.Attributes["WeaponSkinName"] != null) ? childNode.Attributes["WeaponSkinName"].Value : "");
				string value = ((childNode.Attributes["WeaponSkinCnName"] != null) ? childNode.Attributes["WeaponSkinCnName"].Value : "");
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, value);
				}
			}
		}
		return dictionary;
	}
}
