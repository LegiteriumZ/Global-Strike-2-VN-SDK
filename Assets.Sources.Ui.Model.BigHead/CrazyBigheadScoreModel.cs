using System;
using System.Collections.Generic;
using Assets.Sources.Components.GameRule.BigHead;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.BigHead;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.BigHead;

[GameUiTest]
public class CrazyBigheadScoreModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private CrazyBigheadScoreViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new CrazyBigheadScoreViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
			UpdateMessage();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		CrazyBigheadScoreViewModel viewModel = _viewModel;
		string ctScoreString = (_viewModel.TScoreString = "0");
		viewModel.CtScoreString = ctScoreString;
		CrazyBigheadScoreViewModel viewModel2 = _viewModel;
		CrazyBigheadScoreViewModel viewModel3 = _viewModel;
		CrazyBigheadScoreViewModel viewModel4 = _viewModel;
		CrazyBigheadScoreViewModel viewModel5 = _viewModel;
		CrazyBigheadScoreViewModel viewModel6 = _viewModel;
		bool flag2 = (_viewModel.TProgressShow = false);
		bool flag4 = (viewModel6.CrazyTProgressShow = flag2);
		bool flag6 = (viewModel5.CrazyTShow = flag4);
		bool flag8 = (viewModel4.CtProgressShow = flag6);
		bool crazyCtShow = (viewModel3.CrazyCtProgressShow = flag8);
		viewModel2.CrazyCtShow = crazyCtShow;
	}

	private void UpdateMessage()
	{
		if (_gameRuleContext.crazyBigHead.CrazyData != null)
		{
			UpdateScore();
			UpdateProgress();
		}
	}

	private void UpdateScore()
	{
		Dictionary<int, CrazyBigHeadComponent.CrazyTeamData> crazyTeamDic = _gameRuleContext.crazyBigHead.CrazyTeamDic;
		_viewModel.CtScoreString = GetScore(2, crazyTeamDic);
		_viewModel.TScoreString = GetScore(1, crazyTeamDic);
		UpdateTeamScore(1, crazyTeamDic);
		UpdateTeamScore(2, crazyTeamDic);
	}

	private string GetScore(int team, Dictionary<int, CrazyBigHeadComponent.CrazyTeamData> dic)
	{
		CrazyBigHeadComponent.CrazyTeamData crazyTeamData = dic[team];
		if (crazyTeamData.CrazyType == CrazyBigHeadMessageType.CRAZYTIME)
		{
			if (crazyTeamData.MaxCrazyTime != 0)
			{
				return StringCache.IntToString(Convert.ToInt32((float)crazyTeamData.Score * 1f / (float)crazyTeamData.MaxCrazyTime * 1f * (float)crazyTeamData.MaxScore));
			}
			return StringCache.IntToString(0);
		}
		return StringCache.IntToString(crazyTeamData.Score);
	}

	private void UpdateTeamScore(int team, Dictionary<int, CrazyBigHeadComponent.CrazyTeamData> dic)
	{
		CrazyBigHeadComponent.CrazyTeamData crazyTeamData = dic[team];
		if (crazyTeamData.CrazyType == CrazyBigHeadMessageType.CRAZYTIME)
		{
			crazyTeamData.Score -= _timeComponent.FrameInterval;
			if (crazyTeamData.Score <= 0)
			{
				crazyTeamData.Score = 0;
				crazyTeamData.CrazyType = CrazyBigHeadMessageType.TEAMCRAZYDATA;
			}
		}
	}

	private void UpdateProgress()
	{
		Dictionary<int, CrazyBigHeadComponent.CrazyTeamData> crazyTeamDic = _gameRuleContext.crazyBigHead.CrazyTeamDic;
		if (GetProgressVisiable(2, crazyTeamDic))
		{
			CrazyBigheadScoreViewModel viewModel = _viewModel;
			bool crazyCtShow = (_viewModel.CrazyCtProgressShow = false);
			viewModel.CrazyCtShow = crazyCtShow;
			_viewModel.CtProgressShow = true;
			_viewModel.CtProgressFillamount = GetProgress(2, crazyTeamDic);
		}
		else
		{
			CrazyBigheadScoreViewModel viewModel2 = _viewModel;
			bool crazyCtShow = (_viewModel.CrazyCtProgressShow = true);
			viewModel2.CrazyCtShow = crazyCtShow;
			_viewModel.CtProgressShow = false;
			_viewModel.CrazyCtProgressFillamount = GetProgress(2, crazyTeamDic);
		}
		if (GetProgressVisiable(1, crazyTeamDic))
		{
			CrazyBigheadScoreViewModel viewModel3 = _viewModel;
			bool crazyCtShow = (_viewModel.CrazyTProgressShow = false);
			viewModel3.CrazyTShow = crazyCtShow;
			_viewModel.TProgressShow = true;
			_viewModel.TProgressFillamount = GetProgress(1, crazyTeamDic);
		}
		else
		{
			CrazyBigheadScoreViewModel viewModel4 = _viewModel;
			bool crazyCtShow = (_viewModel.CrazyTProgressShow = true);
			viewModel4.CrazyTShow = crazyCtShow;
			_viewModel.TProgressShow = false;
			_viewModel.CrazyTProgressFillamount = GetProgress(1, crazyTeamDic);
		}
	}

	private bool GetProgressVisiable(int team, Dictionary<int, CrazyBigHeadComponent.CrazyTeamData> dic)
	{
		return dic[team].CrazyType == CrazyBigHeadMessageType.TEAMCRAZYDATA;
	}

	private float GetProgress(int team, Dictionary<int, CrazyBigHeadComponent.CrazyTeamData> dic)
	{
		CrazyBigHeadComponent.CrazyTeamData crazyTeamData = dic[team];
		if (crazyTeamData.CrazyType == CrazyBigHeadMessageType.CRAZYTIME)
		{
			return (float)crazyTeamData.Score * 1f / (float)crazyTeamData.MaxCrazyTime;
		}
		return (float)crazyTeamData.Score * 1f / (float)crazyTeamData.MaxScore;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
