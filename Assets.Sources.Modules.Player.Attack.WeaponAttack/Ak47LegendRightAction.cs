using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Ak47LegendRightAction : AbstractKnifeFireAction, IRightCmdAction, ICmdAction
{
	public Ak47LegendRightAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(SetAttackAnim);
		AddFire(OnFire);
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + 866);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
		WeaponUtility.SetDelayAttackStabTime(ref arg, 400);
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

	public int Fire(ref CommonWeaponArg arg)
	{
		return OnFire(ref arg);
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
}
