using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Assets.Sources.Info.Career;
using SSJJAsset.AssetManager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class AccessoryConfigLoader : IConfigLoader
{
	private class AccessoryConfig
	{
		public string accessoryName;

		public bool isView;
	}

	public static AccessoryConfigLoader Instance = new AccessoryConfigLoader();

	private Dictionary<string, AccessoryConfig> _dictionary = new Dictionary<string, AccessoryConfig>();

	public Dictionary<string, AsccessoryConfigure> _AsccessoryConfigures = new Dictionary<string, AsccessoryConfigure>();

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("accessory/other", "AccessoryConfig");
		string text = loader.Result.text;
		Load(text);
	}

	public void Clear()
	{
		_dictionary.Clear();
	}

	public void Load(string data)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(data);
		foreach (XmlNode childNode in xmlDocument.SelectSingleNode("accessoryConfig").ChildNodes)
		{
			if (childNode.Name == "AccessoryInfo")
			{
				XmlAttributeCollection attributes = childNode.Attributes;
				string value = attributes["accessoryName"].Value;
				bool isView = Convert.ToBoolean(attributes["isView"].Value);
				_dictionary.Add(value, new AccessoryConfig
				{
					accessoryName = value,
					isView = isView
				});
			}
		}
	}

	public void Add_AsccessoryConfigures(string accessoryName, AsccessoryConfigure asccessoryConfigure)
	{
		if (asccessoryConfigure != null && !_AsccessoryConfigures.ContainsKey(accessoryName))
		{
			_AsccessoryConfigures.Add(accessoryName, asccessoryConfigure);
		}
	}

	public bool hasAccessoryIsView(string accessoryName)
	{
		if (_AsccessoryConfigures.ContainsKey(accessoryName))
		{
			return _AsccessoryConfigures[accessoryName].isView;
		}
		return false;
	}
}
