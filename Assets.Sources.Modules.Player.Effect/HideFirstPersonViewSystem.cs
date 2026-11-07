using Assets.Sources.Framework;
using Entitas;
using share.constant;

namespace Assets.Sources.Modules.Player.Effect;

public class HideFirstPersonViewSystem : IAfterPredicationSystem
{
	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private IGroup<PlayerEntity> _group;

	public HideFirstPersonViewSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.FirstPersonUnityObjects, PlayerMatcher.Fov));
		_gameRuleContext = contexts.gameRule;
		_weaponContext = contexts.weapon;
	}

	public void OnAfterPredication()
	{
		foreach (PlayerEntity item in _group)
		{
			if (item.hasFirstPersonUnityObjects)
			{
				bool isHideFirstViewHand = false;
				bool isHideFirstViewWeapon = false;
				if (item.firstPersonUnityObjects.HandCameraObject.IsActiveSelf() != !item.fov.IsHideFristView)
				{
					isHideFirstViewHand = item.fov.IsHideFristView;
					item.firstPersonUnityObjects.HandCameraObject.SetObjectActive(!item.fov.IsHideFristView);
				}
				if (_weaponContext != null && _weaponContext.currentWeaponEntity != null && _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName != "trick_glass_darts" && item.firstPersonUnityObjects.WeaponGameObject.IsActiveSelf() != !item.fov.IsHideFristView)
				{
					isHideFirstViewWeapon = item.fov.IsHideFristView;
					item.firstPersonUnityObjects.WeaponGameObject.SetObjectActive(!item.fov.IsHideFristView);
				}
				if (_gameRuleContext.weaponCombination.HideFirstPersonView && item.firstPersonUnityObjects.HandCameraObject.IsActiveSelf())
				{
					isHideFirstViewHand = true;
					item.firstPersonUnityObjects.HandCameraObject.SetObjectActive(isactive: false);
				}
				if (_gameRuleContext.weaponCombination.HideFirstPersonView && item.firstPersonUnityObjects.WeaponGameObject.IsActiveSelf())
				{
					isHideFirstViewWeapon = true;
					item.firstPersonUnityObjects.WeaponGameObject.SetObjectActive(isactive: false);
				}
				hidePlayerKicking(item, isHideFirstViewHand, isHideFirstViewWeapon);
			}
		}
	}

	private void hidePlayerKicking(PlayerEntity player, bool isHideFirstViewHand, bool isHideFirstViewWeapon)
	{
		if (!isHideFirstViewHand)
		{
			if (player.HasStatus(PlayerInfoStatusConstant.PLAYER_KICKING_P1.ID))
			{
				if (player.firstPersonUnityObjects.HandGameObject.IsActiveSelf())
				{
					player.firstPersonUnityObjects.HandGameObject.SetObjectActive(isactive: false);
				}
			}
			else if (!player.firstPersonUnityObjects.HandGameObject.IsActiveSelf())
			{
				player.firstPersonUnityObjects.HandGameObject.SetObjectActive(isactive: true);
			}
		}
		if (isHideFirstViewWeapon)
		{
			return;
		}
		if (player.HasStatus(PlayerInfoStatusConstant.PLAYER_KICKING_P1.ID))
		{
			if (player.firstPersonUnityObjects.WeaponGameObject.IsActiveSelf())
			{
				player.firstPersonUnityObjects.WeaponGameObject.SetObjectActive(isactive: false);
			}
		}
		else if (!player.firstPersonUnityObjects.WeaponGameObject.IsActiveSelf())
		{
			player.firstPersonUnityObjects.WeaponGameObject.SetObjectActive(isactive: true);
		}
	}
}
