using System;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HeroWeaponBaseRightAction : KnifeRightAction, IRightCmdAction, ICmdAction
{
	private readonly int[] RIGHT_ATTACK_INTERVAL;

	public HeroWeaponBaseRightAction(Contexts contexts, int[] rightAttackInterval)
		: base(contexts)
	{
		RIGHT_ATTACK_INTERVAL = rightAttackInterval;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (base.CanFire(ref arg))
		{
			return arg.CurrentWeapon.power.Power > 15;
		}
		return false;
	}

	protected override int SetOtherFireAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info.HasOtherFire && !arg.CurrentWeapon.hasDelayAttack)
		{
			if (arg.CurrentWeapon.power.Power < 15)
			{
				return -1;
			}
			if ((123 == arg.Player.viewAnim.ViewAnimInfo.StateId || 125 == arg.Player.viewAnim.ViewAnimInfo.StateId) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId) - arg.Player.viewAnim.RemainTime < 50)
			{
				return 0;
			}
		}
		return -1;
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		setAttackIndex(arg, getNextAttackIndexByRaiseAnim(arg));
		int num = RIGHT_ATTACK_INTERVAL[getAttackIndex(arg)];
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + num);
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.CurrentWeapon.attack.NextAttackTimer;
		arg.CurrentWeapon.power.Power -= 15;
		arg.CurrentWeapon.power.Power = Math.Max(0, arg.CurrentWeapon.power.Power);
		FireUtility.PlayFireSound(ref arg);
		return 0;
	}

	protected override int GetDelayTime(ref CommonWeaponArg arg)
	{
		return HeroWeaponBasePredicationSystem.getDelayAttackTime(arg.Player.viewAnim.ViewAnimInfo.StateId);
	}

	public void setAttackIndex(CommonWeaponArg commonWeaponArg, int v)
	{
		commonWeaponArg.CurrentWeapon.basicInfo.Data.NextSkillTimer = (uint)v;
	}

	private int getNextAttackIndexByRaiseAnim(CommonWeaponArg commonWeaponArg)
	{
		return commonWeaponArg.Player.viewAnim.ViewAnimInfo.StateId switch
		{
			123 => 1, 
			125 => 2, 
			_ => 0, 
		};
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		int attackAnim = getAttackAnim(getAttackIndex(arg));
		PlayerAnimationUtility.SetViewAnimation(arg.Player, attackAnim);
		PlayerAnimationUtility.SetLegsAnimation(arg.Player, getLegAttackAnim(getAttackIndex(arg)));
		return 0;
	}

	private int getLegAttackAnim(uint attackIndex)
	{
		return attackIndex switch
		{
			0u => 318, 
			1u => 320, 
			2u => 322, 
			_ => 318, 
		};
	}

	private int getAttackAnim(uint index)
	{
		return index switch
		{
			0u => 122, 
			1u => 124, 
			2u => 126, 
			_ => 122, 
		};
	}

	private uint getAttackIndex(CommonWeaponArg arg)
	{
		return (uint)arg.CurrentWeapon.basicInfo.Data.NextSkillTimer;
	}
}
