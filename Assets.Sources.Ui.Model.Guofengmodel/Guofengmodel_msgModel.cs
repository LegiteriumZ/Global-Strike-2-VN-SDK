using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Guofengmodel;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Guofengmodel;

[GameUiTest]
public class Guofengmodel_msgModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private Guofengmodel_msgViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private Dictionary<int, string> msgList = new Dictionary<int, string>
	{
		{ -141016, "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/msg/out.png" },
		{ -141017, "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/msg/mouse_appear.png" },
		{ -141018, "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/msg/destroy.png" },
		{ -141019, "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/msg/open1.png" },
		{ -141020, "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/msg/open2.png" },
		{ -141021, "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/msg/open3.png" },
		{ -141022, "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/msg/box_appear.png" },
		{ -141025, "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/msg/undercontribution.png" }
	};

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
		_viewModel = new Guofengmodel_msgViewModel();
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
		_viewModel.ImageShow = false;
		_viewModel.outShow = false;
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
			if (tipsEvent[i].TypeId == -141017 || tipsEvent[i].TypeId == -141018 || tipsEvent[i].TypeId == -141019 || tipsEvent[i].TypeId == -141020 || tipsEvent[i].TypeId == -141021 || tipsEvent[i].TypeId == -141022)
			{
				_viewModel.ImageShow = false;
				base.Loader.RetriveSprite("ui/guofengmodel", msgList[tipsEvent[i].TypeId], delegate(Sprite sprite)
				{
					_centerActiveChip.Time = 3000;
					_viewModel.ImageSprite = sprite;
					_viewModel.ImageNtvsize();
				});
				tipsEvent.RemoveAt(i);
				i--;
			}
			else if (tipsEvent[i].TypeId == -141025)
			{
				_viewModel.ImageShow = false;
				base.Loader.RetriveSprite("ui/guofengmodel", msgList[tipsEvent[i].TypeId], delegate(Sprite sprite)
				{
					_centerActiveChip.Time = 4000;
					_viewModel.ImageSprite = sprite;
					_viewModel.ImageNtvsize();
				});
				tipsEvent.RemoveAt(i);
				i--;
			}
			else if (tipsEvent[i].TypeId == -141016)
			{
				_viewModel.outShow = tipsEvent[i].Show;
				base.Loader.RetriveSprite("ui/guofengmodel", msgList[tipsEvent[i].TypeId], delegate(Sprite sprite)
				{
					_viewModel.outSprite = sprite;
					_viewModel.outNtvsize();
				});
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
		_viewModel.ImageShow = _centerActiveChip.Update(time);
	}
}
