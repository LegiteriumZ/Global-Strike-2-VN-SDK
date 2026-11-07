using System.Collections.Generic;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using SSJJAsset.AssetLoader.Xml;

namespace Assets.Sources.XmlAsset;

public class EffectXmlAsset : AbstractXmlAsset
{
	public Dictionary<string, EffectConfig> Dict { get; private set; }

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		Dict = ParticleManager.ParseEffectXml(text);
	}

	public void ParseXmlImmediatory(string text)
	{
		ParseXml(text);
	}
}
