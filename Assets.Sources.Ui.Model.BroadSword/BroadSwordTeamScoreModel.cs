using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BroadSword;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.BroadSword;

public class BroadSwordTeamScoreModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetBattleRoomContext
{
	private BroadSwordlteamscoreViewModel _viewModel;

	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BroadSwordlteamscoreViewModel();
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_WinCondition, SetWinCondition, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_WinScore, SetWinScore, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Minutes, SetMinutes, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Seconds, SetSeconds, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetKillNum, SetKillNum, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetAceKillNum, SetAceKillNum, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetRank, SetRank, null, initinvoke: true);
	}

	private void SetRank(int arg1, int arg2)
	{
		_viewModel.RankTextString = arg2.ToString();
	}

	private int GetRank()
	{
		int num = 0;
		int cameraOwnerData_PlayerId = UiIEventCondition.Get_cameraOwnerData_PlayerId();
		List<OneKillInfoData> all = _battleRoomContext.playerInfo.All;
		for (int i = 0; i < all.Count; i++)
		{
			num++;
			if (all[i].Id == cameraOwnerData_PlayerId)
			{
				return num;
			}
		}
		return 0;
	}

	private void SetAceKillNum(int arg1, int arg2)
	{
	}

	private int GetAceKillNum()
	{
		if (_battleRoomContext.playerInfo.All.Count > 0)
		{
			return _battleRoomContext.playerInfo.All[0].KillNum;
		}
		return 0;
	}

	private void SetKillNum(int arg1, int arg2)
	{
		_viewModel.ScoreTextString = arg2.ToString();
	}

	private int GetKillNum()
	{
		if (_playerContext.isCameraOwner)
		{
			PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
			if (cameraOwnerEntity.hasOneKillInfo && cameraOwnerEntity.oneKillInfo.Data != null)
			{
				return cameraOwnerEntity.oneKillInfo.Data.KillNum;
			}
		}
		return 0;
	}

	private void SetSeconds(int ov, int seconds)
	{
		_viewModel.SecondsString = StringCache.IntToStringD2(seconds);
	}

	private void SetMinutes(int ov, int minutes)
	{
		_viewModel.MinutesString = StringCache.IntToStringD2(minutes);
	}

	private void SetWinScore(int ov, int score)
	{
	}

	private void SetWinCondition(int ov, int type)
	{
	}

	public void OnPlayback()
	{
	}

	private void InitChips()
	{
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}
}
