using System.Xml;

namespace Assets.Sources.Particle.Config;

public class EffectConfig
{
	public string EffectName;

	public string EffectPath;

	public void Parse(XmlNode xn)
	{
		EffectName = xn.Attributes["name"].Value;
		EffectPath = xn.Attributes["url"].Value;
	}
}
