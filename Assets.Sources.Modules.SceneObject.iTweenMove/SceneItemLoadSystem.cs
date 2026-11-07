using Assets.Sources.Framework;
using Entitas;
using NetData;
using SSJJAnim.Animator;
using SSJJAnim.Parser;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.iTweenMove;

public class SceneItemLoadSystem : IResourceInitSystem
{
	private IGroup<SceneObjectEntity> _group;

	public SceneItemLoadSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.iTweenMove, SceneObjectMatcher.UnityObjects).NoneOf(SceneObjectMatcher.SceneItemUnity));
	}

	private void InitEntity(SceneObjectEntity entity)
	{
		SceneItweenEntityData data = entity.iTweenMove.Data;
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		GameObject gameObject2 = new GameObject(data.BaseMoveEntity.Name);
		gameObject.transform.SetParent(gameObject2.transform, worldPositionStays: false);
		gameObject.transform.localPosition = Vector3.zero;
		if (entity.unityObjects.LoadResults.Count > 1)
		{
			SJAnimator component = gameObject.GetComponent<SJAnimator>();
			component.Init();
			component.AddLayer(0, 1f);
			if (!entity.hasVisiable || entity.visiable.IsVisiable)
			{
				_ = 1;
			}
			else
				_ = entity.visiable.IsNear;
			SJAnimationAsset sJAnimationAsset = entity.unityObjects.LoadResults[1].Object as SJAnimationAsset;
			component.AddAnimationClips(0, sJAnimationAsset.Clips);
			entity.AddSJAnim(component, 0);
		}
		entity.AddSceneItemUnity(gameObject2, gameObject);
	}

	public void OnInitResources()
	{
		foreach (SceneObjectEntity item in _group)
		{
			InitEntity(item);
		}
	}
}
