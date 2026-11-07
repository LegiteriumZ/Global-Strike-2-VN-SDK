using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BowFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public BowFrameAction(Contexts contexts)
		: base(contexts)
	{
		_contexts = contexts;
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		fire(ref arg);
		fovControll(ref arg);
		delayFrame(arg.Player, arg.CurrentWeapon);
		onAttack(ref arg);
		return true;
	}

	private void onAttack(ref CommonWeaponArg arg)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 25) && !arg.Cmd.IsAttackOn && arg.CurrentWeapon.attack.ShotsFired >= 1)
		{
			arg.CurrentWeapon.attack.ShotsFired = 0;
			BowAttach bowAttach = arg.CurrentWeapon.attach.Data as BowAttach;
			if (arg.ClientTime >= bowAttach.startAttackTime)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + 600;
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
			}
			bowAttach.startAttackTime = arg.ClientTime;
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

	private void delayFrame(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (currentWeapon.attach.Data is BowAttach bowAttach && bowAttach.changeDelay > 0 && player.clientTime.ClientTime >= bowAttach.changeDelay)
		{
			bowAttach.changeDelay = 0L;
		}
	}

	private void fovControll(ref CommonWeaponArg arg)
	{
		BowAttach bowAttach = ((arg.CurrentWeapon != null && arg.CurrentWeapon.hasAttach) ? (arg.CurrentWeapon.attach.Data as BowAttach) : null);
		if (bowAttach == null || arg.Player == null || !arg.Player.hasFov)
		{
			return;
		}
		if (arg.CurrentWeapon.hasAttack && arg.CurrentWeapon.attack.ShotsFired < 1)
		{
			bowAttach.isFovDown = false;
			arg.Player.fov.Fov = 90;
			return;
		}
		if (!bowAttach.isFovDown && arg.Cmd.IsAttackOn)
		{
			bowAttach.isFovDown = true;
			bowAttach.startAttackTime = arg.ClientTime + bowAttach.focusDelayTime;
		}
		if (bowAttach.isFovDown && !arg.Cmd.IsAttackOn)
		{
			bowAttach.isFovDown = false;
			arg.Player.fov.Fov = 90;
		}
		else if (bowAttach.isFovDown)
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
