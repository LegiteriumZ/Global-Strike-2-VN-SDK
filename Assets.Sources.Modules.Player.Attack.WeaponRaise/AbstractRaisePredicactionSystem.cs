using Assets.Sources.Framework;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal abstract class AbstractRaisePredicactionSystem : IPredicateSystem
{
	private WeaponContext _weaponContext;

	private Contexts _contexts;

	protected AbstractRaisePredicactionSystem(Contexts contexts)
	{
		_weaponContext = contexts.weapon;
		_contexts = contexts;
	}

	protected abstract int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd);

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			InitWeapon(player, currentWeaponEntity, cmd);
			if (_weaponContext.lastWeaponEntity != null)
			{
				RaiseAction(player, currentWeaponEntity, _weaponContext.lastWeaponEntity, cmd);
			}
		}
	}

	protected virtual void SetRaiseAnim(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon, IUserCmd cmd)
	{
	}

	protected virtual void RaiseAction(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon, IUserCmd cmd)
	{
		SetRaiseAnim(player, currentWeapon, lastWeapon, cmd);
		RightAfterRaised(player, currentWeapon, lastWeapon, cmd);
		if (WeaponUtility.HasLeftAnim(currentWeapon.basicInfo.Info))
		{
			LeftAfterRaised(player, currentWeapon, lastWeapon, cmd);
		}
	}

	protected virtual void InitWeapon(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		currentWeapon.attack.ShotsFired = 0;
		if (currentWeapon.hasBurstMode)
		{
			currentWeapon.burstMode.BurstModeShotsFired = 0;
		}
		WeaponUtility.ResetDelayFire(currentWeapon);
		WeaponUtility.ResetReload(currentWeapon);
	}

	protected virtual float GetNextWeaponRaisedSpeed(PlayerEntity player, WeaponEntity currentWeaponEntity, WeaponEntity nextWeaponEntity)
	{
		return 1f;
	}

	protected AbstractRaisePredicactionSystem GetRaisePredicactionSystemByName(string name)
	{
		if (PlayerWeaponRaisePredicationSystem.SubSystems != null && PlayerWeaponRaisePredicationSystem.SubSystems.TryGetValue(name, out var value))
		{
			return value as AbstractRaisePredicactionSystem;
		}
		return new DefaultRaisePrediactionSystem(_contexts);
	}

	protected void RightAfterRaised(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon, IUserCmd cmd)
	{
		int raiseAdminId = GetRaiseAdminId(player, currentWeapon, cmd);
		setViewRaiseAnim(player, raiseAdminId, currentWeapon);
		float raiseSpeed = GetRaiseSpeed(player, currentWeapon, lastWeapon);
		player.viewAnim.RightSpeed = raiseSpeed;
		player.viewAnim.LeftSpeed = raiseSpeed;
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, raiseAdminId);
		viewAnimDuration = (int)((float)viewAnimDuration / raiseSpeed);
		currentWeapon.attack.NextAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
		currentWeapon.attack.NextSecondaryAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
		if (player.hasBasicInfo && !player.basicInfo.IsDead)
		{
			setTorsoRaiseAnim(player, raiseAdminId, currentWeapon);
		}
	}

	protected float GetRaiseSpeed(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon)
	{
		float result = 1f;
		if (lastWeapon != null)
		{
			result = GetRaisePredicactionSystemByName(lastWeapon.basicInfo.Info.RaiseType).GetNextWeaponRaisedSpeed(player, lastWeapon, currentWeapon);
			if (SelfRaiseSpeed(currentWeapon))
			{
				float nextWeaponRaisedSpeed = GetRaisePredicactionSystemByName(currentWeapon.basicInfo.Info.RaiseType).GetNextWeaponRaisedSpeed(player, currentWeapon, currentWeapon);
				result = ((nextWeaponRaisedSpeed > result) ? nextWeaponRaisedSpeed : result);
			}
			result = Mathf.Max(result, player.viewAnim.RightSpeed);
		}
		return result;
	}

	private static bool SelfRaiseSpeed(WeaponEntity currentWeapon)
	{
		if (currentWeapon.hasBasicInfo)
		{
			if (!currentWeapon.basicInfo.Data.WeaponName.Equals("ak47_strike") && !currentWeapon.basicInfo.Data.WeaponName.Equals("blade_strike") && !currentWeapon.basicInfo.Data.WeaponName.Equals("grenade_strike") && !currentWeapon.basicInfo.Data.WeaponName.Equals("m249_moon") && !currentWeapon.basicInfo.Data.WeaponName.Equals("scar_legend1") && !currentWeapon.basicInfo.Data.WeaponName.Equals("scar_legend2"))
			{
				return currentWeapon.basicInfo.Data.WeaponName.Equals("scar_legend3");
			}
			return true;
		}
		return false;
	}

	protected virtual void setTorsoRaiseAnim(PlayerEntity player, int animId, WeaponEntity currentWeapon)
	{
		PlayerAnimationUtility.SetTorseAnimation(player, animId);
	}

	protected virtual void setViewRaiseAnim(PlayerEntity player, int animId, WeaponEntity weapon)
	{
		PlayerAnimationUtility.SetViewAnimation(player, animId);
	}

	protected void LeftAfterRaised(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon, IUserCmd cmd)
	{
		int raiseAdminId = GetRaiseAdminId(player, currentWeapon, cmd);
		PlayerAnimationUtility.SetLeftViewAnimation(player, raiseAdminId);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, raiseAdminId);
		string raiseType = lastWeapon.basicInfo.Info.RaiseType;
		float nextWeaponRaisedSpeed = GetRaisePredicactionSystemByName(raiseType).GetNextWeaponRaisedSpeed(player, lastWeapon, currentWeapon);
		float leftSpeed = player.viewAnim.LeftSpeed;
		if (nextWeaponRaisedSpeed > leftSpeed)
		{
			player.viewAnim.LeftSpeed = nextWeaponRaisedSpeed;
		}
		viewAnimDuration = (int)((float)viewAnimDuration / player.viewAnim.LeftSpeed);
		currentWeapon.attack.NextAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
		currentWeapon.attack.NextSecondaryAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
	}
}
