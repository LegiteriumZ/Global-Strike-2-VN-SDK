using System.Collections.Generic;
using System.IO;
using System.Xml;
using SSJJBase.Utility;

namespace Assets.Sources.Info.EffectParser;

public class TextureConfigs
{
	public List<TextureConfig> _list = new List<TextureConfig>();

	private readonly string xmlPath = "textureconfig.xml";

	public void Parse(string weaponPath)
	{
		string text = PathEx.Combine(weaponPath, xmlPath);
		if (!File.Exists(text))
		{
			return;
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(text);
		foreach (XmlNode item in xmlDocument.DocumentElement)
		{
			if (!item.Name.Equals("texture"))
			{
				continue;
			}
			TextureConfig textureConfig = new TextureConfig();
			if (item.Attributes != null && item.Attributes["name"] != null)
			{
				textureConfig.Name = item.Attributes["name"].Value;
				textureConfig.IsAlphaKill = item.Attributes["alphakill"].Value.Equals("1");
				textureConfig.IsTranslucent = item.Attributes["translucent"].Value.Equals("1");
				if (item.Attributes["alphaKillValue"] != null)
				{
					textureConfig.AlphaKillValue = float.Parse(item.Attributes["alphaKillValue"].Value);
				}
				_list.Add(textureConfig);
			}
		}
	}
}
