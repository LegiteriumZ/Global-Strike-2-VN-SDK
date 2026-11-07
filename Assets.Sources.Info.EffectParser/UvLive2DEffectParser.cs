using System.Globalization;
using System.Xml;
using UnityEngine;

namespace Assets.Sources.Info.EffectParser;

public class UvLive2DEffectParser : AbstractEffectParser
{
	protected string assetsName;

	protected string liuguangAssets;

	protected string maskAssets;

	protected Color32 color;

	public static bool IsNode(XmlNode node)
	{
		if (node.Name == "uv2effectlive2D")
		{
			return true;
		}
		return false;
	}

	public override void ParseFromXmlNode(XmlNode node)
	{
		foreach (XmlNode item in node)
		{
			if (item.Name.Equals("altas"))
			{
				string[] array = item.Attributes["txtPath"].Value.Split('.');
				assetsName = array[0];
			}
			else if (item.Name.Equals("effectTexture"))
			{
				liuguangAssets = item.Attributes["name"].Value.Replace(".atf", ".png");
				color = getColor(item.Attributes["color"].Value);
			}
			else if (item.Name.Equals("effectMaskTexture"))
			{
				maskAssets = item.Attributes["name"].Value.Replace(".atf", ".png");
			}
		}
	}

	private Color32 getColor(string colorStr)
	{
		if (colorStr.IndexOf("#") == -1)
		{
			return new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}
		colorStr = colorStr.TrimStart('#');
		byte r = byte.Parse(colorStr.Substring(0, 2), NumberStyles.HexNumber);
		byte g = byte.Parse(colorStr.Substring(2, 2), NumberStyles.HexNumber);
		byte b = byte.Parse(colorStr.Substring(4, 2), NumberStyles.HexNumber);
		return new Color32(r, g, b, byte.MaxValue);
	}

	public UvLive2DEffectParser(string _name)
		: base(_name)
	{
	}
}
