using Assets.Sources.Utils.Weapon;

namespace Sources.Modules.Player.Chain;

public class WeaponFireChain : IWeaponGenericChain<CommonWeaponArg>
{
	private FireUtility.FireFunc _firefunc;

	public int Action(ref CommonWeaponArg args)
	{
		if (_firefunc != null)
		{
			return _firefunc(ref args);
		}
		return 0;
	}

	public static explicit operator WeaponFireChain(FireUtility.FireFunc func)
	{
		return new WeaponFireChain
		{
			_firefunc = func
		};
	}
}
