using System;
using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Components.Player.Anims;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.HitBox;
using Assets.Sources.Particle.Config;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJMath;
using SSJJPhysics;
using UnityEngine;
using config;
using data;
using physics;
using physics.trace;
using share;
using share.constant;
using weapon;

namespace Assets.Sources.Utils.Weapon;

public class FireUtility
{
	public delegate int FireFunc(ref CommonWeaponArg arg);

	private static readonly LoggerAdapter Logger = new LoggerAdapter(typeof(FireUtility));

	private static Vector3 startVector3;

	private static readonly int TraceDistance = 3000;

	private static readonly float[] Zero = new float[3];

	private static Vector3 _tracePos = Vector3.zero;

	public static bool IsFiring(PlayerEntity player, bool isSelf, bool right = true, bool viewCheckLeftAttackFire = false)
	{
		bool result = Contexts.sharedInstance.userCommand.commands.CommandList.Last?.Value.IsAttackOn ?? false;
		if (right)
		{
			if (isSelf)
			{
				ViewAnimComponent viewAnim = player.viewAnim;
				if (viewAnim != null && viewAnim.ViewAnimInfo != null && viewAnim.ViewAnimInfo.StateName.Contains("ATTACK") && viewAnim.RemainTime >= 0)
				{
					if (viewCheckLeftAttackFire)
					{
						return result;
					}
					return true;
				}
			}
			else
			{
				TorseAnimComponent torseAnim = player.torseAnim;
				if (torseAnim != null && torseAnim.TorsoAnimInfo != null && torseAnim.TorsoAnimInfo.StateName.Contains("ATTACK") && torseAnim.RemainTime >= 0)
				{
					return true;
				}
			}
		}
		else if (isSelf)
		{
			ViewAnimComponent viewAnim2 = player.viewAnim;
			if (viewAnim2 != null && viewAnim2.LeftViewAnimInfo != null && viewAnim2.LeftViewAnimInfo.StateName.Contains("ATTACK") && viewAnim2.RemainTime >= 0)
			{
				if (viewCheckLeftAttackFire)
				{
					return result;
				}
				return true;
			}
		}
		else
		{
			TorseAnimComponent torseAnim2 = player.torseAnim;
			if (torseAnim2 != null && torseAnim2.TorsoAnimInfo != null && torseAnim2.TorsoAnimInfo.StateName.Contains("ATTACK") && torseAnim2.RemainTime >= 0)
			{
				return true;
			}
		}
		return false;
	}

	public static double CalShotsFiredSpread(int shotsFiredSpreadMin, int shotsFiredSpreadMax, int shotsFiredSpreadTime, int shotsFired, int attackInterval)
	{
		double num = 0.0;
		if ((shotsFiredSpreadMin != 0 || shotsFiredSpreadMax != 0) && shotsFiredSpreadTime > 0)
		{
			double val = (double)shotsFired * (double)attackInterval / (double)shotsFiredSpreadTime;
			val = Math.Min(1.0, val);
			num = (double)shotsFiredSpreadMin + (double)(shotsFiredSpreadMax - shotsFiredSpreadMin) * val;
		}
		return 1.0 - num / 1000.0;
	}

	public static TraceResult FireNormal(PlayerEntity player, WeaponEntity currentWeapon, int seq, float attackDistance, float[] mins, float[] maxs)
	{
		IEntitsWeaponInfo info = currentWeapon.basicInfo.Info;
		float num = player.orientation.Yaw + player.GetPunchYaw() * 2f;
		float num2 = player.orientation.Pitch + player.GetPunchPitch() * 2f;
		double shotsFiredSpread = CalShotsFiredSpread(info.ShotsFiredSpreadMin, info.ShotsFiredSpreadMax, info.ShotsFiredSpreadTime, currentWeapon.attack.ShotsFired, info.AttackInterval);
		Vector3D data = ShootingDirUtils.CalculateShotingDir(seq, num, num2, currentWeapon.spread.Spread, currentWeapon.spread.SpreadScaleY, shotsFiredSpread);
		return BulletTraceNormal(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, player, attackDistance, VectorTypeConverter.Ssjj2Unity(data), mins, maxs);
	}

	public static void FirePreliminary(PlayerEntity player, WeaponEntity currentWeapon, int seq, float attackDistance, float[] mins, float[] maxs, List<int> results)
	{
		IEntitsWeaponInfo info = currentWeapon.basicInfo.Info;
		float num = player.orientation.Yaw + player.GetPunchYaw() * 2f;
		float num2 = player.orientation.Pitch + player.GetPunchPitch() * 2f;
		double shotsFiredSpread = CalShotsFiredSpread(info.ShotsFiredSpreadMin, info.ShotsFiredSpreadMax, info.ShotsFiredSpreadTime, currentWeapon.attack.ShotsFired, info.AttackInterval);
		Vector3D forward = ShootingDirUtils.CalculateShotingDir(seq, num, num2, currentWeapon.spread.Spread, currentWeapon.spread.SpreadScaleY, shotsFiredSpread);
		BulletTracePreliminary(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, player, Contexts.sharedInstance.player, attackDistance, forward, mins, maxs, results);
	}

	public static TraceResult Fire(PlayerEntity player, WeaponEntity currentWeapon, int seq, float attackDistance, float[] mins, float[] maxs, bool knife = false)
	{
		IEntitsWeaponInfo info = currentWeapon.basicInfo.Info;
		float num = player.orientation.Yaw + player.GetPunchYaw() * 2f;
		float num2 = player.orientation.Pitch + player.GetPunchPitch() * 2f;
		if (player.move.ActThirdMove)
		{
			num = (float)player.basicInfo.MoveYaw;
		}
		double shotsFiredSpread = CalShotsFiredSpread(info.ShotsFiredSpreadMin, info.ShotsFiredSpreadMax, info.ShotsFiredSpreadTime, currentWeapon.attack.ShotsFired, info.AttackInterval);
		Vector3D forward = ShootingDirUtils.CalculateShotingDir(seq, num, num2, currentWeapon.spread.Spread, currentWeapon.spread.SpreadScaleY, shotsFiredSpread);
		return BulletTrace(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, player, Contexts.sharedInstance.player, attackDistance, forward, mins, maxs, knife);
	}

	public static TraceResult[] SplitShot(PlayerEntity player, WeaponEntity currentWeapon, int seq, float attackDistance, float[] mins, float[] maxs, int splitNum, float splitAngle)
	{
		IEntitsWeaponInfo info = currentWeapon.basicInfo.Info;
		float num = player.orientation.Yaw + player.GetPunchYaw() * 2f;
		float num2 = player.orientation.Pitch + player.GetPunchPitch() * 2f;
		double shotsFiredSpread = CalShotsFiredSpread(info.ShotsFiredSpreadMin, info.ShotsFiredSpreadMax, info.ShotsFiredSpreadTime, currentWeapon.attack.ShotsFired, info.AttackInterval);
		TraceResult[] array = new TraceResult[splitNum];
		for (int i = 0; i < splitNum; i++)
		{
			float num3 = num + (float)(i - (splitNum - 1) / 2) * splitAngle;
			Vector3D forward = ShootingDirUtils.CalculateShotingDir(seq, num3, num2, currentWeapon.spread.Spread, currentWeapon.spread.SpreadScaleY, shotsFiredSpread);
			TraceResult traceResult = (array[i] = BulletTrace(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, player, Contexts.sharedInstance.player, attackDistance, forward, mins, maxs, knife: false));
			array[i].EndPos = (float[])traceResult.EndPos.Clone();
			array[i].Plane = traceResult.Plane.Clone();
			array[i].BoneName = (string)traceResult.BoneName.Clone();
			array[i].ResolvedEnd = (float[])traceResult.ResolvedEnd.Clone();
		}
		return array;
	}

	public static TraceResult BulletTrace(IPyEngine pyEngine, PlayerEntity player, PlayerContext otherPlayers, float attackDistance, Vector3D forward, float[] mins, float[] maxs, bool knife)
	{
		Trace trace = TraceObjectPool.AllocateTrace();
		Vector3D vector3D = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D2 = TraceObjectPool.AllocateVector3D();
		float[] array = TraceObjectPool.AllocateFloat3();
		float[] array2 = TraceObjectPool.AllocateFloat3();
		TraceResult result = default(TraceResult);
		try
		{
			vector3D.x = player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).x;
			vector3D.y = player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).y;
			vector3D.z = (double)player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).z + player.move.PyPlayerMove.GetViewHeight();
			if (PlayerCareerUtil.IsTPS(player.GetCareer()))
			{
				Vector3D vector3D3 = new Vector3D();
				AngleUtility.VectorToAngles(forward, vector3D3);
				float cameraYaw = (float)vector3D3.x;
				float cameraPitch = (float)vector3D3.x;
				Vector3D forward2 = new Vector3D();
				Vector3D vector3D4 = new Vector3D();
				Vector3D vector3D5 = new Vector3D();
				AngleUtility.AnglesToVectors2(cameraYaw, cameraPitch, forward2, vector3D4, vector3D5);
				vector3D4.Normalize();
				vector3D5.Normalize();
				vector3D.x += vector3D4.x * 50.0;
				vector3D.y += vector3D4.y * 50.0;
				vector3D.z += vector3D4.z * 50.0;
				vector3D.z += 10.0;
			}
			setMaxAndMinByWeaponName(player.currentWeapon.WeaponInfo.Name, knife, mins, maxs);
			VectorUtils.VectorMA(vector3D, attackDistance, forward, vector3D2);
			VectorUtils.Vector3DToFloat3(vector3D, array);
			VectorUtils.Vector3DToFloat3(vector3D2, array2);
			PyEngineUtility.BulletTraceToWorld(pyEngine, trace, array, array2, mins, maxs);
			PyEngineUtility.BulletTraceToPlayers(pyEngine, trace, array, array2, mins, maxs, otherPlayers, forward);
			result.CopyFrom(trace);
			if (BspConstantUtil.NoImpact(pyEngine.GetWorld().GetDecalsId(), trace.surfaceFlags))
			{
				trace.entityId = -1;
			}
			else if (knife)
			{
				mins[0] = 0f;
				mins[1] = 0f;
				mins[2] = 0f;
				maxs[0] = 0f;
				maxs[1] = 0f;
				maxs[2] = 0f;
				VectorUtils.VectorMA(vector3D, attackDistance, forward, vector3D2);
				pyEngine.GetWorld().WorldTrace(trace, array, array2, mins, maxs, 100663299);
			}
			if (trace.entityId != -1)
			{
				DebugDrawUtility.DrawTrace(trace, vector3D);
			}
		}
		catch (Exception message)
		{
			Logger.Error(message);
		}
		finally
		{
			TraceObjectPool.ReturnVector3D(vector3D);
			TraceObjectPool.ReturnVector3D(vector3D2);
			TraceObjectPool.ReturnFloat3(array);
			TraceObjectPool.ReturnFloat3(array2);
			TraceObjectPool.ReturnTrace(trace);
		}
		return result;
	}

	private static void setMaxAndMinByWeaponName(string weaponName, bool knife, float[] mins, float[] maxs)
	{
		if (knife)
		{
			if (weaponName == "doun_yecha")
			{
				mins[0] = -10f;
				mins[1] = -10f;
				mins[2] = -45f;
				maxs[0] = 10f;
				maxs[1] = 10f;
				maxs[2] = 45f;
			}
			else
			{
				mins[0] = -40f;
				mins[1] = -40f;
				mins[2] = -45f;
				maxs[0] = 40f;
				maxs[1] = 40f;
				maxs[2] = 45f;
			}
		}
		else
		{
			mins[0] = 0f;
			mins[1] = 0f;
			mins[2] = 0f;
			maxs[0] = 0f;
			maxs[1] = 0f;
			maxs[2] = 0f;
		}
	}

	private static void VectorMa(Vector3D v, double s, ref Vector3 b, Vector3D o)
	{
		o.x = v.x + (double)b.x * s;
		o.y = v.y + (double)b.y * s;
		o.z = v.z + (double)b.z * s;
	}

	public static TraceResult BulletTraceNormal(PlayerEntity player, float attackDistance, Vector3 forward)
	{
		float[] array = TraceObjectPool.AllocateFloat3();
		float[] array2 = TraceObjectPool.AllocateFloat3();
		TraceResult result = BulletTraceLinkEntity(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, player, attackDistance, forward, array, array2);
		TraceObjectPool.ReturnFloat3(array);
		TraceObjectPool.ReturnFloat3(array2);
		return result;
	}

	public static TraceResult BulletTraceLinkEntity(IPyEngine pyEngine, PlayerEntity player, float attackDistance, Vector3 forward, float[] mins, float[] maxs)
	{
		Trace trace = TraceObjectPool.AllocateTrace();
		Vector3D vector3D = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D2 = TraceObjectPool.AllocateVector3D();
		float[] array = TraceObjectPool.AllocateFloat3();
		float[] array2 = TraceObjectPool.AllocateFloat3();
		TraceResult result = default(TraceResult);
		try
		{
			startVector3 = VectorCoordConverter.UnityToSsjj(Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.transform.position);
			vector3D.x = startVector3.x;
			vector3D.y = startVector3.y;
			vector3D.z = startVector3.z;
			VectorMa(vector3D, attackDistance, ref forward, vector3D2);
			VectorUtils.Vector3DToFloat3(vector3D, array);
			VectorUtils.Vector3DToFloat3(vector3D2, array2);
			PyEngineUtility.BulletTraceToWorld(pyEngine, trace, array, array2, mins, maxs);
			result.CopyFrom(trace);
			return result;
		}
		finally
		{
			TraceObjectPool.ReturnVector3D(vector3D);
			TraceObjectPool.ReturnVector3D(vector3D2);
			TraceObjectPool.ReturnFloat3(array);
			TraceObjectPool.ReturnFloat3(array2);
			TraceObjectPool.ReturnTrace(trace);
		}
	}

	public static TraceResult BulletTraceNormal(IPyEngine pyEngine, PlayerEntity player, float attackDistance, Vector3 forward, float[] mins, float[] maxs)
	{
		Trace trace = TraceObjectPool.AllocateTrace();
		Vector3D vector3D = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D2 = TraceObjectPool.AllocateVector3D();
		float[] array = TraceObjectPool.AllocateFloat3();
		float[] array2 = TraceObjectPool.AllocateFloat3();
		TraceResult result = default(TraceResult);
		try
		{
			vector3D.x = player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).x;
			vector3D.y = player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).y;
			vector3D.z = (double)player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).z + player.move.PyPlayerMove.GetViewHeight();
			VectorMa(vector3D, attackDistance, ref forward, vector3D2);
			VectorUtils.Vector3DToFloat3(vector3D, array);
			VectorUtils.Vector3DToFloat3(vector3D2, array2);
			PyEngineUtility.BulletTrace(pyEngine, trace, player.move.PyPlayerMove.GetEntity(), array, array2, mins, maxs);
			result.CopyFrom(trace);
			return result;
		}
		finally
		{
			TraceObjectPool.ReturnVector3D(vector3D);
			TraceObjectPool.ReturnVector3D(vector3D2);
			TraceObjectPool.ReturnFloat3(array);
			TraceObjectPool.ReturnFloat3(array2);
			TraceObjectPool.ReturnTrace(trace);
		}
	}

	public static void BulletTracePreliminary(IPyEngine pyEngine, PlayerEntity player, PlayerContext otherPlayers, float attackDistance, Vector3D forward, float[] mins, float[] maxs, List<int> results)
	{
		Trace trace = TraceObjectPool.AllocateTrace();
		Vector3D vector3D = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D2 = TraceObjectPool.AllocateVector3D();
		float[] array = TraceObjectPool.AllocateFloat3();
		float[] array2 = TraceObjectPool.AllocateFloat3();
		float[] array3 = TraceObjectPool.AllocateFloat3();
		try
		{
			vector3D.x = player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).x;
			vector3D.y = player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).y;
			vector3D.z = (double)player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).z + player.move.PyPlayerMove.GetViewHeight();
			VectorUtils.VectorMA(vector3D, attackDistance, forward, vector3D2);
			VectorUtils.Vector3DToFloat3(vector3D, array);
			VectorUtils.Vector3DToFloat3(vector3D2, array2);
			foreach (PlayerEntity otherPlayer in otherPlayers)
			{
				if (otherPlayer.hasBasicInfo && otherPlayer != player)
				{
					VectorTypeConverter.Vector3ToFloat3(otherPlayer.GetCompenstatePos(otherPlayer.fpos.Change.GetPosIndex()), array3);
					if (!otherPlayer.hasHitBox || otherPlayer.hitBox.HitPreliminaryGeo == null || !pyEngine.GetWorld().BulletPreliminaryTrace(array, array2, mins, maxs, array3, otherPlayer.headScale.Scale, otherPlayer.hitBox.HitPreliminaryGeo))
					{
						results.Add(otherPlayer.entityId.Value);
					}
				}
			}
		}
		finally
		{
			TraceObjectPool.ReturnVector3D(vector3D);
			TraceObjectPool.ReturnVector3D(vector3D2);
			TraceObjectPool.ReturnFloat3(array);
			TraceObjectPool.ReturnFloat3(array2);
			TraceObjectPool.ReturnFloat3(array3);
			TraceObjectPool.ReturnTrace(trace);
		}
	}

	public static void GetInfoFromTrace(Vector3D start, Vector3D endPos, Vector3D normal, TraceResult results, PlayerEntity player, bool isKnife = true)
	{
		start.x = player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).x;
		start.y = player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).y;
		if (!isKnife)
		{
			start.z = (double)player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).z + player.move.PyPlayerMove.GetViewHeight();
			VectorUtils.Float3ToVectoe3D(results.EndPos, endPos);
			VectorUtils.Float3ToVectoe3D(results.Plane.normal, normal);
			return;
		}
		start.z = (double)player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).z + player.move.PyPlayerMove.GetViewHeight();
		if (results.Fraction < 1f)
		{
			VectorUtils.Float3ToVectoe3D(results.EndPos, endPos);
			VectorUtils.Float3ToVectoe3D(results.Plane.normal, normal);
		}
	}

	public static int FireSetSpread(ref CommonWeaponArg arg)
	{
		IEntitsWeaponInfo info = arg.CurrentWeapon.basicInfo.Info;
		bool isWeightlessness = Contexts.sharedInstance.battleRoom.pyEngine.PyEngine.GetWorld().GetSceneMoveData() is SceneMoveData sceneMoveData && sceneMoveData.isWeightlessness;
		if (!arg.Cmd.PredicatedOnce && info.SpreadLogic != null)
		{
			info.SpreadLogic.BeforeFire(out arg.CurrentWeapon.spread.Spread, arg.Player, arg.CurrentWeapon, arg.Cmd, isWeightlessness);
		}
		return 0;
	}

	public static int FireSetAccuracy(ref CommonWeaponArg arg)
	{
		IEntitsWeaponInfo info = arg.CurrentWeapon.basicInfo.Info;
		if (!arg.Cmd.PredicatedOnce && info.AccuracyLogic != null)
		{
			info.AccuracyLogic.BeforeFire(arg.Cmd.Seq, arg.Player, arg.CurrentWeapon, arg.ClientTime);
		}
		return 0;
	}

	public static int RifleFireIncShotsFired(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.DelayFire = true;
		arg.CurrentWeapon.attack.ShotsFired++;
		return 0;
	}

	public static int PostolFireIncShotsFired(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.ShotsFired++;
		return 0;
	}

	public static int FireDescClip(ref CommonWeaponArg arg)
	{
		WeaponUtility.DescClip(arg.CurrentWeapon);
		return 0;
	}

	public static int FireNoDescClipWhenUpSpeed(ref CommonWeaponArg arg)
	{
		if (!arg.Player.state.GetPlayerStateType(512))
		{
			WeaponUtility.DescClip(arg.CurrentWeapon);
		}
		return 0;
	}

	public static int LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.ShotsFired > 3 && arg.CurrentWeapon.basicInfo.Info.HasDoubleAttack)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 32);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	public static int DoubleLeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.ShotsFired > 3 && arg.CurrentWeapon.basicInfo.Info.HasDoubleAttack)
		{
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 32);
		}
		else
		{
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 15);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	public static int LeftFireSpecialSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.ShotsFired > 3 && arg.CurrentWeapon.basicInfo.Info.HasDoubleAttack)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 41);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 40);
		return 0;
	}

	public static int RifleAfterFire(ref CommonWeaponArg arg)
	{
		bool isWeightlessness = Contexts.sharedInstance.battleRoom.pyEngine.PyEngine.GetWorld().GetSceneMoveData() is SceneMoveData sceneMoveData && sceneMoveData.isWeightlessness;
		KickBack(arg.Cmd.Seq, arg.Player, arg.CurrentWeapon, isWeightlessness);
		return 0;
	}

	private static void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		if (currentWeapon.basicInfo.Info is IGunWeaponInfo { KickbackLogic: not null } gunWeaponInfo)
		{
			gunWeaponInfo.KickbackLogic.KickBack(seed, player, currentWeapon, isWeightlessness);
		}
	}

	public static int FireNextAttack(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval);
		return 0;
	}

	public static int FireSetLastFireTime(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.LastFire = arg.ClientTime;
		return 0;
	}

	public static int DebugAfterFire(ref CommonWeaponArg arg)
	{
		Logger.DebugFormat("DebugAfterFire:{0} ,{1},{2},{3}", arg.Cmd.Seq, arg.CurrentWeapon.attack, arg.CurrentWeapon.clip, arg.CurrentWeapon.special);
		return 0;
	}

	public static int RightFireQkhhAfterFire(ref CommonWeaponArg arg)
	{
		if (arg.Player.hasFirstPersonUnityObjects && !arg.Player.fov.IsZoom() && !arg.Cmd.PredicatedOnce)
		{
			WeaponUtility.Fire(arg.Player.firstPersonUnityObjects.RightFires, arg.CurrentWeapon.special.SpecialMode, arg.FireParentTranName, arg.FireTranName);
			WeaponUtility.RightFire(arg.Player);
		}
		else if (arg.Player.hasThirdPersonUnityObjects && !arg.Player.fov.IsZoom() && !arg.Cmd.PredicatedOnce)
		{
			WeaponUtility.Fire(arg.Player.thirdPersonUnityObjects.RightFires, arg.CurrentWeapon.special.SpecialMode, arg.FireParentTranName, arg.FireTranName);
			WeaponUtility.RightFire(arg.Player);
		}
		return 0;
	}

	public static int LeftFireQkhhAfterFire(ref CommonWeaponArg arg)
	{
		if (arg.Player.hasFirstPersonUnityObjects && !arg.Player.fov.IsZoom() && !arg.Cmd.PredicatedOnce)
		{
			WeaponUtility.Fire(arg.Player.firstPersonUnityObjects.LeftFires, arg.CurrentWeapon.special.SpecialMode, arg.FireParentTranName);
			WeaponUtility.LeftFire(arg.Player);
		}
		else if (arg.Player.hasThirdPersonUnityObjects && !arg.Player.fov.IsZoom() && !arg.Cmd.PredicatedOnce)
		{
			WeaponUtility.Fire(arg.Player.thirdPersonUnityObjects.LeftFires, arg.CurrentWeapon.special.SpecialMode, arg.FireParentTranName);
			WeaponUtility.LeftFire(arg.Player);
		}
		return 0;
	}

	public static int AllFireQkhhAfterFire(ref CommonWeaponArg arg)
	{
		if (arg.Player.hasFirstPersonUnityObjects && !arg.Player.fov.IsZoom() && !arg.Cmd.PredicatedOnce)
		{
			WeaponUtility.AllFire(arg.Player.firstPersonUnityObjects.LeftFires, arg.CurrentWeapon.special.SpecialMode);
			WeaponUtility.AllFire(arg.Player.firstPersonUnityObjects.RightFires, arg.CurrentWeapon.special.SpecialMode);
			WeaponUtility.AllFire(arg.Player);
		}
		return 0;
	}

	public static void PlayConfigSound(SoundConfigData data, BaseEventEntityData eventdata, Vector3? entityPosition)
	{
		if (data.Point)
		{
			Vector3 inv = new Vector3(eventdata.X, eventdata.Y, eventdata.Z);
			inv = VectorCoordConverter.SsjjToUnity(inv);
			if (data.NoStop)
			{
				if (!MonoBehaviourSingleton<GameSoundManager>.Instance.IsInJob(ref data.AssetInfo))
				{
					MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Shoot, isMyself: false, data.AssetInfo, inv, GameSoundManager.Config.WeaponVolume, data.Scale, 0, data.Loop, data.MoveTime);
				}
			}
			else
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Shoot, isMyself: false, data.AssetInfo, inv, data.Vol, data.Scale, 0, data.Loop);
			}
		}
		else if (data.NoStop)
		{
			if (!MonoBehaviourSingleton<GameSoundManager>.Instance.IsInJob(ref data.AssetInfo))
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Shoot, isMyself: true, data.AssetInfo, GameSoundManager.Config.WeaponVolume, 0, data.Loop);
			}
		}
		else
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.StopSound(ref data.AssetInfo);
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Shoot, isMyself: true, data.AssetInfo, data.Vol, 0, data.Loop);
		}
	}

	public static int PlayFireSound(ref CommonWeaponArg arg)
	{
		if (!arg.Cmd.PredicatedOnce)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Shoot, arg.Player.isMyPlayer, SoundResourceUtility.GetWeaponSoundFireAssetInfo(arg.CurrentWeapon.basicInfo.Data.WeaponName), GameSoundManager.Config.WeaponVolume);
		}
		return 0;
	}

	public static int PlayFire3Sound(ref CommonWeaponArg arg)
	{
		if (arg.Player.hasFirstPersonUnityObjects && !arg.Cmd.PredicatedOnce)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Shoot, arg.Player.isMyPlayer, SoundResourceUtility.GetWeaponSoundFire3AssetInfo(arg.CurrentWeapon.basicInfo.Data.WeaponName), GameSoundManager.Config.WeaponVolume);
		}
		return 0;
	}

	public static int PlayFire4Sound(ref CommonWeaponArg arg)
	{
		if (arg.Player.hasFirstPersonUnityObjects && !arg.Cmd.PredicatedOnce)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Shoot, arg.Player.isMyPlayer, SoundResourceUtility.GetWeaponSoundFire4AssetInfo(arg.CurrentWeapon.basicInfo.Data.WeaponName), GameSoundManager.Config.WeaponVolume);
		}
		return 0;
	}

	public static void ForcePlaySecFireSound(ref CommonWeaponArg arg)
	{
		if (!arg.Cmd.PredicatedOnce)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Shoot, arg.Player.isMyPlayer, SoundResourceUtility.GetWeaponSoundSecFireAssetInfo(arg.CurrentWeapon.basicInfo.Data.WeaponName), GameSoundManager.Config.WeaponVolume);
		}
	}

	public static int PlaySecFireSound(ref CommonWeaponArg arg)
	{
		if (arg.Player.hasFirstPersonUnityObjects && !arg.Cmd.PredicatedOnce)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Shoot, arg.Player.isMyPlayer, SoundResourceUtility.GetWeaponSoundSecFireAssetInfo(arg.CurrentWeapon.basicInfo.Data.WeaponName), GameSoundManager.Config.WeaponVolume);
		}
		return 0;
	}

	public static int FovLeft(ref CommonWeaponArg arg)
	{
		arg.Player.fov.ResumeZoom = true;
		arg.Player.fov.LastFov = arg.Player.fov.Fov;
		arg.Player.fov.DelayFov = 90;
		arg.Player.fov.Fov = 90;
		return 0;
	}

	public static Vector3 TraceWorldInDistance(PlayerEntity player, WeaponEntity currentWeapon)
	{
		TraceResult traceResult = Fire(player, currentWeapon, 0, TraceDistance, Zero, Zero);
		if (traceResult.EntityId != -1)
		{
			PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(traceResult.EntityId);
			if (entityWithEntityId != null)
			{
				if (player.OnGround())
				{
					return entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex());
				}
			}
			else if ((double)traceResult.Plane.normal[2] > 0.7 && traceResult.Fraction < 1f)
			{
				_tracePos.x = traceResult.EndPos[0];
				_tracePos.y = traceResult.EndPos[1];
				_tracePos.z = traceResult.EndPos[2];
				return _tracePos;
			}
		}
		return Vector3.zero;
	}

	public static void CheckShowGun(CommonWeaponArg arg)
	{
		if (arg.Cmd.IsShowGun && arg.Player.viewAnim.ViewAnimInfo.StateId != 44)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
		}
	}
}
