using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ShotGunWalker1RightAction : AbstractKnifeFireAction, IRightCmdAction, ICmdAction
{
	public ShotGunWalker1RightAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(SetNextAttack);
		AddFire(SetAttackAnim);
		AddFire(OnFire);
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + 1166);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
		if (base.DelayAttackStabTimeSet > 0)
		{
			WeaponUtility.SetDelayAttackStabTime(ref arg, base.DelayAttackStabTimeSet);
		}
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, base.ViewAnimId);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
		return 0;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo rifleMeleeWeaponInfo)
		{
			float shotDistance = rifleMeleeWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, null);
			FireUtility.PlaySecFireSound(ref arg);
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.clip.CarryClip2 != 2)
		{
			return false;
		}
		if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo)
		{
			return WeaponUtility.CanSecondaryAttack(ref arg);
		}
		return false;
	}

	protected override int GetDelayTime(ref CommonWeaponArg arg)
	{
		return base.GetDelayTime(ref arg);
	}
}
