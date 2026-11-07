using System.Collections.Generic;
using System.Xml;

namespace Assets.Sources.Info.EffectParser;

public class ModelTextureSheetParser : AbstractEffectParser
{
	public int speed;

	public int minmap;

	public Dictionary<int, string[]> texturesDict = new Dictionary<int, string[]>();

	public string[] textures;

	public bool isLoop;

	public ModelTextureSheetParser(string _name)
		: base(_name)
	{
		minmap = 1;
		isLoop = true;
	}

	public static bool IsNode(XmlNode node)
	{
		if (node.Name == "uv2effecthuxi" || node.Name == "uv2effectlightmap" || node.Name == "uv2effecthuxiplayer" || node.Name == "uv2effectliuguang")
		{
			return false;
		}
		foreach (XmlNode item in node)
		{
			if (item.Name.Equals("effecttime"))
			{
				return true;
			}
		}
		return false;
	}

	public override void ParseFromXmlNode(XmlNode node)
	{
		Dictionary<int, Dictionary<int, string>> dictionary = new Dictionary<int, Dictionary<int, string>>();
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		foreach (XmlNode item in node)
		{
			if (item.Name.Equals("effecttime"))
			{
				speed = int.Parse(item.Attributes["speed"].Value);
				if (item.Attributes["isEffectRepeat"] != null)
				{
					isLoop = bool.Parse(item.Attributes["isEffectRepeat"].Value);
				}
				if (item.Attributes["minmap"] != null && !int.TryParse(item.Attributes["minmap"].Value, out minmap))
				{
					minmap = (bool.Parse(item.Attributes["minmap"].Value) ? 1 : 0);
				}
			}
			else if (item.Name.Equals("effectTexture"))
			{
				int key = 0;
				string value = item.Attributes["name"].Value.Replace(".atf", ".png");
				if (item.Attributes["group"] != null)
				{
					key = int.Parse(item.Attributes["group"].Value);
				}
				int num = (dictionary2.ContainsKey(key) ? dictionary2[key] : 0);
				if (!dictionary.ContainsKey(key))
				{
					dictionary[key] = new Dictionary<int, string>();
				}
				if (item.Attributes["index"] != null)
				{
					num = int.Parse(item.Attributes["index"].Value);
					dictionary[key][num] = value;
				}
				else
				{
					dictionary[key][num++] = value;
				}
				dictionary2[key] = num;
			}
		}
		foreach (KeyValuePair<int, Dictionary<int, string>> item2 in dictionary)
		{
			texturesDict[item2.Key] = new string[item2.Value.Count];
			foreach (KeyValuePair<int, string> item3 in item2.Value)
			{
				texturesDict[item2.Key][item3.Key] = item3.Value;
			}
		}
		textures = texturesDict[0];
	}
}
