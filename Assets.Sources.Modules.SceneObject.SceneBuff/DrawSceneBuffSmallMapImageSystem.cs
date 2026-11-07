using Assets.Sources.Components.Common;
using Assets.Sources.Framework;
using Entitas;
using NetData;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneBuff;

public class DrawSceneBuffSmallMapImageSystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	public DrawSceneBuffSmallMapImageSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.SceneBuff);
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			if (!item.hasSmallMapImage)
			{
				item.AddComponent(13, new SmallMapImageComponent());
			}
			SceneBufEntityData data = item.sceneBuff.Data;
			item.smallMapImage.Position = new Vector3(data.X, data.Y, data.Z);
			if (item.sceneBuff.Data.BufName == "NEXT_SAFE_AREA" || item.sceneBuff.Data.BufName == "SAFE_AREA")
			{
				item.smallMapImage.RealWidth = item.sceneBuff.Data.Scale.X * 100f;
			}
		}
	}
}
