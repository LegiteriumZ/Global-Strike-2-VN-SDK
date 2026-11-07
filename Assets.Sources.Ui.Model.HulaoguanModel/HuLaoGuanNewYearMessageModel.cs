using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.HulaoguanModel;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.HulaoguanModel;

[GameUiTest]
public class HuLaoGuanNewYearMessageModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private HuLaoGuanNewYearMessageViewModel _viewModel;

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
		_viewModel = new HuLaoGuanNewYearMessageViewModel();
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
		NotifyManager.MakeNotifyClass(114, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			int typeId = tipsEvent[i].TypeId;
			_viewModel.PanelShow = true;
			_viewModel.msgShow = false;
			_viewModel.fhtShow = false;
			_viewModel.bossShow1 = false;
			_viewModel.bossShow2 = false;
			_viewModel.bossShow3 = false;
			_viewModel.ftShow = false;
			if (tipsEvent[i].Time4 <= 0)
			{
				_centerActiveChip.Time = int.MaxValue;
				if (!tipsEvent[i].Show)
				{
					_centerActiveChip.Time = 0;
				}
			}
			else
			{
				_centerActiveChip.Time = tipsEvent[i].Time4;
			}
			switch (typeId)
			{
			case -13216:
				_viewModel.fhtShow = _centerActiveChip.Time > 0;
				break;
			case -13222:
				_viewModel.SetbossShow(tipsEvent[i].Time1, _centerActiveChip.Time > 0);
				break;
			case -13221:
				_viewModel.msgShow = _centerActiveChip.Time > 0;
				break;
			case -13225:
				_viewModel.ftShow = _centerActiveChip.Time > 0;
				break;
			}
		}
		tipsEvent.Clear();
	}

	private void InitChips()
	{
		_centerActiveChip.Time = 0;
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.PanelShow = _centerActiveChip.Update(_timeComponent);
	}
}
