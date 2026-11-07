using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class ElectricPistolLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public ElectricPistolLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.PostolFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(FireNextSkill);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private static int FireNextSkill(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.basicInfo.Data.NextSkillTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval);
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime) && CanReleaseSkill(arg.CurrentWeapon, arg.ClientTime))
		{
			return arg.CurrentWeapon.special.SpecialMode;
		}
		return false;
	}

	private static bool CanReleaseSkill(WeaponEntity weapon, int clientTime)
	{
		return clientTime >= weapon.basicInfo.Data.NextSkillTimer;
	}
}
