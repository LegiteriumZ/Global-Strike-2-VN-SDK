using System.Collections.Generic;
using System.Xml;

namespace Assets.Sources.Info.EffectParser;

public class ModelFireTextureSheetParser : ModelTextureSheetParser
{
	protected int _specialModeIndexOffect;

	protected bool _isRoate;

	protected int _fireLength;

	protected int _indexLength;

	protected int _specialFireLength;

	protected int _specialIndexLength;

	protected bool specialMode;

	public void InitParams(string weaponName)
	{
		_specialModeIndexOffect = 0;
		switch (weaponName.ToUpper())
		{
		case "AWM_HERO":
		case "AWM_HERO1":
		case "AWM_HERO_LITE":
			_fireLength = 39;
			_indexLength = 1;
			break;
		case "SANDAN_HERO":
		case "SANDAN_HERO1":
			_specialModeIndexOffect = 2;
			_fireLength = 4;
			_indexLength = 1;
			_specialFireLength = 2;
			_specialIndexLength = 1;
			break;
		case "AK47_HERO1":
		case "AK47_HERO":
		case "AK_HERO_ALPHA":
			_fireLength = 1;
			_indexLength = 4;
			break;
		case "RAGE":
			_fireLength = 3;
			_indexLength = 1;
			break;
		case "M4A1_HERO":
		case "M4A1_HERO1":
		case "M4A1_HERO_ALPHA":
			_fireLength = 1;
			_indexLength = 5;
			break;
		case "GHOST_TWINS":
		case "GHOST_TWINS1":
			_fireLength = 1;
			_indexLength = 4;
			break;
		case "M249_ROCKET":
			_fireLength = 1;
			_indexLength = 6;
			break;
		case "SHOTGUN_3_BARREL":
			_fireLength = 1;
			_indexLength = 4;
			break;
		case "GHOST_RIDER":
		case "GHOST_RIDER1":
			_fireLength = 7;
			_indexLength = 1;
			break;
		case "M32_A":
			_fireLength = 1;
			_indexLength = 5;
			break;
		default:
			_isRoate = true;
			_fireLength = 4;
			_indexLength = 3;
			break;
		}
	}

	public ModelFireTextureSheetParser(string _name)
		: base(_name)
	{
	}

	public static bool IsFireNode(XmlNode node)
	{
		if (ModelTextureSheetParser.IsNode(node))
		{
			return node.Name.ToLower().Contains("fire");
		}
		return false;
	}

	public override void ParseFromXmlNode(XmlNode node)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		foreach (XmlNode item in node)
		{
			if (item.Name.Equals("effecttime"))
			{
				if (item.Attributes["minmap"] != null && !int.TryParse(item.Attributes["minmap"].Value, out minmap))
				{
					minmap = (bool.Parse(item.Attributes["minmap"].Value) ? 1 : 0);
				}
			}
			else if (item.Name.Equals("effectTexture"))
			{
				string value = item.Attributes["name"].Value.Replace(".atf", ".png");
				int key = int.Parse(item.Attributes["index"].Value);
				dictionary[key] = value;
			}
		}
		textures = new string[dictionary.Count];
		foreach (KeyValuePair<int, string> item2 in dictionary)
		{
			textures[item2.Key] = item2.Value;
		}
	}
}
