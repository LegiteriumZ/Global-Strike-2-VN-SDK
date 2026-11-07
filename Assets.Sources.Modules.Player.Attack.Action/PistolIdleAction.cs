using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class PistolIdleAction : IIdleCmdAction, ICmdAction
{
	protected readonly Contexts Contexts;

	public PistolIdleAction(Contexts contexts)
	{
		Contexts = contexts;
	}

	public virtual bool Action(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.ShotsFired = 0;
		return true;
	}
}
