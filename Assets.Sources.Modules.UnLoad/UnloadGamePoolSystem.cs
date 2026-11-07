using System.Collections.Generic;
using Assets.Scripts.Utility;
using Assets.Scripts.Utility.Pool;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Entitas;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Pool;
using UnityEngine;

namespace Assets.Sources.Modules.UnLoad;

public class UnloadGamePoolSystem : IPlaybackSystem
{
	public class AssetRef
	{
		public int Count;

		public int StartCheckTime;

		public void Reset(int count, int time)
		{
			Count = count;
			StartCheckTime = time;
		}
	}

	private TimeComponent _time;

	private float _unloadTime;

	private readonly BattleRoomContext _battleRoomContext;

	private readonly IGroup<UnloadEntity> _unloads;

	private readonly UnityGameObjectPool _pool;

	private readonly Dictionary<AssetInfo, AssetRef> _assetRefs;

	private readonly Dictionary<AssetInfo, int> _unloadDictionary;

	public UnloadGamePoolSystem(Contexts contexts)
	{
		_unloads = contexts.unload.GetGroup(UnloadMatcher.AllOf(UnloadMatcher.UnloadGamePool));
		_time = contexts.time.time;
		_assetRefs = new Dictionary<AssetInfo, AssetRef>();
		_pool = Contexts.sharedInstance.battleRoom.gameObjectPool.Pool as UnityGameObjectPool;
		_unloadDictionary = new Dictionary<AssetInfo, int>();
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnPlayback()
	{
		if (!canUnloadPoolRes())
		{
			return;
		}
		this.Info("UnloadGamePoolSystem Check");
		UnloadSign.UnloadPoolRes = false;
		_unloadTime = _time.ClientRealTime;
		foreach (UnloadEntity unload in _unloads)
		{
			_ = unload;
			CheckGamePool();
		}
	}

	private bool canUnloadPoolRes()
	{
		if ((float)(_time.ClientRealTime - 180000) > _unloadTime)
		{
			return true;
		}
		return UnloadSign.UnloadPoolRes;
	}

	private void CheckGamePool()
	{
		if (!(_pool != null))
		{
			return;
		}
		foreach (KeyValuePair<AssetInfo, StackObjectPool<GameObject>> poo in _pool.Poos)
		{
			if (!_assetRefs.TryGetValue(poo.Key, out var value))
			{
				value = new AssetRef();
				value.Reset(poo.Value.Count(), _time.ClientRealTime);
				_assetRefs.Add(poo.Key, value);
			}
			if (value.Count == poo.Value.Count() || poo.Value.Count() >= 80)
			{
				if (_time.ClientRealTime - value.StartCheckTime > 80000)
				{
					int num = 10;
					if (poo.Key.BundleName.Info.Equals("effectprefab/hole"))
					{
						num = 80;
					}
					else if (poo.Key.BundleName.Info.Equals("effect/common"))
					{
						num = 25;
					}
					else if (poo.Key.BundleName.Info.StartsWith("playereffectprefab/"))
					{
						num = 40;
					}
					if (value.Count > num)
					{
						int num2 = poo.Value.Count() - num;
						_unloadDictionary.Add(poo.Key, num2);
						TotalMemoryUtility.SetUnloadCount(num2);
					}
					value.Reset(poo.Value.Count(), _time.ClientRealTime);
				}
			}
			else
			{
				value.Reset(poo.Value.Count(), _time.ClientRealTime);
			}
			foreach (KeyValuePair<AssetInfo, int> item in _unloadDictionary)
			{
				int value2 = item.Value;
				AssetInfo key = item.Key;
				_pool.Unload(key, value2);
			}
			_unloadDictionary.Clear();
		}
	}
}
