using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class CyBerPunkSwordRightAction : KnifeRightAction
{
	internal CyBerPunkSwordRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		_ = arg.CurrentWeapon.basicInfo.Info;
		if (arg.CurrentWeapon.basicInfo.Info is DefaultWeaponInfo defaultWeaponInfo)
		{
			float shotDistance = defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			if (arg.CurrentWeapon.special.EffectLevel == 1)
			{
				KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFire4Sound);
			}
			else
			{
				KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlaySecFireSound);
			}
		}
		return 0;
	}
}
