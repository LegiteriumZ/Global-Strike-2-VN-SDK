using System;
using System.Collections.Generic;
using Assets.Scripts.Effect.Level;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Framework;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using Assets.Sources.Utils;
using Entitas;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect;

public class PlayerStateEffectAddRenderSystem : ReactiveSystem<SceneObjectEntity>, IPlaybackSystem
{
	private PlayerContext _playerContext;

	public PlayerStateEffectAddRenderSystem(Contexts contexts)
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
		if (entity.hasPlayerEffect && entity.hasUnityObjects)
		{
			return !entity.isDestroy;
		}
		return false;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			Type thirdRenderType = entity.playerEffect.EffectInfo.GetThirdRenderType();
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(entity.playerEffect.TargetId);
			if (thirdRenderType != null && entityWithEntityId != null)
			{
				GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
				LodUtility.AddInstanceLod(gameObject);
				ParticleEffectUtility.InitSceneParticle(gameObject, entity.unityObjects.LoadResults[0].AssetInfo.AssetName);
				IPlayerEffectRender playerEffectRender = (IPlayerEffectRender)Activator.CreateInstance(thirdRenderType);
				playerEffectRender.Init(entityWithEntityId, gameObject);
				if (entity.hasPlayerEffectRender)
				{
					this.LogErrorFormat("{0} Already HasRenderEffectRender {1}  targetPlayer {2}", entity, thirdRenderType, entityWithEntityId);
					entity.ReplacePlayerEffectRender(playerEffectRender);
				}
				else
				{
					entity.AddPlayerEffectRender(playerEffectRender);
				}
			}
			else
			{
				DefaultPlayerNoEffectRender newRender = new DefaultPlayerNoEffectRender();
				entity.AddPlayerEffectRender(newRender);
			}
		}
	}
}
