using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.CameraEffect;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.CameraEntity;

public class CameraEntityEffectAddRenderSystem : ReactiveSystem<SceneObjectEntity>, IPlaybackSystem
{
	private SceneObjectContext _sceneObjectContext;

	public CameraEntityEffectAddRenderSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
		_sceneObjectContext = contexts.sceneObject;
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
		if (entity.hasCameraEffect && entity.hasUnityObjects && !entity.isDestroy)
		{
			return !entity.hasCameraEffectRender;
		}
		return false;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			Type renderType = entity.cameraEffect.EffectInfo.GetRenderType();
			if (renderType != null)
			{
				ICameraEffectRender cameraEffectRender = (ICameraEffectRender)Activator.CreateInstance(renderType);
				SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(entity.cameraEffect.CameraEntityId);
				if (entityWithEntityId != null)
				{
					cameraEffectRender.Init(entityWithEntityId, entity.unityObjects.LoadResults[0].GameObject);
					entity.AddCameraEffectRender(cameraEffectRender);
				}
			}
		}
	}
}
