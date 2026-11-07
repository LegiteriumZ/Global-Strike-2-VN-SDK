using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class DangongCrossModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetWeaponContext
{
	private DangongCrossViewModel _viewModel;

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
		_viewModel = new DangongCrossViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_viewModel.ShowShow && _weaponContext.isCurrentWeapon)
		{
			PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
			WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
			float num = 0f;
			if (currentWeaponEntity.basicInfo.Data.ShotsFired > 0)
			{
				num = (float)(cameraOwnerEntity.clientTime.ClientTime - currentWeaponEntity.basicInfo.Data.NextAttackTimer) / 800f;
				num = ((num < 0f) ? 0f : ((num > 1f) ? 16f : (num * 16f)));
			}
			_viewModel.DangongLeftPosition = new Vector3(0f - num, 0f, 0f);
			_viewModel.DangongRightPosition = new Vector3(num, 0f, 0f);
			_viewModel.DangongTopPosition = new Vector3(0f, 0f - num, 0f);
			_viewModel.DangongBottomPosition = new Vector3(0f, num, 0f);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_HideCross, SetHideCross, null, initinvoke: true);
	}

	private void SetHideCross(bool ov, bool value)
	{
		_viewModel.ShowShow = !value;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
