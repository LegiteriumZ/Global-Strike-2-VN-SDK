using System;
using System.Xml;
using SSJJAsset.AssetLoader.Xml;
using UnityEngine;

namespace Assets.Sources.Info.ThirdWeaponAnim;

public class PreGeometryInfo : AbstractXmlAsset
{
	public Vector3 Pos;

	public float Radius;

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		XmlElement documentElement = xmlDocument.DocumentElement;
		float x = Convert.ToSingle(documentElement.GetAttribute("x"));
		float y = Convert.ToSingle(documentElement.GetAttribute("y"));
		float z = Convert.ToSingle(documentElement.GetAttribute("z"));
		float radius = Convert.ToSingle(documentElement.GetAttribute("r"));
		Pos = new Vector3(x, y, z);
		Radius = radius;
	}
}
