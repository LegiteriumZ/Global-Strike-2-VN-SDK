using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HonorShielKnifeFrameAction : AbstractKnifeFireAction, IFrameCmdAction, ICmdAction
{
	public HonorShielKnifeFrameAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitUtility.KnifeHitWorldAction);
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.hasDelayAttack && !CheckDelayAttack(ref arg))
		{
			arg.CurrentWeapon.RemoveDelayAttack();
		}
		if (arg.Cmd.IsSecondaryAttackOn)
		{
			arg.CurrentWeapon.power.Power += arg.Cmd.FrameInterval;
		}
		else
		{
			CheckSecondaryAttack(ref arg);
			arg.CurrentWeapon.power.Power = 0;
			if (arg.Player.viewAnim.Equals(63) || arg.Player.viewAnim.Equals(39))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 65);
				if (arg.Player.GetVelocity() > 0f)
				{
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 14);
				}
				else
				{
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 13);
				}
			}
		}
		if (arg.CurrentWeapon.power.Power > 200 && !arg.Player.viewAnim.Equals(64) && !arg.Player.viewAnim.Equals(63) && !arg.Player.viewAnim.Equals(39))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 64);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 63);
		}
		if (arg.CurrentWeapon.power.Power > 200)
		{
			if (arg.Player.viewAnim.Equals(63) && arg.Player.GetVelocity() <= 1f)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 39);
			}
			if (arg.Player.viewAnim.Equals(39) && arg.Player.GetVelocity() > 1f)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 63);
			}
		}
		return true;
	}

	protected override int GetDelayTime(ref CommonWeaponArg arg)
	{
		if (arg.Player.viewAnim.Equals(31))
		{
			return GetDelayAttackSlashTime(ref arg);
		}
		if (arg.Player.viewAnim.Equals(20))
		{
			return GetDelayAttackStabTime(ref arg);
		}
		if (arg.Player.viewAnim.Equals(29))
		{
			int delayAttackSlashTime = GetDelayAttackSlashTime2(ref arg);
			if (delayAttackSlashTime > 0)
			{
				return delayAttackSlashTime;
			}
			return GetDelayAttackSlashTime(ref arg);
		}
		return 0;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		return false;
	}

	protected bool CheckDelayAttack(ref CommonWeaponArg arg)
	{
		if (!arg.Player.viewAnim.Equals(31) && !arg.Player.viewAnim.Equals(29) && !arg.Player.viewAnim.Equals(20))
		{
			return false;
		}
		return true;
	}

	private void CheckSecondaryAttack(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.power.Power != 0 && arg.CurrentWeapon.power.Power <= 200 && !arg.Player.viewAnim.Equals(20))
		{
			KnifeWeaponInfo obj = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
			int stabSlashTime = obj.StabSlashTime;
			arg.CurrentWeapon.attack.NextAttackTimer = arg.Player.clientTime.ClientTime + stabSlashTime;
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			float shotDistance = obj.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			if (!arg.Cmd.PredicatedOnce)
			{
				KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlaySecFireSound);
			}
		}
	}
}
