using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgStateProgressModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetBattleRoomContext
{
	protected RpgStateProgressViewModel _viewModel;

	protected float _initPercent = -1f;

	protected GameRuleContext _gameRuleContext;

	protected BattleRoomContext _battleRoomContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgStateProgressViewModel();
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
			int gameProgressData_ProgressTotalTime = UiIEventCondition.Get_gameProgressData_ProgressTotalTime();
			int gameProgressData_CurrentProgressTime = UiIEventCondition.Get_gameProgressData_CurrentProgressTime();
			float num = ((gameProgressData_ProgressTotalTime > 0) ? ((float)gameProgressData_CurrentProgressTime / (float)gameProgressData_ProgressTotalTime) : 0f);
			if (!Mathf.Approximately(num - _initPercent, 0f))
			{
				_viewModel.ProgressFillamount = num;
				_viewModel.LightPosition = new Vector3(-145f + 290f * num, 0f);
				_initPercent = num;
			}
			if (gameProgressData_CurrentProgressTime >= gameProgressData_ProgressTotalTime)
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
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_gameProgressData_Details, SetDetails, null, initinvoke: true);
	}

	protected void SetPlayerName(string ov, string name)
	{
		_viewModel.PlayerNameString = name;
		_viewModel.GridHlayoutupdate();
	}

	protected void SetDetails(string ov, string value)
	{
		_viewModel.TextString = value;
		_viewModel.GridHlayoutupdate();
	}

	protected void SetProgressTotalTime(int ov, int time)
	{
		if (Contexts.sharedInstance.gameRule.gameProgressData.ProgressType != ProgressType.ROLESKILL1018)
		{
			_viewModel.PanelShow = time > 0;
		}
	}

	protected void SetIsDead(bool ov, bool isDead)
	{
		if (isDead)
		{
			_gameRuleContext.gameProgressData.ProgressTotalTime = 0;
		}
	}

	protected void SetProgressType(ProgressType ov, ProgressType type)
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
			_viewModel.TextString = "";
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
		case ProgressType.FREEPROGRESS:
			_viewModel.PanelShow = true;
			break;
		case ProgressType.SPEEDCHANGE:
			_viewModel.PanelShow = true;
			break;
		default:
			_viewModel.PanelShow = false;
			break;
		}
		_viewModel.GridHlayoutupdate();
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

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}
}
