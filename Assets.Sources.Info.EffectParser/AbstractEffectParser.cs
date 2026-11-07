using System.Xml;

namespace Assets.Sources.Info.EffectParser;

public abstract class AbstractEffectParser : IEffectParser
{
	private string _name;

	public string Name => _name;

	protected AbstractEffectParser(string name)
	{
		_name = name;
	}

	public abstract void ParseFromXmlNode(XmlNode node);
}
