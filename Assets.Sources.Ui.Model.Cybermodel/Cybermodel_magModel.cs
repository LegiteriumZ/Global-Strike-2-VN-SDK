using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Cybermodel;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;

namespace Assets.Sources.Ui.Model.Cybermodel;

[GameUiTest]
public class Cybermodel_magModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private Cybermodel_magViewModel _viewModel;

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
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Cybermodel_magViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
		Contexts.sharedInstance.message.cyberRpg.exittime -= time.FrameInterval;
		_viewModel.ShowShow = Contexts.sharedInstance.message.cyberRpg.exittime > 0;
		if (Contexts.sharedInstance.message.cyberRpg.exittime > 0)
		{
			_viewModel.timerString = (Contexts.sharedInstance.message.cyberRpg.exittime / 1000).ToString();
		}
	}
}
