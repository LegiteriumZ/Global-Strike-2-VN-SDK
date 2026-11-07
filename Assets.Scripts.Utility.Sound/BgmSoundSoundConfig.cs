using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Utils.Sound;
using SSJJAsset.Asset;
using SSJJBase.Singleton;

namespace Assets.Scripts.Utility.Sound;

public class BgmSoundSoundConfig
{
	internal class RaceTypeListCondition
	{
		private List<RaceTypeRange> raceList;

		public void Parse(string para)
		{
			raceList = new List<RaceTypeRange>();
			if (string.IsNullOrEmpty(para))
			{
				return;
			}
			string[] array = para.Split(',');
			foreach (string text in array)
			{
				RaceTypeRange raceTypeRange = new RaceTypeRange();
				int num = 0;
				int num2 = 0;
				if (text.Contains("-"))
				{
					string[] array2 = text.Split('-');
					num = int.Parse(array2[0]);
					num2 = int.Parse(array2[1]);
				}
				else
				{
					num = int.Parse(text);
					num2 = int.Parse(text);
				}
				raceTypeRange.init(num, num2);
				raceList.Add(raceTypeRange);
			}
		}

		public bool CheckIsIn(int para)
		{
			for (int i = 0; i < raceList.Count; i++)
			{
				if (raceList[i].CheckIsIn(para))
				{
					return true;
				}
			}
			return false;
		}
	}

	internal class RaceTypeRange
	{
		private int _minRaceType;

		private int _maxRaceType;

		public void init(int min, int max)
		{
			_minRaceType = min;
			_maxRaceType = max;
		}

		public bool CheckIsIn(int raceType)
		{
			if (raceType >= _minRaceType && raceType <= _maxRaceType)
			{
				return true;
			}
			return false;
		}
	}

	public int CdTime;

	public string SoundUrl;

	private RaceTypeListCondition RuleTypeList;

	public string FreeCondition;

	public bool Loop;

	public float vol;

	private AssetInfo _resInfo;

	public void parseRuleTypeList(string param)
	{
		if (RuleTypeList == null)
		{
			RuleTypeList = new RaceTypeListCondition();
		}
		RuleTypeList.Parse(param);
	}

	public void Init()
	{
		_resInfo = new AssetInfo("sound/bgm", $"Assets/Res/Assets/sound/bgm/{SoundUrl}");
	}

	public void Stop()
	{
		MonoBehaviourSingleton<GameSoundManager>.Instance.StopSound(ref _resInfo);
	}

	public void Play()
	{
		MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Scene, isMyself: true, _resInfo, GameSoundManager.Config.BgmSpeakVolume * vol);
	}

	public bool CheckCanPlay(int raceType, string freeConditionData)
	{
		if (!RuleTypeList.CheckIsIn(raceType))
		{
			return false;
		}
		if (freeConditionData != FreeCondition)
		{
			return false;
		}
		return true;
	}
}
