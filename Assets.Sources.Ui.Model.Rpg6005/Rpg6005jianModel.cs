using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg6005;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Rpg6005;

[GameUiTest]
public class Rpg6005jianModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private Rpg6005jianViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

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

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Rpg6005jianViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_Jian, setJianShow, null, initinvoke: true, isFrameSeparation: true);
	}

	private void setJianShow(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
