using System;
using System.Collections.Generic;
using Assets.Scripts.Effect.Level;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Entitas;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneBuff;

public class SceneBuffEffectAddRenderSystem : ReactiveSystem<SceneObjectEntity>, IPlaybackSystem
{
	public SceneBuffEffectAddRenderSystem(Contexts contexts)
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
		if (entity.hasSceneBufferEffect && entity.hasUnityObjects && !entity.isDestroy)
		{
			return !entity.hasSceneBufferEffectRender;
		}
		return false;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			Type renderType = entity.sceneBufferEffect.EffectInfo.GetRenderType();
			if (renderType != null)
			{
				ISceneBuffEffectRender sceneBuffEffectRender = (ISceneBuffEffectRender)Activator.CreateInstance(renderType);
				GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
				sceneBuffEffectRender.Init(entity.sceneBufferEffect.Target, gameObject);
				entity.AddSceneBufferEffectRender(sceneBuffEffectRender);
				LodUtility.AddInstanceLod(gameObject);
				ParticleEffectUtility.InitSceneParticle(gameObject, entity.unityObjects.LoadResults[0].AssetInfo.AssetName);
			}
			else
			{
				this.LogErrorFormat("not found render type :{0}", entity);
			}
		}
	}
}
