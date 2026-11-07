using Assets.Sources.Components.Time;
using NetData;
using UnityEngine;

public class rpgBaseRunModelRpgBaseRunTaskUIProvider : IrpgBaseRunModelRpgBaseRunTaskUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgBaseRunModelRpgBaseRunTaskUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool checkTaskUIShow()
	{
		return _gameRuleContext.rpgBaseRunChallenge.IsUpdate;
	}

	public float updateAddNum()
	{
		return _gameRuleContext.rpgBaseRunChallenge.AddRewardNum;
	}

	public float updateMulNum()
	{
		return _gameRuleContext.rpgBaseRunChallenge.MulRewardNum;
	}

	public float updateTotalNum()
	{
		float num = (float)_gameRuleContext.rpgBaseRunChallenge.PveLevelRage / 1000f;
		return (float)_gameRuleContext.rpgBaseRunChallenge.TotalRewardNum * num;
	}

	public bool IsItemShowByIndex(int index)
	{
		if (!_gameRuleContext.rpgBaseRunChallenge.IsUpdate)
		{
			return false;
		}
		return index < _gameRuleContext.rpgBaseRunChallenge.TaskList.Count;
	}

	public bool IsItemAddDiByIndex(int index)
	{
		if (!_gameRuleContext.rpgBaseRunChallenge.IsUpdate)
		{
			return false;
		}
		if (index < _gameRuleContext.rpgBaseRunChallenge.TaskList.Count)
		{
			return _gameRuleContext.rpgBaseRunChallenge.TaskList[index].AddValue > 0;
		}
		return false;
	}

	public string updateTaskNameByIndex(int index)
	{
		if (!_gameRuleContext.rpgBaseRunChallenge.IsUpdate)
		{
			return "";
		}
		if (index < _gameRuleContext.rpgBaseRunChallenge.TaskList.Count)
		{
			return _gameRuleContext.rpgBaseRunChallenge.TaskList[index].Name;
		}
		return "";
	}

	public float updateTaskProgressByIndex(int index)
	{
		if (!_gameRuleContext.rpgBaseRunChallenge.IsUpdate)
		{
			return 0f;
		}
		if (index < _gameRuleContext.rpgBaseRunChallenge.TaskList.Count)
		{
			ChallengeMessageCellData challengeMessageCellData = _gameRuleContext.rpgBaseRunChallenge.TaskList[index];
			return Mathf.FloorToInt((float)challengeMessageCellData.Cur / (float)challengeMessageCellData.Total * 100f);
		}
		return 0f;
	}

	public float updateTaskScoreByIndex(int index)
	{
		if (!_gameRuleContext.rpgBaseRunChallenge.IsUpdate)
		{
			return 0f;
		}
		if (index < _gameRuleContext.rpgBaseRunChallenge.TaskList.Count)
		{
			ChallengeMessageCellData challengeMessageCellData = _gameRuleContext.rpgBaseRunChallenge.TaskList[index];
			return (challengeMessageCellData.AddValue > 0) ? challengeMessageCellData.AddValue : challengeMessageCellData.MulValue;
		}
		return 0f;
	}

	public float updatePercentNum()
	{
		if (!_gameRuleContext.rpgBaseRunChallenge.IsUpdate)
		{
			return 0f;
		}
		return _gameRuleContext.rpgBaseRunChallenge.PveLevelRage / 10;
	}

	public float updateLvl()
	{
		if (!_gameRuleContext.rpgBaseRunChallenge.IsUpdate)
		{
			return 0f;
		}
		return _gameRuleContext.rpgBaseRunChallenge.RewardLvlNum;
	}
}
