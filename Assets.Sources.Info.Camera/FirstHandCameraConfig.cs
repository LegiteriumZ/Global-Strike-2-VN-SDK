using System.Xml;
using SSJJAsset.AssetLoader.Xml;

namespace Assets.Sources.Info.Camera;

public class FirstHandCameraConfig : AbstractXmlAsset
{
	public XmlNode Model3D;

	public XmlNode Camera1;

	public XmlNode Camera2;

	public XmlNode Camera3;

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		Model3D = xmlDocument.SelectSingleNode("/node/matrix[@name='model3D']");
		Camera1 = xmlDocument.SelectSingleNode("/node/matrix[@name='Camera01']");
		Camera2 = xmlDocument.SelectSingleNode("/node/matrix[@name='Camera02']");
		Camera3 = xmlDocument.SelectSingleNode("/node/matrix[@name='Camera03']");
	}
}
