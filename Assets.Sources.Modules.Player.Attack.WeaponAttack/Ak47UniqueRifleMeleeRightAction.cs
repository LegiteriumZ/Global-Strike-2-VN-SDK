using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Ak47UniqueRifleMeleeRightAction : RifleMeleeRightAction
{
	public static int G18_DELAYATTACKSTABTIME = 400;

	public static int AK47_DELAYATTACKSTABTIME = 500;

	public Ak47UniqueRifleMeleeRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 72);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo)
		{
			return WeaponUtility.CanSecondaryAttack(ref arg);
		}
		return false;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo rifleMeleeWeaponInfo)
		{
			float shotDistance = rifleMeleeWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, null);
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				FireUtility.PlayFire4Sound(ref arg);
			}
			else
			{
				FireUtility.PlaySecFireSound(ref arg);
			}
		}
		return 0;
	}

	protected override int GetDelayTime(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			return G18_DELAYATTACKSTABTIME;
		}
		return AK47_DELAYATTACKSTABTIME;
	}
}
