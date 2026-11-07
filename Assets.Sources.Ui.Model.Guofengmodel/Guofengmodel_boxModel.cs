using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Guofengmodel;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Guofengmodel;

[GameUiTest]
public class Guofengmodel_boxModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private Guofengmodel_boxViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

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
		_viewModel = new Guofengmodel_boxViewModel();
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
		_viewModel.progressString1 = 0 + "%";
		for (int i = 0; i < 3; i++)
		{
			_viewModel.Setation1_Show(i + 1, value: false);
		}
		_viewModel.progressString2 = 0 + "%";
		for (int j = 0; j < 3; j++)
		{
			_viewModel.Setation2_Show(j + 1, value: false);
		}
		NotifyManager.MakeNotifyClass(156, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].TypeId == -141011)
			{
				_viewModel.progressString1 = tipsEvent[i].Time2 + "%";
				for (int j = 0; j < tipsEvent[i].Time1; j++)
				{
					_viewModel.Setation1_Show(j + 1, value: true);
				}
				for (int k = tipsEvent[i].Time1; k < 3; k++)
				{
					_viewModel.Setation1_Show(k + 1, value: false);
				}
				tipsEvent.RemoveAt(i);
				i--;
			}
			else if (tipsEvent[i].TypeId == -141012)
			{
				_viewModel.progressString2 = tipsEvent[i].Time2 + "%";
				for (int l = 0; l < tipsEvent[i].Time1; l++)
				{
					_viewModel.Setation2_Show(l + 1, value: true);
				}
				for (int m = tipsEvent[i].Time1; m < 3; m++)
				{
					_viewModel.Setation2_Show(m + 1, value: false);
				}
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
	}
}
