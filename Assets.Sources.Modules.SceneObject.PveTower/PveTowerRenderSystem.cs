using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PveTower;

public class PveTowerRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _group;

	public PveTowerRenderSystem(Contexts contexts)
	{
		SceneObjectContext sceneObject = contexts.sceneObject;
		_group = sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PveTower, SceneObjectMatcher.UnityObjects));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			Vector3 position = VectorCoordConverter.SsjjToUnity(item.position.Origin);
			Vector3 localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(item.rotation.EulerAngles);
			GameObject gameObject = item.unityObjects.LoadResults[0].GameObject;
			gameObject.transform.position = position;
			gameObject.transform.localEulerAngles = localEulerAngles;
		}
	}
}
