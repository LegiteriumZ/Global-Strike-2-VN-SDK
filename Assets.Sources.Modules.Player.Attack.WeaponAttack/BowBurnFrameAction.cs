using Assets.Sources.Constant;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJBase.Logger;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BowBurnFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public BowBurnFrameAction(Contexts contexts)
		: base(contexts)
	{
		_contexts = contexts;
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		Fire(ref arg);
		DelayFrame(ref arg);
		OnAttack(ref arg);
		return true;
	}

	private void OnAttack(ref CommonWeaponArg arg)
	{
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 25) || arg.CurrentWeapon.attack.ShotsFired < 1)
		{
			return;
		}
		if (!arg.Cmd.IsAttackOn)
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 25) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 24) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36))
			{
				StrongHit(ref arg);
				this.DebugFormat("strongHit:{0}", arg.Player.viewAnim);
			}
			else if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 104) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37))
			{
				StrongSpecialHit(ref arg);
				this.DebugFormat("strongSpecialHit:{0}", arg.Player.viewAnim);
			}
			else
			{
				WeakHit(ref arg);
				this.DebugFormat("weakHit:{0}", arg.Player.viewAnim);
			}
			WeaponUtility.DescClip(arg.CurrentWeapon);
			FireUtility.PlayFireSound(ref arg);
			arg.CurrentWeapon.attack.ShotsFired = 0;
			arg.CurrentWeapon.special.SpecialMode = false;
			arg.CurrentWeapon.special.EffectLevel = 0;
			(arg.CurrentWeapon.attach.Data as BowBurnAttach).arrowType = 0;
		}
		else if (arg.ClientTime > arg.CurrentWeapon.basicInfo.Data.NextSkillTimer && arg.CurrentWeapon.power.Power == 0)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 25);
			arg.CurrentWeapon.power.Power = arg.ClientTime;
			BowBurnAttach bowBurnAttach = arg.CurrentWeapon.attach.Data as BowBurnAttach;
			arg.CurrentWeapon.power.MaxPower = arg.CurrentWeapon.power.Power + bowBurnAttach.focusEndIntvalTime;
			this.DebugFormat("TORSO_START_READY:{0}, {1}", arg.Player.clientTime, arg.CurrentWeapon.power.MaxPower);
		}
		else if (arg.CurrentWeapon.power.Power != 0 && arg.CurrentWeapon.power.Power < arg.ClientTime && (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 13) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 14) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 48) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 39)))
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 104);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 24);
			}
		}
		else if (arg.CurrentWeapon.power.MaxPower < arg.ClientTime && arg.CurrentWeapon.power.Power > 0)
		{
			arg.CurrentWeapon.special.EffectLevel = 1;
			if (arg.Cmd.IsSecondaryAttackOn && PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 24))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
				arg.CurrentWeapon.special.SpecialMode = true;
			}
			if (!arg.Cmd.IsSecondaryAttackOn && PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 104))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
				arg.CurrentWeapon.special.SpecialMode = false;
			}
		}
	}

	private void WeakHit(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval;
		OnFire(ref arg);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
	}

	private void StrongSpecialHit(ref CommonWeaponArg arg)
	{
		string freeType = _contexts.battleRoom.roomData.Data.FreeType;
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval;
		if (arg.CurrentWeapon.power.MaxPower < arg.ClientTime && arg.CurrentWeapon.power.Power > 0 && freeType != "BulletStorm")
		{
			SplitSpecialFireBullets(ref arg);
		}
		else
		{
			OnFire(ref arg);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 72);
	}

	private void StrongHit(ref CommonWeaponArg arg)
	{
		string freeType = _contexts.battleRoom.roomData.Data.FreeType;
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval;
		if (arg.CurrentWeapon.power.MaxPower < arg.ClientTime && arg.CurrentWeapon.power.Power > 0 && freeType != "BulletStorm")
		{
			SplitFireBullets(ref arg);
		}
		else
		{
			OnFire(ref arg);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
	}

	private void SplitSpecialFireBullets(ref CommonWeaponArg arg)
	{
		if (!arg.Cmd.PredicatedOnce)
		{
			BowBurnAttach obj = arg.CurrentWeapon.attach.Data as BowBurnAttach;
			obj.arrowType = 0;
			float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
			GunFire(ref arg, arg.Cmd.Seq, shotDistance);
			obj.arrowType = 1;
			float viewPitch = arg.Player.GetViewPitch();
			arg.Player.orientation.Pitch -= 6f;
			GunFire(ref arg, arg.Cmd.Seq, shotDistance);
			arg.Player.orientation.Pitch = viewPitch;
			obj.arrowType = 1;
			viewPitch = arg.Player.GetViewPitch();
			arg.Player.orientation.Pitch += 6f;
			GunFire(ref arg, arg.Cmd.Seq, shotDistance);
			arg.Player.orientation.Pitch = viewPitch;
			obj.arrowType = 0;
		}
	}

	private void SplitFireBullets(ref CommonWeaponArg arg)
	{
		if (!arg.Cmd.PredicatedOnce)
		{
			BowBurnAttach obj = arg.CurrentWeapon.attach.Data as BowBurnAttach;
			obj.arrowType = 0;
			float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
			GunFire(ref arg, arg.Cmd.Seq, shotDistance);
			obj.arrowType = 1;
			float viewYaw = arg.Player.GetViewYaw();
			arg.Player.orientation.Yaw -= 6f;
			GunFire(ref arg, arg.Cmd.Seq, shotDistance);
			arg.Player.orientation.Yaw = viewYaw;
			obj.arrowType = 1;
			viewYaw = arg.Player.GetViewYaw();
			arg.Player.orientation.Yaw += 6f;
			GunFire(ref arg, arg.Cmd.Seq, shotDistance);
			arg.Player.orientation.Yaw = viewYaw;
			obj.arrowType = 0;
		}
	}

	private static void Fire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsAttackOn && WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime) && arg.CurrentWeapon.attack.ShotsFired < 1)
		{
			arg.CurrentWeapon.attack.ShotsFired++;
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval;
			arg.CurrentWeapon.basicInfo.Data.NextSkillTimer = (uint)(arg.ClientTime + 200);
			arg.CurrentWeapon.power.Power = 0;
			arg.CurrentWeapon.power.MaxPower = 0;
			arg.CurrentWeapon.special.EffectLevel = 0;
			FireUtility.PlaySecFireSound(ref arg);
		}
	}

	private void DelayFrame(ref CommonWeaponArg arg)
	{
		InitConfig(ref arg);
	}

	private void InitConfig(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon != null && arg.CurrentWeapon.hasAttach && arg.CurrentWeapon.attach.Data != null && arg.CurrentWeapon.attach.Data is BowBurnAttach { isInit: false } bowBurnAttach)
		{
			bowBurnAttach.isInit = true;
			if (RuleUtilty.IsPve(_contexts.battleRoom.roomData.Data.RaceType))
			{
				bowBurnAttach.focusDamageMin = 100;
				bowBurnAttach.focusDamageMax = 300;
				bowBurnAttach.focusEndIntvalTime = 2000;
			}
			else
			{
				bowBurnAttach.focusDamageMin = 85;
				bowBurnAttach.focusDamageMax = 125;
				bowBurnAttach.focusEndIntvalTime = 1000;
			}
		}
	}
}
