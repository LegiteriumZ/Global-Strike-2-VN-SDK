using System.Xml;

namespace Assets.Sources.Info.EffectParser;

public interface IEffectParser
{
	string Name { get; }

	void ParseFromXmlNode(XmlNode node);
}
