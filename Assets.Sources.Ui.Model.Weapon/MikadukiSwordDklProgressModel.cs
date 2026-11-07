using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class MikadukiSwordDklProgressModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private BowprogressViewModel _viewModel;

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private const int Component3 = 32768;

	private float _percent;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

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
		_viewModel.ProgressPosition = new Vector3(12f, 0.5f, 0f);
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

	private bool GetVisible()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasClip)
		{
			_percent = ((currentWeaponEntity.clip.CarryClip2 > 0) ? ((float)currentWeaponEntity.clip.Clip2 / (float)currentWeaponEntity.clip.CarryClip2) : 0f);
		}
		else
		{
			_percent = 0f;
		}
		if (_percent > 0f)
		{
			return (currentWeaponEntity.basicInfo.Data.EffectLevel & 0x8000) > 0;
		}
		return false;
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
			_viewModel.ProgressSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "progress"), delegate(Sprite sprite)
			{
				_viewModel.ProgressSprite = sprite;
				_viewModel.ProgressNtvsize();
			});
			_viewModel.ProgressBackSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "progressBg"), delegate(Sprite sprite)
			{
				_viewModel.ProgressBackSprite = sprite;
				_viewModel.ProgressBackNtvsize();
			});
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}
