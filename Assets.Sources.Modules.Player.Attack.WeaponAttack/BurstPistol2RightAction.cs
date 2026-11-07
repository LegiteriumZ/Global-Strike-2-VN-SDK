using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BurstPistol2RightAction : IRightCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public BurstPistol2RightAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		_ = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
		_ = (float)arg.ClientTime;
		return true;
	}
}
