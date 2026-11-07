using System.Xml;

namespace Assets.Sources.Info.EffectParser;

public class ParticleFireParser : ParticleEffectParser
{
	public static bool IsEffectNode(XmlNode node)
	{
		if (ParticleEffectParser.IsNode(node))
		{
			return node.Name.ToLower().Contains("fire");
		}
		return false;
	}

	public ParticleFireParser(string _name)
		: base(_name)
	{
	}
}
