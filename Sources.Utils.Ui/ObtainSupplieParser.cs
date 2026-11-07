using System.Collections;
using System.Collections.Generic;
using System.Xml;
using SSJJAsset.Asset;
using SSJJAsset.AssetManager;
using SSJJBase.Singleton;
using UnityEngine;

namespace Sources.Utils.Ui;

public class ObtainSupplieParser : SingletonInstance<ObtainSupplieParser>
{
	private Dictionary<int, string> _dictionary = new Dictionary<int, string>();

	private List<int> _newAddConfig;

	public Dictionary<int, string> GetObtainSupplieConfig()
	{
		if (_dictionary == null)
		{
			return null;
		}
		return _dictionary;
	}

	public List<int> GetNewAddConfig()
	{
		return _newAddConfig;
	}

	public IEnumerator LoadConfig()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync(new AssetInfo("ui/halfloadedres/obtainsupplies", "obtainSupplieConfig"));
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
				dictionary.Add(int.Parse(childNode.Attributes["playerStatus"].Value), childNode.Attributes["url"].Value);
			}
		}
		return dictionary;
	}

	public void AddObtainSuppliesConfig(int ps, string url)
	{
		if (_dictionary != null)
		{
			_dictionary.Add(ps, url);
			if (_newAddConfig == null)
			{
				_newAddConfig = new List<int>();
			}
			if (!_newAddConfig.Contains(ps))
			{
				_newAddConfig.Add(ps);
			}
		}
	}
}
