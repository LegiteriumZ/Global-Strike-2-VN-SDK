using Assets.Sources.Modules.Player.Attack.Utils;

namespace Sources.Modules.Player.Chain;

public class WeaponHitPlayerChain : IWeaponGenericChain<HitPlayerArgs>
{
	private HitPlayerAction _hitPlayerAction;

	public int Action(ref HitPlayerArgs args)
	{
		if (_hitPlayerAction != null)
		{
			return _hitPlayerAction(ref args);
		}
		return 0;
	}

	public static explicit operator WeaponHitPlayerChain(HitPlayerAction hitevent)
	{
		return new WeaponHitPlayerChain
		{
			_hitPlayerAction = hitevent
		};
	}
}
