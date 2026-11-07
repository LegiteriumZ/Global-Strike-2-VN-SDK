using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg6005;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Rpg6005;

[GameUiTest]
public class Rpg6005LeiyinModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private Rpg6005LeiyinViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

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
		_viewModel = new Rpg6005LeiyinViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null)
		{
			_ = _viewModel.IsInited;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_Boss_LeiyinShow, SetShow, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_Boss_LeiyinCengshu, SetCengshu, null, initinvoke: true);
	}

	private void SetShow(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private void SetCengshu(int arg1, int arg2)
	{
		_viewModel.TextString = string.Concat(arg2);
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
