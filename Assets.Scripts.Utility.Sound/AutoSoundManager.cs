using System;
using System.Collections.Generic;
using Assets.Sources.Config;
using Assets.Sources.Constant.Career;
using SSJJBase.Singleton;
using UnityEngine;
using share.constant;

namespace Assets.Scripts.Utility.Sound;

public class AutoSoundManager : MonoBehaviourSingleton<AutoSoundManager>
{
	private AutoSoundEventConfig _nowEventConfig;

	private AutoSoundItemConfig _nowItemConfig;

	private int _cdTime;

	public List<AutoSoundEventConfig> AutoConfigs = new List<AutoSoundEventConfig>();

	private Dictionary<long, Dictionary<string, List<int>>> _playerAutoSoundInfoDataDic;

	private string _lastCareer;

	private PlayerEntity GetPlayerEntity(int id)
	{
		if (id == 0)
		{
			return Contexts.sharedInstance.player.myPlayerEntity;
		}
		if (id > 0)
		{
			return Contexts.sharedInstance.player.GetEntityWithEntityId(id);
		}
		return null;
	}

	public void OnAutoSound(AutoSoundEventType eventType, int playerId = 0, object para = null, string careerName = null)
	{
		PlayerEntity playerEntity = GetPlayerEntity(playerId);
		AutoSoundEventConfig autoSoundEventConfig = null;
		for (int i = 0; i < AutoConfigs.Count; i++)
		{
			if (AutoConfigs[i].EventType.Equals(eventType.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				autoSoundEventConfig = AutoConfigs[i];
				break;
			}
		}
		if (autoSoundEventConfig == null || !CheckCanPlaySound(autoSoundEventConfig))
		{
			return;
		}
		AutoSoundItemConfig itemConfig = GetItemConfig(autoSoundEventConfig, playerEntity, para, careerName);
		if (itemConfig != null)
		{
			if (_nowItemConfig != null && _nowItemConfig.Cankill)
			{
				_nowItemConfig.Stop();
			}
			itemConfig.Play();
			_nowEventConfig = autoSoundEventConfig;
			_nowItemConfig = itemConfig;
			_cdTime = itemConfig.CdTime;
		}
	}

	private void Update()
	{
		if (_cdTime > 0)
		{
			_cdTime -= (int)(Time.deltaTime * 1000f);
			if (_cdTime <= 0)
			{
				_cdTime = 0;
				_nowEventConfig = null;
				_nowItemConfig = null;
			}
		}
		CheckChangeCareer();
	}

	private void CheckChangeCareer()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity == null)
		{
			return;
		}
		string career = myPlayerEntity.GetCareer();
		if (!string.IsNullOrEmpty(_lastCareer) && !string.IsNullOrEmpty(career))
		{
			if (!_lastCareer.Equals(career) && (PlayerCareerConstantUtility.IsDoun(career) || PlayerCareerConstantUtility.IsEmpress(career)))
			{
				OnAutoSound(AutoSoundEventType.ChangeBio, 0, null, career);
			}
			if (PlayerCareerUtil.IsHumanity(_lastCareer) && PlayerCareerConstantUtility.IsHero(career) && 29 != Contexts.sharedInstance.battleRoom.roomData.Data.RaceType)
			{
				OnAutoSound(AutoSoundEventType.ChangeHero, 0, null, _lastCareer);
			}
		}
		_lastCareer = career;
	}

	private bool CheckCanPlaySound(AutoSoundEventConfig playSoundEvent)
	{
		if (playSoundEvent.CanClose && GameSetting.Config.AutoSound == 1)
		{
			return false;
		}
		if (_nowEventConfig != null && playSoundEvent.EventPriority < _nowEventConfig.EventPriority)
		{
			return false;
		}
		if ((float)playSoundEvent.Probability / 100f < UnityEngine.Random.Range(0f, 1f))
		{
			return false;
		}
		return true;
	}

	private AutoSoundItemConfig GetItemConfig(AutoSoundEventConfig playSoundEvent, PlayerEntity player, object para, string careerName)
	{
		if (player == null)
		{
			return null;
		}
		if (string.IsNullOrEmpty(careerName))
		{
			careerName = player.GetCareer();
		}
		List<AutoSoundItemConfig> list = new List<AutoSoundItemConfig>();
		for (int i = 0; i < playSoundEvent.SoundItems.Count; i++)
		{
			AutoSoundItemConfig autoSoundItemConfig = playSoundEvent.SoundItems[i];
			Dictionary<string, List<int>> value = null;
			List<int> value2 = null;
			if (_playerAutoSoundInfoDataDic != null && _playerAutoSoundInfoDataDic.TryGetValue(player.basicInfo.Cid, out value))
			{
				value.TryGetValue(careerName, out value2);
			}
			if (autoSoundItemConfig.CheckCanPlay(playSoundEvent.EventType, careerName, value2, para) && (_nowItemConfig == null || _nowEventConfig == null || !playSoundEvent.EventType.Equals(_nowEventConfig.EventType) || _nowItemConfig.SoundPriority <= autoSoundItemConfig.SoundPriority))
			{
				list.Add(autoSoundItemConfig);
			}
		}
		bool flag = false;
		for (int j = 0; j < list.Count; j++)
		{
			if (!list[j].IsDefault)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			for (int k = 0; k < list.Count; k++)
			{
				if (list[k].IsDefault)
				{
					list.RemoveAt(k);
					k--;
				}
			}
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		return null;
	}

	public void SetPlayerAutoSoundInfo(long cid, Dictionary<string, List<int>> dictionary)
	{
		if (_playerAutoSoundInfoDataDic == null)
		{
			_playerAutoSoundInfoDataDic = new Dictionary<long, Dictionary<string, List<int>>>();
		}
		if (_playerAutoSoundInfoDataDic.ContainsKey(cid))
		{
			_playerAutoSoundInfoDataDic[cid] = dictionary;
		}
		else
		{
			_playerAutoSoundInfoDataDic.Add(cid, dictionary);
		}
	}

	public void RemovePlayerAutoSoundInfo(long cid)
	{
		if (_playerAutoSoundInfoDataDic != null)
		{
			_playerAutoSoundInfoDataDic.Remove(cid);
		}
	}
}
