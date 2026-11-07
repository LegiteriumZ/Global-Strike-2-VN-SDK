using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class CrystalBowLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public CrystalBowLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireDescClip);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			arg.CurrentWeapon.spread.Spread = 0.001f;
			return 0;
		}
		if (arg.CurrentWeapon.clip.Clip2 == 40)
		{
			arg.CurrentWeapon.spread.Spread = 0.001f;
		}
		return base.OnFire(ref arg);
	}

	private int FireDescClip(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.clip.Clip2 == 40)
		{
			return 0;
		}
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			if (arg.CurrentWeapon.clip.Clip >= 3)
			{
				arg.CurrentWeapon.clip.Clip -= 3;
			}
			else
			{
				arg.CurrentWeapon.clip.Clip = 0;
			}
		}
		else
		{
			arg.CurrentWeapon.clip.Clip -= arg.CurrentWeapon.basicInfo.Info.ClipPerShot;
		}
		return 0;
	}
}
