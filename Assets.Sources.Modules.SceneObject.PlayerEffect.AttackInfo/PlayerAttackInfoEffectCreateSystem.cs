using System.Collections.Generic;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Entitas;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect.AttackInfo;

public class PlayerAttackInfoEffectCreateSystem : IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _playerGroup;

	private readonly IBattleRoom _battleRoomAdapter;

	private readonly SceneObjectContext _sceneObjectContext;

	public PlayerAttackInfoEffectCreateSystem(Contexts contexts)
	{
		_playerGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects));
		_sceneObjectContext = contexts.sceneObject;
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
	}

	public void OnEntityCreate()
	{
		int frameCount = Time.frameCount;
		int num = 0;
		foreach (PlayerEntity item in _playerGroup)
		{
			if (item.isCameraOwner || (frameCount - num++) % 10 == 0)
			{
				CreatePlayerEffect(item);
			}
		}
	}

	public void OnPlayback()
	{
		OnEntityCreate();
	}

	private void CreatePlayerEffect(PlayerEntity player)
	{
		if (player.IsDead() || !player.hasSkill || player.skill.Status == null)
		{
			return;
		}
		foreach (KeyValuePair<int, PlayerInfoComponent.StatusDes> item in player.skill.Status)
		{
			PlayerInfoAttackEffectData playerAttackInfoEffectData = ParticleManager.Instance().GetPlayerAttackInfoEffectData(item.Key);
			if (playerAttackInfoEffectData != null)
			{
				string name = playerAttackInfoEffectData.GetName();
				EntityEffectId entityEffectId = new EntityEffectId(player.entityId.Value, name);
				if (_sceneObjectContext.GetEntityWithPlayerEffectId(entityEffectId) == null)
				{
					SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
					sceneObjectEntity.AddPlayerEffectId(entityEffectId);
					sceneObjectEntity.AddPosition(player.GetCompenstatePos(player.fpos.Change.GetPosIndex()));
					sceneObjectEntity.AddScale(Vector3.one);
					sceneObjectEntity.AddPlayerAttackEffect(player.entityId.Value, item.Key);
					sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(playerAttackInfoEffectData.AssetInfo), entityEffectId);
				}
			}
		}
	}
}
