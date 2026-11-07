using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class ThorHammerModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private ThorHammerViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
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
		_viewModel = new ThorHammerViewModel();
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
		if (!RuleUtilty.IsGeneralPve(_battleRoomContext.roomData.Data.RaceType) && (!RuleUtilty.IsPveModel(_battleRoomContext.roomData.Data.RaceType) || RuleUtilty.IsGeneralPve(_battleRoomContext.roomData.Data.RaceType)))
		{
			_viewModel.RightBottomShow = false;
		}
		NotifyManager.MakeTempNotify(GetShiled, SetShiled, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetDamage, SetDamage, null, initinvoke: true);
	}

	private void SetDamage(float arg1, float arg2)
	{
		_viewModel.DamageString = ((int)arg2).ToString("D3");
	}

	private float GetDamage()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasClip)
		{
			return 0f;
		}
		return currentWeaponEntity.clip.Clip2;
	}

	private void SetShiled(float arg1, float arg2)
	{
		_viewModel.ShieldString = ((int)arg2).ToString("D2");
	}

	private float GetShiled()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasClip)
		{
			return 0f;
		}
		return currentWeaponEntity.clip.Clip;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
