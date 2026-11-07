using Assets.Sources.Constant;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BowRightAction : IRightCmdAction, ICmdAction
{
	public bool Action(ref CommonWeaponArg arg)
	{
		if (!canSecondaryFire(arg.CurrentWeapon, arg.ClientTime))
		{
			return false;
		}
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + 1000;
		arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
		(arg.CurrentWeapon.attach.Data as BowAttach).changeDelay = arg.ClientTime + 340;
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 66);
		return true;
	}

	private bool canSecondaryFire(WeaponEntity currentWeapon, int clientTime)
	{
		if (currentWeapon.attack.ShotsFired >= 1)
		{
			return false;
		}
		if (currentWeapon.clip.Clip == 0)
		{
			return false;
		}
		if ((currentWeapon.attach.Data as BowAttach).changeDelay > 0)
		{
			return false;
		}
		if ((float)clientTime < currentWeapon.attack.NextSecondaryAttackTimer)
		{
			return false;
		}
		if (!RuleUtilty.IsPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			return false;
		}
		return true;
	}
}
