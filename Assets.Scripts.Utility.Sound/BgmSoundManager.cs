using System.Collections.Generic;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Scripts.Utility.Sound;

public class BgmSoundManager : MonoBehaviourSingleton<BgmSoundManager>
{
	public List<BgmSoundSoundConfig> soundConfigs = new List<BgmSoundSoundConfig>();

	private BgmSoundSoundConfig _playItem;

	private int _delayTime;

	private BattleRoomContext _battleRoomContext;

	public void Clear()
	{
		_battleRoomContext = null;
		soundConfigs.Clear();
	}

	public void playBgmSound(string freeConditionData, int delayTime)
	{
		if (_battleRoomContext == null)
		{
			_battleRoomContext = Contexts.sharedInstance.battleRoom;
		}
		int raceType = _battleRoomContext.roomData.Data.RaceType;
		BgmSoundSoundConfig bgmSoundSoundConfig = null;
		for (int i = 0; i < soundConfigs.Count; i++)
		{
			BgmSoundSoundConfig bgmSoundSoundConfig2 = soundConfigs[i];
			if (bgmSoundSoundConfig2.CheckCanPlay(raceType, freeConditionData))
			{
				bgmSoundSoundConfig = bgmSoundSoundConfig2;
				break;
			}
		}
		if (bgmSoundSoundConfig != null)
		{
			if (_playItem != null)
			{
				_playItem.Stop();
			}
			_playItem = bgmSoundSoundConfig;
			_delayTime = delayTime;
		}
	}

	private void Update()
	{
		if (_delayTime > 0)
		{
			_delayTime -= (int)(Time.deltaTime * 1000f);
		}
		if (_delayTime <= 0 && _playItem != null)
		{
			if (_playItem != null)
			{
				_playItem.Stop();
			}
			_playItem.Play();
			if (_playItem.Loop)
			{
				_delayTime = _playItem.CdTime;
			}
			else
			{
				_playItem = null;
			}
		}
	}
}
