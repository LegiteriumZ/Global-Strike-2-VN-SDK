using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class VoidJumpRightAction : RifleMeleeRightAction
{
	public VoidJumpRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + 1266);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
		if (base.DelayAttackStabTimeSet > 0)
		{
			WeaponUtility.SetDelayAttackStabTime(ref arg, base.DelayAttackStabTimeSet);
		}
		return 0;
	}
}
