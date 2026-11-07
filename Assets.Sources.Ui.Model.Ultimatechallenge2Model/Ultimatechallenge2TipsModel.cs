using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Ultimatechallenge2Model;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Ultimatechallenge2Model;

[GameUiTest]
public class Ultimatechallenge2TipsModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private Ultimatechallenge2TipsViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private ActiveChip READY_TO_START = new ActiveChip();

	private ActiveChip TAKEOFF_TIPS = new ActiveChip();

	private ActiveChip WAIT_INFO = new ActiveChip();

	private ActiveChip FROG_DEC_COUNTDOWN = new ActiveChip();

	private ActiveChip FROG_REFRESH_COUNTDOWN = new ActiveChip();

	private ActiveChip PLAYER_BE_HURT = new ActiveChip();

	private ActiveChip SAFEAREA_DEC_TIP = new ActiveChip();

	private ActiveChip MOVE_TO_NEW_AREA_TIP = new ActiveChip();

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
		_viewModel = new Ultimatechallenge2TipsViewModel();
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
		_viewModel.takeOffCountDownShow = false;
		_viewModel.takeOffTipsShow = false;
		NotifyManager.MakeNotifyClass(118, GetMessageList, SetTipsEvent, initinvoke: true);
	}

	public List<UltChallenge> GetMessageList()
	{
		return Contexts.sharedInstance.message.ultimatechallenge2.MessageEvent;
	}

	protected virtual void SetTipsEvent(List<UltChallenge> ov, List<UltChallenge> messageEvent)
	{
		if (messageEvent == null)
		{
			return;
		}
		for (int i = 0; i < messageEvent.Count; i++)
		{
			if (messageEvent[i].EventId == 4)
			{
				_viewModel.takeOffCountDownShow = true;
				READY_TO_START.Time = messageEvent[i].Ins[0];
				messageEvent.RemoveAt(i);
				i--;
			}
			else if (messageEvent[i].EventId == 5)
			{
				if (messageEvent[i].Ins == null || messageEvent[i].Ins.Count == 0)
				{
					_viewModel.takeOffTipsShow = true;
					TAKEOFF_TIPS.Time = 3000;
				}
				else
				{
					_viewModel.takeOffTipsShow = true;
					TAKEOFF_TIPS.Time = ((messageEvent[i].Ins[0] == 0) ? 3000 : messageEvent[i].Ins[0]);
				}
				messageEvent.RemoveAt(i);
				i--;
			}
			else if (messageEvent[i].EventId == 3)
			{
				_viewModel.wait_infoShow = true;
				WAIT_INFO.Time = messageEvent[i].Ins[1];
				WAIT_INFO.maxTime = messageEvent[i].Ins[2];
				_viewModel._Number_wait_info_time_FreeCanvas_maxString = (messageEvent[i].Ins[2] / 1000).ToString();
				_viewModel._Number_wait_info_player_FreeCanvas_String = messageEvent[i].Ins[3].ToString();
				_viewModel._Number_wait_info_player_FreeCanvas_maxString = messageEvent[i].Ins[4].ToString();
				WAIT_INFO.Time = messageEvent[i].Ins[1];
				messageEvent.RemoveAt(i);
				i--;
			}
			else if (messageEvent[i].EventId == 8)
			{
				if (messageEvent[i].Ins[0] == 1)
				{
					for (int j = 0; j < 5; j++)
					{
						if (messageEvent[i].Ss.Count > j)
						{
							_viewModel.SetL_MessageString(j, messageEvent[i].Ss[j]);
						}
						else
						{
							_viewModel.SetL_MessageString(j, "");
						}
					}
				}
				else if (messageEvent[i].Ins[0] == 2)
				{
					for (int k = 0; k < 5; k++)
					{
						if (messageEvent[i].Ss.Count > k)
						{
							if (string.IsNullOrEmpty(messageEvent[i].Ss[k]))
							{
								_viewModel.SetuiList_Show(k, value: false);
								continue;
							}
							_viewModel.SetuiList_Show(k, value: true);
							_viewModel.SetuiList_name_String(k, messageEvent[i].Ss[k]);
						}
						else
						{
							_viewModel.SetuiList_Show(k, value: false);
						}
					}
				}
				messageEvent.RemoveAt(i);
				i--;
			}
			else if (messageEvent[i].EventId == 9)
			{
				_viewModel.Setmessage_text_String(messageEvent[i].Ins[0], messageEvent[i].Ss[0]);
				messageEvent.RemoveAt(i);
				i--;
			}
			else if (messageEvent[i].EventId == 22)
			{
				_viewModel.safeAreaDecreaseShow = true;
				SAFEAREA_DEC_TIP.Time = 3000;
				messageEvent.RemoveAt(i);
				i--;
			}
			else if (messageEvent[i].EventId == 23)
			{
				_viewModel.moveToNewAreaShow = true;
				MOVE_TO_NEW_AREA_TIP.Time = 3000;
				messageEvent.RemoveAt(i);
				i--;
			}
			else if (messageEvent[i].EventId == 24)
			{
				_viewModel.frogDecreaseCountDownShow = true;
				FROG_DEC_COUNTDOWN.Time = 10000;
				messageEvent.RemoveAt(i);
				i--;
			}
			else if (messageEvent[i].EventId == 25)
			{
				_viewModel.frogRefreshCountDownShow = true;
				FROG_REFRESH_COUNTDOWN.Time = 10000;
				messageEvent.RemoveAt(i);
				i--;
			}
			else if (messageEvent[i].EventId == 26)
			{
				_viewModel.damageUIShow = true;
				PLAYER_BE_HURT.Time = 2000;
				messageEvent.RemoveAt(i);
				i--;
			}
		}
	}

	private void InitChips()
	{
		READY_TO_START.Time = 0;
		TAKEOFF_TIPS.Time = 0;
		WAIT_INFO.Time = 0;
		FROG_DEC_COUNTDOWN.Time = 0;
		PLAYER_BE_HURT.Time = 0;
		SAFEAREA_DEC_TIP.Time = 0;
		MOVE_TO_NEW_AREA_TIP.Time = 0;
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.takeOffCountDownShow = READY_TO_START.Update(_timeComponent);
		if (_viewModel.takeOffCountDownShow)
		{
			_viewModel._Number_takeOffCountDown_FreeUI_FreeCanvas_String = (READY_TO_START.Time / 1000).ToString();
		}
		_viewModel.takeOffTipsShow = TAKEOFF_TIPS.Update(_timeComponent);
		_viewModel.damageUIShow = PLAYER_BE_HURT.Update(_timeComponent);
		_viewModel.safeAreaDecreaseShow = SAFEAREA_DEC_TIP.Update(_timeComponent);
		_viewModel.moveToNewAreaShow = MOVE_TO_NEW_AREA_TIP.Update(_timeComponent);
		_viewModel.wait_infoShow = WAIT_INFO.UpdateAdd(_timeComponent);
		if (_viewModel.wait_infoShow)
		{
			_viewModel._Number_wait_info_time_FreeCanvas_String = (WAIT_INFO.Time / 1000).ToString();
		}
		_viewModel.frogDecreaseCountDownShow = FROG_DEC_COUNTDOWN.UpdateAdd(_timeComponent);
		if (_viewModel.wait_infoShow)
		{
			_viewModel.frogDecreaseCountDown_TimeString = (FROG_DEC_COUNTDOWN.Time / 1000).ToString();
		}
		_viewModel.frogRefreshCountDownShow = FROG_REFRESH_COUNTDOWN.UpdateAdd(_timeComponent);
		if (_viewModel.wait_infoShow)
		{
			_viewModel.frogRefreshCountDown_TimeString = (FROG_REFRESH_COUNTDOWN.Time / 1000).ToString();
		}
	}
}
