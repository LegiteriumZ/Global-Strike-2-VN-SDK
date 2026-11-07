using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgMouseYear;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.RpgMouseYear;

[GameUiTest]
public class RpgMouseYearCarProgressModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private RpgMouseYearCarProgressViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private float _carSignMin = -526f;

	private float _carSignMax = 508f;

	private float _checkPointMin = -1f;

	private float _checkPointMax = 1024f;

	private const int CheckPointCount = 7;

	private float[] _checkPointPercent = new float[5] { 0.098f, 0.198f, 0.354f, 0.594f, 0.901f };

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	private void SetCheckPoint()
	{
		for (int i = 1; i <= 7; i++)
		{
			_viewModel.SetCheckPointShow(i, i <= _checkPointPercent.Length);
		}
		for (int j = 1; j <= _checkPointPercent.Length; j++)
		{
			Vector3 checkPointPosition = _viewModel.GetCheckPointPosition(j);
			checkPointPosition.x = (_checkPointMax - _checkPointMin) * _checkPointPercent[j - 1] + _checkPointMin;
			_viewModel.SetCheckPointPosition(j, new Vector3(checkPointPosition.x, checkPointPosition.y, checkPointPosition.z));
		}
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgMouseYearCarProgressViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		SetCheckPoint();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_MouseYear_CarProgress, SetProgress, null, initinvoke: true);
	}

	private void SetProgress(float arg1, float arg2)
	{
		_viewModel.ProgressUpFillamount = arg2;
		_viewModel.CarPosition = new Vector3(_carSignMin + (_carSignMax - _carSignMin) * arg2, _viewModel.CarPosition.y, _viewModel.CarPosition.z);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
