using System.Collections.Generic;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom;

public class BaseWeaponAction : IWeaponAction
{
	private readonly List<IWeaponAction> _weaponActions = new List<IWeaponAction>();

	public IWeaponAction AddAction(IWeaponAction action)
	{
		_weaponActions.Add(action);
		return this;
	}

	public WeaponActionResult.ACTION_RESULT DoAction(ref CommonWeaponArg arg)
	{
		foreach (IWeaponAction weaponAction in _weaponActions)
		{
			weaponAction.DoAction(ref arg);
		}
		return WeaponActionResult.ACTION_RESULT.DONE;
	}
}
