using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.CameraEntity;

public class CameraEntityEffectRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _effectGroup;

	private SceneObjectContext _sceneObjectContext;

	public CameraEntityEffectRenderSystem(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
		_effectGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.CameraEffect, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.Position).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _effectGroup)
		{
			SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(item.cameraEffect.CameraEntityId);
			if (entityWithEntityId != null)
			{
				GameObject gameObject = item.unityObjects.LoadResults[0].GameObject;
				Vector3 vector = VectorCoordConverter.SsjjToUnity(entityWithEntityId.position.Origin);
				gameObject.transform.localPosition = new Vector3((int)vector.x, (int)vector.y, (int)vector.z);
			}
		}
	}
}
