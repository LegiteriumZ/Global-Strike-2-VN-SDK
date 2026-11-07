using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GatlingRightAction : IRightCmdAction, ICmdAction
{
	public GatlingRightAction(Contexts contexts)
	{
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer <= (float)arg.ClientTime)
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + 300;
			arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
		}
		return true;
	}
}
