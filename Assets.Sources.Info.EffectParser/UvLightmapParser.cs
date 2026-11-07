using System;
using System.Xml;

namespace Assets.Sources.Info.EffectParser;

public class UvLightmapParser : AbstractEffectParser
{
	protected string lightmapTextureName;

	protected float tileU = 1f;

	protected float tileV = 1f;

	protected float u;

	protected float v;

	protected int version;

	public static bool IsNode(XmlNode node)
	{
		if (node.Name == "uv2effectlightmap")
		{
			return true;
		}
		return false;
	}

	public override void ParseFromXmlNode(XmlNode node)
	{
		if (node.Attributes["version"] != null)
		{
			version = Convert.ToInt16(node.Attributes["version"].Value);
		}
		foreach (XmlNode item in node)
		{
			if (item.Name.Equals("effectTexture"))
			{
				lightmapTextureName = item.Attributes["name"].Value;
			}
			if (item.Name.Equals("effecttime"))
			{
				if (item.Attributes["tileU"] != null)
				{
					tileU = Convert.ToSingle(item.Attributes["tileU"].Value);
				}
				if (item.Attributes["tileV"] != null)
				{
					tileV = Convert.ToSingle(item.Attributes["tileV"].Value);
				}
				if (item.Attributes["u"] != null)
				{
					u = Convert.ToSingle(item.Attributes["u"].Value);
				}
				if (item.Attributes["v"] != null)
				{
					v = Convert.ToSingle(item.Attributes["v"].Value);
				}
			}
		}
	}

	public UvLightmapParser(string _name)
		: base(_name)
	{
	}
}
