using System.Collections.Generic;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using SSJJAsset.AssetLoader.Xml;

namespace Assets.Sources.XmlAsset;

public class ParticleXmlAsset : AbstractXmlAsset
{
	public List<BaseEffectData> List { get; private set; }

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		List = ParticleManager.ParseParticleXml(text);
	}

	public void ParseXmlImmediatory(string text)
	{
		ParseXml(text);
	}
}
