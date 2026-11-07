using System.Xml;

namespace Assets.Sources.Info.EffectParser;

public class UvLiuGuangEffectParser : AbstractEffectParser
{
	protected int speed;

	protected string textrue;

	public static bool IsNode(XmlNode node)
	{
		if (node.Name == "uv2effectliuguang")
		{
			return true;
		}
		return false;
	}

	public override void ParseFromXmlNode(XmlNode node)
	{
		foreach (XmlNode item in node)
		{
			if (item.Name.Equals("effecttime"))
			{
				if (item.Attributes != null && item.Attributes["speed"] != null)
				{
					speed = int.Parse(item.Attributes["speed"].Value);
				}
			}
			else if (item.Name.Equals("effectTexture") && item.Attributes != null && item.Attributes["name"] != null)
			{
				textrue = item.Attributes["name"].Value.Replace(".atf", ".png");
			}
		}
	}

	public UvLiuGuangEffectParser(string _name)
		: base(_name)
	{
	}
}
