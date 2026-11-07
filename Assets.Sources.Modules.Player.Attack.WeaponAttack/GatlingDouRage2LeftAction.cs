using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GatlingDouRage2LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	private const int addAttackSpeed = 100;

	public GatlingDouRage2LeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(DoubleLeftFireSetAnim);
		AddFire(DoubleLeftBeforeFireAttackInterval);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.LeftFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private int DoubleLeftBeforeFireAttackInterval(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.Kill == 3)
		{
			if (arg.CurrentWeapon.basicInfo.Info.AttackInterval == 75)
			{
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = (int)((double)arg.CurrentWeapon.basicInfo.Info.AttackInterval / 2.0);
			}
		}
		else if (arg.CurrentWeapon.basicInfo.Info.AttackInterval != 75)
		{
			arg.CurrentWeapon.basicInfo.Info.AttackInterval = 75;
		}
		return 0;
	}

	private int DoubleLeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.ShotsFired > 3 && arg.CurrentWeapon.basicInfo.Info.HasDoubleAttack)
		{
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 32);
		}
		else
		{
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 15);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}
}
