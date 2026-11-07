using System.Collections.Generic;
using System.Xml;
using SSJJAsset.AssetLoader.Xml;

namespace Assets.Sources.Info.Career;

public class NpcEffectConfig : AbstractXmlAsset
{
	public Dictionary<string, NpcEffectItem> NpcParticleEffect = new Dictionary<string, NpcEffectItem>();

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		foreach (XmlElement childNode in xmlDocument.FirstChild.ChildNodes)
		{
			if (!(childNode.LocalName == "npc_particle_effect"))
			{
				continue;
			}
			int num = 0;
			string key = null;
			if (childNode.HasAttribute("visiblestate"))
			{
				string[] array = childNode.GetAttribute("visiblestate").Split(',');
				for (int i = 0; i < array.Length; i++)
				{
					int num2 = int.Parse(array[i]);
					num = ((num2 != 0) ? (num | (1 << num2 - 1)) : (num | 0x7FFFFFFF));
				}
			}
			bool resetEffect = false;
			if (((XmlElement)childNode.FirstChild).HasAttribute("resetEffect"))
			{
				resetEffect = ((XmlElement)childNode.FirstChild).GetAttribute("resetEffect") == "true";
			}
			if (((XmlElement)childNode.FirstChild).HasAttribute("name"))
			{
				key = ((XmlElement)childNode.FirstChild).GetAttribute("name").Replace(".uf3d", "");
			}
			NpcEffectItem npcEffectItem = new NpcEffectItem();
			npcEffectItem.visible = num;
			npcEffectItem.resetEffect = resetEffect;
			NpcParticleEffect.Add(key, npcEffectItem);
		}
	}
}
