using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.HomeLandModel;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJNetworking.BattleServer;
using UnityEngine;

namespace Assets.Sources.Ui.Model.HomeLandModel;

[GameUiTest]
public class HomeLandModelModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, IKeyboardResponder
{
	private HomeLandModelViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private bool E_keyDown;

	private bool Q_keyDown;

	private bool T_keyDown;

	private ActiveChip timeUpdate = new ActiveChip();

	private ActiveChip msgtime = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

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
		_viewModel = new HomeLandModelViewModel();
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
		NotifyManager.MakeNotifyClass(150, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
		Contexts.sharedInstance.message.homeLandScene.unlockid = -1;
		_viewModel.MsgShow = false;
		_viewModel.ProgressShowShow = false;
		_viewModel.T_msgShow = false;
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].TypeId == -14001)
			{
				_viewModel.MsgShow = tipsEvent[i].Show;
				_viewModel.TimeString1 = tipsEvent[i].Time2.ToString();
				_viewModel.TimeString2 = tipsEvent[i].Time1.ToString();
				Contexts.sharedInstance.message.homeLandScene.unlockid = (tipsEvent[i].Show ? tipsEvent[i].Time4 : (-1));
				if (tipsEvent[i].Show)
				{
					string assetName = "Assets/Res/Assets/ui/GameGUIRes/rpgModel/HomeLandModel/" + ((Contexts.sharedInstance.message.homeLandScene.unlockid > 10000) ? "room.png" : "display.png");
					base.Loader.RetriveSprite("ui/rpgModel", assetName, delegate(Sprite sprite)
					{
						_viewModel.MsgSprite = sprite;
					});
					_viewModel.unlockmsgShow = tipsEvent[i].Time2 < tipsEvent[i].Time1;
					_viewModel.TimeTextcolor1 = (_viewModel.unlockmsgShow ? Color.red : Color.white);
				}
				tipsEvent.RemoveAt(i);
				i--;
			}
			else if (tipsEvent[i].TypeId == -14002)
			{
				_viewModel.errorMsgString = ScriptLocalization.Get("HomeLandError" + tipsEvent[i].Time1);
				if (string.IsNullOrEmpty(_viewModel.errorMsgString))
				{
					_viewModel.errorMsgString = "HomeLandError:" + tipsEvent[i].Time1;
				}
				msgtime.Time = 3000;
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
		if (msgtime.Time > 0)
		{
			msgtime.Update(time);
			if (msgtime.Time <= 0)
			{
				_viewModel.errorMsgString = string.Empty;
			}
		}
		if (Contexts.sharedInstance.player.myPlayerEntity == null)
		{
			return;
		}
		if (Contexts.sharedInstance.player.myPlayerEntity.GetCharacterId() != Contexts.sharedInstance.message.homeLandScene.CharacterId)
		{
			_viewModel.E_Oth_msgShow = Contexts.sharedInstance.message.homeLandScene.isShowET;
			if (E_keyDown)
			{
				timeUpdate.Update(time);
				if (timeUpdate.Time > 0)
				{
					_viewModel.ProgressShowShow = true;
					_viewModel.ProgressFillamount = 1f - (float)timeUpdate.Time * 1f / 3000f;
					return;
				}
				_viewModel.ProgressShowShow = false;
				if (E_keyDown && Contexts.sharedInstance.message.homeLandScene.isShowET)
				{
					Contexts.sharedInstance.message.homeLandScene.weaponList = Contexts.sharedInstance.message.homeLandScene.dicGid_Weapon[Contexts.sharedInstance.message.homeLandScene.isRentid];
					if (Contexts.sharedInstance.message.homeLandScene.weaponList.Count > 0)
					{
						Contexts.sharedInstance.message.homeLandScene.isShowRent = true;
					}
				}
			}
			else
			{
				_viewModel.ProgressShowShow = false;
				_viewModel.ProgressFillamount = 0f;
			}
			return;
		}
		if (Contexts.sharedInstance.message.homeLandScene.CameraTargetId < 0 && Contexts.sharedInstance.message.homeLandScene.unlockid >= 0 && Contexts.sharedInstance.message.homeLandScene.unlockid < 10000)
		{
			timeUpdate.Time = 3000;
			_viewModel.MsgShow = false;
			_viewModel.ProgressShowShow = false;
		}
		if (E_keyDown || Q_keyDown || T_keyDown)
		{
			_viewModel.ShowShow = timeUpdate.Update(time);
			if (timeUpdate.Time > 0)
			{
				_viewModel.ProgressShowShow = true;
				_viewModel.ProgressFillamount = 1f - (float)timeUpdate.Time * 1f / 3000f;
			}
			else
			{
				_viewModel.ProgressShowShow = false;
				if (E_keyDown || Q_keyDown)
				{
					IBattleServer server = Contexts.sharedInstance.battleServer.battleServer.Server;
					if (E_keyDown && Contexts.sharedInstance.message.homeLandScene.unlockid >= 0)
					{
						HomelandUnlockData homelandUnlockData = new HomelandUnlockData();
						homelandUnlockData.UnlockId = Contexts.sharedInstance.message.homeLandScene.unlockid;
						homelandUnlockData.Type = 0;
						server.SendTcpMessage(126, homelandUnlockData);
						Contexts.sharedInstance.message.homeLandScene.unlockid = -1;
						timeUpdate.Time = 3000;
						return;
					}
					HomelandTakeData homelandTakeData = new HomelandTakeData();
					homelandTakeData.OffIdx = Contexts.sharedInstance.message.homeLandScene.putdown;
					homelandTakeData.UpIdx = (Q_keyDown ? (-1) : Contexts.sharedInstance.message.homeLandScene.pickup);
					server.SendTcpMessage(125, homelandTakeData);
					timeUpdate.Time = 3000;
				}
				else if (T_keyDown)
				{
					Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(127, new HomelandRentData
					{
						Type = 1
					});
					timeUpdate.Time = 3000;
				}
			}
		}
		else
		{
			_viewModel.ProgressShowShow = false;
			_viewModel.ProgressFillamount = 0f;
		}
		if (Contexts.sharedInstance.message.homeLandScene.isShowEP)
		{
			_viewModel.E_msgShow = Contexts.sharedInstance.message.homeLandScene.pickup > -1;
			_viewModel.Q_msgShow = Contexts.sharedInstance.message.homeLandScene.putdown > -1;
			E_keyDown = E_keyDown && (_viewModel.E_msgShow || _viewModel.MsgShow);
			Q_keyDown = Q_keyDown && _viewModel.Q_msgShow;
			_viewModel.T_msgShow = !_viewModel.E_msgShow;
		}
		else
		{
			_viewModel.E_msgShow = false;
			_viewModel.Q_msgShow = false;
			E_keyDown = E_keyDown && _viewModel.MsgShow;
			Q_keyDown = false;
			_viewModel.T_msgShow = false;
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.E && Contexts.sharedInstance.message.homeLandScene.isShowEP)
		{
			timeUpdate.Time = 3000;
			E_keyDown = key == KeyCode.E;
		}
		if (key == KeyCode.E && Contexts.sharedInstance.message.homeLandScene.isShowET)
		{
			timeUpdate.Time = 3000;
			E_keyDown = key == KeyCode.E;
		}
		if (key == KeyCode.L && Contexts.sharedInstance.message.homeLandScene.isShowEP)
		{
			timeUpdate.Time = 3000;
			T_keyDown = key == KeyCode.L;
		}
		if (key == KeyCode.Q && Contexts.sharedInstance.message.homeLandScene.putdown > 0)
		{
			Q_keyDown = key == KeyCode.Q;
			timeUpdate.Time = 3000;
		}
		if (key == KeyCode.E && Contexts.sharedInstance.message.homeLandScene.unlockid >= 0)
		{
			timeUpdate.Time = 3000;
			E_keyDown = key == KeyCode.E;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		if (key == KeyCode.E)
		{
			E_keyDown = false;
		}
		if (key == KeyCode.Q)
		{
			Q_keyDown = false;
		}
		if (key == KeyCode.L)
		{
			T_keyDown = false;
		}
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
}
