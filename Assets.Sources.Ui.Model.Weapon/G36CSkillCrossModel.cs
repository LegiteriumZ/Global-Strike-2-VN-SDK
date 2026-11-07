using Assets.Generated.Table;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class G36CSkillCrossModel : AbstractModel, IPlaybackSystem
{
	private G36CSkillCrossViewModel _viewModel;

	private int _g36CEffect;

	private int _g36CTime;

	private bool _inSpecialModel;

	private bool _checkShow;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new G36CSkillCrossViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!_checkShow)
		{
			_viewModel.ShowShow = false;
			return;
		}
		if (!Contexts.sharedInstance.weapon.isCurrentWeapon)
		{
			_viewModel.ShowShow = false;
			return;
		}
		WeaponEntity currentWeaponEntity = Contexts.sharedInstance.weapon.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			_viewModel.ShowShow = false;
			return;
		}
		string weaponName = currentWeaponEntity.basicInfo.Data.WeaponName;
		int num = 0;
		if (currentWeaponEntity.hasSpecial && ((weaponName != "block_combined_jet" && currentWeaponEntity.special.EffectLevel > 0) || (weaponName == "block_combined_jet" && (currentWeaponEntity.special.EffectLevel & 1) > 0)))
		{
			if (!_inSpecialModel)
			{
				_g36CTime = 0;
			}
			_inSpecialModel = true;
			_viewModel.ShowShow = true;
			_g36CTime += Contexts.sharedInstance.time.time.FrameInterval;
			num = _g36CTime / 50 + 1;
			if (num > 25)
			{
				num = (num - 25) % 19 + 7;
			}
		}
		else if (_viewModel.ShowShow)
		{
			if (_inSpecialModel)
			{
				_g36CTime = 0;
			}
			_inSpecialModel = false;
			_g36CTime += Contexts.sharedInstance.time.time.FrameInterval;
			num = 7 - _g36CTime / 50;
			if (num <= 0)
			{
				_viewModel.ShowShow = false;
				return;
			}
		}
		if (_g36CEffect != num && _viewModel.ShowShow)
		{
			_g36CEffect = num;
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "aim" + num), delegate(Sprite sprite)
			{
				_viewModel.SpecialSprite = sprite;
				_viewModel.SpecialSize = new Vector3(Screen.height, Screen.height);
			});
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ShowShow = false;
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
	}

	private void SetWeaponName(string ov, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			if (weaponName == "block_combined_jet")
			{
				_checkShow = true;
				return;
			}
			WeaponCrossTable.Row row = WeaponCrossLoader.Instance.Table.Find_Name(weaponName);
			if (row != null && row.SniperCross == WeaponCrossTable.SniperCrossType.G36c)
			{
				_checkShow = true;
				return;
			}
		}
		_checkShow = false;
		_viewModel.ShowShow = false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
