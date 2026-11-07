using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Jump;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.Extensions;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Jump;

public class JumpGameOverModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext
{
	private JumpgameoverViewModel _viewModel;

	private ActiveChip _panelActiveChip = new ActiveChip();

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
		_viewModel = new JumpgameoverViewModel();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_jumpGameOver_JumpGameOver, UpdateJumpGameOver, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_jumpGameOver_SimpleProto, UpdateSimpleProto, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_roomData_SceneId, SetSceneId, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		if (arg2)
		{
			_viewModel.PanelObj.HideEverythingExceptGameObject();
		}
		else
		{
			_viewModel.PanelObj.RecoveryEverything();
		}
	}

	private bool GetVisible()
	{
		return _panelActiveChip.Time > 0;
	}

	private void SetSceneId(int arg1, int arg2)
	{
		_viewModel.SceneTextString = ScriptLocalization.Get($"Scene{arg2}Name");
	}

	private void UpdateJumpGameOver(bool old, bool value)
	{
		if (value)
		{
			_battleRoomContext.gameOver.IsJumpGameOver = false;
			_panelActiveChip.Time = 10000;
		}
	}

	private void UpdateSimpleProto(SimpleProto old, SimpleProto simpleProto)
	{
		if (simpleProto != null)
		{
			int num = simpleProto.Ins[0];
			int value = simpleProto.Ins[2];
			int value2 = simpleProto.Ins[3];
			int value3 = simpleProto.Ins[1];
			int num2 = num / 1000;
			_viewModel.MinutesString = StringCache.IntToStringD2(num2 / 60);
			_viewModel.SecondsString = StringCache.IntToStringD2(num2 % 60);
			_viewModel.MillisecondsString = StringCache.IntToStringD3(num % 1000 / 10);
			_viewModel.SavePointString = StringCache.IntToString(value);
			_viewModel.ReadPointString = StringCache.IntToString(value2);
			_viewModel.PenaltyPointString = StringCache.IntToString(value3);
		}
	}

	[GameUiTestMethod]
	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_viewModel.PanelShow)
		{
			int num = 10000 - _panelActiveChip.Time;
			if (num < 700)
			{
				_viewModel.MinutesAlpha = 0f;
			}
			else if (num < 1000)
			{
				_viewModel.MinutesAlpha = (float)(num - 700) / 300f;
			}
			else
			{
				_viewModel.MinutesAlpha = 1f;
			}
			if (num < 410)
			{
				_viewModel.TitleImageScale = Vector3.zero;
			}
			else if (num < 535)
			{
				_viewModel.TitleImageScale = Vector3.one * (2.5f - (float)(num - 410) / 125f * 1.5f);
			}
			else
			{
				_viewModel.TitleImageScale = Vector3.one;
			}
			if (num < 200)
			{
				_viewModel.TitleBackScale = Vector3.zero;
			}
			else if (num < 410)
			{
				_viewModel.TitleBackScale = Vector3.one * (num - 200) / 210f;
			}
			else
			{
				_viewModel.TitleBackScale = Vector3.one;
			}
			if (num < 300)
			{
				_viewModel.BaseBackImageAlpha = (float)num / 300f * 0.6f;
			}
			else
			{
				_viewModel.BaseBackImageAlpha = 0.6f;
			}
		}
	}

	private void InitChips()
	{
		_panelActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.PanelShow = _panelActiveChip.Update(_timeComponent);
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}
}
