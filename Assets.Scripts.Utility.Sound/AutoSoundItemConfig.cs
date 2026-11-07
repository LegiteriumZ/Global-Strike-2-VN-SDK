using System;
using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Utils.Sound;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using share.constant;

namespace Assets.Scripts.Utility.Sound;

public class AutoSoundItemConfig
{
	internal class KillPara
	{
		private int _start;

		private int _end;

		public void Parse(string para)
		{
			if (!string.IsNullOrEmpty(para) && para.Contains("|"))
			{
				string[] array = para.Split('|');
				_start = int.Parse(array[0]);
				_end = int.Parse(array[1]);
			}
		}

		public bool CheckIsIn(int para)
		{
			if (para >= _start && para <= _end)
			{
				return true;
			}
			return false;
		}
	}

	public int CdTime;

	public int CodeName;

	public string SoundUrl;

	public List<int> RuleTypeList;

	public bool AllRule;

	public bool AllPvpRule;

	public bool AllPveRule;

	public bool AllRpgRule;

	public bool AllBioRule;

	public bool AllExplodRule;

	public List<string> CareerList;

	public bool AllHumanity;

	public bool AllDoun;

	public int IsMan;

	public bool IsDefault;

	public int SoundPriority;

	public bool Cankill;

	public bool CanUse;

	public string FreeCondition;

	private KillPara _killPara;

	private AssetInfo _resInfo;

	public void Init()
	{
		_resInfo = new AssetInfo("sound/autosound", $"Assets/Res/Assets/sound/autosound/{SoundUrl}");
		_killPara = new KillPara();
		_killPara.Parse(FreeCondition);
	}

	public void Stop()
	{
		MonoBehaviourSingleton<GameSoundManager>.Instance.StopSound(ref _resInfo);
	}

	public void Play()
	{
		MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Scene, isMyself: true, _resInfo, GameSoundManager.Config.EnvironmentVolume);
	}

	public bool CheckCanPlay(string eventType, string career, List<int> codeNameList, object para)
	{
		if (eventType.Equals(AutoSoundEventType.Kills.ToString(), StringComparison.InvariantCultureIgnoreCase) && !_killPara.CheckIsIn((int)para))
		{
			return false;
		}
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (RuleUtilty.IsBioMode(raceType) && (PlayerCareerConstantUtility.IsDoun(career) || PlayerCareerConstantUtility.IsEmpress(career)) && (eventType.Equals(AutoSoundEventType.FirstBlood.ToString(), StringComparison.OrdinalIgnoreCase) || eventType.Equals(AutoSoundEventType.Kills.ToString(), StringComparison.OrdinalIgnoreCase)))
		{
			if (!CheckManBio(career))
			{
				return false;
			}
			return true;
		}
		if (RuleUtilty.IsBioUnion(raceType) && (PlayerCareerConstantUtility.IsDoun(career) || PlayerCareerConstantUtility.IsEmpress(career)))
		{
			if (eventType.Equals(AutoSoundEventType.FirstBlood.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return IsMan == 0;
			}
			if (eventType.Equals(AutoSoundEventType.Kills.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				if ((int)para <= 1)
				{
					return IsMan != 0;
				}
				return IsMan == 0;
			}
		}
		if (!CheckRule(raceType))
		{
			return false;
		}
		if (!CheckCodeName(codeNameList))
		{
			return false;
		}
		if (!CheckCareer(career))
		{
			return false;
		}
		if (!CheckMan(career))
		{
			return false;
		}
		return true;
	}

	private bool CheckCareer(string career)
	{
		if (string.IsNullOrEmpty(career))
		{
			return false;
		}
		if (AllHumanity && (PlayerCareerUtil.IsHumanity(career) || PlayerCareerConstantUtility.IsHero(career)))
		{
			return true;
		}
		if (AllDoun && (PlayerCareerConstantUtility.IsDoun(career) || PlayerCareerConstantUtility.IsEmpress(career)))
		{
			return true;
		}
		for (int i = 0; i < CareerList.Count; i++)
		{
			if (CareerList[i] == career)
			{
				return true;
			}
		}
		return false;
	}

	public bool CheckMan(string career)
	{
		if (IsMan == -1)
		{
			return true;
		}
		if (string.IsNullOrEmpty(career))
		{
			return false;
		}
		if (IsMan == 0 && (PlayerCareerUtil.IsWoman(career) || PlayerCareerConstantUtility.IsFemale(career)))
		{
			return true;
		}
		if (IsMan == 1 && !PlayerCareerConstantUtility.IsFemale(career) && !PlayerCareerUtil.IsWoman(career) && !PlayerCareerConstantUtility.IsDoun(career) && !PlayerCareerConstantUtility.IsEmpress(career))
		{
			return true;
		}
		return false;
	}

	public bool CheckManBio(string career)
	{
		if (IsMan == -1)
		{
			return true;
		}
		if (string.IsNullOrEmpty(career))
		{
			return false;
		}
		if (IsMan == 0 && (PlayerCareerUtil.IsWoman(career) || PlayerCareerConstantUtility.IsFemale(career)))
		{
			return true;
		}
		if (IsMan == 1 && !PlayerCareerConstantUtility.IsFemale(career) && !PlayerCareerUtil.IsWoman(career))
		{
			return true;
		}
		return false;
	}

	private bool CheckCodeName(List<int> codeNameList)
	{
		if (!IsDefault)
		{
			if (codeNameList != null)
			{
				for (int i = 0; i < codeNameList.Count; i++)
				{
					if (codeNameList[i] == CodeName)
					{
						return true;
					}
				}
			}
			return false;
		}
		return true;
	}

	private bool CheckRule(int raceType)
	{
		if (AllRule)
		{
			return true;
		}
		if (AllBioRule && RuleUtilty.IsBioMode(raceType))
		{
			return true;
		}
		if (AllExplodRule && RuleUtilty.IsExplode(raceType))
		{
			return true;
		}
		if (AllPvpRule && !RuleUtilty.IsPveModel(raceType))
		{
			return true;
		}
		if (AllRpgRule && RuleUtilty.IsGeneralPve(raceType))
		{
			return true;
		}
		if (AllPveRule && RuleUtilty.IsOldPve(raceType))
		{
			return true;
		}
		for (int i = 0; i < RuleTypeList.Count; i++)
		{
			if (RuleTypeList[i] == raceType)
			{
				return true;
			}
		}
		return false;
	}
}
