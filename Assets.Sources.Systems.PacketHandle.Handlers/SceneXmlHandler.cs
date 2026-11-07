using System.Collections.Generic;
using System.Xml;
using Assets.Sources.Components.SceneObject;
using NetData;
using SSJJBase.Utility;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class SceneXmlHandler : ApcPacketHandler<SceneXMLFile>
{
	public override int MethodId()
	{
		return 119;
	}

	public override void Handle(SceneXMLFile data)
	{
		_ = data.IdRemapTable;
		string xml = ZipUtility.Decompress(data.Data);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("DynamicEntity");
		BattleRoomEntity battleRoomEntity = Contexts.sharedInstance.battleRoom.CreateEntity();
		battleRoomEntity.AddSceneXmlFile(new Dictionary<int, SceneDynamicEntity>());
		foreach (XmlNode item in elementsByTagName)
		{
			int num = 0;
			foreach (XmlAttribute attribute in item.Attributes)
			{
				if (attribute.Name == "Id")
				{
					num = int.Parse(attribute.Value);
					break;
				}
			}
			XmlNode xmlNode2 = item.SelectSingleNode("Shape");
			SceneDynamicEntityShape sceneDynamicEntityShape = new SceneDynamicEntityShape();
			foreach (XmlAttribute attribute2 in xmlNode2.Attributes)
			{
				if (attribute2.Name == "Name")
				{
					sceneDynamicEntityShape.Name = attribute2.Value;
					break;
				}
			}
			foreach (XmlAttribute attribute3 in xmlNode2.SelectSingleNode("Bounds").Attributes)
			{
				if (attribute3.Name == "X")
				{
					sceneDynamicEntityShape.BoundsX = float.Parse(attribute3.Value);
				}
				if (attribute3.Name == "Y")
				{
					sceneDynamicEntityShape.BoundsY = float.Parse(attribute3.Value);
				}
				if (attribute3.Name == "Z")
				{
					sceneDynamicEntityShape.BoundsZ = float.Parse(attribute3.Value);
				}
			}
			SceneDynamicEntity value = new SceneDynamicEntity
			{
				Id = num,
				Shape = sceneDynamicEntityShape
			};
			battleRoomEntity.sceneXmlFile.DynamicEntityDictionary.Add(num, value);
		}
	}
}
