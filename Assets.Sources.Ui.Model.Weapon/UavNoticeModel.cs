using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class UavNoticeModel : AbstractModel, IPlaybackSystem
{
	private UavnoticeViewModel _viewModel;

	private int _raceType;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new UavnoticeViewModel();
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
		_raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		_viewModel.ShowShow = true;
		if (RuleUtilty.IsRpg(_raceType))
		{
			_viewModel.ShowShow = false;
		}
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			_viewModel.ImageSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "operation_guide"), delegate(Sprite sprite)
			{
				_viewModel.ImageSprite = sprite;
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
