using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class InfiniteHand1Change2LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public InfiniteHand1Change2LeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireDescClip);
		AddFire(DoubleLeftFireSetAnim);
		AddFire(FireNextAttack);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.LeftFireQkhhAfterFire);
	}

	private int DoubleLeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 40);
			if (arg.CurrentWeapon.special.Kil == 0)
			{
				FireUtility.PlayFire3Sound(ref arg);
			}
			else
			{
				FireUtility.PlayFireSound(ref arg);
			}
		}
		else
		{
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 15);
			FireUtility.PlayFireSound(ref arg);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	public static int FireNextAttack(ref CommonWeaponArg arg)
	{
		int num = arg.CurrentWeapon.basicInfo.Info.AttackInterval;
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			num = 700;
		}
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + num);
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			if (arg.CurrentWeapon.special.Kil == 0)
			{
				return (float)arg.Player.clientTime.ClientTime >= arg.CurrentWeapon.attack.NextAttackTimer;
			}
			return false;
		}
		return base.CanFire(ref arg);
	}
}
