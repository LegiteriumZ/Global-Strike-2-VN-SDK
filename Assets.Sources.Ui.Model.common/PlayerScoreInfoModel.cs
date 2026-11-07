using System;
using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class PlayerScoreInfoModel : AbstractModel, IPlaybackSystem
{
	public enum ScoreType
	{
		Kill,
		Kill5,
		Kill10,
		Kill50,
		Kill100,
		Assist,
		Assist5,
		Assist10,
		Assist50,
		Assist100,
		HeadShot,
		KniefKill
	}

	private PlayerScoreInfoViewModel _viewModel = new PlayerScoreInfoViewModel();

	private List<ScoreType> _scoreHistory = new List<ScoreType>();

	private Stack<ScoreType> _scoreStack = new Stack<ScoreType>();

	private Dictionary<ScoreType, string> _scoreNames = new Dictionary<ScoreType, string>();

	private Dictionary<ScoreType, int> _showScoreDictionary = new Dictionary<ScoreType, int>();

	private List<ScoreType> _showQueue = new List<ScoreType>();

	private bool _changed;

	protected override IUiViewModel ViewModel => _viewModel;

	public Dictionary<ScoreType, string> ScoreNames => _scoreNames;

	protected override void OnGameobjectInitialized()
	{
		base.OnGameobjectInitialized();
		InitCollections();
	}

	private void InitCollections()
	{
		_scoreNames.Clear();
		_scoreNames.Add(ScoreType.Assist, "SingleAssist");
		_scoreNames.Add(ScoreType.Assist5, "FiveAssist");
		_scoreNames.Add(ScoreType.Assist10, "TenAssist");
		_scoreNames.Add(ScoreType.Assist50, "FiftyAssist");
		_scoreNames.Add(ScoreType.Assist100, "HundredAssist");
		_scoreNames.Add(ScoreType.Kill, "SingleKill");
		_scoreNames.Add(ScoreType.Kill5, "FiveKill");
		_scoreNames.Add(ScoreType.Kill10, "TenKill");
		_scoreNames.Add(ScoreType.Kill50, "FiftyKill");
		_scoreNames.Add(ScoreType.Kill100, "HundredKill");
		_scoreNames.Add(ScoreType.HeadShot, "HeadShot");
		_showQueue.Clear();
		_showQueue.Add(ScoreType.Kill100);
		_showQueue.Add(ScoreType.Kill50);
		_showQueue.Add(ScoreType.Kill10);
		_showQueue.Add(ScoreType.Kill5);
		_showQueue.Add(ScoreType.Kill);
		_showQueue.Add(ScoreType.Assist100);
		_showQueue.Add(ScoreType.Assist50);
		_showQueue.Add(ScoreType.Assist10);
		_showQueue.Add(ScoreType.Assist5);
		_showQueue.Add(ScoreType.Assist);
		_showQueue.Add(ScoreType.HeadShot);
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		if (RuleUtilty.IsOldPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			_viewModel.ShowAnchoredposition = new Vector2(935f, 0f);
		}
		for (int i = 1; i <= 20; i++)
		{
			_viewModel.SetSlotShow(i, value: false);
		}
		NotifyManager.MakeNotifyClass(22, UiIEventCondition.Get_killPlayerInfo_InfoList, SetInfoList, initinvoke: true);
		NotifyManager.MakeNotify(35, UiIEventCondition.Get_assistsNumData_AssistsNum, SetAssistsNum);
	}

	private void SetInfoList(Queue<KillPlayerInfoData> ov, Queue<KillPlayerInfoData> infoList)
	{
		if (infoList == null)
		{
			this.LogError("KillPlayerInfos is null !!");
		}
		else
		{
			if (infoList.Count <= 0)
			{
				return;
			}
			foreach (KillPlayerInfoData info in infoList)
			{
				if (info.KillPlayerId == UiIEventCondition.Get_uiMyPlayer_PlayerId())
				{
					_changed = true;
					_scoreHistory.Add(info.Headshot ? ScoreType.HeadShot : ScoreType.Kill);
				}
			}
		}
	}

	private void SetAssistsNum(int ov, int assistsNum)
	{
		if (assistsNum > 0)
		{
			_scoreHistory.Add(ScoreType.Assist);
			_changed = true;
		}
	}

	public void OnPlayback()
	{
		RefreshScoreHistoryShow();
	}

	private void RefreshScoreHistoryShow()
	{
		if (!_changed)
		{
			return;
		}
		_changed = false;
		_viewModel.ShowShow = true;
		int num = 0;
		int num2 = 0;
		_scoreStack.Clear();
		foreach (ScoreType item in _scoreHistory)
		{
			switch (item)
			{
			case ScoreType.Kill:
			case ScoreType.HeadShot:
				num++;
				break;
			case ScoreType.Assist:
				num2++;
				break;
			}
			_scoreStack.Push(item);
		}
		SetScore(num, num2, _scoreStack);
	}

	private void SetScore(int allkill, int allassist, Stack<ScoreType> scoreStack)
	{
		int value = allkill / 100;
		int value2 = allkill % 100 / 50;
		int value3 = allkill % 50 / 10;
		int value4 = allkill % 10 / 5;
		int value5 = allkill % 5;
		int value6 = allassist / 100;
		int value7 = allassist % 100 / 50;
		int value8 = allassist % 50 / 10;
		int value9 = allassist % 10 / 5;
		int value10 = allassist % 5;
		_showScoreDictionary[ScoreType.Kill100] = value;
		_showScoreDictionary[ScoreType.Assist100] = value6;
		_showScoreDictionary[ScoreType.Kill50] = value2;
		_showScoreDictionary[ScoreType.Assist50] = value7;
		_showScoreDictionary[ScoreType.Kill10] = value3;
		_showScoreDictionary[ScoreType.Assist10] = value8;
		_showScoreDictionary[ScoreType.Kill5] = value4;
		_showScoreDictionary[ScoreType.Assist5] = value9;
		_showScoreDictionary[ScoreType.Kill] = value5;
		_showScoreDictionary[ScoreType.Assist] = value10;
		int i = 0;
		foreach (ScoreType item in _showQueue)
		{
			if (!_showScoreDictionary.ContainsKey(item))
			{
				continue;
			}
			int num = _showScoreDictionary[item];
			for (int j = 0; j < num; j++)
			{
				SetSlotScore(i + j, item);
			}
			if (item == ScoreType.Kill)
			{
				List<int> list = new List<int>();
				int num2 = 0;
				while (num2 < num)
				{
					num2++;
					if (scoreStack.Pop() == ScoreType.HeadShot)
					{
						list.Add(num - num2);
					}
				}
				foreach (int item2 in list)
				{
					SetSlotScore(i + item2, ScoreType.HeadShot);
				}
			}
			i += num;
		}
		for (; i < 20; i++)
		{
			_viewModel.SetSlotShow(i + 1, value: false);
		}
	}

	private void SetSlotScore(int index, ScoreType type)
	{
		foreach (ScoreType value in Enum.GetValues(typeof(ScoreType)))
		{
			SetActiveByType(value, index + 1, value == type);
		}
		_viewModel.SetSlotShow(index + 1, value: true);
	}

	private void SetActiveByType(ScoreType type, int index, bool val)
	{
		switch (type)
		{
		case ScoreType.Assist:
			_viewModel.SetSingleAssistEnabled(index, val);
			break;
		case ScoreType.Assist5:
			_viewModel.SetFiveAssistEnabled(index, val);
			break;
		case ScoreType.Assist10:
			_viewModel.SetTenAssistEnabled(index, val);
			break;
		case ScoreType.Assist50:
			_viewModel.SetFiftyAssistEnabled(index, val);
			break;
		case ScoreType.Assist100:
			_viewModel.SetHundredAssistEnabled(index, val);
			break;
		case ScoreType.Kill:
			_viewModel.SetSingleKillEnabled(index, val);
			break;
		case ScoreType.Kill5:
			_viewModel.SetFiveKillEnabled(index, val);
			break;
		case ScoreType.Kill10:
			_viewModel.SetTenKillEnabled(index, val);
			break;
		case ScoreType.Kill50:
			_viewModel.SetFiftyKillEnabled(index, val);
			break;
		case ScoreType.Kill100:
			_viewModel.SetHundredKillEnabled(index, val);
			break;
		case ScoreType.HeadShot:
			_viewModel.SetHeadShotEnabled(index, val);
			break;
		}
	}
}
