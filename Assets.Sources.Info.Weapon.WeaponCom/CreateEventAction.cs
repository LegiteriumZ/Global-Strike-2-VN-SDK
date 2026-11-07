using System.Collections.Generic;
using Assets.Sources.Info.Weapon.WeaponCom.Conditions;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom;

public class CreateEventAction : IWeaponAction
{
	private IWeaponAction _doAction;

	private int _delay;

	private List<IWeaponAction> _weaponActionList;

	private int _seq;

	public CreateEventAction(IWeaponAction doAction, List<IWeaponAction> weaponActionList, int delay)
	{
		_doAction = doAction;
		_weaponActionList = weaponActionList;
		_delay = delay;
	}

	public WeaponActionResult.ACTION_RESULT DoAction(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.Seq <= _seq)
		{
			return WeaponActionResult.ACTION_RESULT.DONE;
		}
		_seq = arg.Cmd.Seq;
		_weaponActionList.Add(new ConditionAction().SetCanDo(new RenderTimeBigCondition(arg.ClientTime + _delay)).SetTrueLogic(_doAction));
		return WeaponActionResult.ACTION_RESULT.DONE;
	}
}
