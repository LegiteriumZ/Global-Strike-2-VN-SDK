using System.Collections.Generic;
using System.Xml;

namespace Assets.Sources.Info.EffectParser;

public class WeaponDissolutionParser : AbstractEffectParser
{
	public string[] meshName;

	public int[] visiblestates;

	public bool[] specialModeVisibles;

	public bool[] specialModes;

	public float time;

	public string maskTexPath;

	public WeaponDissolutionParser(string name)
		: base(name)
	{
	}

	public static bool IsNode(XmlNode node)
	{
		if (node.Name == "weapon_dissolution")
		{
			return true;
		}
		return false;
	}

	public override void ParseFromXmlNode(XmlNode node)
	{
		List<string> list = new List<string>();
		List<int> list2 = new List<int>();
		List<bool> list3 = new List<bool>();
		List<bool> list4 = new List<bool>();
		time = int.Parse(node.Attributes["time"].Value);
		if (node.Attributes["maskTexPath"] != null)
		{
			maskTexPath = node.Attributes["maskTexPath"].Value;
		}
		for (int i = 0; i < node.ChildNodes.Count; i++)
		{
			XmlNode xmlNode = node.ChildNodes[i];
			if (xmlNode.Attributes != null && xmlNode.Name.Equals("effect"))
			{
				list.Add(xmlNode.Attributes["meshname"].Value);
				list2.Add(int.Parse(xmlNode.Attributes["visiblestate"].Value));
				if (xmlNode.Attributes["specialMode"] != null)
				{
					list3.Add(item: true);
					list4.Add(xmlNode.Attributes["specialMode"].Value == "1");
				}
				else
				{
					list3.Add(item: false);
					list4.Add(item: false);
				}
			}
		}
		meshName = list.ToArray();
		visiblestates = list2.ToArray();
		specialModeVisibles = list3.ToArray();
		specialModes = list4.ToArray();
	}

	public int[] GetVisiblestates(string mn)
	{
		string[] array = mn.Split(',');
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = int.Parse(array[i]);
		}
		return array2;
	}
}
