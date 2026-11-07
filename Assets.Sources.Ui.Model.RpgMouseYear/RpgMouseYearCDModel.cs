using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgMouseYear;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgMouseYear;

[GameUiTest]
public class RpgMouseYearCDModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private RpgMouseYearCDViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private ActiveChip _pickTipsActiveChip = new ActiveChip();

	private ActiveChip _cdTipsActiveChip = new ActiveChip();

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
		_viewModel = new RpgMouseYearCDViewModel();
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
		_viewModel.DropWeaponCDShow = false;
		_viewModel.PickDropWeaponShow = false;
		NotifyManager.MakeNotify(78, UiIEventCondition.Get_menu_VisibleChanged, SetPickShow);
	}

	private void SetCdShow(bool arg1, bool arg2)
	{
		if (arg2)
		{
			_cdTipsActiveChip.Time = 1000;
			_gameRuleContext.mouseYear.TipsCd = false;
		}
	}

	private void SetPickShow(bool arg1, bool arg2)
	{
		if (arg2)
		{
			_pickTipsActiveChip.Time = 3000;
			_gameRuleContext.mouseYear.TipsPick = false;
		}
	}

	private void InitChips()
	{
		_pickTipsActiveChip.Time = 0;
		_cdTipsActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.DropWeaponCDShow = _cdTipsActiveChip.Update(_timeComponent);
		_viewModel.PickDropWeaponShow = _pickTipsActiveChip.Update(_timeComponent);
	}
}
