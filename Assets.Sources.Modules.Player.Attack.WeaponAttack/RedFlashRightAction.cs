using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RedFlashRightAction : RifleMeleeNoSoundRightAction
{
	public RedFlashRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (RuleUtilty.IsBioMode(Contexts.battleRoom.roomData.Data.RaceType))
		{
			return false;
		}
		return base.CanFire(ref arg);
	}
}
