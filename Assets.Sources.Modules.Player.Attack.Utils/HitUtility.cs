using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Constant.Weapon;
using Assets.Sources.Info.Res;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.SceneObject;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Ui;
using NotifyEvent;
using SSJJBase.Manager;
using SSJJBase.String;
using SSJJMath;
using UnityEngine;
using config;
using physics.trace;
using share;

namespace Assets.Sources.Modules.Player.Attack.Utils;

internal class HitUtility
{
	private static List<string> NotSendHitStatusList = new List<string> { "blink_shadow", "shotgun_pistol_stone" };

	private static float[] MIN = new float[3];

	private static float[] MAX = new float[3];

	private static System.Random random = new System.Random();

	public static int BulletHitWorldAction(ref HitWorldArgs arg)
	{
		if (!BspConstantUtil.NoImpact(arg.contexts.battleRoom.pyEngine.PyEngine.GetWorld().GetDecalsId(), arg.surfaceFlags))
		{
			bool isSpecialMode = false;
			if (arg.currentWeapon.hasSpecial)
			{
				isSpecialMode = arg.currentWeapon.special.SpecialMode;
			}
			arg.currentWeapon.basicInfo.Info.HoleLogic.CreateBulletHoleEntity(VectorTypeConverter.Ssjj2Unity(arg.startPos), VectorTypeConverter.Ssjj2Unity(arg.endPos), VectorTypeConverter.Ssjj2Unity(arg.normal), arg.player.entityId.Value, isKnife: false, isSpecialMode);
		}
		if (arg.currentWeapon.basicInfo.Info is IGunWeaponInfo)
		{
			CreateFireRail(arg.player, arg.currentWeapon, arg.contexts, arg.startPos, arg.endPos);
		}
		if (arg.player.normalTrace.EntityId != -2)
		{
			ISnapshot nowSnapshot = Contexts.sharedInstance.snapshot.snapshots.NowSnapshot;
			if (nowSnapshot != null && nowSnapshot.SimpleEngineEntityDataDict.Count > 0)
			{
				nowSnapshot.SimpleEngineEntityDataDict.TryGetValue(arg.player.normalTrace.EntityId, out var value);
				if (value != null)
				{
					SceneObjectFactory.Instance.CreateHitEffectEntity(arg.player.isMyPlayer, VectorCoordConverter.SsjjToUnity(arg.player.normalTrace.CollisionPoint), 100, isKnife: false);
				}
			}
		}
		return 0;
	}

	public static bool GetWeaponRailStartPoint(PlayerEntity player, Contexts contexts, Vector3D weaponRailStart, bool isForceLeftParticleRail)
	{
		if (!player.hasFirstPersonUnityObjects)
		{
			return false;
		}
		Camera camera = player.firstPersonUnityObjects.HandCameraObject.GetComponent<Camera>();
		if (camera == null)
		{
			camera = player.firstPersonUnityObjects.WeaponGameObject.GetComponentInChildren<Camera>();
		}
		if (camera == null)
		{
			camera = player.firstPersonUnityObjects.HandGameObject.GetComponentInChildren<Camera>();
		}
		if (camera == null)
		{
			return false;
		}
		Vector3? vector = null;
		Transform transform = contexts.worldCamera.unityObjects.mainCamera.transform;
		bool flag = false;
		foreach (KeyValuePair<IgnoreCaseString, Transform> allTransform in player.firstPersonUnityObjects.AllTransforms)
		{
			Transform value = allTransform.Value;
			string text = value.name.ToLower();
			if (WeaponJoinConstant.RightFireJoins.Contains(text) && !isForceLeftParticleRail)
			{
				Vector3 vector2 = transform.TransformPoint(camera.transform.InverseTransformPoint(value.position));
				weaponRailStart.x = vector2.x;
				weaponRailStart.y = vector2.y;
				weaponRailStart.z = vector2.z;
				return true;
			}
			if (!vector.HasValue && WeaponJoinConstant.LeftFireJoins.Contains(text))
			{
				Vector3 vector3 = transform.TransformPoint(camera.transform.InverseTransformPoint(value.position));
				vector = new Vector3(vector3.x, vector3.y, vector3.z);
			}
			else if (!flag && text.Contains("rail"))
			{
				flag = true;
				Vector3 vector4 = transform.TransformPoint(camera.transform.InverseTransformPoint(value.position));
				weaponRailStart.x = vector4.x;
				weaponRailStart.y = vector4.y;
				weaponRailStart.z = vector4.z;
			}
		}
		if (!flag && vector.HasValue)
		{
			weaponRailStart.x = vector.Value.x;
			weaponRailStart.y = vector.Value.y;
			weaponRailStart.z = vector.Value.z;
			return true;
		}
		return flag;
	}

	public static int KnifeHitWorldAction(ref HitWorldArgs arg)
	{
		if (!BspConstantUtil.NoImpact(arg.contexts.battleRoom.pyEngine.PyEngine.GetWorld().GetDecalsId(), arg.surfaceFlags))
		{
			arg.currentWeapon.basicInfo.Info.HoleLogic.CreateBulletHoleEntity(VectorTypeConverter.Ssjj2Unity(arg.startPos), VectorTypeConverter.Ssjj2Unity(arg.endPos), VectorTypeConverter.Ssjj2Unity(arg.normal), arg.player.entityId.Value, isKnife: true, isSpecialMode: false);
		}
		return 0;
	}

	private static bool CheckSendHitStatus(string weaponName, IEntitsWeaponInfo info)
	{
		if (string.IsNullOrEmpty(weaponName))
		{
			return true;
		}
		if (info is ShotGunWeaponInfo)
		{
			return false;
		}
		return !NotSendHitStatusList.Contains(weaponName);
	}

	public static int HiPlayerAction(ref HitPlayerArgs arg, bool isKnife)
	{
		int raceType = arg.contexts.battleRoom.roomData.Data.RaceType;
		int subRaceType = arg.contexts.battleRoom.roomData.Data.SubRaceType;
		if ((subRaceType == 58 || subRaceType == 46 || raceType == 21) && arg.hitGroup != 1)
		{
			return 0;
		}
		if (arg.beHitPlayer.basicInfo.Current.Team != arg.player.basicInfo.Current.Team)
		{
			arg.contexts.gameRule.hpProgressData.TargetId = arg.beHitPlayer.basicInfo.Current.Id;
			NotifyManager.ForceInvoke(3);
			if (GameSetting.Config.OpenBulletBlood == 1)
			{
				CreateHitPlayerEffect(ref arg, isKnife);
				if (!PlayerCareerConstantUtility.IsMech(arg.beHitPlayer.GetCareer()) || !PlayerCareerConstantUtility.IsHumanity(arg.player.GetCareer()) || !RuleUtilty.IsMechwarrior2(Contexts.sharedInstance.battleRoom.roomData.Data.FreeType))
				{
					CreateWallBloodEffect(arg.player, arg.contexts, arg.startPos, arg.endPos);
				}
			}
			if (raceType == 3 || raceType == 2)
			{
				bool flag = true;
				if (arg.currentWeapon != null && arg.currentWeapon.hasBasicInfo)
				{
					flag = CheckSendHitStatus(arg.currentWeapon.basicInfo.Data.WeaponName, arg.currentWeapon.basicInfo.Info);
				}
				if (flag)
				{
					HitDebug.SendHitStatics(Contexts.sharedInstance.time.time.RenderTime, arg.player, arg.beHitPlayer);
				}
			}
		}
		if (arg.currentWeapon.basicInfo.Info is IGunWeaponInfo)
		{
			CreateFireRail(arg.player, arg.currentWeapon, arg.contexts, arg.startPos, arg.endPos);
		}
		return 0;
	}

	private static void CreateWallBloodEffect(PlayerEntity player, Contexts contexts, Vector3D startPos, Vector3D endPos)
	{
		Trace trace = TraceObjectPool.AllocateTrace();
		Vector3D vector3D = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D2 = TraceObjectPool.AllocateVector3D();
		Vector3D vec = TraceObjectPool.AllocateVector3D();
		Vector3D vec2 = TraceObjectPool.AllocateVector3D();
		Vector3D vec3 = TraceObjectPool.AllocateVector3D();
		float[] array = TraceObjectPool.AllocateFloat3();
		float[] array2 = TraceObjectPool.AllocateFloat3();
		try
		{
			Vector3D vector3D3 = endPos.Subtract(startPos);
			vector3D3.Normalize();
			vector3D3.x += 0.125 - random.NextDouble() * 0.25;
			vector3D3.y += 0.125 - random.NextDouble() * 0.25;
			vector3D3.z = -0.3;
			vector3D.CopyFrom(endPos);
			Math3D.Vector3DMA(vector3D, 300f, vector3D3, vector3D2);
			VectorUtils.Vector3DToFloat3(vector3D, array);
			VectorUtils.Vector3DToFloat3(vector3D2, array2);
			PyEngineUtility.BulletTraceToWorld(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, trace, array, array2, MIN, MAX);
			if (trace.fraction >= 1f || (double)trace.plane.normal[2] >= 0.7)
			{
				vector3D3.z = -0.6;
				Math3D.Vector3DMA(vector3D, 300f, vector3D3, vector3D2);
				VectorUtils.Vector3DToFloat3(vector3D2, array2);
				PyEngineUtility.BulletTraceToWorld(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, trace, array, array2, MIN, MAX);
			}
			_ = trace.fraction;
			_ = 1f;
		}
		finally
		{
			TraceObjectPool.ReturnTrace(trace);
			TraceObjectPool.ReturnVector3D(vector3D);
			TraceObjectPool.ReturnVector3D(vector3D2);
			TraceObjectPool.ReturnVector3D(vec);
			TraceObjectPool.ReturnVector3D(vec2);
			TraceObjectPool.ReturnVector3D(vec3);
			TraceObjectPool.ReturnFloat3(array);
			TraceObjectPool.ReturnFloat3(array2);
		}
	}

	private static void CreateHitPlayerEffect(ref HitPlayerArgs arg, bool isKnife)
	{
		if (arg.beHitPlayer.basicInfo.IsDead || arg.beHitPlayer.state.GetPlayerStateType(1))
		{
			return;
		}
		string name = arg.player.basicInfo.CareerInfo.Name;
		string name2 = arg.beHitPlayer.basicInfo.CareerInfo.Name;
		int raceType = arg.contexts.battleRoom.roomData.Data.RaceType;
		GameBootConfig gameBootConfig = TplManager.Instance.GameBootConfig;
		if (gameBootConfig.IsSplashEffectOpen)
		{
			int num = 0;
			num = ((!RuleUtilty.IsPveModel(raceType)) ? BattleSingletonInstance<ResConfigFactory>.Instance.GetSplashEventId(gameBootConfig.PvpSplashEffectType, gameBootConfig.PvpSplashEffectColor) : BattleSingletonInstance<ResConfigFactory>.Instance.GetSplashEventId(gameBootConfig.PveSplashEffectType, gameBootConfig.PveSplashEffectColor));
			EventEffectData eventEntityData = ParticleManager.Instance().GetEventEntityData(num);
			if (eventEntityData != null)
			{
				SceneObjectFactory.Instance.CreateHitEffectEntity(arg.player.isMyPlayer, VectorCoordConverter.SsjjToUnity(VectorTypeConverter.Ssjj2Unity(arg.endPos)), eventEntityData.AssetInfo, isKnife);
			}
		}
		else
		{
			int resId = ((arg.hitGroup == 9) ? 4 : (((PlayerCareerConstantUtility.IsHero(name) || PlayerCareerConstantUtility.IsEmpress(name)) && (PlayerCareerConstantUtility.IsHero(name2) || PlayerCareerConstantUtility.IsEmpress(name2) || PlayerCareerConstantUtility.IsDoun(name2))) ? 4 : (name2.Equals("PVE_VOIDDEVICE") ? 5 : ((RuleUtilty.IsBioMode(raceType) || RuleUtilty.IsPve(raceType)) ? 3 : ((PlayerCareerConstantUtility.IsMech(name2) && PlayerCareerConstantUtility.IsHumanity(name) && RuleUtilty.IsMechwarrior2(Contexts.sharedInstance.battleRoom.roomData.Data.FreeType)) ? 6 : ((arg.hitGroup == 1) ? 2 : ((!isKnife) ? 1 : 0)))))));
			SceneObjectFactory.Instance.CreateHitEffectEntity(arg.player.isMyPlayer, VectorCoordConverter.SsjjToUnity(VectorTypeConverter.Ssjj2Unity(arg.endPos)), resId, isKnife);
		}
	}

	private static void CreateFireRail(PlayerEntity player, WeaponEntity currentWeapon, Contexts contexts, Vector3D startPos, Vector3D endPos)
	{
		if (currentWeapon.basicInfo.Info.WeaponType != 6 && !FreeWeaponConstant.IsDoubleRifle(currentWeapon.basicInfo.Info.Name))
		{
			(currentWeapon.basicInfo.Info as IGunWeaponInfo).RailLogic.CreateBulletRailEntity(player, currentWeapon, VectorTypeConverter.Ssjj2Unity(startPos), VectorTypeConverter.Ssjj2Unity(endPos));
		}
	}

	public static int KnifeHitPlayerAction(ref HitPlayerArgs arg)
	{
		HiPlayerAction(ref arg, isKnife: true);
		return 0;
	}

	public static int BulletHiPlayerAction(ref HitPlayerArgs arg)
	{
		HiPlayerAction(ref arg, isKnife: false);
		return 0;
	}
}
