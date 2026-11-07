using System.Diagnostics;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Input;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJBase.Thread;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class AceReportModel : AbstractModel, ICursorControl, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private AceReportViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private int _autoCloseTime;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = context.roomData.Data.RaceType;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new AceReportViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowRootshow = false;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_Ace, InitAce, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(GetAutoTime, SetAutoTime, null, initinvoke: true, isFrameSeparation: true);
		_viewModel.CreateTriggerEntry(_viewModel.ComfirmTriggers, EventTriggerType.PointerClick, ComfirmBtnClick);
	}

	private int GetAutoTime()
	{
		return _autoCloseTime / 1000 + 1;
	}

	private void SetAutoTime(int arg1, int arg2)
	{
		_viewModel.TimeString = StringCache.IntToString(arg2);
	}

	private void InitAce(bool arg1, bool arg2)
	{
		this.Info("Show Ace Ui" + arg2);
		_viewModel.ShowRootshow = arg2;
		if (arg2)
		{
			_autoCloseTime = 10000;
		}
	}

	private void ComfirmBtnClick(BaseEventData data)
	{
		GameClose();
	}

	private void GameClose()
	{
		_battleRoomContext.ace.IsRefresh = false;
		this.Info("Ace Exit Game");
		UnityMainThreadDispatcher.Enqueue(delegate
		{
			MonoBehaviourSingleton<GameExitManager>.Instance.ExitGame();
			ExecuteGG.CloseNPGameMon();
			if (!Application.isEditor)
			{
				Process.GetCurrentProcess().Kill();
			}
		});
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
		if (_autoCloseTime > 0)
		{
			_autoCloseTime -= time.FrameInterval;
			if (_autoCloseTime < 0)
			{
				GameClose();
			}
		}
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowRootshow)
		{
			return 0;
		}
		return 524288;
	}

	public int GetForbidButtons()
	{
		return 0;
	}
}
