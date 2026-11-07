using System;
using System.Collections.Generic;
using System.Xml;
using SSJJAsset.AssetLoader.Xml;
using UnityEngine;

namespace Assets.Sources.Info.CyberStyle;

public class CyberMonsterConfigInfo : AbstractXmlAsset
{
	public Dictionary<string, CyberMonsterConfigItem> CyberConfigs = new Dictionary<string, CyberMonsterConfigItem>();

	public void LoadXml(string text, string codeName)
	{
		base.ParseXml(text);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		XmlNode xmlNode = null;
		foreach (XmlNode childNode in xmlDocument.ChildNodes)
		{
			if (childNode.Name.Equals("CyberMonster"))
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
			if (!item.Name.Equals(codeName))
			{
				continue;
			}
			foreach (XmlElement item2 in item)
			{
				CyberMonsterConfigItem cyberMonsterConfigItem = new CyberMonsterConfigItem();
				if (item2.HasAttribute("time"))
				{
					cyberMonsterConfigItem.time = Convert.ToSingle(item2.GetAttribute("time"));
				}
				if (item2.HasAttribute("edgeWidth"))
				{
					cyberMonsterConfigItem.edgeWidth = Convert.ToSingle(item2.GetAttribute("edgeWidth"));
				}
				if (item2.HasAttribute("color"))
				{
					Color color = Color.red;
					ColorUtility.TryParseHtmlString(item2.GetAttribute("color"), out color);
					cyberMonsterConfigItem.color = color;
				}
				if (item2.HasAttribute("colorIntensity"))
				{
					cyberMonsterConfigItem.rimAmount = Convert.ToSingle(item2.GetAttribute("colorIntensity"));
				}
				if (item2.HasAttribute("rimAlpha"))
				{
					cyberMonsterConfigItem.rimAlpha = Convert.ToSingle(item2.GetAttribute("rimAlpha"));
				}
				if (item2.HasAttribute("scanAmount"))
				{
					cyberMonsterConfigItem.rimAlpha = Convert.ToSingle(item2.GetAttribute("scanAmount"));
				}
				CyberConfigs.Add(item2.Name, cyberMonsterConfigItem);
			}
		}
	}
}
