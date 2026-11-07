using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class TripleAttackKnifeRightAction : KnifeRightAction
{
	public TripleAttackKnifeRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		int result = base.OnFire(ref arg);
		arg.CurrentWeapon.special.SpecialMode = false;
		return result;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
		{
			return false;
		}
		bool flag = false;
		if (!WeaponUtility.CanSecondaryAttack(ref arg))
		{
			if (arg.CurrentWeapon.special.SpecialMode && PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 15))
			{
				flag = true;
				arg.CurrentWeapon.special.SpecialMode = false;
			}
		}
		else if (arg.CurrentWeapon.attack.ShotsFired == 0)
		{
			flag = true;
		}
		if (flag)
		{
			arg.CurrentWeapon.attack.ShotsFired = 1;
		}
		return flag;
	}
}
