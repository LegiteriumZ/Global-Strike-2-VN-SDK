using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom.Conditions;

public class NextSecondaryAttackTimerCondition : IWeaponCondition
{
	public bool DoCondition(ref CommonWeaponArg arg)
	{
		return arg.ClientTime > (int)arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
	}
}
