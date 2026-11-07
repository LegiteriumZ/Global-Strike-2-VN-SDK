using System.Collections.Generic;
using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;
using Sources.Modules.Player.Chain;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DoubleBlade1LeftAction : AbstractKnifeFireAction, ILeftCmdAction, ICmdAction
{
	public static float ANIMATION_SPEED_RATE = 0.2f;

	public static int DELAY_ATTACK_SLASH_TIME = 300;

	public DoubleBlade1LeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.KnifeHitWorldAction);
		AddAction(HitUtility.KnifeHitPlayerAction);
		AddAction(HitPlayer);
		AddCondition();
	}

	private void AddCondition()
	{
		WeaponChain<CommonWeaponArg> weaponChain = base.OnFireFunc.AddChain(0, (WeaponFireChain)SetNextAttack);
		weaponChain.AddChain((WeaponFireChain)SetAttackAnim);
		weaponChain.AddChain((WeaponFireChain)OnFire);
		WeaponChain<CommonWeaponArg> weaponChain2 = base.OnFireFunc.AddChain(1, (WeaponFireChain)SetOtherFireAnim);
		weaponChain2.AddChain((WeaponFireChain)SetNextAttack);
		weaponChain2.AddChain((WeaponFireChain)SetAttackAnim);
		weaponChain2.AddChain((WeaponFireChain)OnFire);
		weaponChain2.AddChain((WeaponFireChain)ResetMode);
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

	protected virtual int ResetMode(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.special.SpecialMode = false;
		return 0;
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)((float)arg.ClientTime + (float)knifeWeaponInfo.SlashSlashTime * (1f - (float)arg.CurrentWeapon.clip.Clip2 * ANIMATION_SPEED_RATE));
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)((float)arg.ClientTime + (float)knifeWeaponInfo.SlashStabTime * (1f - (float)arg.CurrentWeapon.clip.Clip2 * ANIMATION_SPEED_RATE));
		return 0;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		arg.Player.viewAnim.RightSpeed = 1f + (float)arg.CurrentWeapon.clip.Clip2 * ANIMATION_SPEED_RATE;
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 31);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		}
		WeaponUtility.SetDelayAttackSlashTime(ref arg, (int)((float)DELAY_ATTACK_SLASH_TIME * (1f - (float)arg.CurrentWeapon.clip.Clip2 * ANIMATION_SPEED_RATE)));
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

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
		{
			return false;
		}
		return WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime);
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		base.OnFireFunc.Step(ref arg);
		return true;
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

	protected int OnFireInDelayTime(ref CommonWeaponArg arg, int delayTime)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		_ = arg.CurrentWeapon.basicInfo.Info;
		float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
		if (delayTime > 0)
		{
			if (arg.CurrentWeapon.hasDelayAttack)
			{
				arg.CurrentWeapon.delayAttack.DelayFireRemain = delayTime;
				arg.CurrentWeapon.delayAttack.IsLeftAttack = arg.Cmd.IsAttackOn;
				arg.CurrentWeapon.delayAttack.Player = arg.Player;
				arg.CurrentWeapon.delayAttack.CurrentWeapon = arg.CurrentWeapon;
				arg.CurrentWeapon.delayAttack.Seq = arg.Cmd.Seq;
				arg.CurrentWeapon.delayAttack.Distance = shotDistance;
				arg.CurrentWeapon.delayAttack.SoundFunc = new FireUtility.FireFunc(FireUtility.PlayFireSound);
				arg.CurrentWeapon.delayAttack.CallBack = base.DelayAttackDone;
				arg.CurrentWeapon.delayAttack.CurrentFrameInterval = arg.Cmd.FrameInterval;
				arg.CurrentWeapon.delayAttack.Cmds.Clear();
			}
			else
			{
				arg.CurrentWeapon.AddDelayAttack(delayTime, arg.Cmd.IsAttackOn, arg.Player, arg.CurrentWeapon, arg.Cmd.Seq, shotDistance, new FireUtility.FireFunc(FireUtility.PlayFireSound), newIsDelayAttackImmdiately: false, arg.Cmd.FrameInterval, new Dictionary<int, IUserCmd>(), base.DelayAttackDone);
			}
		}
		return 0;
	}
}
