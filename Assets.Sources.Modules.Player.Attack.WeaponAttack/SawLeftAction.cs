using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SawLeftAction : ILeftCmdAction, ICmdAction
{
	protected bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			return false;
		}
		if (arg.CurrentWeapon.power.Power == 0)
		{
			return false;
		}
		if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
		{
			return false;
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64))
		{
			return false;
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63))
		{
			return false;
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 65))
		{
			return false;
		}
		return WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime);
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (CanFire(ref arg))
		{
			KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 64);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 64);
			arg.CurrentWeapon.special.SpecialMode = true;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + knifeWeaponInfo.SlashStabTime;
		}
		return true;
	}
}
