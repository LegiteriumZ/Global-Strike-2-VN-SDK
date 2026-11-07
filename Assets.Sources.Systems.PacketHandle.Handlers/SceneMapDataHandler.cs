using System.Collections.Generic;
using Assets.Sources.Components.StandAlone;
using NetData;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class SceneMapDataHandler : ApcPacketHandler<MapPositionNodeListData>
{
	public SceneMapDataHandler(Contexts contexts)
	{
		if (!contexts.worldCamera.hasSceneCameraInfo)
		{
			contexts.worldCamera.SetSceneCameraInfo(newPlayerCameraNotMove: false, Vector3.zero, 0f, 0f);
		}
		contexts.worldCamera.SetScenemapPosition(null, new Dictionary<string, List<Vector3DData>>());
	}

	public override int MethodId()
	{
		return 216;
	}

	public override void Handle(MapPositionNodeListData data)
	{
		ScenemapPositionComponent scenemapPosition = Contexts.sharedInstance.worldCamera.scenemapPosition;
		scenemapPosition.MapPositionData = data;
		scenemapPosition.MapDict.Clear();
		foreach (MapPositionNodeData item in data.DataNode)
		{
			scenemapPosition.MapDict[item.Name] = item.Pos;
		}
	}
}
