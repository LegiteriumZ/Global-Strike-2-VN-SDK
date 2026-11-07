using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Assets.Scripts;
using Assets.Sources.Utils.AssetManager;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.Utils.Accessory;

public class AccessoryHeadChangeParser : SingletonInstance<AccessoryHeadChangeParser>
{
	private Dictionary<string, bool> _accessoryHeadChangeConfig;

	public bool GetAccessoryHeadChange(string accessoryName)
	{
		if (_accessoryHeadChangeConfig == null)
		{
			return false;
		}
		if (_accessoryHeadChangeConfig.ContainsKey(accessoryName))
		{
			return _accessoryHeadChangeConfig[accessoryName];
		}
		return false;
	}

	public IEnumerator LoadConfig()
	{
		AssetInfo accessoryHeadChangeConfig = new AssetInfo("accessory/default", "Assets/Res/Assets/accessory/headChangeAccessoryConfig.xml", typeof(TextAsset), optional: true);
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(accessoryHeadChangeConfig, BaseAsyncManager.Instance);
		yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(accessoryHeadChangeConfig);
		TextAsset textAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(accessoryHeadChangeConfig) as TextAsset;
		if (textAsset != null)
		{
			_accessoryHeadChangeConfig = ParseConfig(textAsset.text);
		}
		Resources.UnloadAsset(textAsset);
		MonoBehaviourSingleton<GarbageDestoryer>.Instance.RemoveLinker(accessoryHeadChangeConfig);
	}

	private Dictionary<string, bool> ParseConfig(string xml)
	{
		Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		XmlNode documentElement = xmlDocument.DocumentElement;
		if (documentElement != null)
		{
			foreach (XmlNode childNode in documentElement.ChildNodes)
			{
				if (childNode.Attributes["AccessoryName"] != null)
				{
					string value = childNode.Attributes["AccessoryName"].Value;
					if (!dictionary.ContainsKey(value))
					{
						dictionary.Add(value, value: true);
					}
				}
			}
		}
		return dictionary;
	}
}
