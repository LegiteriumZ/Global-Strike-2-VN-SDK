using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class WeaponStateChangeModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private WeaponStateChangeViewModel _viewModel;

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
		_viewModel = new WeaponStateChangeViewModel();
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
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		NotifyManager.MakeTempNotify(GetCanUse, SetCanUse, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetSpecialMode, SetSpecialMode, null, initinvoke: true);
		base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Data.WeaponName}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Data.WeaponName}/ui/activeBg.png", delegate(Sprite sprite)
		{
			_viewModel.SkillEnableSprite = sprite;
		});
		base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Data.WeaponName}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Data.WeaponName}/ui/activeBg_special.png", delegate(Sprite sprite)
		{
			_viewModel.SkillSpecialEnableSprite = sprite;
		});
	}

	private void SetCanUse(bool arg1, bool arg2)
	{
		_viewModel.SkillSpecialEnableShow = !arg2;
		_viewModel.SkillEnableShow = arg2;
	}

	private bool GetCanUse()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasBasicInfo && currentWeaponEntity.basicInfo.Data != null && (currentWeaponEntity.basicInfo.Data.EffectLevel & 0x80) > 0 && (currentWeaponEntity.basicInfo.Data.EffectLevel & 0x40) > 0)
		{
			return true;
		}
		return false;
	}

	private bool GetSpecialMode()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasBasicInfo)
		{
			return _weaponContext.currentWeaponEntity.basicInfo.Data.SpecialMode;
		}
		return false;
	}

	private void SetSpecialMode(bool arg1, bool arg2)
	{
		_ = _weaponContext.currentWeaponEntity;
		_viewModel.RightBottomShow = arg2;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
