using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom;

public class SetNextAttackTimerAction : IWeaponAction
{
	private readonly int _addTime;

	public SetNextAttackTimerAction(int addTime)
	{
		_addTime = addTime;
	}

	public WeaponActionResult.ACTION_RESULT DoAction(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + _addTime;
		return WeaponActionResult.ACTION_RESULT.DONE;
	}
}
