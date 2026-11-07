using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class DsrProgressModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetWeaponContext
{
	private BowprogressViewModel _viewModel;

	private PlayerContext _playerContext;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
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
		_viewModel = new BowprogressViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ProgressBackPosition = new Vector3(-130f, 68f);
		_viewModel.ProgressPosition = Vector3.zero;
		base.DoSubscribe();
		string text = (_weaponContext.isCurrentWeapon ? _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName : "");
		if (!string.IsNullOrEmpty(text))
		{
			SetWeaponImage(text, "attackintervalback", _viewModel.ProgressBackImage);
			SetWeaponImage(text, "attackinterval", _viewModel.ProgressImage);
		}
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_AwpVisible, SetAwpVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_HideCross, SetHideCross, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetPercent, SetPercent, null, initinvoke: true);
	}

	private void SetPercent(float arg1, float arg2)
	{
		_viewModel.ProgressFillamount = arg2;
	}

	private float GetPercent()
	{
		if (_viewModel.ShowShow && _playerContext.isCameraOwner && _weaponContext.isCurrentWeapon)
		{
			PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
			WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
			return 1f - (float)(currentWeaponEntity.basicInfo.Data.NextAttackTimer - cameraOwnerEntity.clientTime.ClientTime) / (float)currentWeaponEntity.basicInfo.Info.AttackInterval;
		}
		return 0f;
	}

	private void SetHideCross(bool ov, bool value)
	{
		CheckVisible();
	}

	private void SetAwpVisible(bool ov, bool awpVisible)
	{
		CheckVisible();
	}

	private void CheckVisible()
	{
		if (UiIEventCondition.Get_uiCross_HideCross())
		{
			_viewModel.ShowShow = false;
		}
		else
		{
			_viewModel.ShowShow = UiIEventCondition.Get_uiCross_AwpVisible();
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
