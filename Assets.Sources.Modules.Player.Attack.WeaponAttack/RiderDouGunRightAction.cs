using Assets.Sources.Info.Weapon;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RiderDouGunRightAction : AbstractKnifeFireAction, IRightCmdAction, ICmdAction
{
	public RiderDouGunRightAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(SetAttackAnim);
		AddFire(OnFire);
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + base.AttackInterval);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
		int num = ((arg.CurrentWeapon.basicInfo.Data.EffectLevel == 1) ? 72 : 20);
		PlayerAnimationUtility.SetViewAnimation(arg.Player, num);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
		if (arg.CurrentWeapon.attach.Data is RiderSwordAttach riderSwordAttach)
		{
			riderSwordAttach.AddKnifeSpeed(arg.Player, arg.CurrentWeapon, num);
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo)
		{
			return WeaponUtility.CanSecondaryAttack(ref arg);
		}
		return false;
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
			int delayAttackStabTime = rifleMeleeWeaponInfo.DelayAttackStabTime;
			if (arg.CurrentWeapon.attach.Data is RiderSwordAttach riderSwordAttach)
			{
				KnifeFireWithSureDelayTime(ref arg, arg.Cmd.Seq, shotDistance, (int)((float)delayAttackStabTime / riderSwordAttach.KnifeSpeed), null);
			}
			FireUtility.PlaySecFireSound(ref arg);
		}
		return 0;
	}
}
