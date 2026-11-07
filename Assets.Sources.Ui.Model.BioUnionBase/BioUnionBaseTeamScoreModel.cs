using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.BioUnionBase;

public class BioUnionBaseTeamScoreModel : AbstractModel, IPlaybackSystem
{
	private const int MaxTeamMember = 32;

	protected BiochemicalteamscoreViewModel _viewModel;

	private int _lastHumanityCount = -1;

	private int _lastVariantsCount = -1;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
	}

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel = new BiochemicalteamscoreViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/biounionbase";
		_viewModel.ResourceAssetName = "bioUnionBase_TeamScore";
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_broadcastScore_CurrentScore, SetCurrentScore, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_broadcastScore_Team1Score, SetTeam1Score, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_broadcastScore_Team2Score, SetTeam2Score, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_broadcastScore_WinScore, SetWinScore, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Minutes, SetMinutes, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Seconds, SetSeconds, null, initinvoke: true);
		NotifyManager.MakeNotifyClass(19, UiIEventCondition.Get_allKillInfo_All, SetAll, initinvoke: true);
	}

	private void SetSeconds(int arg1, int arg2)
	{
		_viewModel.SecondsString = StringCache.IntToStringD2(arg2);
	}

	private void SetMinutes(int arg1, int arg2)
	{
		_viewModel.MinutesString = StringCache.IntToStringD2(arg2);
	}

	private void SetWinScore(int arg1, int arg2)
	{
		_viewModel.WinConditionString2 = StringCache.IntToString(arg2);
	}

	private void SetTeam2Score(long arg1, long arg2)
	{
		_viewModel.TeamScoreString1 = StringCache.LongToString(arg2);
	}

	private void SetTeam1Score(long arg1, long arg2)
	{
		_viewModel.TeamScoreString2 = StringCache.LongToString(arg2);
	}

	private void SetCurrentScore(int arg1, int arg2)
	{
		_viewModel.WinConditionString1 = StringCache.IntToString(arg2);
	}

	public void OnPlayback()
	{
	}

	protected virtual void SetAll(List<OneKillInfoData> ov, List<OneKillInfoData> allKillInfo)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < allKillInfo.Count; i++)
		{
			if (!allKillInfo[i].IsDead)
			{
				if (allKillInfo[i].Team == 1)
				{
					num++;
				}
				else
				{
					num2++;
				}
			}
		}
		if (num != _lastHumanityCount)
		{
			_lastHumanityCount = num;
			for (int j = 0; j < 32; j++)
			{
				if (j < num)
				{
					_viewModel.SetLiveShow(j + 1, value: true);
				}
				else
				{
					_viewModel.SetLiveShow(j + 1, value: false);
				}
			}
		}
		if (num2 == _lastVariantsCount)
		{
			return;
		}
		_lastVariantsCount = num2;
		for (int k = 0; k < 32; k++)
		{
			if (k < num2)
			{
				_viewModel.SetCtLiveShow(k + 1, value: true);
			}
			else
			{
				_viewModel.SetCtLiveShow(k + 1, value: false);
			}
		}
	}
}
