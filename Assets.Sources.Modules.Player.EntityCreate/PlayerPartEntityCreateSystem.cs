using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Utils.ComponentInit;
using NetData;

namespace Assets.Sources.Modules.Player.EntityCreate;

public class PlayerPartEntityCreateSystem : IEntityCreateSystem
{
	private SnapshotContext _snapshotContext;

	private PlayerContext _playerContext;

	public PlayerPartEntityCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_playerContext = contexts.player;
	}

	public void OnEntityCreate()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		ISnapshot nextSnapshot = _snapshotContext.snapshots.NextSnapshot;
		if (nowSnapshot != null && nextSnapshot != null)
		{
			DeleteEntites(nowSnapshot);
			SetPlaybackEntities(nowSnapshot, nextSnapshot);
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
			}
		}
	}

	private void SetPlaybackEntities(ISnapshot current, ISnapshot next)
	{
		foreach (KeyValuePair<int, PlayerPartEntityData> item in current.PlayerPartEntityDataDict)
		{
			PlayerPartEntityData value = item.Value;
			int id = value.Id;
			if (next.PlayerPartEntityDataDict.TryGetValue(id, out var value2))
			{
				PlayerEntity playerEntity = _playerContext.GetEntityWithEntityId(id);
				if (playerEntity == null)
				{
					playerEntity = CreateNewPlayerEntity(id);
				}
				InitPlayerComponents(playerEntity, current.ServerTime, value, value2);
			}
		}
	}

	private void InitPlayerComponents(PlayerEntity playerEntity, int serverTime, PlayerPartEntityData entityData, PlayerPartEntityData nextEntityData)
	{
		playerEntity.basicInfo.SnapsotServerTime = serverTime;
		CopyPartEntityData(playerEntity.basicInfo.Current, entityData);
		CopyPartEntityData(playerEntity.basicInfo.Next, nextEntityData);
		playerEntity.partBasicInfo.IsFootStep = entityData.IsFootstep;
		playerEntity.partBasicInfo.OnLadder = entityData.OnLadder;
		PlayerEntityUtility.PostInitBasicInfo(playerEntity);
		playerEntity.state.StateFlag = entityData.PlayerStateFlag;
	}

	private static void CopyPartEntityData(PlayerEntityData fullData, PlayerPartEntityData partData)
	{
		fullData.Id = partData.Id;
		fullData.PlayerStateFlag = partData.PlayerStateFlag;
		fullData.X = partData.X;
		fullData.Y = partData.Y;
		fullData.Z = partData.Z;
		fullData.PlayerName = partData.PlayerName;
		fullData.ViewYaw = partData.ViewYaw;
		fullData.IsDead = partData.IsDead;
		fullData.Hp = partData.Hp;
		fullData.HasC4 = partData.HasC4;
		fullData.Career = partData.Career;
		fullData.TeamId = partData.TeamId;
		fullData.Team = partData.Team;
		fullData.CharacterId = partData.CharacterId;
	}

	private PlayerEntity CreateNewPlayerEntity(int entityId)
	{
		PlayerEntity playerEntity = _playerContext.CreateEntity();
		playerEntity.AddEntityId(entityId);
		PlayerEntityUtility.AddBasicInfo(playerEntity);
		PlayerEntityUtility.AddPartBasicInfo(playerEntity);
		PlayerEntityUtility.AddPosition(playerEntity);
		PlayerEntityUtility.AddOrientation(playerEntity);
		PlayerEntityUtility.AddPunchOrientation(playerEntity);
		playerEntity.basicInfo.IsPart = true;
		playerEntity.basicInfo.Current = new PlayerEntityData();
		playerEntity.basicInfo.Next = new PlayerEntityData();
		PlayerEntityUtility.AddState(playerEntity);
		PlayerEntityUtility.AddSkill(playerEntity);
		PlayerEntityUtility.AddBuff(playerEntity);
		PlayerEntityUtility.AddPassiveSkillInfo(playerEntity);
		PlayerEntityUtility.AddStudioSkillInfo(playerEntity);
		PlayerEntityUtility.AddVoice(playerEntity);
		PlayerEntityUtility.AddOneKillInfo(playerEntity);
		PlayerEntityUtility.AddCurrKill(playerEntity);
		PlayerEntityUtility.AddBeinghit(playerEntity);
		return playerEntity;
	}
}
