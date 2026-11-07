using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgMystery;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.RpgMystery;

[GameUiTest]
public class LightFireStatusModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private float _initPercent = -1f;

	private int _startTime;

	private int _allTime;

	private LightFireStatusViewModel _viewModel;

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
	}

	public override void CreateViewModel()
	{
		_viewModel = new LightFireStatusViewModel();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(GetShow, SetShow, null, initinvoke: true);
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited && _viewModel.PanelShow)
		{
			_startTime += _timeComponent.FrameInterval;
			float num = ((_allTime > 0) ? ((float)_startTime / (float)_allTime) : 0f);
			if (!Mathf.Approximately(num - _initPercent, 0f))
			{
				_viewModel.ProgressFillamount = num;
				_viewModel.LightPosition = new Vector3(-145f + 290f * num, 0f);
				_initPercent = num;
			}
			if (_startTime >= _allTime)
			{
				_gameRuleContext.mystery.IsLightFireStatusTips = false;
				_viewModel.PanelShow = false;
			}
		}
	}

	private bool GetShow()
	{
		return _gameRuleContext.mystery.IsLightFireStatusTips;
	}

	private void SetShow(bool ov, bool ne)
	{
		_viewModel.PanelShow = ne;
		if (ne)
		{
			_viewModel.TextString = ScriptLocalization.Get("MY_MSTERY_LIGHT_STATUS");
			_viewModel.PlayerNameString = UiIEventCondition.Get_cameraOwnerData_PlayerName();
			_viewModel.GridHlayoutupdate();
			_allTime = _gameRuleContext.mystery.LightFireStatusTime;
			_startTime = 0;
		}
	}
}
