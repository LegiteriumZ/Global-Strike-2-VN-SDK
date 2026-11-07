using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Sources.Modules.Player.Chain;

public class WeaponKnifeChain : IWeaponGenericChain<CommonWeaponArg>
{
	private KnifeHitAction _firefunc;

	public int Action(ref CommonWeaponArg args)
	{
		if (_firefunc != null)
		{
			return _firefunc(ref args);
		}
		return 0;
	}

	public static explicit operator WeaponKnifeChain(KnifeHitAction func)
	{
		return new WeaponKnifeChain
		{
			_firefunc = func
		};
	}
}
