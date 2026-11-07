using System.Xml;

namespace Assets.Sources.Info.EffectParser;

public class UvHuxiColorEffectParser : AbstractEffectParser
{
	protected int waittime;

	protected int biansetime;

	protected int minMap;

	protected string textrue;

	public int type;

	public static bool IsNode(XmlNode node)
	{
		if (node.Name == "uv2effectbianse" || node.Name == "uv2effectbianseplayer")
		{
			return true;
		}
		return false;
	}

	public override void ParseFromXmlNode(XmlNode node)
	{
		if (node.Name == "uv2effectbianse")
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
				biansetime = int.Parse(item.Attributes["biansetime"].Value);
				minMap = ((item.Attributes["minmap"] != null) ? int.Parse(item.Attributes["minmap"].Value) : 0);
			}
			else if (item.Name.Equals("effectTexture"))
			{
				textrue = item.Attributes["name"].Value.Replace(".atf", ".png");
			}
		}
	}

	public UvHuxiColorEffectParser(string _name)
		: base(_name)
	{
	}
}
