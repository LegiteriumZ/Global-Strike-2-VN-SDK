using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgMouseYear;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgMouseYear;

[GameUiTest]
public class RpgMouseYearTipsModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private RpgMouseYearTipsViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private ActiveChip _tipsReachPoint = new ActiveChip();

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
		_viewModel = new RpgMouseYearTipsViewModel();
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
		_viewModel.TipsReachPointShow = false;
		NotifyManager.MakeNotify(77, UiIEventCondition.Get_menu_VisibleChanged, SetTipsReachPoint);
	}

	private void SetTipsReachPoint(bool arg1, bool arg2)
	{
		_tipsReachPoint.Time = 3000;
	}

	private void InitChips()
	{
		_tipsReachPoint.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.TipsReachPointShow = _tipsReachPoint.Update(_timeComponent);
	}
}
