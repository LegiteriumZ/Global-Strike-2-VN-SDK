using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Group;
using Assets.Sources.Utils;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Group;

public class TeamScoreModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext
{
	protected readonly TeamscoreViewModel _viewModel = new TeamscoreViewModel();

	private bool _isChange;

	private BattleRoomContext _battleRoomContext;

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/teamscore/teamScore1.png");
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

	protected virtual void SetTeam2Score(long arg1, long arg2)
	{
		_viewModel.TeamScoreString2 = StringCache.LongToString(arg2);
	}

	protected virtual void SetTeam1Score(long arg1, long arg2)
	{
		_viewModel.TeamScoreString1 = StringCache.LongToString(arg2);
	}

	private void UpdateWinCondition()
	{
		_viewModel.WinConditionString = ((_battleRoomContext.roomData.Data.WinCondition == 2) ? "" : StringCache.IntToString(_battleRoomContext.roomData.Data.WinScore));
	}

	public void OnPlayback()
	{
		CheckScreen();
	}

	private void CheckScreen()
	{
		ICaptureSnapshot cap = MonoBehaviourSingleton<ScreenShotManager>.Instance.GetCaptureSnapshot();
		if (cap == null || object.Equals(cap.IsPrepareScreen(), _isChange))
		{
			return;
		}
		_isChange = cap.IsPrepareScreen();
		if (_isChange)
		{
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/teamscore/teamScore1.png", delegate(Sprite sprite)
			{
				_viewModel.BackboardSprite = sprite;
				UnityMainThreadDispatcher.Enqueue(delegate
				{
					cap.ScreenNow();
				}, 0.2f);
			});
		}
		else
		{
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/teamscore/teamScore.png", delegate(Sprite sprite)
			{
				_viewModel.BackboardSprite = sprite;
			});
		}
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}
}
