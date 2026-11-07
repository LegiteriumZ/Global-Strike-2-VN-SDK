using Assets.Sources.Constant;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJPhysics;
using share;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BowGodFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	private bool _isChargingAttack;

	public BowGodFrameAction(Contexts contexts)
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

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		int raceType = _contexts.battleRoom.roomData.Data.RaceType;
		float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
		if (RuleUtilty.IsRpg(raceType) && _isChargingAttack)
		{
			SplitShot(ref arg, shotDistance);
		}
		else
		{
			GunFire(ref arg, arg.Cmd.Seq, shotDistance);
		}
		return 0;
	}

	private void SplitShot(ref CommonWeaponArg arg, float distance)
	{
		int num = ((!arg.CurrentWeapon.basicInfo.Info.Name.Equals("bow_god")) ? 1 : 0) * 2 + 1;
		float splitAngle = 7.5f;
		TraceResult[] array = FireUtility.SplitShot(arg.Player, arg.CurrentWeapon, arg.Cmd.Seq, distance, new float[3], new float[3], num, splitAngle);
		for (int i = 0; i < num; i++)
		{
			if (array[i].EntityId != -1)
			{
				Vector3D normal = new Vector3D();
				Vector3D vector3D = new Vector3D();
				Vector3D endPos = new Vector3D();
				FireUtility.GetInfoFromTrace(vector3D, endPos, normal, array[i], arg.Player);
				PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(array[i].EntityId);
				if (entityWithEntityId != null)
				{
					int hitGroup = HitBoxGroupUtilty.GetHitGroup(array[i].BoneName);
					GunFireCell.DoHitPlayerActions(arg.Player, arg.CurrentWeapon, Contexts, arg.Cmd, vector3D, endPos, normal, entityWithEntityId, hitGroup);
				}
				else
				{
					GunFireCell.DoHitWorldActions(arg.Player, arg.CurrentWeapon, Contexts, vector3D, endPos, normal, array[i].SurfaceFlags, array[i].EntityId);
				}
			}
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
		else if (!RuleUtilty.IsRpg(_contexts.battleRoom.roomData.Data.RaceType) && bowAttach != null && bowAttach.isFovDown)
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
