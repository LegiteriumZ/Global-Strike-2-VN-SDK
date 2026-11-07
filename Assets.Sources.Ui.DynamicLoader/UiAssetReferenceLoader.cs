using System.Collections;
using System.Collections.Generic;
using System.Xml;
using SSJJAsset.Asset;
using SSJJAsset.AssetManager;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.Ui.DynamicLoader;

public class UiAssetReferenceLoader : BattleSingletonInstance<UiAssetReferenceLoader>
{
	public Dictionary<string, Dictionary<string, AssetInfo>> AssetCache = new Dictionary<string, Dictionary<string, AssetInfo>>();

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> xmlLoader = new AssetAsyncLoader<TextAsset>();
		yield return xmlLoader.LoadAsync("uiprefabs/common", "UiModelRefrence.xml");
		string text = xmlLoader.Result.text;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		foreach (XmlElement childNode in (xmlDocument.FirstChild as XmlElement).ChildNodes)
		{
			Dictionary<string, AssetInfo> dictionary = new Dictionary<string, AssetInfo>();
			foreach (XmlElement childNode2 in childNode.ChildNodes)
			{
				string attribute = childNode2.GetAttribute("Key");
				string attribute2 = childNode2.GetAttribute("BundleName");
				string attribute3 = childNode2.GetAttribute("AssetName");
				dictionary.Add(attribute, new AssetInfo(attribute2, attribute3));
			}
			AssetCache.Add(childNode.Name.ToLower(), dictionary);
		}
	}

	public override void Clear()
	{
		foreach (Dictionary<string, AssetInfo> value in AssetCache.Values)
		{
			value.Clear();
		}
		AssetCache.Clear();
	}
}
