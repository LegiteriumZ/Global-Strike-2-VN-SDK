using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Group;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.Group;

[GameUiTest]
public class SurvivalTeamScoreModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private SurvivalTeamScoreViewModel _viewModel;

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
		_viewModel = new SurvivalTeamScoreViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_broadcastScore_Team1Score, SetTeam1Score, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_broadcastScore_Team2Score, SetTeam2Score, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Minutes, SetMinutes, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Seconds, SetSeconds, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_WinScore, SetWinScore, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_WinCondition, SetWinCondition, null, initinvoke: true);
	}

	private void SetWinCondition(int arg1, int arg2)
	{
		UpdateWinCondition();
	}

	private void SetWinScore(int arg1, int arg2)
	{
		UpdateWinCondition();
	}

	private void SetSeconds(int arg1, int arg2)
	{
		_viewModel.SecondsString = StringCache.IntToStringD2(arg2);
	}

	private void SetMinutes(int arg1, int arg2)
	{
		_viewModel.MinutesString = StringCache.IntToStringD2(arg2);
	}

	private void SetTeam2Score(long arg1, long arg2)
	{
		_viewModel.TeamScoreString2 = StringCache.LongToString(arg2);
	}

	private void SetTeam1Score(long arg1, long arg2)
	{
		_viewModel.TeamScoreString1 = StringCache.LongToString(arg2);
	}

	private void UpdateWinCondition()
	{
		_viewModel.WinConditionString = ((_battleRoomContext.roomData.Data.WinCondition == 2) ? "" : _battleRoomContext.roomData.Data.WinScore.ToString());
	}
}
