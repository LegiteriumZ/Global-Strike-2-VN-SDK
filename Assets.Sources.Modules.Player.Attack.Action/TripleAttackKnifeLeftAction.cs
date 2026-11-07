using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class TripleAttackKnifeLeftAction : AbstractKnifeFireAction, ILeftCmdAction, ICmdAction
{
	public TripleAttackKnifeLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddFire(SetAttackAnim);
		AddFire(SetNextAttack);
		AddFire(OnFire);
		AddAction(HitPlayer);
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		_ = arg.CurrentWeapon.basicInfo.Info;
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId));
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.CurrentWeapon.attack.NextAttackTimer;
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 31))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
			knifeWeaponInfo.DelayAttackSlashTime = 500;
		}
		else if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 29))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
			knifeWeaponInfo.DelayAttackSlashTime = 400;
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 31);
			knifeWeaponInfo.DelayAttackSlashTime = 500;
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	protected int HitPlayer(ref HitPlayerArgs arg)
	{
		arg.currentWeapon.attack.NextAttackTimer += 50f;
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
		{
			return false;
		}
		bool flag = false;
		if (WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime))
		{
			if (arg.CurrentWeapon.attack.ShotsFired == 0)
			{
				flag = true;
			}
		}
		else if (arg.CurrentWeapon.special.SpecialMode && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 15))
		{
			flag = true;
			arg.CurrentWeapon.special.SpecialMode = false;
		}
		if (flag)
		{
			arg.CurrentWeapon.attack.ShotsFired = 1;
		}
		return flag;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		_ = arg.CurrentWeapon.basicInfo.Info;
		float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
		KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFireSound);
		return 0;
	}
}
