using System.Collections.Generic;
using System.Xml;
using SSJJAsset.AssetLoader.Xml;
using SSJJBase.Extensions;
using SSJJBase.Logger;

namespace Assets.Sources.Info.Res;

public class HowToPlayerConfig : AbstractXmlAsset
{
	private Dictionary<string, string> _howToPlayerDic = new Dictionary<string, string>();

	public string TryGetValue(string key)
	{
		string value = "";
		if (!_howToPlayerDic.TryGetValue(key, out value))
		{
			this.LogErrorFormat("Get Value Error, key {0}", key);
		}
		return value;
	}

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		XmlElement documentElement = xmlDocument.DocumentElement;
		if (documentElement == null)
		{
			return;
		}
		foreach (XmlNode item in documentElement)
		{
			string value = item.Read("texture");
			string key = item.Read("freeType");
			_howToPlayerDic.Add(key, value);
		}
	}
}
