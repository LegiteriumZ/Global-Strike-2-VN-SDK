using System.Collections.Generic;
using System.Xml;
using SSJJBase.Logger;

namespace Assets.Sources.Utils.Ui;

public static class ModeResourcesConfigParser
{
	private static LoggerAdapter _logger = new LoggerAdapter(typeof(ModeResourcesConfigParser));

	public static ModeResourcesConfig ParseConfig(string xml)
	{
		ModeResourcesConfig modeResourcesConfig = default(ModeResourcesConfig);
		modeResourcesConfig.Inited = false;
		modeResourcesConfig.ModeEffectUrls = new List<string>();
		ModeResourcesConfig config = modeResourcesConfig;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		ParseModeTitle(xmlDocument.GetElementsByTagName("modeTitleImage"), ref config);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("modeType");
		if (elementsByTagName.Count > 0 && elementsByTagName[0] != null)
		{
			config.ModeType = elementsByTagName[0].InnerText;
		}
		XmlNodeList elementsByTagName2 = xmlDocument.GetElementsByTagName("modeImage");
		if (elementsByTagName2.Count > 0 && elementsByTagName2[0] != null)
		{
			config.ModeImage = elementsByTagName2[0].InnerText;
		}
		XmlNodeList elementsByTagName3 = xmlDocument.GetElementsByTagName("modeEffectURL");
		if (elementsByTagName3.Count > 0 && elementsByTagName3[0] != null)
		{
			foreach (XmlNode item in elementsByTagName3)
			{
				if (!string.IsNullOrEmpty(item.InnerText))
				{
					config.ModeEffectUrls.Add(item.InnerText.Replace("_zip", "").Replace("effect/", "").ToLower());
				}
			}
		}
		XmlNodeList elementsByTagName4 = xmlDocument.GetElementsByTagName("modeUIURL");
		if (elementsByTagName4.Count > 0 && elementsByTagName4[0] != null)
		{
			config.ModeUiUrl = elementsByTagName4[0].InnerText;
		}
		config.Inited = true;
		return config;
	}

	private static void ParseModeTitle(XmlNodeList elements, ref ModeResourcesConfig config)
	{
		if (elements.Count < 1)
		{
			_logger.Debug("more than one node named modeTitleImage in moderesourcesconfig !!");
			return;
		}
		if (elements[0] == null)
		{
			_logger.Error("no modeTitleImage node exist in moderesourcesconfig !!");
			return;
		}
		string innerText = elements[0].InnerText;
		if (elements[0].Attributes == null)
		{
			_logger.Error("no attribe exist modeTitleImage node in moderesourcesconfig !!");
			return;
		}
		config.ModeTitleTeam1 = innerText;
		config.ModeTitleTeam2 = innerText;
		XmlNodeList xmlNodeList = elements[0].SelectNodes("teamTitleImage");
		if (xmlNodeList == null)
		{
			return;
		}
		foreach (XmlElement item in xmlNodeList)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			string empty = string.Empty;
			innerText = item.InnerText;
			foreach (XmlAttribute attribute in item.Attributes)
			{
				switch (attribute.Name)
				{
				case "team":
					text2 = attribute.Value;
					break;
				case "width":
					text = attribute.Value;
					break;
				case "height":
					text = attribute.Value;
					break;
				}
			}
			if (string.IsNullOrEmpty(text2))
			{
				config.ModeTitleTeam1 = innerText;
				config.ModeTitleWidthTeam1 = text;
				config.ModeTitleHeightTeam1 = empty;
				config.ModeTitleTeam2 = innerText;
				config.ModeTitleWidthTeam2 = text;
				config.ModeTitleHeightTeam2 = empty;
			}
			else if (!(text2 == "1"))
			{
				if (text2 == "2")
				{
					config.ModeTitleTeam2 = innerText;
					config.ModeTitleWidthTeam2 = text;
					config.ModeTitleHeightTeam2 = empty;
				}
			}
			else
			{
				config.ModeTitleTeam1 = innerText;
				config.ModeTitleWidthTeam1 = text;
				config.ModeTitleHeightTeam1 = empty;
			}
		}
	}
}
