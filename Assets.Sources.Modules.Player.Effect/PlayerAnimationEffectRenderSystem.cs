using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerAnimationEffectRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _group;

	private PlayerContext _playerContext;

	public PlayerAnimationEffectRenderSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PlayerAnimationEffect, SceneObjectMatcher.UnityObjects).NoneOf(SceneObjectMatcher.Destroy));
		_playerContext = contexts.player;
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			GameObject gameObject = item.unityObjects.LoadResults[0].GameObject;
			PlayerEntity playerEntity = ContextsExtensions.GetEntityWithEntityId(Value: item.playerAnimationEffect.FollowEntityId, context: _playerContext);
			if (playerEntity != null)
			{
				if (playerEntity.hasFpos)
				{
					item.position.Origin = playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex());
				}
				if (playerEntity.hasOrientation)
				{
					item.rotation.EulerAngles = new Vector3(playerEntity.orientation.Pitch, 0f - playerEntity.orientation.Yaw, 0f);
				}
			}
			gameObject.transform.position = VectorCoordConverter.SsjjToUnity(item.position.Origin) + new Vector3(0f, item.playerAnimationEffect.Up, 0f);
			gameObject.transform.localEulerAngles = item.rotation.EulerAngles;
		}
	}
}
