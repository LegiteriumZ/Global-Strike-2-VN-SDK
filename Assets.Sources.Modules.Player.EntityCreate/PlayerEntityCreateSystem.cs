using System.Collections.Generic;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Assets.Sources.Utils.ComponentInit;
using NetData;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.Player.EntityCreate;

public class PlayerEntityCreateSystem : IEntityCreateSystem
{
	private SnapshotContext _snapshotContext;

	private PlayerContext _playerContext;

	private WeaponContext _weappContext;

	private BattleRoomContext _battleRoomContext;

	private PlayerEntityData currentData;

	private PlayerEntityData nextData;

	public PlayerEntityCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_playerContext = contexts.player;
		_weappContext = contexts.weapon;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnEntityCreate()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		ISnapshot nextSnapshot = _snapshotContext.snapshots.NextSnapshot;
		if (nowSnapshot == null || nextSnapshot == null)
		{
			return;
		}
		createHuanyinEntity();
		DeleteEntites(nowSnapshot);
		if (nowSnapshot.Self != 0)
		{
			SetPredicateEntity(nowSnapshot);
		}
		SetPlaybackEntities(nowSnapshot, nextSnapshot);
		int num = ((nowSnapshot.Observer != 0) ? nowSnapshot.Observer : nowSnapshot.Self);
		foreach (PlayerEntity item in _playerContext.GetGroup(PlayerMatcher.EntityId))
		{
			item.isCameraOwner = item.entityId.Value == num;
		}
		nowSnapshot.IsDispose = true;
	}

	private void createHuanyinEntity()
	{
		bool flag = false;
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		if (nowSnapshot.Self == 0)
		{
			return;
		}
		PlayerEntityData playerEntityData = nowSnapshot.PlayerEntityDataDict[nowSnapshot.Self];
		Dictionary<long, IMyDictionary<int, PlayerInfoComponent.StatusDes>> statusDatas = _battleRoomContext.playerInfo.StatusDatas;
		if (statusDatas.ContainsKey(playerEntityData.CharacterId) && statusDatas[playerEntityData.CharacterId].ContainsKey(PlayerInfoStatusConstant.YINYANG_GRENADE_STAY_IN_BIG_MIRROR.ID))
		{
			flag = true;
		}
		ISnapshot nextSnapshot = _snapshotContext.snapshots.NextSnapshot;
		int num = SceneBufTypeUtility.ConvertYinyangHyPlayerId(playerEntityData.Id);
		if (flag)
		{
			currentData = new PlayerEntityData();
			EntityDataExtension.ClonePlayerEntityData(currentData, playerEntityData);
			currentData.Id = num;
			currentData.Alpha /= 2;
			currentData.PlayerStateFlag |= 134217728;
			currentData.PlayerName = "幻影";
			nowSnapshot.PlayerEntityDataDict[num] = currentData;
			playerEntityData = nowSnapshot.PlayerEntityDataDict[nextSnapshot.Self];
			nextData = new PlayerEntityData();
			EntityDataExtension.ClonePlayerEntityData(nextData, playerEntityData);
			nextData.Id = num;
			nextData.Alpha /= 2;
			nextData.PlayerName = "幻影";
			nextData.PlayerStateFlag |= 134217728;
			nextSnapshot.PlayerEntityDataDict[num] = nextData;
			return;
		}
		if (_playerContext.GetEntityWithEntityId(num) != null)
		{
			if (nowSnapshot.DeletedEntityIdList.IndexOf(num) == -1)
			{
				nowSnapshot.DeletedEntityIdList.Add(num);
			}
		}
		else if (nowSnapshot.PlayerEntityDataDict.ContainsKey(num))
		{
			nowSnapshot.PlayerEntityDataDict.Remove(num);
		}
		if (nextSnapshot.PlayerEntityDataDict.ContainsKey(num))
		{
			nextSnapshot.PlayerEntityDataDict.Remove(num);
		}
	}

	private void SetPredicateEntity(ISnapshot current)
	{
		ISnapshot latestSnapshot = _snapshotContext.snapshots.LatestSnapshot;
		if (latestSnapshot.PlayerEntityDataDict.ContainsKey(current.Self))
		{
			PlayerEntityData entityData = latestSnapshot.PlayerEntityDataDict[current.Self];
			PlayerEntity playerEntity = _playerContext.GetEntityWithEntityId(current.Self);
			bool newCreate = false;
			if (playerEntity == null)
			{
				newCreate = true;
				playerEntity = CreateNewPlayerEntity(current.Self);
				playerEntity.isMyPlayer = true;
				playerEntity.isFirstPersonView = true;
				playerEntity.isPrediction = true;
				PlayerEntityUtility.AddPredicationComfirm(playerEntity);
			}
			else if (_playerContext.myPlayerEntity != playerEntity)
			{
				this.LogErrorFormat("Setting multiple user to myplayer, first is {0} , now is", _playerContext.myPlayerEntity.entityId, playerEntity.entityId);
				playerEntity.isMyPlayer = true;
			}
			if (_battleRoomContext.roomData.IsObserver && playerEntity.entityId.Value == current.Self)
			{
				playerEntity.isDontLoadThirdPerson = true;
			}
			InitPlayerComponents(playerEntity, latestSnapshot.ServerTime, entityData, null, newCreate);
		}
	}

	private void SetPlaybackEntities(ISnapshot current, ISnapshot next)
	{
		foreach (KeyValuePair<int, PlayerEntityData> item in current.PlayerEntityDataDict)
		{
			PlayerEntityData value = item.Value;
			int id = value.Id;
			if (!next.PlayerEntityDataDict.TryGetValue(id, out var value2))
			{
				value2 = value;
			}
			PlayerEntity playerEntity = _playerContext.GetEntityWithEntityId(id);
			bool newCreate = false;
			if (playerEntity == null)
			{
				Debug.LogFormat("Request create player entity of id {0} {1}", id, value.PlayerName);
				newCreate = true;
				playerEntity = CreateNewPlayerEntity(id);
			}
			if (id == current.Self)
			{
				playerEntity.events.UnpredictableEvents = value.UnpredictableEvents;
			}
			else
			{
				InitPlayerComponents(playerEntity, current.ServerTime, value, value2, newCreate);
			}
		}
	}

	private void DeleteEntites(ISnapshot current)
	{
		foreach (int deletedEntityId in current.DeletedEntityIdList)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(deletedEntityId);
			if (entityWithEntityId != null)
			{
				entityWithEntityId.isDestroy = true;
				ThirdResUnloadUtility.ThirdLogOut(deletedEntityId);
			}
		}
	}

	private void InitPlayerComponents(PlayerEntity playerEntity, int serverTime, PlayerEntityData entityData, PlayerEntityData next, bool newCreate)
	{
		bool num = playerEntity.basicInfo.Current != entityData;
		playerEntity.basicInfo.SnapsotServerTime = serverTime;
		playerEntity.basicInfo.Current = entityData;
		playerEntity.basicInfo.Next = next;
		PlayerEntityUtility.PostInitBasicInfo(playerEntity);
		if (newCreate)
		{
			PlayerEntityUtility.PostInitCurrentWeapon(playerEntity);
			PlayerEntityUtility.PostInitQianglingWeaponList(playerEntity);
		}
		if (num)
		{
			playerEntity.events.Events = entityData.Events;
		}
	}

	private PlayerEntity CreateNewPlayerEntity(int entityId)
	{
		PlayerEntity playerEntity = _playerContext.CreateEntity();
		playerEntity.AddEntityId(entityId);
		PlayerEntityUtility.AddBasicInfo(playerEntity);
		PlayerEntityUtility.AddViewAnim(playerEntity);
		PlayerEntityUtility.AddLegAnim(playerEntity);
		PlayerEntityUtility.AddTorseAnim(playerEntity);
		PlayerEntityUtility.AddTransfrom(playerEntity);
		PlayerEntityUtility.AddCurrentWeapon(playerEntity);
		PlayerEntityUtility.AddClientTime(playerEntity);
		PlayerEntityUtility.AddQianglingWeaponList(playerEntity);
		PlayerEntityUtility.AddFavor(playerEntity);
		PlayerEntityUtility.AddMove(playerEntity, _weappContext);
		PlayerEntityUtility.AddPostionErrorSmooth(playerEntity);
		PlayerEntityUtility.AddFov(playerEntity);
		PlayerEntityUtility.AddDecay(playerEntity);
		PlayerEntityUtility.AddViewHeight(playerEntity);
		PlayerEntityUtility.AddState(playerEntity);
		PlayerEntityUtility.AddPunchSmooth(playerEntity);
		PlayerEntityUtility.AddEvents(playerEntity);
		PlayerEntityUtility.AddOrientation(playerEntity);
		PlayerEntityUtility.AddPunchOrientation(playerEntity);
		PlayerEntityUtility.AddSkill(playerEntity);
		PlayerEntityUtility.AddBuff(playerEntity);
		PlayerEntityUtility.AddLife(playerEntity);
		PlayerEntityUtility.AddNormalTrace(playerEntity);
		PlayerEntityUtility.AddHeadScale(playerEntity);
		PlayerEntityUtility.AddPassiveSkillInfo(playerEntity);
		PlayerEntityUtility.AddStudioSkillInfo(playerEntity);
		PlayerEntityUtility.AddVoice(playerEntity);
		PlayerEntityUtility.AddOneKillInfo(playerEntity);
		PlayerEntityUtility.AddCurrKill(playerEntity);
		PlayerEntityUtility.AddBeinghit(playerEntity);
		PlayerEntityUtility.AddShowHp(playerEntity);
		PlayerEntityUtility.AddVisiable(playerEntity);
		PlayerEntityUtility.AddEventParticles(playerEntity);
		PlayerEntityUtility.AddDunHp(playerEntity);
		return playerEntity;
	}
}
