using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Blast;
using Assets.Sources.Utils;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Blast;

public class BlastModelTeamScoreModel : AbstractModel, IPlaybackSystem
{
	private const int MaxTeamMember = 8;

	private readonly BlastmodelteamscoreViewModel _viewModel = new BlastmodelteamscoreViewModel();

	private bool _isChange;

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void OnGameobjectInitialized()
	{
		base.OnGameobjectInitialized();
		_viewModel.MinutesShow = true;
		_viewModel.SecondsShow = true;
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		base.Loader.RetriveSprite("ui/blastmodel", "Assets/Res/Assets/ui/GameGUIRes/blastModel/teamscore/teamScore1.png");
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_broadcastScore_Team1Score, SetTeam1Score, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_broadcastScore_Team2Score, SetTeam2Score, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_c4Message_Active, SetActive, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_NotMoveTime, SetNotMoveTime, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Minutes, SetMinutes, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Seconds, SetSeconds, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_allKillInfo_TeamCount1, SetTeamCount1, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_allKillInfo_TeamCount2, SetTeamCount2, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_allKillInfo_TeamDeadCount1, SetTeamDeadCount1, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_allKillInfo_TeamDeadCount2, SetTeamDeadCount2, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_WinScore, SetWinScore, null, initinvoke: true);
	}

	private void SetTeamDeadCount1(int arg1, int arg2)
	{
		int allKillInfo_TeamCount = UiIEventCondition.Get_allKillInfo_TeamCount1();
		for (int i = 0; i < 8; i++)
		{
			_viewModel.SetDeadShow(i + 1, i >= allKillInfo_TeamCount - arg2);
		}
	}

	private void SetTeamDeadCount2(int arg1, int arg2)
	{
		int allKillInfo_TeamCount = UiIEventCondition.Get_allKillInfo_TeamCount2();
		for (int i = 0; i < 8; i++)
		{
			_viewModel.SetCtDeadShow(i + 1, i >= allKillInfo_TeamCount - arg2);
		}
	}

	private void SetTeamCount2(int arg1, int arg2)
	{
		for (int i = 0; i < 8; i++)
		{
			_viewModel.SetCtLiveShow(i + 1, i < arg2);
		}
		SetTeamDeadCount2(0, UiIEventCondition.Get_allKillInfo_TeamDeadCount2());
	}

	private void SetTeamCount1(int arg1, int arg2)
	{
		for (int i = 0; i < 8; i++)
		{
			_viewModel.SetLiveShow(i + 1, i < arg2);
		}
		SetTeamDeadCount1(0, UiIEventCondition.Get_allKillInfo_TeamDeadCount1());
	}

	private void SetTeam1Score(long arg1, long arg2)
	{
		_viewModel.TeamScoreString1 = StringCache.LongToString(arg2);
	}

	private void SetTeam2Score(long arg1, long arg2)
	{
		_viewModel.TeamScoreString2 = StringCache.LongToString(arg2);
	}

	private void SetActive(bool arg1, bool arg2)
	{
		if (arg2)
		{
			_viewModel.MinutesShow = false;
			_viewModel.SecondsShow = false;
		}
	}

	private void SetNotMoveTime(int arg1, int arg2)
	{
		if (arg2 > 2000)
		{
			_viewModel.MinutesShow = true;
			_viewModel.SecondsShow = true;
		}
	}

	private void SetMinutes(int arg1, int arg2)
	{
		_viewModel.MinutesString = StringCache.IntToStringD2(arg2);
	}

	private void SetSeconds(int arg1, int arg2)
	{
		_viewModel.SecondsString = StringCache.IntToStringD2(arg2);
	}

	private void SetWinScore(int arg1, int arg2)
	{
		_viewModel.WinConditionString = StringCache.IntToStringD2(arg2);
	}

	public void OnPlayback()
	{
		CheckScreen();
	}

	private void CheckScreen()
	{
		ICaptureSnapshot cap = MonoBehaviourSingleton<ScreenShotManager>.Instance.GetCaptureSnapshot();
		if (cap == null || cap.IsPrepareScreen() == _isChange)
		{
			return;
		}
		_isChange = cap.IsPrepareScreen();
		if (_isChange)
		{
			base.Loader.RetriveSprite("ui/blastmodel", "Assets/Res/Assets/ui/GameGUIRes/blastModel/teamscore/teamScore1.png", delegate(Sprite sprite)
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
			base.Loader.RetriveSprite("ui/blastmodel", "Assets/Res/Assets/ui/GameGUIRes/blastModel/teamscore/teamScore.png", delegate(Sprite sprite)
			{
				_viewModel.BackboardSprite = sprite;
			});
		}
	}
}
