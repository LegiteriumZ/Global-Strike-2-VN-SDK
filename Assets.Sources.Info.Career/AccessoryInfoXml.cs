using System.Xml;
using SSJJAnim.AnimData;
using SSJJAsset.AssetLoader.Xml;

namespace Assets.Sources.Info.Career;

public class AccessoryInfoXml : AbstractXmlAsset
{
	public AnimationArray AccessoryAnimations;

	public AnimationDesc GetAccessoryAnimation(string animName)
	{
		if (AccessoryAnimations != null)
		{
			AnimationDesc animDescStr = AccessoryAnimations.GetAnimDescStr(animName);
			if (animDescStr != null)
			{
				return animDescStr;
			}
		}
		return null;
	}

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		AccessoryAnimations = new AnimationArray();
		ReadXmlActionData(text);
	}

	private void ReadXmlActionData(string data)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(data);
		foreach (XmlElement childNode in xmlDocument.SelectSingleNode("actions").ChildNodes)
		{
			if (childNode.Name == "action")
			{
				string attribute = childNode.GetAttribute("name");
				AnimationDesc animationDesc = new AnimationDesc(int.Parse(childNode.GetAttribute("end")) - int.Parse(childNode.GetAttribute("start")) + 1, AnimationDataMapper.MappedBoolString(childNode.GetAttribute("loop")), AnimationDataMapper.MappedBoolString(childNode.GetAttribute("reverse")));
				animationDesc.EventName = attribute;
				AccessoryAnimations.AddAnimStr(attribute, animationDesc);
			}
		}
	}
}
