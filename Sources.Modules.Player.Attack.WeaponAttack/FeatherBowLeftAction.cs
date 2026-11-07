using System;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class FeatherBowLeftAction : ILeftCmdAction, ICmdAction
{
	public bool Action(ref CommonWeaponArg arg)
	{
		if (!CanFire(arg.CurrentWeapon, arg.ClientTime))
		{
			return false;
		}
		arg.CurrentWeapon.basicInfo.Data.Kill++;
		arg.CurrentWeapon.basicInfo.Data.Power = Math.Max(arg.CurrentWeapon.basicInfo.Data.Power - 1, 0);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval;
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 40, 1f, isNewEvent: true);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return true;
	}

	private bool CanFire(WeaponEntity currentWeapon, int clientTime)
	{
		if ((currentWeapon.basicInfo.Data.EffectLevel & 0x10) > 0 && (float)clientTime >= currentWeapon.attack.NextAttackTimer)
		{
			return currentWeapon.basicInfo.Data.Power > 0;
		}
		return false;
	}
}
