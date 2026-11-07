using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class WolfClawLianjiModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private WolfclawlianjiViewModel _viewModel;

	private int _count;

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
		_viewModel = new WolfclawlianjiViewModel();
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
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetCount, SetCount, null, initinvoke: true);
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.showShow = arg2;
	}

	private bool GetVisible()
	{
		return _count > 0;
	}

	private void SetCount(int arg1, int arg2)
	{
		_count = arg2;
		_viewModel.sucTimesString = arg2.ToString();
	}

	private int GetCount()
	{
		if (!_weaponContext.isCurrentWeapon)
		{
			return 0;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity.basicInfo.Data.EffectLevel != 0)
		{
			return currentWeaponEntity.basicInfo.Data.EffectLevel - 1;
		}
		return 0;
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			_viewModel.lianjiSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "lianji"), delegate(Sprite sprite)
			{
				_viewModel.lianjiSprite = sprite;
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
