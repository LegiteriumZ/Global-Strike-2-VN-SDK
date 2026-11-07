using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class Potential2Model : AbstractModel, IPlaybackSystem, ISetWeaponContext, ISetGameRuleContext
{
	private PotentialViewModel _viewModel;

	private WeaponContext _weaponContext;

	private GameRuleContext _gameRuleContext;

	private int _currLevel = -1;

	protected override IUiViewModel ViewModel => _viewModel;

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
		_viewModel = new PotentialViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
		if (_viewModel.RightBottomShow)
		{
			WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
			if (_weaponContext.isCurrentWeapon && currentWeaponEntity.hasSpecial)
			{
				_viewModel.KillCountString = currentWeaponEntity.special.Kil.ToString();
			}
		}
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
	}

	private void SetWeaponName(string ov, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName) && !_gameRuleContext.currentRule.Rule.IsPve())
		{
			WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
			if (currentWeaponEntity.basicInfo.Data.Permanent)
			{
				_viewModel.RightBottomShow = true;
				if (!currentWeaponEntity.hasSpecial)
				{
					return;
				}
				if (_currLevel != currentWeaponEntity.special.Level)
				{
					_currLevel = currentWeaponEntity.special.Level;
					base.Loader.RetriveSprite("ui/common", $"Assets/Res/Assets/ui/GameGUIRes/common/potential/level{currentWeaponEntity.special.Level}.png", delegate(Sprite sprite)
					{
						_viewModel.BackImageSprite = sprite;
					});
				}
				_viewModel.KillCountString = currentWeaponEntity.special.Kil.ToString();
				return;
			}
		}
		_viewModel.RightBottomShow = false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
