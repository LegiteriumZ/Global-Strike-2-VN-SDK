using System;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Framework;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Assets.Sources.Utils.PlayerAnim;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerAnimationEffectSystem : IPlaybackInitSystem
{
	private readonly SceneObjectContext _sceneObjectContext;

	private readonly IGroup<PlayerEntity> _group;

	public PlayerAnimationEffectSystem(Contexts contexts)
	{
		PlayerContext player = contexts.player;
		_group = player.GetGroup(PlayerMatcher.ThirdPersonUnityObjects);
		_sceneObjectContext = contexts.sceneObject;
	}

	public void OnPlaybackInit()
	{
		foreach (PlayerEntity item in _group)
		{
			if (!item.hasLegAnim || item.legAnim.LegsAnimInfo == null)
			{
				continue;
			}
			PlayerAnimEffectData playerAnimEffectData = ParticleManager.Instance().GetPlayerAnimEffectData(item.GetCareer(), item.legAnim.LegsAnimInfo.StateId);
			if (playerAnimEffectData != null)
			{
				EntityEffectId entityEffectId = new EntityEffectId(item.entityId.Value, item.GetCareer() + "_" + item.legAnim.LegsAnimInfo.StateId);
				int legAnimDuration = PlayerAnimationUtility.GetLegAnimDuration(item, item.legAnim.LegsAnimInfo.StateId);
				if (_sceneObjectContext.GetEntityWithPlayerEffectId(entityEffectId) == null)
				{
					SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
					sceneObjectEntity.AddPlayerEffectId(entityEffectId);
					sceneObjectEntity.AddPlayerAnimationEffect(item.legAnim.LegsAnimInfo.StateId, playerAnimEffectData.DelayTime, 0, 0, playerAnimEffectData.AssetInfo, item.entityId.Value, playerAnimEffectData.Up);
					sceneObjectEntity.AddPosition(item.GetCompenstatePos(item.fpos.Change.GetPosIndex()));
					sceneObjectEntity.AddRotation(Vector3.zero);
					sceneObjectEntity.AddLifeTime(DateTime.Now, playerAnimEffectData.DelayTime + legAnimDuration);
				}
			}
		}
	}
}
