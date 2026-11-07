using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg6005;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Rpg6005;

[GameUiTest]
public class Rpg6005XuliModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private Rpg6005XuliViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private int maxValue;

	private int currentValue;

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
		_viewModel = new Rpg6005XuliViewModel();
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
		SetChips(0f, 0f);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_Boss_XuliShow, SetShow, null, initinvoke: true);
	}

	private void SetShow(bool arg1, bool arg2)
	{
		_viewModel.ViewGameObjectShow = arg2;
		currentValue = _gameRuleContext.rpg6005.currentProcessValue;
		maxValue = _gameRuleContext.rpg6005.maxProcessValue;
		_viewModel.UpFillamount = (float)currentValue * 1f / (float)maxValue;
		SetChips(0f, maxValue);
	}

	private void SetProcess(int arg1, int arg2)
	{
		if (_viewModel.ViewGameObjectShow)
		{
			currentValue = _gameRuleContext.rpg6005.currentProcessValue;
			maxValue = _gameRuleContext.rpg6005.maxProcessValue;
			_viewModel.UpFillamount = (float)currentValue * 1f / (float)maxValue;
		}
	}

	private void SetChips(float start, float end)
	{
		_percentChip.Count = start;
		_percentChip.TargetCount = end;
		_percentChip.Speed = 1000f;
		_percentChip.IsOver = false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		if (!_percentChip.IsOver && maxValue > 0)
		{
			_viewModel.UpFillamount = _percentChip.Update(_timeComponent) / (float)maxValue;
		}
	}
}
