using Assets.Sources.Modules.Player.Attack.Utils;
using Sources.Modules.Player.Chain;

namespace Assets.Sources.Modules.Player.Chain;

public class WeaponHitWorldChain : IWeaponGenericChain<HitWorldArgs>
{
	private HitWorldAction _hitWorldAction;

	public int Action(ref HitWorldArgs args)
	{
		if (_hitWorldAction != null)
		{
			return _hitWorldAction(ref args);
		}
		return 0;
	}

	public static explicit operator WeaponHitWorldChain(HitWorldAction hitevent)
	{
		return new WeaponHitWorldChain
		{
			_hitWorldAction = hitevent
		};
	}
}
