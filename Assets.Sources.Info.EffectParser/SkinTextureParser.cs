using System.Collections.Generic;
using System.Xml;

namespace Assets.Sources.Info.EffectParser;

public class SkinTextureParser : AbstractEffectParser
{
	protected List<string> list = new List<string>();

	public static bool IsNode(XmlNode node)
	{
		if (node.Name == "skintexture")
		{
			return true;
		}
		return false;
	}

	public override void ParseFromXmlNode(XmlNode node)
	{
		foreach (XmlNode item in node)
		{
			if (item.Name.Equals("effectTexture"))
			{
				list.Add(item.Attributes["name"].Value);
			}
		}
	}

	public SkinTextureParser(string _name)
		: base(_name)
	{
	}
}
