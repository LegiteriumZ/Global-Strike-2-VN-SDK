using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Particle;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Constant;
using SSJJBase.Singleton;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Beinghit;

public class BeinghitUpdateSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private SnapshotContext _snapshotContext;

	private Dictionary<int, bool> _playDmgDic = new Dictionary<int, bool>();

	private float audioInterval = 0.5f;

	private float upPlayeTime;

	public BeinghitUpdateSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_snapshotContext = contexts.snapshot;
	}

	public void OnPlayback()
	{
		if (!_snapshotContext.hasSnapshots)
		{
			return;
		}
		ISnapshot latestSnapshot = _snapshotContext.snapshots.LatestSnapshot;
		if (latestSnapshot == null || !_playerContext.isMyPlayer)
		{
			return;
		}
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		foreach (KeyValuePair<int, BeingHitEventEntityData> item in latestSnapshot.BeingHitEventEntityDataDict)
		{
			int parentId = item.Value.ParentId;
			int shootId = item.Value.ShootId;
			switch (item.Value.BaseEventEntity.EventId)
			{
			case 3:
				playCareerHitDeathSnd(item.Value, item.Key);
				if (item.Value.Kind == 2)
				{
					return;
				}
				if (parentId == shootId && shootId == myPlayerEntity.entityId.Value)
				{
					myPlayerEntity.beingHit.DamageFrom = 1;
					myPlayerEntity.beingHit.BeinghitData = item.Value;
					return;
				}
				if (myPlayerEntity.entityId.Value == shootId)
				{
					return;
				}
				if (myPlayerEntity.entityId.Value == parentId)
				{
					myPlayerEntity.beingHit.DamageFrom = 0;
					myPlayerEntity.beingHit.BeinghitData = item.Value;
					return;
				}
				break;
			case 45:
				if (myPlayerEntity.entityId.Value == parentId)
				{
					myPlayerEntity.beingHit.DamageFrom = 2;
					myPlayerEntity.beingHit.BeinghitData = item.Value;
				}
				break;
			}
		}
		if (latestSnapshot.BeingHitEventEntityDataDict.Count <= 0 && _playDmgDic.Count > 0)
		{
			_playDmgDic.Clear();
		}
	}

	private void playCareerHitDeathSnd(BeingHitEventEntityData beingHitEvent, int hitId)
	{
		if (Time.time - upPlayeTime < audioInterval)
		{
			return;
		}
		upPlayeTime = Time.time;
		if (_playDmgDic.ContainsKey(hitId))
		{
			return;
		}
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(beingHitEvent.ParentId);
		if (entityWithEntityId != null)
		{
			string career = entityWithEntityId.GetCareer();
			int id = beingHitEvent.BaseEventEntity.EventId;
			if (beingHitEvent.IsKill)
			{
				id = CustomEventType.SELFEV_BEING_DEATH;
			}
			ParticleManager.Instance().TryGetSound(id, career, out var data);
			if (data != null)
			{
				PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
				AssetInfo assetInfo = data.AssetInfo;
				Vector3 inv = new Vector3((float)entityWithEntityId.GetX(), (float)entityWithEntityId.GetY(), (float)entityWithEntityId.GetZ());
				inv = VectorCoordConverter.SsjjToUnity(inv);
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Shoot, entityWithEntityId == myPlayerEntity, assetInfo, inv, GameSoundManager.Config.EnvironmentVolume, data.Scale);
				_playDmgDic.Add(hitId, value: true);
			}
		}
	}
}
