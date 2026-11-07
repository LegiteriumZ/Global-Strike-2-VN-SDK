using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RiderGrenadePredicationSystem : AbstractAttackPredicationSystem
{
	private class RiderGrenadeFrameAction : IFrameCmdAction, ICmdAction
	{
		public RiderGrenadeFrameAction(Contexts contexts)
		{
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			arg.Player.SetWeaponLock(arg.CurrentWeapon.power.Power >= 0);
			return false;
		}
	}

	public RiderGrenadePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		FrameActions.Add(new RiderGrenadeFrameAction(contexts));
	}
}
