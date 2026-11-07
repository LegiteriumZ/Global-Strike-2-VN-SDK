using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgMouseYear;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgMouseYear;

[GameUiTest]
public class RpgMouseYearEnemgyModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private RpgMouseYearEnemgyViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private float _minPercent = 0.1f;

	private float _maxPercent = 0.89f;

	private TimerChip _percentChip = new TimerChip();

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

	public override void CreateViewModel()
	{
		_viewModel = new RpgMouseYearEnemgyViewModel();
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
		_viewModel.UpFillamount = 0f;
		SetChips(0f, _minPercent);
		for (int i = 1; i < 5; i++)
		{
			_viewModel.SetLvUpShow(i, value: false);
		}
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_MouseYear_EnemyData, SetPercent, null, initinvoke: true);
	}

	private void SetPercent(int arg1, int arg2)
	{
		List<int> enemyList = _gameRuleContext.mouseYear.EnemyList;
		if (enemyList == null)
		{
			return;
		}
		float num = 0f;
		int num2 = 0;
		if (arg2 > 0)
		{
			num2 = 1;
		}
		for (int i = 0; i < enemyList.Count; i++)
		{
			if (arg2 >= enemyList[i])
			{
				num += 1f / (float)enemyList.Count;
				arg2 -= enemyList[i];
				num2 = i + 2;
				continue;
			}
			float num3 = (float)arg2 / (float)enemyList[i] / (float)enemyList.Count;
			num += num3;
			break;
		}
		SetChips(_viewModel.UpFillamount, num * (_maxPercent - _minPercent) + _minPercent);
		for (int j = 1; j <= num2; j++)
		{
			_viewModel.SetLvUpShow(j, value: true);
		}
	}

	private void SetChips(float start, float end)
	{
		_percentChip.Count = start;
		_percentChip.TargetCount = end;
		_percentChip.Speed = end - start;
		_percentChip.IsOver = false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		if (!_percentChip.IsOver)
		{
			_viewModel.UpFillamount = _percentChip.Update(_timeComponent);
		}
	}
}
