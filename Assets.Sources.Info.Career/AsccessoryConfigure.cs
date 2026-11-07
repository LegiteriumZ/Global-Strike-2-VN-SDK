using System.Xml;
using SSJJAsset.AssetLoader.Xml;

namespace Assets.Sources.Info.Career;

public class AsccessoryConfigure : AbstractXmlAsset
{
	public string name;

	public bool isView;

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		ReadXmlActionData(text);
	}

	private void ReadXmlActionData(string data)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(data);
		foreach (XmlElement childNode in xmlDocument.SelectSingleNode("accessoryConfig").ChildNodes)
		{
			if (childNode.Name == "AccessoryInfo")
			{
				name = childNode.GetAttribute("jijiazhuangjiap1");
				isView = childNode.GetAttribute("isView") == "true";
			}
		}
	}
}
