using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.HulaoguanModel;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using SSJJAsset.Asset;

namespace Assets.Sources.Ui.Model.HulaoguanModel;

[GameUiTest]
public class HuLaoGuanTopModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private HuLaoGuanTopViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private static AssetInfo a1 = new AssetInfo("ui/hulaoguanModel", "Assets/Res/Assets/ui/GameGUIRes/hulaoguanModel/strongholdstate/A1.png");

	private static AssetInfo a2 = new AssetInfo("ui/hulaoguanModel", "Assets/Res/Assets/ui/GameGUIRes/hulaoguanModel/strongholdstate/A2.png");

	private static AssetInfo b1 = new AssetInfo("ui/hulaoguanModel", "Assets/Res/Assets/ui/GameGUIRes/hulaoguanModel/strongholdstate/B1.png");

	private static AssetInfo b2 = new AssetInfo("ui/hulaoguanModel", "Assets/Res/Assets/ui/GameGUIRes/hulaoguanModel/strongholdstate/B2.png");

	private static AssetInfo c1 = new AssetInfo("ui/hulaoguanModel", "Assets/Res/Assets/ui/GameGUIRes/hulaoguanModel/strongholdstate/C1.png");

	private static AssetInfo c2 = new AssetInfo("ui/hulaoguanModel", "Assets/Res/Assets/ui/GameGUIRes/hulaoguanModel/strongholdstate/C2.png");

	private static AssetInfo effect1 = new AssetInfo("ui/hulaoguanModel", "Assets/Res/Assets/ui/GameGUIRes/hulaoguanModel/strongholdstate/effect1.png");

	private static AssetInfo effect2 = new AssetInfo("ui/hulaoguanModel", "Assets/Res/Assets/ui/GameGUIRes/hulaoguanModel/strongholdstate/effect2.png");

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
		_viewModel = new HuLaoGuanTopViewModel();
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
	}
}
