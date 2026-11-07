using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Assets.Sources.Info.EffectParser;

public class ParticleEffectParser : AbstractEffectParser
{
	public Dictionary<string, ParticleEffect> PrefabNames = new Dictionary<string, ParticleEffect>();

	public ParticleEffectParser(string _name)
		: base(_name)
	{
	}

	public static bool IsNode(XmlNode node)
	{
		foreach (XmlNode item in node)
		{
			if (item.Name.Equals("particleeffect"))
			{
				return true;
			}
		}
		return false;
	}

	public override void ParseFromXmlNode(XmlNode node)
	{
		foreach (XmlNode item in node)
		{
			ParticleEffect particleEffect = new ParticleEffect();
			if (node.Attributes["visiblestate"] != null)
			{
				string[] array = node.Attributes["visiblestate"].Value.Split(',');
				for (int i = 0; i < array.Length; i++)
				{
					particleEffect.VisibleState += uint.Parse(array[i]) * (uint)Mathf.Pow(100f, i);
				}
			}
			if (node.Attributes["scaleX"] != null)
			{
				particleEffect.ParticleScaleX = float.Parse(node.Attributes["scaleX"].Value);
			}
			if (node.Attributes["scaleY"] != null)
			{
				particleEffect.ParticleScaleY = float.Parse(node.Attributes["scaleY"].Value);
			}
			if (node.Attributes["scaleZ"] != null)
			{
				particleEffect.ParticleScaleZ = float.Parse(node.Attributes["scaleZ"].Value);
			}
			if (node.Attributes["animType"] != null)
			{
				string value = node.Attributes["animType"].Value;
				particleEffect.AnimId = int.Parse(value);
			}
			if (node.Attributes["remainTime"] != null)
			{
				string value2 = node.Attributes["remainTime"].Value;
				particleEffect.StartTime = int.Parse(value2);
			}
			if (node.Attributes["finishTime"] != null)
			{
				string value3 = node.Attributes["finishTime"].Value;
				particleEffect.FinishTime = int.Parse(value3);
			}
			if (node.Attributes["visibleType"] != null)
			{
				string value4 = node.Attributes["visibleType"].Value;
				particleEffect.VisibleType = int.Parse(value4);
			}
			if (node.Attributes["animType"] != null)
			{
				string value5 = node.Attributes["animType"].Value;
				particleEffect.AnimId = int.Parse(value5);
			}
			if (node.Attributes["playerInfoStauts"] != null)
			{
				string value6 = node.Attributes["playerInfoStauts"].Value;
				particleEffect.PlayerInfoStatusId = int.Parse(value6);
			}
			if (node.Attributes["visible"] != null)
			{
				string value7 = node.Attributes["visible"].Value;
				particleEffect.PlayerInfoVisible = int.Parse(value7) != 0;
			}
			if (item.Name.Equals("particleeffect") && item.Attributes["name"] != null)
			{
				string key = item.Attributes["name"].Value.Replace(".uf3d", "");
				PrefabNames.Add(key, particleEffect);
			}
		}
	}
}
