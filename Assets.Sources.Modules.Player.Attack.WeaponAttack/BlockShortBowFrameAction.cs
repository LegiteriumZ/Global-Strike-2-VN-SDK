using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BlockShortBowFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	private bool _isChargingAttack;

	public BlockShortBowFrameAction(Contexts contexts)
		: base(contexts)
	{
		_contexts = contexts;
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		fire(ref arg);
		FovControll(ref arg);
		DelayFrame(arg.Player, arg.CurrentWeapon);
		OnAttack(ref arg);
		return true;
	}

	private void OnAttack(ref CommonWeaponArg arg)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 25) && !arg.Cmd.IsAttackOn && arg.CurrentWeapon.attack.ShotsFired >= 1)
		{
			arg.CurrentWeapon.attack.ShotsFired = 0;
			BowAttach bowAttach = arg.CurrentWeapon.attach.Data as BowAttach;
			if (bowAttach != null && arg.ClientTime >= bowAttach.startAttackTime)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + 600;
				_isChargingAttack = true;
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
				_isChargingAttack = false;
			}
			if (bowAttach != null)
			{
				bowAttach.startAttackTime = arg.ClientTime;
			}
			OnFire(ref arg);
			FireUtility.PlayFireSound(ref arg);
		}
	}

	private void fire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsAttackOn && WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime) && arg.CurrentWeapon.attack.ShotsFired < 1)
		{
			arg.CurrentWeapon.attack.ShotsFired++;
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + 600;
			FireUtility.PlayFire3Sound(ref arg);
		}
	}

	private void DelayFrame(PlayerEntity player, WeaponEntity currentWeapon)
	{
		BowAttach bowAttach = currentWeapon.attach.Data as BowAttach;
		if ((bowAttach == null || bowAttach.changeDelay > 0) && (bowAttach == null || player.clientTime.ClientTime >= bowAttach.changeDelay) && bowAttach != null)
		{
			bowAttach.changeDelay = 0L;
		}
	}

	private void FovControll(ref CommonWeaponArg arg)
	{
		BowAttach bowAttach = arg.CurrentWeapon.attach.Data as BowAttach;
		if (arg.CurrentWeapon.attack.ShotsFired < 1)
		{
			if (bowAttach != null)
			{
				bowAttach.isFovDown = false;
			}
			arg.Player.fov.Fov = 90;
			return;
		}
		if (bowAttach != null && !bowAttach.isFovDown && arg.Cmd.IsAttackOn)
		{
			bowAttach.isFovDown = true;
			bowAttach.startAttackTime = arg.ClientTime + bowAttach.focusDelayTime;
		}
		if (bowAttach != null && bowAttach.isFovDown && !arg.Cmd.IsAttackOn)
		{
			bowAttach.isFovDown = false;
			arg.Player.fov.Fov = 90;
		}
		else if (bowAttach != null && bowAttach.isFovDown)
		{
			if ((PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 13) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 14)) && arg.ClientTime >= bowAttach.startAttackTime)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 25);
			}
			float num = (float)(arg.ClientTime - bowAttach.startAttackTime) / bowAttach.changeFoveTotalTime;
			if (num > 1f)
			{
				num = 1f;
			}
			else if (num < 0f)
			{
				num = 0f;
			}
			arg.Player.fov.Fov = (int)(90f * (1f - num) + num * 55f);
		}
	}
}
