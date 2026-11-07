using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class UavLeftAction : ILeftCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public UavLeftAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		return true;
	}
}
