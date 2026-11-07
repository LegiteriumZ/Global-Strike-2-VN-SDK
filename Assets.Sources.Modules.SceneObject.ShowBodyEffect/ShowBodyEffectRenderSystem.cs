using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.ShowBodyEffect;

public class ShowBodyEffectRenderSystem : IRenderSystem
{
	private readonly IGroup<SceneObjectEntity> _group;

	private PlayerContext _playerContext;

	public ShowBodyEffectRenderSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.ShowBodyEffect, SceneObjectMatcher.UnityObjects).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			string boneName = item.showBodyEffect.BoneName;
			int ownerId = item.showBodyEffect.OwnerId;
			GameObject gameObject = item.unityObjects.LoadResults[0].GameObject;
			bool isFresh = item.showBodyEffect.IsFresh;
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(ownerId);
			if (entityWithEntityId == null || gameObject == null || string.IsNullOrEmpty(boneName))
			{
				continue;
			}
			GameObject gameObject2 = null;
			if (entityWithEntityId.GetSkinnedMeshRender() == null)
			{
				continue;
			}
			Transform[] bones = entityWithEntityId.GetSkinnedMeshRender().bones;
			foreach (Transform transform in bones)
			{
				if (transform != null)
				{
					gameObject2 = transform.FindForeachByName(boneName);
					if (gameObject2 == null && transform.parent.name == boneName)
					{
						gameObject2 = transform.parent.gameObject;
					}
					if (gameObject2 != null)
					{
						break;
					}
				}
			}
			if (gameObject2 == null)
			{
				gameObject.SetObjectActive(isactive: false);
				continue;
			}
			Vector3 inv = VectorCoordConverter.UnityToSsjj(gameObject2.transform.position);
			gameObject.transform.localPosition = VectorCoordConverter.SsjjToUnity(inv);
			Quaternion rotation = gameObject2.transform.rotation;
			gameObject.transform.rotation = Quaternion.Euler(VectorCoordConverter.SsjjRotationToUnity(new Vector3(rotation.x + item.showBodyEffect.Pitch, rotation.y, rotation.z + item.showBodyEffect.Yaw)));
			if (isFresh)
			{
				item.showBodyEffect.IsFresh = false;
				gameObject.SetObjectActive(isactive: false);
				gameObject.SetObjectActive(isactive: true);
			}
		}
	}
}
