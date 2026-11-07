using System.Xml;

namespace Assets.Sources.Info.EffectParser;

public class UvHuxiEffectParser : AbstractEffectParser
{
	protected int waittime;

	protected int huxitime;

	protected int minMap;

	protected string textrue;

	public int type;

	public static bool IsNode(XmlNode node)
	{
		if (node.Name == "uv2effecthuxi" || node.Name == "uv2effecthuxiplayer")
		{
			return true;
		}
		return false;
	}

	public override void ParseFromXmlNode(XmlNode node)
	{
		if (node.Name == "uv2effecthuxi")
		{
			type = 0;
		}
		else
		{
			type = 1;
		}
		foreach (XmlNode item in node)
		{
			if (item.Name.Equals("effecttime"))
			{
				waittime = int.Parse(item.Attributes["waittime"].Value);
				huxitime = int.Parse(item.Attributes["huxitime"].Value);
				minMap = ((item.Attributes["minmap"] != null) ? int.Parse(item.Attributes["minmap"].Value) : 0);
			}
			else if (item.Name.Equals("effectTexture"))
			{
				textrue = item.Attributes["name"].Value.Replace(".atf", ".png");
			}
		}
	}

	public UvHuxiEffectParser(string _name)
		: base(_name)
	{
	}
}
