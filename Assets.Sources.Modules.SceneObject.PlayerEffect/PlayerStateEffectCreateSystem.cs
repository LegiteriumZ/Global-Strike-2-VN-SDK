using System.Collections.Generic;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Framework;
using Assets.Sources.Info.Effect.PlayerEffect;
using Assets.Sources.Modules.BattleRoom;
using Entitas;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect;

public class PlayerStateEffectCreateSystem : IEntityCreateSystem
{
	private readonly IGroup<PlayerEntity> _playerGroup;

	private readonly SceneObjectContext _sceneObjectContext;

	private readonly BattleRoomContext _battleRoomContext;

	private readonly IBattleRoom _battleRoomAdapter;

	private readonly List<int> _showToEnemy = new List<int> { 1205 };

	private readonly List<int> _showViewList = new List<int> { 31113, 31114, 31115, 31116, 30044, 30045, 30046 };

	public PlayerStateEffectCreateSystem(Contexts contexts)
	{
		_playerGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects));
		_sceneObjectContext = contexts.sceneObject;
		_battleRoomContext = contexts.battleRoom;
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
	}

	public void OnEntityCreate()
	{
		if (!Contexts.sharedInstance.player.isMyPlayer)
		{
			return;
		}
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

	private void CreatePlayerEffect(PlayerEntity player)
	{
		List<IPlayerEffectInfo> playerInfoList = PlayerEffectInfoFactory.Instance.PlayerInfoList;
		for (int i = 0; i < playerInfoList.Count; i++)
		{
			IPlayerEffectInfo playerEffectInfo = playerInfoList[i];
			if (playerEffectInfo.IsEffectOn(player, _battleRoomAdapter) && (!player.IsDead() || playerEffectInfo.IsEffectOnPlayerDead()))
			{
				AddEffect(player, playerEffectInfo);
			}
		}
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		int team = myPlayerEntity.GetTeam();
		if (player.IsDead() || !player.hasSkill || player.skill.Status == null)
		{
			return;
		}
		foreach (KeyValuePair<int, PlayerInfoComponent.StatusDes> item in player.skill.Status)
		{
			if ((!_showToEnemy.Contains(item.Key) || player.GetTeam() != team) && (player.basicInfo.Cid == myPlayerEntity.basicInfo.Cid || !_showViewList.Contains(item.Key)))
			{
				IPlayerEffectInfo playerEffectInfoByStatusId = PlayerEffectInfoFactory.Instance.GetPlayerEffectInfoByStatusId(item.Key);
				if (playerEffectInfoByStatusId != null)
				{
					AddEffect(player, playerEffectInfoByStatusId, item.Value);
				}
			}
		}
	}

	private void AddEffect(PlayerEntity player, IPlayerEffectInfo effectInfo, PlayerInfoComponent.StatusDes status = null)
	{
		string uniqueId = effectInfo.GetUniqueId();
		EntityEffectId entityEffectId = new EntityEffectId(player.entityId.Value, uniqueId);
		SceneObjectEntity sceneObjectEntity = _sceneObjectContext.GetEntityWithPlayerEffectId(entityEffectId);
		Vector3 one = Vector3.one;
		if (status != null && status.Scale > 0f)
		{
			one *= status.Scale;
			if (effectInfo.IsScaleOnlyXy())
			{
				one.z = 1f;
			}
		}
		if (sceneObjectEntity == null)
		{
			AssetInfo thirdEffectAssetInfo = effectInfo.GetThirdEffectAssetInfo(player, _battleRoomContext.roomData.Data.RaceType);
			thirdEffectAssetInfo.AssetType = typeof(GameObject);
			sceneObjectEntity = _sceneObjectContext.CreateEntity();
			sceneObjectEntity.AddPlayerEffectId(entityEffectId);
			sceneObjectEntity.AddPosition(Vector3.zero);
			sceneObjectEntity.AddScale(one);
			sceneObjectEntity.AddPlayerEffect(player.entityId.Value, effectInfo, null);
			sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(thirdEffectAssetInfo), entityEffectId);
			if (effectInfo.IsSmallMirror() && status != null)
			{
				sceneObjectEntity.ReplaceParticleLerpRotation(status.Number, status.Number);
			}
		}
		if (sceneObjectEntity != null)
		{
			sceneObjectEntity.ReplaceScale(one);
			if (effectInfo.IsSmallMirror() && status != null)
			{
				sceneObjectEntity.ReplaceParticleLerpRotation(sceneObjectEntity.particleLerpRotation.nowRotation, status.Number);
			}
		}
	}
}
