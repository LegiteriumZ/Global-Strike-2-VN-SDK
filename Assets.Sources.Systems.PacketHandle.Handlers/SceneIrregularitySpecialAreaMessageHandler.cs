using System.Collections.Generic;
using NetData;
using physics.data;
using physics.trace;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class SceneIrregularitySpecialAreaMessageHandler : ApcPacketHandler<SceneIrregularAreaListData>
{
	public SceneIrregularitySpecialAreaMessageHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 241;
	}

	public override void Handle(SceneIrregularAreaListData data)
	{
		if (!(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine.GetWorld() is WorldBase worldBase))
		{
			return;
		}
		IList<SceneIrregularitySpecialArea> list = worldBase.GetClipMap().GetSceneIrregularitySpecialAreaList() ?? new List<SceneIrregularitySpecialArea>();
		foreach (SceneIrregularArea item in data.List)
		{
			SceneIrregularitySpecialArea sceneIrregularitySpecialArea = new SceneIrregularitySpecialArea();
			sceneIrregularitySpecialArea.SetAreaHeight(item.AreaHeight);
			sceneIrregularitySpecialArea.SetJumpVelocity(item.JumpVelocity);
			sceneIrregularitySpecialArea.SetSpecialAreaType(item.SpecialAreaType);
			sceneIrregularitySpecialArea.SetSpeedScale(item.SpeedScale);
			float[][] array = new float[item.Points.Count][];
			for (int i = 0; i < item.Points.Count; i++)
			{
				array[i] = new float[item.Points[i].Data.Count];
				for (int j = 0; j < item.Points[i].Data.Count; j++)
				{
					array[i][j] = item.Points[i].Data[j];
				}
			}
			sceneIrregularitySpecialArea.SetPoints(array);
			list.Add(sceneIrregularitySpecialArea);
		}
	}
}
