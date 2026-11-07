using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BigFishSwordLeftAction : KnifeLeftAction
{
	public BigFishSwordLeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
		{
			return false;
		}
		if (WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime))
		{
			return arg.CurrentWeapon.basicInfo.Data.Kill == 0;
		}
		return false;
	}
}
