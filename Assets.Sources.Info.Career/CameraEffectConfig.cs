using System;
using System.Xml;
using Assets.Sources.Particle;
using SSJJAsset.AssetLoader.Xml;

namespace Assets.Sources.Info.Career;

public class CameraEffectConfig : AbstractXmlAsset
{
	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		foreach (XmlElement childNode in xmlDocument.ChildNodes)
		{
			foreach (XmlElement childNode2 in childNode.ChildNodes)
			{
				CameraEffectConfigItem cameraEffectConfigItem = null;
				foreach (XmlElement childNode3 in childNode2.ChildNodes)
				{
					if (childNode3.LocalName == "effect")
					{
						cameraEffectConfigItem = new CameraEffectConfigItem();
						if (childNode3.HasAttribute("name"))
						{
							cameraEffectConfigItem.EffectName = childNode3.GetAttribute("name");
						}
						if (childNode3.HasAttribute("time"))
						{
							cameraEffectConfigItem.Time = Convert.ToInt32(childNode3.GetAttribute("time"));
						}
					}
					if (cameraEffectConfigItem != null && childNode3.LocalName == "path")
					{
						CameraEffectPath cameraEffectPath = new CameraEffectPath();
						if (childNode3.HasAttribute("x"))
						{
							cameraEffectPath.X = Convert.ToDouble(childNode3.GetAttribute("x"));
						}
						if (childNode3.HasAttribute("y"))
						{
							cameraEffectPath.Y = Convert.ToDouble(childNode3.GetAttribute("y"));
						}
						if (childNode3.HasAttribute("z"))
						{
							cameraEffectPath.Z = Convert.ToDouble(childNode3.GetAttribute("z"));
						}
						if (childNode3.HasAttribute("rotationx"))
						{
							cameraEffectPath.RotationX = Convert.ToDouble(childNode3.GetAttribute("rotationx"));
						}
						if (childNode3.HasAttribute("rotationy"))
						{
							cameraEffectPath.RotationY = Convert.ToDouble(childNode3.GetAttribute("rotationy"));
						}
						if (childNode3.HasAttribute("rotationz"))
						{
							cameraEffectPath.RotationZ = Convert.ToDouble(childNode3.GetAttribute("rotationz"));
						}
						if (childNode3.HasAttribute("time"))
						{
							cameraEffectPath.Time = Convert.ToInt32(childNode3.GetAttribute("time"));
						}
						cameraEffectConfigItem.PathList.Add(cameraEffectPath);
					}
				}
				if (cameraEffectConfigItem != null)
				{
					ParticleManager.Instance().AddCameraEffect(cameraEffectConfigItem);
				}
			}
		}
	}
}
