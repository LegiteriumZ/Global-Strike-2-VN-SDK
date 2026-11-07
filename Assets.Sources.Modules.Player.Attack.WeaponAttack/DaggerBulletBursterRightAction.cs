using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DaggerBulletBursterRightAction : KnifeRightAction
{
	public DaggerBulletBursterRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
		float speed = GetSpeed(ref arg);
		arg.Player.viewAnim.RightSpeed = speed;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)((float)arg.ClientTime + (float)knifeWeaponInfo.StabStabTime / speed);
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)((float)arg.ClientTime + (float)knifeWeaponInfo.StabSlashTime / speed);
		return 0;
	}

	private float GetSpeed(ref CommonWeaponArg arg)
	{
		float result = 1f;
		if (arg.CurrentWeapon.basicInfo.Data.Level >= 35)
		{
			result = 1.2f;
		}
		else if (arg.CurrentWeapon.basicInfo.Data.Level >= 15)
		{
			result = 1.1f;
		}
		return result;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		if (!arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 28);
			arg.CurrentWeapon.basicInfo.Data.Clip2 = 2;
		}
		return 0;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.Clip2 == 0)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			_ = arg.CurrentWeapon.basicInfo.Info;
			KnifeFire(ref arg, arg.Cmd.Seq, 145f, FireUtility.PlaySecFireSound);
		}
		return 0;
	}
}
