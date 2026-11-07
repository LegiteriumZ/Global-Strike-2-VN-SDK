using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class G18FrameAction : AbstractFrameAction
{
	public G18FrameAction(Contexts contexts)
		: base(contexts)
	{
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		FireUtility.CheckShowGun(arg);
		return base.Action(ref arg);
	}
}
