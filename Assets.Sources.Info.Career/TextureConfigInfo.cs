using System;
using System.Collections.Generic;
using System.Xml;
using SSJJAsset.AssetLoader.Xml;

namespace Assets.Sources.Info.Career;

public class TextureConfigInfo : AbstractXmlAsset
{
	public Dictionary<string, TextureConfigItem> TextureConfigs = new Dictionary<string, TextureConfigItem>();

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		XmlNode xmlNode = null;
		foreach (XmlNode childNode in xmlDocument.ChildNodes)
		{
			if (childNode.Name.Equals("textureconfig"))
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
			TextureConfigItem textureConfigItem = new TextureConfigItem();
			if (item.HasAttribute("name"))
			{
				textureConfigItem.TextureName = item.GetAttribute("name");
			}
			if (item.HasAttribute("alphakill"))
			{
				textureConfigItem.AlphaKill = Convert.ToInt32(item.GetAttribute("alphakill"));
			}
			if (item.HasAttribute("translucent"))
			{
				textureConfigItem.Translucet = Convert.ToInt32(item.GetAttribute("translucent"));
			}
			if (item.HasAttribute("alphaKillValue"))
			{
				textureConfigItem.AlphaKillValue = Convert.ToSingle(item.GetAttribute("alphaKillValue"));
			}
			if (textureConfigItem.TextureName != null)
			{
				TextureConfigs.Add(textureConfigItem.TextureName, textureConfigItem);
			}
		}
	}
}
