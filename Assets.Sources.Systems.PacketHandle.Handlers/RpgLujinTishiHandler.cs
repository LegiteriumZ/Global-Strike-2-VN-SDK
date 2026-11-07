using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Rpg;
using NetData;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgLujinTishiHandler : ApcPacketHandler<ZhiShiLuJinData>
{
	private RpgPathGuideComponent guideComponent;

	public RpgLujinTishiHandler(Contexts contexts)
	{
		guideComponent = Contexts.sharedInstance.gameRule.rpgPathGuide;
	}

	public override int MethodId()
	{
		return 1212;
	}

	public override void Handle(ZhiShiLuJinData data)
	{
		ZhishiData zhishiData = new ZhishiData();
		zhishiData.Id = data.Id;
		zhishiData.Kind = data.Kind;
		zhishiData.PointList = new List<Vector3>();
		foreach (Vector3DData point in data.PointList)
		{
			zhishiData.PointList.Add(VectorTypeConverter.Net2Unity(point));
		}
		if (data.Kind == 4)
		{
			guideComponent.minimapPaths[data.Id] = zhishiData;
		}
		else
		{
			guideComponent.scenePaths[data.Id] = zhishiData;
		}
		guideComponent.minimapPathChanged = true;
	}
}
