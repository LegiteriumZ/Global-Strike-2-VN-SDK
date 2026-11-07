using System.Collections.Generic;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZTeamScoreModel : AbstractModel, IPlaybackSystem
{
	private Biochemical3TeamScoreViewModel _viewModel;

	private const int MaxTeamMember = 24;

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
		_viewModel = new Biochemical3TeamScoreViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/biochemical_z";
		_viewModel.ResourceAssetName = "BioChemical_ZTeamScore";
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_broadcastScore_CurrentScore, SetCurrentScore, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_broadcastScore_Team1Score, SetTeam1Score, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_broadcastScore_Team2Score, SetTeam2Score, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_WinScore, SetWinScore, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Minutes, SetMinutes, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Seconds, SetSeconds, null, initinvoke: true);
		NotifyManager.MakeNotifyClass(19, UiIEventCondition.Get_allKillInfo_All, SetAll, initinvoke: true);
	}

	private void SetSeconds(int arg1, int arg2)
	{
		_viewModel.SecondsString = arg2.ToString("D2");
	}

	private void SetMinutes(int arg1, int arg2)
	{
		_viewModel.MinutesString = arg2.ToString("D2");
	}

	private void SetWinScore(int arg1, int arg2)
	{
		_viewModel.WinConditionString2 = arg2.ToString();
	}

	private void SetTeam2Score(long arg1, long arg2)
	{
		_viewModel.TeamScoreString1 = arg2.ToString();
	}

	private void SetTeam1Score(long arg1, long arg2)
	{
		_viewModel.TeamScoreString2 = arg2.ToString();
	}

	private void SetCurrentScore(int arg1, int arg2)
	{
		_viewModel.WinConditionString1 = arg2.ToString();
	}

	public void OnPlayback()
	{
	}

	private void SetAll(List<OneKillInfoData> ov, List<OneKillInfoData> allKillInfo)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < allKillInfo.Count; i++)
		{
			if (!allKillInfo[i].IsDead)
			{
				if (PlayerCareerConstantUtility.IsHumanity(allKillInfo[i].Career) || PlayerCareerConstantUtility.IsHero(allKillInfo[i].Career))
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
			for (int j = 0; j < 24; j++)
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
		for (int k = 0; k < 24; k++)
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
