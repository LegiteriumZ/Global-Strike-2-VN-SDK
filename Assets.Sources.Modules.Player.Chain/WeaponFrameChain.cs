using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;
using Sources.Modules.Player.Chain;

namespace Assets.Sources.Modules.Player.Chain;

public class WeaponFrameChain : IWeaponGenericChain<CommonWeaponArg>
{
	private WeaponFrameAction _action;

	public int Action(ref CommonWeaponArg args)
	{
		if (_action != null)
		{
			return _action(ref args);
		}
		return 0;
	}

	public static explicit operator WeaponFrameChain(WeaponFrameAction func)
	{
		return new WeaponFrameChain
		{
			_action = func
		};
	}
}
