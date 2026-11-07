using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DaggerBulletBursterLeftAction : KnifeLeftAction
{
	public DaggerBulletBursterLeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
		float speed = GetSpeed(ref arg);
		arg.Player.viewAnim.RightSpeed = speed;
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)((float)arg.ClientTime + (float)knifeWeaponInfo.SlashSlashTime / speed);
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)((float)arg.ClientTime + (float)knifeWeaponInfo.SlashStabTime / speed);
		return 0;
	}

	protected override int ResetMode(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.basicInfo.Data.Kill = 0;
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		int num = 0;
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			if (arg.CurrentWeapon.basicInfo.Data.Kill == 3)
			{
				num = 176;
			}
			else if (arg.CurrentWeapon.basicInfo.Data.Kill == 2)
			{
				num = 174;
			}
			else if (arg.CurrentWeapon.basicInfo.Data.Kill == 1)
			{
				num = 172;
				arg.CurrentWeapon.attack.NextAttackTimer += 200f;
			}
			else
			{
				num = 170;
			}
			WeaponUtility.SetDelayAttackSlashTime(ref arg, 200);
		}
		else
		{
			num = ((arg.CurrentWeapon.basicInfo.Data.Kill == 1) ? 29 : 31);
			WeaponUtility.SetDelayAttackSlashTime(ref arg, 400);
		}
		PlayerAnimationUtility.SetViewAnimation(arg.Player, num);
		return 0;
	}

	private float GetSpeed(ref CommonWeaponArg arg)
	{
		float result = 1f;
		if (arg.CurrentWeapon.basicInfo.Data.Level > 35)
		{
			result = 1.2f;
		}
		else if (arg.CurrentWeapon.basicInfo.Data.Level > 15)
		{
			result = 1.1f;
		}
		return result;
	}

	protected override int SetOtherFireAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info.HasOtherFire && !arg.CurrentWeapon.hasDelayAttack)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 173))
				{
					if (PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 173) - arg.Player.viewAnim.RemainTime < 50)
					{
						arg.CurrentWeapon.basicInfo.Data.Kill = 3;
						arg.CurrentWeapon.basicInfo.Data.Clip2 = 1;
						return 0;
					}
				}
				else if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 171))
				{
					if (PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 171) - arg.Player.viewAnim.RemainTime < 50)
					{
						arg.CurrentWeapon.basicInfo.Data.Kill = 2;
						return 0;
					}
				}
				else if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 169) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 169) - arg.Player.viewAnim.RemainTime < 50)
				{
					arg.CurrentWeapon.basicInfo.Data.Kill = 1;
					arg.CurrentWeapon.basicInfo.Data.Clip2 = 1;
					return 0;
				}
			}
			else if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 30) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 30) - arg.Player.viewAnim.RemainTime < 50)
			{
				arg.CurrentWeapon.basicInfo.Data.Kill = 1;
				return 0;
			}
		}
		return -1;
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
			KnifeFire(ref arg, arg.Cmd.Seq, 145f, FireUtility.PlayFireSound);
		}
		return 0;
	}
}
