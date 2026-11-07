using System;
using NetData;
using config;
using physics;
using physics.configData;
using physics.data;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class SpecialAreaHandler : ApcPacketHandler<SceneSpecialAreaListData>
{
	public override int MethodId()
	{
		return 210;
	}

	public override void Handle(SceneSpecialAreaListData specialAreaList)
	{
		IPyClipMap clipMap = Contexts.sharedInstance.battleRoom.pyEngine.PyEngine.GetWorld().GetClipMap();
		foreach (NetData.SceneSpecialAreaData item in specialAreaList.List)
		{
			SceneSpecialArea sceneSpecialArea = new SceneSpecialArea();
			physics.configData.SceneSpecialAreaData sceneSpecialAreaData = new physics.configData.SceneSpecialAreaData();
			sceneSpecialAreaData.specialAreaType = (SpecialAreaEnum)Enum.Parse(typeof(SpecialAreaEnum), item.SpecialAreaType);
			sceneSpecialAreaData.min = new float[3] { item.MinX, item.MinY, item.MinZ };
			sceneSpecialAreaData.max = new float[3] { item.MaxX, item.MaxY, item.MaxZ };
			sceneSpecialAreaData.speedScale = item.SpeedScale;
			sceneSpecialAreaData.jumpVelocity = item.JumpVelocity;
			sceneSpecialArea.PraseConfig(sceneSpecialAreaData);
			clipMap.GetSceneSpecialAreaList().Add(sceneSpecialArea);
		}
	}
}
