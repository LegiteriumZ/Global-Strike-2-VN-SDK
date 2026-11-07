using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SimpleEngineEntity;

public class SimpleEngineEntityEffectRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _group;

	public SimpleEngineEntityEffectRenderSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SimpleEngineEntity, SceneObjectMatcher.EffectObjects));
	}

	private void UpdateSimpleEngineEntity(SceneObjectEntity entity)
	{
		Vector3 position = VectorCoordConverter.SsjjToUnity(entity.position.Origin);
		Vector3 localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(entity.rotation.EulerAngles);
		GameObject gameObject = entity.effectObjects.LoadResults[0].GameObject;
		gameObject.transform.position = position;
		gameObject.transform.localEulerAngles = localEulerAngles;
		gameObject.SetObjectActive(entity.simpleEngineEntity.data.IsStandPlayer);
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			UpdateSimpleEngineEntity(item);
		}
	}
}
