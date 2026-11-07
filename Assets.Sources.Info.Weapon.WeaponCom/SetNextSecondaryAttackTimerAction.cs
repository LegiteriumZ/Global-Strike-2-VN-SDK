using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom;

public class SetNextSecondaryAttackTimerAction : IWeaponAction
{
	private readonly int _addTime;

	public SetNextSecondaryAttackTimerAction(int addTime)
	{
		_addTime = addTime;
	}

	public WeaponActionResult.ACTION_RESULT DoAction(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer += arg.ClientTime + _addTime;
		return WeaponActionResult.ACTION_RESULT.DONE;
	}
}
