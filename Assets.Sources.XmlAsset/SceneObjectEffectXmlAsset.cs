using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using SSJJAsset.AssetLoader.Xml;

namespace Assets.Sources.XmlAsset;

public class SceneObjectEffectXmlAsset : AbstractXmlAsset
{
	public SceneObjectEffectConfig Config;

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		Config = ParticleManager.ParseSceneObjectEffectXml(text);
	}
}
