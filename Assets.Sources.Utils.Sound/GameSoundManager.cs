using System;
using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.CsvLoader;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJMath;
using Sharpen;
using UnityEngine;

namespace Assets.Sources.Utils.Sound;

public class GameSoundManager : MonoBehaviourSingleton<GameSoundManager>
{
	public enum RollOffDistance
	{
		Distance25,
		Distance32,
		Distance57,
		Distance94,
		Distance169
	}

	private static GameSoundConfig _config = new GameSoundConfig(1f, 1f, 1f, 1f, 0.6f, 0.6f, 1f);

	private readonly IDictionary<int, AnimationCurve> _soundCurveMap = new ConcurrentHashMap<int, AnimationCurve>();

	private readonly Dictionary<int, List<IGameSound>> _soundDic = new Dictionary<int, List<IGameSound>>();

	private readonly Dictionary<int, List<IGameSound>> _soundCacheDic = new Dictionary<int, List<IGameSound>>();

	private Dictionary<int, SoundSystemTable.Row> _typeRow = new Dictionary<int, SoundSystemTable.Row>();

	private GameObject _parent;

	private List<IGameSound> _sortedList = new List<IGameSound>();

	private Vector3 _myPosition;

	private Comparison<IGameSound> _sortTotalComparer;

	private Comparison<IGameSound> _sortSubTypeComparer;

	private IGameSound BG;

	public static GameSoundConfig Config => _config;

	private SoundSystemTable.Row GetTypeRow(int type)
	{
		if (!_typeRow.TryGetValue(type, out var value))
		{
			SoundSystemTable.Row row = SoundSystemLoader.Instance.Table.Find_Subtype(type);
			_typeRow.Add(type, row);
			return row;
		}
		return value;
	}

	public static void InitConfig(ref GameSoundConfig copyconfig)
	{
		_config = copyconfig;
	}

	private void Awake()
	{
		List<AudioRolloffTable.Row> rowList = AudioRolloffLoader.Instance.Table.GetRowList();
		_soundCurveMap.Add(0, SoundUtility.GetCurve(rowList[0].Min, rowList[0].Max, rowList[0].A, rowList[0].B));
		_soundCurveMap.Add(1, SoundUtility.GetCurve(rowList[1].Min, rowList[1].Max, rowList[1].A, rowList[1].B));
		_soundCurveMap.Add(2, SoundUtility.GetCurve(rowList[2].Min, rowList[2].Max, rowList[2].A, rowList[2].B));
		_soundCurveMap.Add(3, SoundUtility.GetCurve(rowList[3].Min, rowList[3].Max, rowList[3].A, rowList[3].B));
		_soundCurveMap.Add(4, SoundUtility.GetCurve(rowList[4].Min, rowList[4].Max, rowList[4].A, rowList[4].B));
		_sortSubTypeComparer = SortSubtype;
		_sortTotalComparer = SortTotal;
	}

	private void Update()
	{
		_sortedList.Clear();
		_myPosition = GetMyPosition();
		foreach (KeyValuePair<int, List<IGameSound>> item in _soundDic)
		{
			List<IGameSound> value = item.Value;
			int key = item.Key;
			if (!_soundCacheDic.ContainsKey(key))
			{
				_soundCacheDic.Add(key, new List<IGameSound>());
			}
			SoundSystemTable.Row typeRow = GetTypeRow(key);
			List<IGameSound> list = _soundCacheDic[key];
			foreach (IGameSound item2 in value)
			{
				if (!item2.IsPlaying)
				{
					list.Add(item2);
				}
				else if (typeRow.LimitGlobal)
				{
					_sortedList.Add(item2);
				}
			}
			foreach (IGameSound item3 in list)
			{
				if (value.Contains(item3))
				{
					value.Remove(item3);
				}
			}
			if (value.Count <= typeRow.LimiteWhole)
			{
				continue;
			}
			if (typeRow.LimiteRange)
			{
				value.Sort(_sortSubTypeComparer);
				while (value.Count > typeRow.LimiteWhole)
				{
					IGameSound sound = value.Last();
					RemoveSound(value, sound);
				}
			}
			else
			{
				while (value.Count > typeRow.LimiteWhole)
				{
					IGameSound sound2 = value[0];
					RemoveSound(value, sound2);
				}
			}
		}
		if (_sortedList.Count > 40)
		{
			_sortedList.Sort(_sortTotalComparer);
			while (_sortedList.Count > 40)
			{
				IGameSound gameSound = _sortedList.Last();
				RemoveSound(_soundDic[gameSound.Subtype], gameSound);
			}
		}
	}

	private void RemoveSound(List<IGameSound> list, IGameSound sound)
	{
		sound.Stop();
		list.Remove(sound);
		_soundCacheDic[sound.Subtype].Add(sound);
		_sortedList.Remove(sound);
	}

	private int SortTotal(IGameSound a, IGameSound b)
	{
		if (a.Priority > b.Priority)
		{
			return -1;
		}
		if (a.Priority < b.Priority)
		{
			return 1;
		}
		if (a.Subtype < b.Subtype)
		{
			return -1;
		}
		if (a.Subtype > b.Subtype)
		{
			return 1;
		}
		if (a.Subtype == b.Subtype && GetTypeRow(a.Subtype).LimiteRange)
		{
			return SortSubtype(a, b);
		}
		return 0;
	}

	private Vector3 GetMyPosition()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity != null)
		{
			return VectorCoordConverter.SsjjToUnity(myPlayerEntity.GetCompenstatePos(myPlayerEntity.fpos.Change.GetPosIndex()));
		}
		return Vector3.zero;
	}

	private int SortSubtype(IGameSound a, IGameSound b)
	{
		float num = Vector3.Distance(a.Position, _myPosition);
		float num2 = Vector3.Distance(b.Position, _myPosition);
		if (num < num2)
		{
			return -1;
		}
		if (num > num2)
		{
			return 1;
		}
		return 0;
	}

	public void Play2DSound(int type, bool isMyself, AudioSource source, AssetInfo info, int delay = 0, int playCount = 1)
	{
		if (GetSoundPlayer<Game2DSound>(type, isMyself, source.transform.position, out var result))
		{
			result.PlaySound(info, source, delay, playCount);
		}
		else
		{
			this.LogError(" 11>>load failed :: " + info);
		}
	}

	public void Play2DSound(int type, bool isMyself, AssetInfo info, float volum, int delay = 0, bool loop = false, int playCount = 1)
	{
		if (GetSoundPlayer<Game2DSound>(type, isMyself, Vector3.zero, out var result))
		{
			result.PlayClip(info, volum, null, delay, loop, playCount);
		}
		else
		{
			this.LogError(" 22>>load failed :: " + info);
		}
	}

	public void Play2DSoundBG(int type, bool isMyself, AssetInfo info, float volum, int delay = 0, bool loop = false, int playCount = 1)
	{
		if (GetSoundPlayer<Game2DSound>(type, isMyself, Vector3.zero, out var result))
		{
			result.PlayClip(info, volum, null, delay, loop, playCount);
		}
		else
		{
			this.LogError(" 22>>load failed :: " + info);
		}
	}

	public void Play3DSound(int type, bool isMyself, AssetInfo info, Vector3 position, float volumeScale, RollOffDistance maxDist, int delay = 0, bool loop = false, int playCount = 1)
	{
		Game3DSound result;
		if (isMyself)
		{
			Play2DSound(type, isMyself, info, volumeScale);
		}
		else if (GetSoundPlayer<Game3DSound>(type, isMyself, position, out result))
		{
			AnimationCurve curve = _soundCurveMap[(int)maxDist];
			result.PlayClip(info, position, volumeScale, curve, null, delay, loop, playCount);
		}
		else
		{
			this.LogError(" 33>>load failed :: " + info);
		}
	}

	public void Play3DSound(int type, bool isMyself, AssetInfo info, Vector3 position, float volumeScale, int maxDist, int delay = 0, bool loop = false, float moveTime = 0f, int playCount = 1)
	{
		Game3DSound result;
		if (isMyself)
		{
			Play2DSound(type, isMyself, info, volumeScale);
		}
		else if (GetSoundPlayer<Game3DSound>(type, isMyself, position, out result))
		{
			result.PlayClip(info, position, volumeScale, maxDist, null, delay, loop, playCount, moveTime);
		}
		else
		{
			this.LogError(" 44>>load failed :: " + info);
		}
	}

	private bool GetSoundPlayer<T>(int type, bool isMyself, Vector3 position, out T result) where T : class, IGameSound, new()
	{
		if (_parent == null)
		{
			_parent = new GameObject("GameSoundManager");
			_parent.transform.SetParent(base.transform, worldPositionStays: false);
		}
		if (type == SoundSystemTable.SoundSubtype.BG)
		{
			SoundSystemTable.Row typeRow = GetTypeRow(SoundSystemTable.SoundSubtype.Other);
			if (BG == null)
			{
				BG = new T();
				BG.Priority = typeRow.Priority - ((!isMyself) ? typeRow.PriOffset : 0);
				BG.VolumeOffset = (isMyself ? 0f : ((float)typeRow.VolOffset / 100f));
				BG.Subtype = SoundSystemTable.SoundSubtype.Other;
				BG.CreateNew(_parent.transform);
			}
			result = BG as T;
			return true;
		}
		if (!_soundDic.ContainsKey(type))
		{
			_soundDic.Add(type, new List<IGameSound>());
		}
		if (!_soundCacheDic.ContainsKey(type))
		{
			_soundCacheDic.Add(type, new List<IGameSound>());
		}
		List<IGameSound> list = _soundDic[type];
		SoundSystemTable.Row typeRow2 = GetTypeRow(type);
		List<IGameSound> list2 = _soundCacheDic[type];
		result = null;
		foreach (IGameSound item in list2)
		{
			if (item is T)
			{
				result = item as T;
				list2.Remove(item);
				break;
			}
		}
		if (result == null)
		{
			result = new T();
			result.CreateNew(_parent.transform);
		}
		list.AddLast(result);
		result.Priority = typeRow2.Priority - ((!isMyself) ? typeRow2.PriOffset : 0);
		result.VolumeOffset = (isMyself ? 0f : ((float)typeRow2.VolOffset / 100f));
		result.Subtype = type;
		return true;
	}

	public bool IsPlaying(ref AssetInfo info)
	{
		return IsPlaying(info.AssetName);
	}

	public bool IsInJob(ref AssetInfo info)
	{
		return IsInJob(info.AssetName);
	}

	public void StopSound(ref AssetInfo info)
	{
		StopSound(info.AssetName);
	}

	public void StopSound(string assetpath)
	{
		Stop(assetpath);
	}

	public void ChangeSound(ref AssetInfo info, Vector3 pos)
	{
		ChangeSound(info.AssetName, pos);
	}

	public void ChangeSound(string assetpath, Vector3 pos)
	{
		ChangePos(assetpath, pos);
	}

	public bool ChangeSoundPos(string assetpath, Vector3 pos)
	{
		return ChangePos(assetpath, pos);
	}

	public void PauseSound(ref AssetInfo info)
	{
		PauseSound(info.AssetName);
	}

	public void PauseSound(string assetpath)
	{
		Pause(assetpath);
	}

	public void ResumeSound(ref AssetInfo info)
	{
		ResumeSound(info.AssetName);
	}

	public void ResumeSound(string assetpath)
	{
		Resume(assetpath);
	}

	private bool IsInJob(string path)
	{
		foreach (KeyValuePair<int, List<IGameSound>> item in _soundDic)
		{
			foreach (IGameSound item2 in item.Value)
			{
				if (!string.IsNullOrEmpty(item2.PlayedRes) && item2.PlayedRes.Equals(path))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool IsPlaying(string path)
	{
		foreach (KeyValuePair<int, List<IGameSound>> item in _soundDic)
		{
			foreach (IGameSound item2 in item.Value)
			{
				if (!string.IsNullOrEmpty(item2.PlayedRes) && item2.PlayedRes.Equals(path) && item2.IsPlaying)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool ChangePos(string path, Vector3 pos)
	{
		foreach (KeyValuePair<int, List<IGameSound>> item in _soundDic)
		{
			foreach (IGameSound item2 in item.Value)
			{
				if (!string.IsNullOrEmpty(item2.PlayedRes) && item2.PlayedRes.Equals(path))
				{
					item2.ChangePos(pos);
					return true;
				}
			}
		}
		return false;
	}

	private bool Stop(string path)
	{
		foreach (KeyValuePair<int, List<IGameSound>> item in _soundDic)
		{
			foreach (IGameSound item2 in item.Value)
			{
				if (!string.IsNullOrEmpty(item2.PlayedRes) && item2.PlayedRes.Equals(path))
				{
					item2.Stop();
					return true;
				}
			}
		}
		return false;
	}

	private bool Pause(string path)
	{
		foreach (KeyValuePair<int, List<IGameSound>> item in _soundDic)
		{
			foreach (IGameSound item2 in item.Value)
			{
				if (!string.IsNullOrEmpty(item2.PlayedRes) && item2.PlayedRes.Equals(path))
				{
					item2.Pause();
					return true;
				}
			}
		}
		return false;
	}

	private bool Resume(string path)
	{
		foreach (KeyValuePair<int, List<IGameSound>> item in _soundDic)
		{
			foreach (IGameSound item2 in item.Value)
			{
				if (!string.IsNullOrEmpty(item2.PlayedRes) && item2.PlayedRes.Equals(path))
				{
					item2.Resume();
					return true;
				}
			}
		}
		return false;
	}
}
