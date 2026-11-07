using System;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Scripts.Fog;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Free.Scene;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.Common;

public class MenuModel : AbstractModel, IPlaybackSystem, ICursorControl, IKeyboardResponder, ISetBattleRoomContext, ISetPlayerContext, ISetBattleServerContext, ISetGameRuleContext
{
	private readonly LoggerAdapter _loggerAdapter = new LoggerAdapter(typeof(MenuModel));

	private readonly MenuViewModel _menuViewModel = new MenuViewModel();

	private bool _menuVisible;

	private List<int> _reportRuleList;

	private GameRuleContext _gameRuleContext;

	private BattleRoomContext _battleRoomContext;

	private PlayerContext _playerContext;

	private BattleServerContext _battleServerContext;

	private bool MenuVisible
	{
		get
		{
			return _menuVisible;
		}
		set
		{
			_menuVisible = value;
			CloseDelay = 1;
		}
	}

	protected override IUiViewModel ViewModel => _menuViewModel;

	public int CloseDelay { get; set; }

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void OnPlayback()
	{
		CloseDelay--;
		_menuViewModel.ShowShow = MenuVisible;
	}

	protected override void DoSubscribe()
	{
		_menuViewModel.ReportButtonable = RuleUtilty.hasReportHandle();
		base.DoSubscribe();
		_menuViewModel.CreateTriggerEntry(_menuViewModel.BackLobbyTriggers, EventTriggerType.PointerClick, BackLobbyClick);
		_menuViewModel.CreateTriggerEntry(_menuViewModel.ResumeGameTriggers, EventTriggerType.PointerClick, ResumeGameClick);
		_menuViewModel.CreateTriggerEntry(_menuViewModel.SetupTriggers, EventTriggerType.PointerClick, SetupClick);
		_menuViewModel.ReportClicked.AddListener(ReportClick);
		SetHowToPlayStatus();
		SetShieldStatus();
		_menuViewModel.ShowShow = false;
		SimpleNotify.Add(GetFogdata, SetFogdata);
	}

	private void SetFogdata(FogData arg1, int arg2)
	{
		if (arg1 == null)
		{
			return;
		}
		FreeFog freeFog = MonoBehaviourSingleton<FogManager>.Instance.GetFog(_playerContext.myPlayerEntity.GetId());
		ColorUtility.TryParseHtmlString($"#{Convert.ToString(arg1.FogColor, 16)}", out var color);
		if (!arg1.Start && freeFog != null)
		{
			MonoBehaviourSingleton<FogManager>.Instance.RemoveFog(_playerContext.myPlayerEntity.GetId());
		}
		else if (arg1.Start)
		{
			if (freeFog == null)
			{
				freeFog = new FreeFog(_playerContext.myPlayerEntity.GetId(), new SSJJFog.FogConfig(_playerContext.myPlayerEntity.GetId()));
				MonoBehaviourSingleton<FogManager>.Instance.AddFog(_playerContext.myPlayerEntity.GetId(), freeFog);
			}
			freeFog.getFog().Set(arg1.FogMaxDensity, color, arg1.FogNear, arg1.FogFar);
			freeFog.InitialAuto("");
			freeFog.StartAuto();
		}
	}

	private FogData GetFogdata(int arg1)
	{
		if (_playerContext.cameraOwnerEntity == null)
		{
			return null;
		}
		if (_playerContext.isMyPlayer || (_playerContext.myPlayerEntity != null && _playerContext.myPlayerEntity.basicInfo.Current.FogData != null))
		{
			return _playerContext.myPlayerEntity.basicInfo.Current.FogData;
		}
		return null;
	}

	private void ReportClick()
	{
		_battleServerContext.battleServer.Server.SendTcpMessage(19);
		MenuVisible = false;
	}

	private void SetHowToPlayStatus()
	{
		if (_playerContext.myPlayerEntity != null && _playerContext.myPlayerEntity.basicInfo != null)
		{
			int value = 0;
			_battleRoomContext.playerInfo.VipLevels.TryGetValue(_playerContext.myPlayerEntity.basicInfo.PlayerName, out value);
			_menuViewModel.HowToPlayButtonable = _battleRoomContext.roomData.Data.CanVote && value >= 7;
			if (_menuViewModel.HowToPlayButtonable)
			{
				_menuViewModel.CreateTriggerEntry(_menuViewModel.HowToPlayTriggers, EventTriggerType.PointerClick, HowToPlayClick);
			}
		}
	}

	private void SetShieldStatus()
	{
		_menuViewModel.ShieldLightShow = false;
		_menuViewModel.ShieldButtonable = !VoiceUtility.CheckVoiceIsForbiden(_battleRoomContext.roomData.Data.RaceType);
		if (_menuViewModel.ShieldButtonable)
		{
			_menuViewModel.CreateTriggerEntry(_menuViewModel.ShieldTriggers, EventTriggerType.PointerClick, ShieldClick);
		}
	}

	private void SetVisibleChanged(bool ov, bool visible)
	{
		MenuVisible = visible;
	}

	private void HowToPlayClick(BaseEventData obj)
	{
		_gameRuleContext.kickOut.Visible = true;
		MenuVisible = false;
	}

	private void ShieldClick(BaseEventData obj)
	{
		NotifyManager.ForceInvoke(31);
		MenuVisible = false;
		if (_playerContext.myPlayerEntity != null && _battleRoomContext.playerInfo.VoiceFlag == 1)
		{
			_battleRoomContext.playerInfo.VoiceFlag = 3;
		}
	}

	private void ResumeGameClick(BaseEventData obj)
	{
		MenuVisible = false;
		Screen.fullScreen = true;
	}

	private void BackLobbyClick(BaseEventData obj)
	{
		VoiceUtility.QuitVoice();
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(18);
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(23, new UnityProxyData
		{
			Type = UnityProxyType.EVENT,
			Func = "GAME_BACK_LOBBY",
			Key = TplManager.Instance.GameBootConfig.Sign
		});
		_loggerAdapter.Info("Menu Ui Exit, LogOut");
		Contexts.sharedInstance.battleServer.battleServer.Server.Disconnect();
		UnityMainThreadDispatcher.Enqueue(delegate
		{
			MonoBehaviourSingleton<GameExitManager>.Instance.ExitGame();
			ExecuteGG.CloseNPGameMon();
			if (!Application.isEditor)
			{
				Process.GetCurrentProcess().Kill();
			}
		}, 0.5f);
	}

	private void SetupClick(BaseEventData data)
	{
		NotifyManager.ForceInvoke(39);
		MenuVisible = false;
	}

	public int GetCursorState()
	{
		if (!MenuVisible && CloseDelay <= 0)
		{
			return 0;
		}
		return 1;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.Escape)
		{
			MenuVisible = !MenuVisible;
			if (MenuVisible)
			{
				CheckShow();
			}
		}
		return false;
	}

	private void CheckShow()
	{
		if (_playerContext.myPlayerEntity != null)
		{
			_menuViewModel.ShieldLightShow = _battleRoomContext.playerInfo.VoiceFlag == 1;
		}
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public void SetBattleServerContext(BattleServerContext context)
	{
		_battleServerContext = context;
	}
}
