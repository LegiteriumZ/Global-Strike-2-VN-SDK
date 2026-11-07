using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.FirstPlayerEffect;

public class FirstPlayerEffectAddRenderSystem : ReactiveSystem<SceneObjectEntity>, IPlaybackSystem
{
	private PlayerContext _playerContext;

	public FirstPlayerEffectAddRenderSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
		_playerContext = contexts.player;
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
		if (entity.hasFirstPlayerEffect && entity.hasUnityObjects)
		{
			return !entity.isDestroy;
		}
		return false;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			Type firstRenderType = entity.firstPlayerEffect.EffectInfo.GetFirstRenderType();
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(entity.firstPlayerEffect.TargetId);
			if (firstRenderType != null && entityWithEntityId != null)
			{
				IFirstPlayerEffectRender firstPlayerEffectRender = (IFirstPlayerEffectRender)Activator.CreateInstance(firstRenderType);
				firstPlayerEffectRender.Init(entityWithEntityId, entity.unityObjects.LoadResults[0].GameObject);
				entity.AddFirstPlayerEffectRender(firstPlayerEffectRender);
			}
		}
	}
}
