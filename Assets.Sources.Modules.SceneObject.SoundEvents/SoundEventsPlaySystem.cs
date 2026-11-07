using System;
using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Weapon;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Pool;
using SSJJBase.Singleton;
using SSJJBase.Utility;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SoundEvents;

public class SoundEventsPlaySystem : IRenderSystem
{
	public struct SoundCache : IEquatable<SoundCache>
	{
		public string SoundName;

		public Vector3 SoundPos;

		public bool Equals(SoundCache other)
		{
			if (string.Equals(SoundName, other.SoundName))
			{
				return SoundPos.Equals(other.SoundPos);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is SoundCache)
			{
				return Equals((SoundCache)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((SoundName != null) ? SoundName.GetHashCode() : 0) * 397) ^ SoundPos.GetHashCode();
		}
	}

	private readonly SnapshotContext _snapshotContext;

	private readonly PlayerContext _playerContext;

	private int _lastSnapshotId = -1;

	private StackObjectPool<SoundCache> _soundPool = new StackObjectPool<SoundCache>();

	private Dictionary<SoundCache, int> _caches = new Dictionary<SoundCache, int>(8);

	public SoundEventsPlaySystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_playerContext = contexts.player;
	}

	public void OnRender()
	{
		ISnapshot latestSnapshot = _snapshotContext.snapshots.LatestSnapshot;
		if (latestSnapshot == null || _lastSnapshotId >= latestSnapshot.SeqId)
		{
			return;
		}
		_lastSnapshotId = latestSnapshot.SeqId;
		_caches.Clear();
		foreach (KeyValuePair<int, SoundEventEntityData> item in latestSnapshot.SoundEventEntityDataDict)
		{
			SoundEventEntityData value = item.Value;
			SoundCache orNull = _soundPool.GetOrNull();
			orNull.SoundName = value.SoundName;
			orNull.SoundPos = new Vector3(value.BaseEventEntity.X, value.BaseEventEntity.Y, value.BaseEventEntity.Z);
			int value2 = 0;
			if (!_caches.TryGetValue(orNull, out value2))
			{
				_caches.Add(orNull, 0);
			}
			if (value2 <= 3)
			{
				_caches[orNull]++;
				Vector3 vector = VectorCoordConverter.SsjjToUnity(new Vector3(value.BaseEventEntity.X, value.BaseEventEntity.Y, value.BaseEventEntity.Z));
				Vector3 b = VectorCoordConverter.SsjjToUnity(_playerContext.myPlayerEntity.GetCompenstatePos(_playerContext.myPlayerEntity.fpos.Change.GetPosIndex()));
				string soundName = value.SoundName;
				bool flag = _playerContext.GetEntityWithEntityId(value.BaseEventEntity.OwnerId)?.isMyPlayer ?? false;
				if (!flag && PredicationErrorUtility.Approximately(vector, b, 0.1f))
				{
					flag = true;
				}
				int data = value.BaseEventEntity.Data;
				string arg = soundName;
				if (!string.IsNullOrEmpty(soundName))
				{
					arg = WeaponUtility.GetAssetBundleName(soundName);
				}
				if (value.SoundType == 1)
				{
					MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Skill, flag, new AssetInfo("sound/acgsound", $"Assets/Res/Assets/sound/acgsound/{soundName}.mp3", typeof(AudioClip)), vector, GameSoundManager.Config.WeaponVolume, 10000);
				}
				if (data > 0)
				{
					MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Operate, flag, new AssetInfo($"sound/weapon/{arg}", $"Assets/Res/Assets/sound/weapon/{soundName}{data}.mp3", typeof(AudioClip)), vector, GameSoundManager.Config.WeaponVolume, 10000);
				}
				else
				{
					MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Operate, flag, new AssetInfo($"sound/weapon/{arg}", $"Assets/Res/Assets/sound/weapon/{soundName}.mp3", typeof(AudioClip)), vector, GameSoundManager.Config.WeaponVolume, 10000);
				}
			}
		}
		foreach (KeyValuePair<SoundCache, int> cache in _caches)
		{
			_soundPool.Add(cache.Key);
		}
		_caches.Clear();
	}
}
