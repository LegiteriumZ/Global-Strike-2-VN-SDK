using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class SceneObjectEffectConfig
{
	public string EffectName;

	public void Parse(XmlNode xn)
	{
		EffectName = xn.Read("name");
	}
}
