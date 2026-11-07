using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BigHead;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;
using share.constant;

namespace Assets.Sources.Ui.Model.BigHead;

[GameUiTest]
public class CrazyBigheadHeroStateModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private CrazyBigheadHeroStateViewModel _viewModel;

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
		_viewModel = new CrazyBigheadHeroStateViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Hp, SetHp, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_HeroPower, SetEn, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_Career, SetView, null, initinvoke: true);
		base.DoSubscribe();
	}

	private void SetHp(long arg1, long arg2)
	{
		AddUpdateHandler(SetHpProgress);
	}

	private void SetEn(int arg1, int arg2)
	{
		AddUpdateHandler(SetEnProgress);
	}

	private void SetView(string arg1, string arg2)
	{
		AddUpdateHandler(ShowView);
	}

	private void SetHpProgress(int idx)
	{
		if (UiIEventCondition.Get_cameraOwnerData_MaxHp() > 0 && UiIEventCondition.Get_cameraOwnerData_Hp() > 0)
		{
			_viewModel.HPNumberString = StringCache.LongToString(UiIEventCondition.Get_cameraOwnerData_Hp());
			_viewModel.HPBarFillamount = (float)UiIEventCondition.Get_cameraOwnerData_Hp() / (float)UiIEventCondition.Get_cameraOwnerData_MaxHp();
		}
		else
		{
			_viewModel.HPNumberString = "0";
			_viewModel.HPBarFillamount = 0f;
		}
	}

	private void SetEnProgress(int index)
	{
		_viewModel.EnNumberString = StringCache.IntToString(UiIEventCondition.Get_cameraOwnerData_HeroPower());
		_viewModel.ENBarFillamount = (float)UiIEventCondition.Get_cameraOwnerData_HeroPower() / (float)UiIEventCondition.Get_cameraOwnerData_HeroMaxPower();
	}

	private void ShowView(int index)
	{
		if (PlayerCareerUtil.IsHumanHero(UiIEventCondition.Get_cameraOwnerData_Career()))
		{
			_viewModel.ShowShow = true;
		}
		else
		{
			_viewModel.ShowShow = false;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
