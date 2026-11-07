using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgEndlessStatisticsModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private RpgEndlessStatisticsViewModel _viewModel;

	private string _myName;

	private const int MaxNum = 6;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgEndlessStatisticsViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		for (int i = 1; i <= 6; i++)
		{
			_viewModel.SetDescShow(i, value: false);
			_viewModel.SetRankIconShow(i, value: false);
		}
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_allKillInfo_Team2);
		for (int j = 0; j < 6; j++)
		{
			_viewModel.SetStatisticShow(j + 1, value: false);
			listNotify.AddEvent<OneKillInfoData, string>("PlayerName", UiIEventCondition.Get_OneKillInfoData_PlayerName, SetPlayerName, j);
			listNotify.AddEvent<OneKillInfoData, bool>("IsDead", UiIEventCondition.Get_OneKillInfoData_IsDead, SetIsDead, j);
			listNotify.AddEvent<OneKillInfoData, long>("Score", UiIEventCondition.Get_OneKillInfoData_Score, SetScore, j);
			listNotify.AddEvent<OneKillInfoData, float>("RelivePercent", UiIEventCondition.Get_pveScoreRank_RelivePercent, SetRelivePercent, j);
			listNotify.AddEvent<OneKillInfoData, long>("TotalScore", UiIEventCondition.Get_OneKillInfoData_TotalScore, SetTotalScore, j);
			listNotify.AddEvent<OneKillInfoData, long>("FirstScore", UiIEventCondition.Get_OneKillInfoData_FirstScore, SetFirstScore, j);
		}
		listNotify.ForceInvoke();
		_myName = UiIEventCondition.Get_uiMyPlayer_PlayerName();
	}

	private void SetFirstScore(OneKillInfoData val, int idx, long oldfs, long newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			SetRankIcon(idx, val);
		}
	}

	private void SetTotalScore(OneKillInfoData val, int idx, long oldfs, long newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			SetRatio(idx, val);
		}
	}

	private void SetRankIcon(int idx, OneKillInfoData data)
	{
		long firstScore = _gameRuleContext.pveScoreRank.FirstScore;
		_viewModel.SetRankIconShow(idx + 1, firstScore <= 0 || (float)data.Score / (float)firstScore < 0.3f);
	}

	private void SetRelivePercent(OneKillInfoData val, int idx, float oldfs, float newfs, ElementStatus status)
	{
		_viewModel.SetRelieveProgressBarFillamount(idx + 1, newfs);
	}

	private void SetScore(OneKillInfoData val, int idx, long oldfs, long newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			SetScore(idx, val);
			SetRatio(idx, val);
			SetRankIcon(idx, val);
		}
	}

	private void SetIsDead(OneKillInfoData val, int idx, bool oldfs, bool newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_viewModel.SetRelieveBgShow(idx + 1, newfs);
			_viewModel.SetReleiveImageShow(idx + 1, newfs);
			SetScore(idx, val);
			SetRatio(idx, val);
			SetRankIcon(idx, val);
			SetColor(idx, val);
		}
	}

	private void SetPlayerName(OneKillInfoData val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_viewModel.SetStatisticShow(idx + 1, value: true);
			_viewModel.SetPlayerNameString(idx + 1, newfs);
			SetColor(idx, val);
		}
		else
		{
			_viewModel.SetStatisticShow(idx + 1, value: false);
		}
	}

	private void SetScore(int idx, OneKillInfoData data)
	{
		_viewModel.SetScoreString(idx + 1, data.IsDead ? "" : data.Score.ToString());
	}

	private void SetColor(int idx, OneKillInfoData data)
	{
		if (data.IsDead)
		{
			_viewModel.SetPlayerNameTextcolor(idx + 1, new Color(0.598f, 0.598f, 0.598f));
		}
		else if (data.PlayerName == _myName)
		{
			_viewModel.SetPlayerNameTextcolor(idx + 1, new Color(0f, 1f, 0f));
		}
		else
		{
			_viewModel.SetPlayerNameTextcolor(idx + 1, new Color(0.266f, 0.805f, 0.961f));
		}
	}

	private void SetRatio(int idx, OneKillInfoData data)
	{
		long totalScore = _gameRuleContext.pveScoreRank.TotalScore;
		_viewModel.SetIntegralRatioString(idx + 1, data.IsDead ? "" : ((totalScore == 0L) ? "0%" : ((float)data.Score / (float)totalScore).ToString("P2")));
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
