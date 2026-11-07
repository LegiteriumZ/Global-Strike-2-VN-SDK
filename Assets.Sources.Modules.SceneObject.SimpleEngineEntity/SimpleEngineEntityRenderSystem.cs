using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SimpleEngineEntity;

public class SimpleEngineEntityRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _group;

	public SimpleEngineEntityRenderSystem(Contexts context)
	{
		_group = context.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SimpleEngineEntity, SceneObjectMatcher.UnityObjects));
	}

	private void UpdateSimpleEngineEntity(SceneObjectEntity entity)
	{
		Vector3 position = VectorCoordConverter.SsjjToUnity(entity.position.Origin);
		Vector3 localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(entity.rotation.EulerAngles);
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		gameObject.transform.position = position;
		gameObject.transform.localEulerAngles = localEulerAngles;
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			UpdateSimpleEngineEntity(item);
		}
	}
}
