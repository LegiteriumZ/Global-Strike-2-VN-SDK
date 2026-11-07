using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.DeathMatch;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.DeathMatch;

public class DeathMatchReliveProgressModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private DeathmatchreliveprogressViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new DeathmatchreliveprogressViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_viewModel.PanelShow)
		{
			_viewModel.ProgressFillamount = ((UiIEventCondition.Get_gameProgressData_ProgressTotalTime() > 0) ? ((float)UiIEventCondition.Get_gameProgressData_CurrentProgressTime() / (float)UiIEventCondition.Get_gameProgressData_ProgressTotalTime()) : 0f);
			_viewModel.LightPosition = new Vector3(-146f + 292f * _viewModel.ProgressFillamount, 0f);
			if (UiIEventCondition.Get_gameProgressData_CurrentProgressTime() >= UiIEventCondition.Get_gameProgressData_ProgressTotalTime())
			{
				_viewModel.PanelShow = false;
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotify(11, UiIEventCondition.Get_gameProgressData_ProgressType, SetProgressType, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_gameProgressData_ProgressTotalTime, SetProgressTotalTime, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_gameProgressData_PlayerName, SetPlayerName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_IsDead, SetIsDead, null, initinvoke: true);
	}

	private void SetPlayerName(string arg1, string arg2)
	{
		_viewModel.PlayerNameString = arg2;
	}

	private void SetProgressTotalTime(int ov, int time)
	{
		_viewModel.PanelShow = time > 0;
	}

	private void SetIsDead(bool ov, bool isDead)
	{
		if (isDead)
		{
			_gameRuleContext.gameProgressData.ProgressTotalTime = 0;
		}
	}

	private void SetProgressType(ProgressType ov, ProgressType type)
	{
		switch (type)
		{
		case ProgressType.GENERALRESTWEAPON:
			if (!UiIEventCondition.Get_cameraOwnerData_IsDead())
			{
				_viewModel.PanelShow = true;
				_viewModel.TextString = ScriptLocalization.Get("ResetWeapon");
			}
			break;
		case ProgressType.ACTIVE:
			_viewModel.PanelShow = true;
			if (_gameRuleContext.currentRule.Rule.IsPve())
			{
				_viewModel.TextString = ScriptLocalization.Get("Placedc4");
			}
			else
			{
				_viewModel.TextString = ScriptLocalization.Get("ResetWeapon");
			}
			break;
		case ProgressType.DEMOLITION:
			_viewModel.PanelShow = true;
			_viewModel.TextString = ScriptLocalization.Get("Dismantledc4");
			break;
		case ProgressType.MERELIVEPLAYER:
			_viewModel.PanelShow = true;
			_viewModel.TextString = ScriptLocalization.Get("Mereliveplayer");
			break;
		case ProgressType.PLAYERRELIVEME:
			_viewModel.PanelShow = true;
			_viewModel.TextString = ScriptLocalization.Get("Playerreliveme");
			break;
		default:
			_viewModel.PanelShow = false;
			break;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
