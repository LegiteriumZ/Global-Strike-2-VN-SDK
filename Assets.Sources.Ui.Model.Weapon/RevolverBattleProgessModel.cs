using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class RevolverBattleProgessModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private BowprogressViewModel _viewModel;

	private WeaponContext _weaponContext;

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private const int Component3 = 32768;

	private float _percent;

	protected override IUiViewModel ViewModel => _viewModel;

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
		_viewModel.ProgressBackPosition = Vector3.zero;
		_viewModel.ProgressPosition = Vector3.zero;
		base.DoSubscribe();
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetPercent, SetPercent, null, initinvoke: true));
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
		_notifyGroup.SetSuspend(!arg2);
	}

	private bool IsSpecialSwordHeavenJudge()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		bool flag = currentWeaponEntity != null && currentWeaponEntity.hasSpecial && currentWeaponEntity.special.SpecialMode;
		if (currentWeaponEntity != null && currentWeaponEntity.basicInfo.Data.WeaponName == "sword_heaven_judge")
		{
			return !flag;
		}
		return false;
	}

	private bool GetVisible()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			if (IsSpecialSwordHeavenJudge())
			{
				_percent = ((currentWeaponEntity.hasPower && currentWeaponEntity.power.MaxPower > 0) ? ((float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower) : 0f);
			}
			else
			{
				_percent = ((currentWeaponEntity.hasClip && currentWeaponEntity.clip.CarryClip2 > 0) ? ((float)currentWeaponEntity.clip.Clip2 / (float)currentWeaponEntity.clip.CarryClip2) : 0f);
			}
		}
		else
		{
			_percent = 0f;
		}
		return _percent > 0f;
	}

	private void SetPercent(float arg1, float percent)
	{
		_viewModel.ProgressFillamount = percent;
	}

	private float GetPercent()
	{
		return _percent;
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			_viewModel.ProgressSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, IsSpecialSwordHeavenJudge() ? "skillProgress" : "progress"), delegate(Sprite sprite)
			{
				_viewModel.ProgressSprite = sprite;
				_viewModel.ProgressNtvsize();
			});
			_viewModel.ProgressBackSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "progressBg"), delegate(Sprite sprite)
			{
				_viewModel.ProgressBackSprite = sprite;
				_viewModel.ProgressBackNtvsize();
				_viewModel.ProgressPosition = ((weaponName == "sword_heaven_judge") ? new Vector3(16f, 0f) : Vector3.zero);
			});
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
