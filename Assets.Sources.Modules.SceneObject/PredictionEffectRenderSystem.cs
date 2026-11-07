using Assets.Sources.Framework;
using Entitas;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject;

public class PredictionEffectRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _group;

	public PredictionEffectRenderSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.UnityObjects, SceneObjectMatcher.PredictionEffect).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			foreach (LoadResults.MultiTV loadResult in item.unityObjects.LoadResults)
			{
				GameObject gameObject = loadResult.Value.GameObject;
				gameObject.name = "predictionEffect";
				gameObject.transform.position = VectorCoordConverter.SsjjToUnity(item.position.Origin);
			}
		}
	}
}
