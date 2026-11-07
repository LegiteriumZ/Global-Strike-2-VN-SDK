using System;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Constant;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;
using SSJJMath;
using SSJJPhysics;
using math;
using share;
using weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ShotGunWalker1LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	private static readonly float[] Mins = new float[3];

	private static readonly float[] Maxs = new float[3];

	private static readonly Vector3D _endPos = new Vector3D();

	private static readonly Vector3D _normal = new Vector3D();

	private static readonly Vector3D _start = new Vector3D();

	public ShotGunWalker1LeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(ResetReload);
		AddFire(ShotGunFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private int ShotGunFire(ref CommonWeaponArg arg)
	{
		if (!arg.Cmd.PredicatedOnce)
		{
			float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
			int seq = arg.Cmd.Seq;
			if (arg.CurrentWeapon.basicInfo.Info is IMutilFireBullets)
			{
				int fireBullets = (arg.CurrentWeapon.basicInfo.Info as IMutilFireBullets).FireBullets;
				for (int i = 0; i < fireBullets; i++)
				{
					ShotGunWalkerGunFire(ref arg, seq, i, shotDistance);
				}
			}
		}
		return 0;
	}

	private void ShotGunWalkerGunFire(ref CommonWeaponArg arg, int seq, int i, float distance)
	{
		TraceResult results = Fire(i, arg.Player, arg.CurrentWeapon, seq, distance, Mins, Maxs);
		if (results.EntityId == -1)
		{
			return;
		}
		if (Contexts.battleRoom.roomData.Data.RaceType == 100 && Contexts.battleRoom.roomData.Data.FreeType == "BulletStorm")
		{
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval * 2;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval * 2;
			return;
		}
		FireUtility.GetInfoFromTrace(_start, _endPos, _normal, results, arg.Player, isKnife: false);
		PlayerEntity entityWithEntityId = Contexts.player.GetEntityWithEntityId(results.EntityId);
		if (entityWithEntityId != null)
		{
			int hitGroup = HitBoxGroupUtilty.GetHitGroup(results.BoneName);
			GunFireCell.DoHitPlayerActions(arg.Player, arg.CurrentWeapon, Contexts, arg.Cmd, _start, _endPos, _normal, entityWithEntityId, hitGroup);
		}
		else
		{
			GunFireCell.DoHitWorldActions(arg.Player, arg.CurrentWeapon, Contexts, _start, _endPos, _normal, results.SurfaceFlags, results.EntityId);
		}
	}

	private TraceResult Fire(int i, PlayerEntity player, WeaponEntity currentWeapon, int seq, float attackDistance, float[] mins, float[] maxs, bool knife = false)
	{
		Vector3D vector3D = new Vector3D();
		IEntitsWeaponInfo info = currentWeapon.basicInfo.Info;
		float num = player.orientation.Yaw + player.GetPunchYaw() * 2f;
		float num2 = player.orientation.Pitch + player.GetPunchPitch() * 2f;
		if (player.move.ActThirdMove)
		{
			num = (float)player.basicInfo.MoveYaw;
		}
		double shotsFiredSpread = FireUtility.CalShotsFiredSpread(info.ShotsFiredSpreadMin, info.ShotsFiredSpreadMax, info.ShotsFiredSpreadTime, currentWeapon.attack.ShotsFired, info.AttackInterval);
		return FireUtility.BulletTrace(forward: (currentWeapon.power.RpgMaxPower != 1) ? ShootingDirUtils.CalculateShotingDir(seq + i, num, num2, currentWeapon.spread.Spread, currentWeapon.spread.SpreadScaleY, shotsFiredSpread) : calculateHexGunFire(i, num, num2), pyEngine: Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, player: player, otherPlayers: Contexts.sharedInstance.player, attackDistance: attackDistance, mins: mins, maxs: maxs, knife: knife);
	}

	private Vector3D calculateHexGunFire(int num, double yaw, double pitch)
	{
		int num2 = 2;
		Vector3D vector3D = new Vector3D();
		if (num == 0)
		{
			AngleUtility.AnglesToVector(yaw, pitch, vector3D);
			vector3D.Normalize();
		}
		else if (num >= 1)
		{
			double yaw2 = AngleUtils.MakeAngleInRange(yaw + (double)num2 * Math.Sin((double)((num - 1) * 60) * AngleUtility.RAD));
			double angle = pitch + (double)num2 * Math.Cos((double)((num - 1) * 60) * AngleUtility.RAD);
			angle = AngleUtils.MakeAngleInRange(angle);
			AngleUtility.AnglesToVector(yaw2, angle, vector3D);
			vector3D.Normalize();
		}
		return vector3D;
	}

	private int ResetReload(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.reload.ReloadEndTime = 0f;
		arg.CurrentWeapon.reload.IsStartReload = false;
		return 0;
	}
}
