using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;
using NetData;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.NewNpc;

public class NpcTransformPlaybackSystem : IPlaybackSystem
{
	private TimeComponent _time;

	private readonly IGroup<SceneObjectEntity> _group;

	public NpcTransformPlaybackSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcBasicInfo));
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			NpcEntityData current2 = item.npcBasicInfo.Current;
			NpcEntityData npcEntityData = item.npcBasicInfo.Next;
			if (current2 != null)
			{
				if (npcEntityData == null)
				{
					npcEntityData = current2;
				}
				if (item.hasPosition)
				{
					item.position.Origin = Vector3.Lerp(new Vector3(current2.X, current2.Y, current2.Z), new Vector3(npcEntityData.X, npcEntityData.Y, npcEntityData.Z), _time.FrameInterpolation);
				}
				if (item.hasRotation)
				{
					item.rotation.EulerAngles = new Vector3(0f, current2.Pitch, current2.Yaw);
				}
				if (item.hasScale)
				{
					item.scale.Scale = Vector3.Lerp(new Vector3(current2.Scale, current2.Scale, current2.Scale), new Vector3(npcEntityData.Scale, npcEntityData.Scale, npcEntityData.Scale), _time.FrameInterpolation);
				}
			}
		}
	}
}
