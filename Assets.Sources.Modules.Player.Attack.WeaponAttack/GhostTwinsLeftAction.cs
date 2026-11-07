using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GhostTwinsLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public GhostTwinsLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(GhostTwinsFireDescClip);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(GhostTwinsFireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private static int GhostTwinsFireDescClip(ref CommonWeaponArg arg)
	{
		if (!arg.Player.state.GetPlayerStateType(512))
		{
			int num = 3;
			arg.CurrentWeapon.clip.Clip -= num;
			if (arg.CurrentWeapon.clip.Clip < 0)
			{
				arg.CurrentWeapon.clip.Clip = 0;
			}
		}
		return 0;
	}

	private static int GhostTwinsFireNextAttack(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval + 1200);
		return 0;
	}
}
