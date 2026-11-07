using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class SniperGuardianProgressModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private SniperGuardianProgressViewModel _viewModel;

	private WeaponContext _weaponContext;

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
	}

	public override void CreateViewModel()
	{
		_viewModel = new SniperGuardianProgressViewModel();
	}

	public void OnPlayback()
	{
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowShow = false;
		_viewModel.SpecialCenterFillamount = 0f;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_AwpVisible, SetAwpVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetProgress, SetProgress, null, initinvoke: true);
	}

	private void SetAwpVisible(bool ov, bool awpVisible)
	{
		_viewModel.ShowShow = awpVisible;
	}

	private float GetProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return 0f;
		}
		if (!currentWeaponEntity.hasPower)
		{
			return 0f;
		}
		if (currentWeaponEntity.power.MaxPower == 0)
		{
			return 0f;
		}
		return Mathf.Clamp01((float)currentWeaponEntity.power.Power * 1f / (float)currentWeaponEntity.power.MaxPower);
	}

	private void SetProgress(float ov, float now)
	{
		_viewModel.SpecialCenterFillamount = now;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}
