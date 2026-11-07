using System.Collections.Generic;
using Assets.Sources.Framework;
using Entitas;
using SSJJBase.Logger;
using UnityEngine;
using cakeslice;

namespace Assets.Sources.Modules.BattleRoom;

public class LoadOutlineOnCameraSystem : ReactiveSystem<BattleRoomEntity>, IPlaybackSystem
{
	private WorldCameraContext _worldCameraContext;

	public LoadOutlineOnCameraSystem(Contexts contexts)
		: base((IContext<BattleRoomEntity>)contexts.battleRoom)
	{
		Activate();
		_worldCameraContext = contexts.worldCamera;
	}

	protected override ICollector<BattleRoomEntity> GetTrigger(IContext<BattleRoomEntity> context)
	{
		return context.CreateCollector(BattleRoomMatcher.AnyOf(BattleRoomMatcher.Outline, BattleRoomMatcher.SeeAllPlayer).AddedOrRemoved());
	}

	protected override bool Filter(BattleRoomEntity entity)
	{
		return true;
	}

	protected override void Execute(List<BattleRoomEntity> entities)
	{
		bool flag = false;
		foreach (BattleRoomEntity entity in entities)
		{
			if (entity.isOutline || entity.isSeeAllPlayer)
			{
				flag = true;
				break;
			}
		}
		Camera mainCamera = _worldCameraContext.unityObjects.mainCamera;
		if (mainCamera == null)
		{
			this.LogError("MainCamera is Null when draw outline");
			return;
		}
		OutlineEffect outlineEffect = mainCamera.gameObject.GetComponent<OutlineEffect>();
		if (flag)
		{
			if (outlineEffect == null)
			{
				outlineEffect = mainCamera.gameObject.AddComponent<OutlineEffect>();
			}
			outlineEffect.additiveRendering = true;
		}
		else if (outlineEffect != null)
		{
			Object.Destroy(outlineEffect);
		}
	}

	public void OnPlayback()
	{
		Execute();
	}
}
