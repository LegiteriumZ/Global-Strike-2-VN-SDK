using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using Sources.Modules.Player.Chain;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class KnifeRightAction : AbstractKnifeFireAction, IRightCmdAction, ICmdAction
{
	public KnifeRightAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
		AddAction(HitPlayer);
		AddCondition();
	}

	private void AddCondition()
	{
		WeaponChain<CommonWeaponArg> weaponChain = base.OnFireFunc.AddChain(0, (WeaponFireChain)SetNextAttack);
		weaponChain.AddChain((WeaponFireChain)SetAttackAnim);
		weaponChain.AddChain((WeaponFireChain)OnFire);
	}

	protected virtual int SetOtherFireAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info.HasOtherFire && !arg.CurrentWeapon.hasDelayAttack && (70 == arg.Player.viewAnim.ViewAnimInfo.StateId || 30 == arg.Player.viewAnim.ViewAnimInfo.StateId) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId) - arg.Player.viewAnim.RemainTime < 50)
		{
			arg.CurrentWeapon.special.SpecialMode = true;
			return 0;
		}
		return -1;
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo knifeWeaponInfo)
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + knifeWeaponInfo.StabStabTime);
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + knifeWeaponInfo.StabSlashTime);
		}
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
		{
			return false;
		}
		if (arg.Cmd.IsAttackOn)
		{
			return false;
		}
		if (!WeaponUtility.CanSecondaryAttack(ref arg))
		{
			return false;
		}
		return true;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		if (!arg.CurrentWeapon.hasBasicInfo)
		{
			return 0;
		}
		_ = arg.CurrentWeapon.basicInfo.Info;
		if (arg.CurrentWeapon.basicInfo.Info is DefaultWeaponInfo defaultWeaponInfo)
		{
			float shotDistance = defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlaySecFireSound);
		}
		return 0;
	}

	protected int OnFireInDelayTime(ref CommonWeaponArg arg, int delayTime)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		_ = arg.CurrentWeapon.basicInfo.Info;
		if (arg.CurrentWeapon.basicInfo.Info is DefaultWeaponInfo defaultWeaponInfo)
		{
			float shotDistance = defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFireSound);
		}
		return 0;
	}

	protected virtual int HitPlayer(ref HitPlayerArgs arg)
	{
		if (arg.cmd != null)
		{
			if (arg.cmd.IsAttackOn)
			{
				arg.currentWeapon.attack.NextAttackTimer += 50f;
			}
			else
			{
				arg.currentWeapon.attack.NextAttackTimer += 100f;
				arg.currentWeapon.attack.NextSecondaryAttackTimer += 100f;
			}
		}
		return 0;
	}
}
