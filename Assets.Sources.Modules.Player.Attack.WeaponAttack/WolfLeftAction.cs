using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class WolfLeftAction : KnifeLeftAction
{
	public WolfLeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
		{
			return false;
		}
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			return false;
		}
		return WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime);
	}
}
