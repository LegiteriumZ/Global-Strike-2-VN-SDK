using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Info.Effect.PlayerHpBar;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.PlayerHpBar;

public class PlayerHpBarAddRenderSystem : ReactiveSystem<SceneObjectEntity>, IPlaybackSystem
{
	private PlayerEntity _targetPlayer;

	public PlayerHpBarAddRenderSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
		Activate();
	}

	public void OnPlayback()
	{
		Execute();
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.UnityObjects.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		if (entity.hasPlayerHpBar && entity.hasUnityObjects)
		{
			return !entity.isDestroy;
		}
		return false;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			if (entity.hasPlayerHpBar && UiIEventCondition.Cid2PlayerEntity.TryGetValue(entity.playerHpBar.Cid, out _targetPlayer) && _targetPlayer != null && _targetPlayer.hasBasicInfo)
			{
				entity.playerHpBar.HpBarObj = entity.unityObjects.LoadResults[0].GameObject;
				PlayerHpBarRender playerHpBarRender = new PlayerHpBarRender();
				playerHpBarRender.Init(_targetPlayer, entity.playerHpBar.HpBarObj);
				entity.AddPlayerHpBarRender(playerHpBarRender);
			}
		}
	}
}
