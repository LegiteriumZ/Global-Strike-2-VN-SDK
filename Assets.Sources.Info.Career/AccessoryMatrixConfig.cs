using System.Collections.Generic;
using System.Xml;
using SSJJAsset.AssetLoader.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Info.Career;

public class AccessoryMatrixConfig : AbstractXmlAsset
{
	public class AccessoryMatrix
	{
		public string Name;

		public string Joint;

		public string[] Data;
	}

	public Dictionary<string, AccessoryMatrix> AccessoryMatrixDictionary = new Dictionary<string, AccessoryMatrix>();

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		foreach (XmlElement childNode in xmlDocument.FirstChild.ChildNodes)
		{
			if (childNode.LocalName == "matrix")
			{
				AccessoryMatrix accessoryMatrix = new AccessoryMatrix();
				if (childNode.HasAttribute("name"))
				{
					accessoryMatrix.Name = childNode.GetAttribute("name");
				}
				if (childNode.HasAttribute("joint"))
				{
					accessoryMatrix.Joint = childNode.GetAttribute("joint");
				}
				accessoryMatrix.Data = childNode.InnerText.Split(" ");
				if (!AccessoryMatrixDictionary.ContainsKey(accessoryMatrix.Name))
				{
					AccessoryMatrixDictionary.Add(accessoryMatrix.Name, accessoryMatrix);
				}
			}
		}
	}
}
