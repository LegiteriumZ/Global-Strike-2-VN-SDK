using System;
using System.Globalization;
using System.Xml;
using UnityEngine;

namespace Assets.Sources.Info.EffectParser;

public class UvLiuGuangMaskEffectParser : AbstractEffectParser
{
	protected Vector2 speed;

	protected int blend;

	protected string liuguangAssets;

	protected string maskAssets;

	protected Color32 color;

	protected int waitTime;

	protected int hxSpeed;

	protected float _Alpha;

	protected Vector2 tiling;

	public static bool IsNode(XmlNode node)
	{
		if (node.Name == "uv2liuguangeffect")
		{
			return true;
		}
		return false;
	}

	public override void ParseFromXmlNode(XmlNode node)
	{
		foreach (XmlNode item in node)
		{
			if (item.Name.Equals("effecParameter"))
			{
				speed = SplitVector2(item.Attributes["speed"].Value);
				waitTime = int.Parse(item.Attributes["WaitTime"].Value);
				hxSpeed = int.Parse(item.Attributes["LgSpeed"].Value);
				blend = int.Parse(item.Attributes["Blend"].Value);
			}
			else if (item.Name.Equals("effectTexture"))
			{
				liuguangAssets = item.Attributes["name"].Value.Replace(".atf", ".png");
				color = getColor(item.Attributes["color"].Value);
				_Alpha = float.Parse(item.Attributes["Alpha"].Value);
			}
			else if (item.Name.Equals("maskTexture"))
			{
				maskAssets = item.Attributes["name"].Value.Replace(".atf", ".png");
			}
		}
	}

	private Color32 getColor(string colorStr)
	{
		if (colorStr.IndexOf("#") == -1)
		{
			return new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}
		colorStr = colorStr.TrimStart('#');
		byte r = byte.Parse(colorStr.Substring(0, 2), NumberStyles.HexNumber);
		byte g = byte.Parse(colorStr.Substring(2, 2), NumberStyles.HexNumber);
		byte b = byte.Parse(colorStr.Substring(4, 2), NumberStyles.HexNumber);
		return new Color32(r, g, b, byte.MaxValue);
	}

	private static Vector2 SplitVector2(string data)
	{
		string[] array = ((data.IndexOf(' ') > -1) ? data.Split(' ') : data.Split(','));
		return new Vector2(Convert.ToSingle(array[0]), Convert.ToSingle(array[1]));
	}

	public UvLiuGuangMaskEffectParser(string _name)
		: base(_name)
	{
	}
}
