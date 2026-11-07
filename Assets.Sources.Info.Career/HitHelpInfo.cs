using System;
using System.Collections.Generic;
using System.Xml;
using SSJJAsset.AssetLoader.Xml;
using physics.data;
using share;

namespace Assets.Sources.Info.Career;

public class HitHelpInfo : AbstractXmlAsset
{
	public List<HitBox> HitBoxList = new List<HitBox>();

	public HitPreliminaryGeo HitPreliminaryGeo = new HitPreliminaryGeo();

	protected override void ParseXml(string xml)
	{
		base.ParseXml(xml);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		foreach (XmlNode childNode in xmlDocument.FirstChild.ChildNodes)
		{
			if (childNode.Name.Equals("hitbox", StringComparison.OrdinalIgnoreCase))
			{
				HitBoxList.Add(ParseHitbox(childNode));
			}
			else if (childNode.Name.Equals("preliminarygeo", StringComparison.OrdinalIgnoreCase))
			{
				HitPreliminaryGeo = ParseHitPreliminaryGeo(childNode);
			}
		}
	}

	private static HitBox ParseHitbox(XmlNode node)
	{
		HitBox hitBox = new HitBox();
		foreach (XmlNode childNode in node.ChildNodes)
		{
			if (childNode.Name == "name")
			{
				hitBox.SetJointName(childNode.FirstChild.Value);
			}
			else if (childNode.Name == "pos")
			{
				hitBox.SetOrg(ParsePos(childNode));
			}
			else if (childNode.Name == "size")
			{
				ParseSize(hitBox, childNode);
			}
		}
		return hitBox;
	}

	private static HitPreliminaryGeo ParseHitPreliminaryGeo(XmlNode node)
	{
		HitPreliminaryGeo hitPreliminaryGeo = new HitPreliminaryGeo();
		foreach (XmlNode childNode in node.ChildNodes)
		{
			if (childNode.Name == "pos")
			{
				hitPreliminaryGeo.pos = ParsePos(childNode);
			}
			else if (childNode.Name == "size")
			{
				hitPreliminaryGeo.r = int.Parse(childNode.FirstChild.FirstChild.Value);
			}
		}
		return hitPreliminaryGeo;
	}

	private static Vector3D ParsePos(XmlNode node)
	{
		Vector3D vector3D = new Vector3D();
		foreach (XmlNode childNode in node.ChildNodes)
		{
			if (childNode.Name == "x")
			{
				vector3D.x = float.Parse(childNode.FirstChild.Value);
			}
			else if (childNode.Name == "y")
			{
				vector3D.y = float.Parse(childNode.FirstChild.Value);
			}
			else if (childNode.Name == "z")
			{
				vector3D.z = float.Parse(childNode.FirstChild.Value);
			}
		}
		return vector3D;
	}

	private static void ParseSize(HitBox box, XmlNode node)
	{
		foreach (XmlNode childNode in node.ChildNodes)
		{
			if (childNode.Name == "sizeX")
			{
				box.sizeX = float.Parse(childNode.FirstChild.Value);
			}
			else if (childNode.Name == "sizeY")
			{
				box.sizeY = float.Parse(childNode.FirstChild.Value);
			}
			else if (childNode.Name == "sizeZ")
			{
				box.sizeZ = float.Parse(childNode.FirstChild.Value);
			}
		}
	}
}
