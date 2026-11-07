using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.NewescapeModel;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.NewescapeModel;

[GameUiTest]
public class NewEscapeLeftModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private NewEscapeLeftViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private ActiveChip _centerActiveChip = new ActiveChip();

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
		_viewModel = new NewEscapeLeftViewModel();
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
		NotifyManager.MakeNotifyClass(117, GetTipsList, SetTipsEvent, initinvoke: true);
		NotifyManager.MakeNotifyClass(125, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
	}

	public List<NewEscapeMessageData> GetTipsList()
	{
		return Contexts.sharedInstance.message.newEscapeTipsShow.TipsEvent;
	}

	protected virtual void SetTipsEvent(List<NewEscapeMessageData> ov, List<NewEscapeMessageData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].Type == NewEscapeMessageType.WAITINGOPENDOOR)
			{
				_centerActiveChip.Time = tipsEvent[i].Time;
				_viewModel.PanelShow = true;
				_viewModel.DecString = ScriptLocalization.Get("NewEscapeMid1");
				tipsEvent.RemoveAt(i);
				i--;
			}
			else if (tipsEvent[i].Type == NewEscapeMessageType.WAITINGTRIGGER)
			{
				string text = ScriptLocalization.Get("NewEscapeMid" + tipsEvent[i].CustomId);
				if (!string.IsNullOrEmpty(text))
				{
					_centerActiveChip.Time = tipsEvent[i].Time;
					_viewModel.PanelShow = true;
					_viewModel.DecString = text;
				}
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			bool flag = false;
			if (tipsEvent[i].TypeId == -13531)
			{
				string text = ScriptLocalization.Get("BIOZ_GAME_FINAL");
				if (!string.IsNullOrEmpty(text))
				{
					_centerActiveChip.Time = tipsEvent[i].Time2 - (_timeComponent.ServerTime - tipsEvent[i].Time1);
					_viewModel.PanelShow = true;
					_viewModel.DecString = text;
				}
				flag = true;
			}
			if (flag)
			{
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	private void InitChips()
	{
		_centerActiveChip.Time = 0;
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.PanelShow = _centerActiveChip.Update(_timeComponent);
		if (_viewModel.PanelShow)
		{
			_viewModel.TimeString = Mathf.CeilToInt((float)_centerActiveChip.Time / 1000f).ToString();
		}
	}
}
