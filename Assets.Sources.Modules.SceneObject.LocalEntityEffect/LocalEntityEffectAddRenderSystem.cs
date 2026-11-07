using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.LocalEntityEffect;

public class LocalEntityEffectAddRenderSystem : ReactiveSystem<SceneObjectEntity>, IPlaybackSystem
{
	public LocalEntityEffectAddRenderSystem(Contexts contexts)
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
		if (entity.hasLocalEntityEffect && entity.hasUnityObjects && !entity.isDestroy)
		{
			return !entity.hasLocalEntityEffectRender;
		}
		return false;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			if (entity.hasLocalEntityEffect)
			{
				Type renderType = entity.localEntityEffect.RenderType;
				if (renderType != null)
				{
					ILocalEntityEffectRender localEntityEffectRender = (ILocalEntityEffectRender)Activator.CreateInstance(renderType);
					localEntityEffectRender.Init(entity, entity.unityObjects.LoadResults[0].GameObject);
					entity.AddLocalEntityEffectRender(localEntityEffectRender);
				}
			}
		}
	}
}
