using System.Collections.Generic;
using System.Xml;
using SSJJAsset.AssetLoader.Xml;
using UnityEngine;

namespace Assets.Sources.Info.Res;

public class PlayerVolumeConfig : AbstractXmlAsset
{
	public struct ConfigData
	{
		public string Career;

		public string Root;

		public Vector3 Position;

		public Vector3 Rotation;

		public Vector3 Scale;
	}

	private Dictionary<string, ConfigData> _dictionary = new Dictionary<string, ConfigData>();

	public bool TryGet(string key, out ConfigData data)
	{
		return _dictionary.TryGetValue(key, out data);
	}

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		for (XmlNode xmlNode = xmlDocument.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			if (xmlNode.HasChildNodes)
			{
				foreach (XmlElement childNode in xmlNode.ChildNodes)
				{
					if (childNode.LocalName == "config")
					{
						ConfigData value = default(ConfigData);
						value.Career = ReadNode(childNode, "name");
						value.Root = ReadNode(childNode, "root");
						value.Position.x = ReadNode<float>(childNode, "x");
						value.Position.y = ReadNode<float>(childNode, "y");
						value.Position.z = ReadNode<float>(childNode, "z");
						value.Rotation.x = ReadNode<float>(childNode, "rotationX");
						value.Rotation.y = ReadNode<float>(childNode, "rotationY");
						value.Rotation.z = ReadNode<float>(childNode, "rotationZ");
						value.Scale.x = ReadNode<float>(childNode, "scaleX");
						value.Scale.y = ReadNode<float>(childNode, "scaleY");
						value.Scale.z = ReadNode<float>(childNode, "scaleZ");
						_dictionary[value.Career] = value;
					}
				}
			}
		}
	}
}
