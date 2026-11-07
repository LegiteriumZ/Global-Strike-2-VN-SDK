using System.Xml;

namespace Assets.Sources.Info.EffectParser;

public class EffectUnityParser : AbstractEffectParser
{
	public string MeshSkinName;

	public string MaterialName;

	public static bool IsNode(XmlNode node)
	{
		if (node.Name == "player_meshskin_effect")
		{
			return true;
		}
		return false;
	}

	public override void ParseFromXmlNode(XmlNode node)
	{
		foreach (XmlNode item in node)
		{
			MeshSkinName = item.Attributes["meshskinname"].Value;
			MaterialName = item.Attributes["materialname"].Value;
		}
	}

	public EffectUnityParser(string _name)
		: base(_name)
	{
	}
}
