using System;
using System.Collections.Generic;
using System.Xml;

namespace Assets.Sources.Info.EffectParser;

public class ModelU3dParser : AbstractEffectParser
{
	protected float posX;

	protected float posY;

	protected float posZ;

	public Dictionary<string, ParticleEffect> PrefabNames = new Dictionary<string, ParticleEffect>();

	public static bool IsNode(XmlNode node)
	{
		if (node.Name == "u3d")
		{
			return true;
		}
		return false;
	}

	public override void ParseFromXmlNode(XmlNode node)
	{
		foreach (XmlNode item in node)
		{
			if (item.Name.Equals("pos"))
			{
				posX = Convert.ToSingle(item.Attributes["posX"].Value);
				posY = Convert.ToSingle(item.Attributes["posY"].Value);
				posZ = Convert.ToSingle(item.Attributes["posZ"].Value);
			}
			ParticleEffect value = new ParticleEffect();
			if (item.Name.Equals("u3dParticle") && item.Attributes["name"] != null)
			{
				string key = item.Attributes["name"].Value.Replace(".uf3d", "");
				PrefabNames.Add(key, value);
			}
		}
	}

	public ModelU3dParser(string _name)
		: base(_name)
	{
	}
}
