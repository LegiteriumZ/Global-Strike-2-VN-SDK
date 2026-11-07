using System.Xml;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using SSJJAsset.AssetLoader.Xml;

namespace Assets.Sources.XmlAsset;

public class SounfConfigXmlAsset : AbstractXmlAsset
{
	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		if (!xmlDocument.FirstChild.HasChildNodes)
		{
			return;
		}
		foreach (object childNode in xmlDocument.FirstChild.ChildNodes)
		{
			if (childNode != null)
			{
				SoundConfigData soundConfigData = new SoundConfigData();
				soundConfigData.Parse(childNode as XmlNode);
				ParticleManager.Instance().AddSoundData(soundConfigData);
			}
		}
	}

	public void ParseXmlImmediatory(string text)
	{
		ParseXml(text);
	}
}
