using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.LinkObject;
using Assets.Sources.Framework;
using Assets.Sources.Info.LinkObject;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Weapon;
using Entitas;
using NetData;
using SSJJBase.Manager;
using SSJJMath;
using SSJJPhysics;
using UnityEngine;
using math;
using physics.entity;
using physics.trace;
using share;
using weapon;

namespace Assets.Sources.Modules.SceneObject.LinkObject;

internal class LinkObjectUpdateSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _group;

	private readonly SnapshotContext _snapshotContext;

	private PlayerContext _playerContext;

	public LinkObjectUpdateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.LinkObject).NoneOf(SceneObjectMatcher.Destroy));
		_playerContext = contexts.player;
	}

	public void OnRender()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		ISnapshot snapshot = _snapshotContext.snapshots.NextSnapshot;
		if (nowSnapshot == null)
		{
			return;
		}
		if (snapshot == null)
		{
			snapshot = nowSnapshot;
		}
		foreach (SceneObjectEntity item in _group)
		{
			nowSnapshot.LinkEntityDataDict.TryGetValue(item.entityId.Value, out var value);
			snapshot.LinkEntityDataDict.TryGetValue(item.entityId.Value, out var value2);
			if (value != null)
			{
				if (value2 == null)
				{
					value2 = value;
				}
				item.linkObject.UseId = value.UsePlayerId;
				item.linkObject.LinkId = value.LinkPlayerId;
				item.linkObject.Alpha = value.Alpha;
				AbstractLinkObjectInfo info = item.linkObject.Info as AbstractLinkObjectInfo;
				UpdateNowData(value, value2, item, info);
				float frameInterpolation = Contexts.sharedInstance.time.time.FrameInterpolation;
				item.linkObject.LerpStart = Vector3.Lerp(new Vector3(value.X, value.Y, value.Z), new Vector3(value2.X, value2.Y, value2.Z), frameInterpolation);
				item.linkObject.LerpEnd = Vector3.Lerp(new Vector3(value.LinkX, value.LinkY, value.LinkZ), new Vector3(value2.LinkX, value2.LinkY, value2.LinkZ), frameInterpolation);
				UpdateLinkPosition(item, info);
				float num = Vector3.Distance(item.linkObject.LerpStart, item.linkObject.LerpEnd);
				item.scale.Scale = new Vector3(1f, 1f, num / 100f);
				item.position.Origin = item.linkObject.LerpStart;
			}
		}
	}

	private void UpdateNowData(LinkEntityData nowData, LinkEntityData nextData, SceneObjectEntity sceneObjectEntity, AbstractLinkObjectInfo info)
	{
		if (info.isReplace)
		{
			UpdateLink(nowData, nextData, sceneObjectEntity);
			return;
		}
		LinkEntityType linkType = nowData.LinkType;
		if ((uint)(linkType - 93) <= 1u || (uint)(linkType - 104) <= 1u || (uint)(linkType - 114) <= 1u)
		{
			UpdateLink(nowData, nextData, sceneObjectEntity);
		}
	}

	private void UpdateLink(LinkEntityData nowData, LinkEntityData nextData, SceneObjectEntity sceneObjectEntity)
	{
		ILinkObjectInfo linkObjectInfo = BattleSingletonInstance<LinkObjectInfoFactory>.Instance.GetLinkObjectInfo(nowData.LinkType, nowData.LinkType2);
		if (nowData.LinkWidth != sceneObjectEntity.linkObject.Now.LinkWidth || nowData.LinkHeight != sceneObjectEntity.linkObject.Now.LinkHeight)
		{
			sceneObjectEntity.ReplaceLinkObject(nowData, nextData, linkObjectInfo, 0, 0, 100f, Vector3.zero, Vector3.zero);
		}
		if (nowData.LinkType != sceneObjectEntity.linkObject.Now.LinkType)
		{
			sceneObjectEntity.isDestroy = true;
		}
	}

	private void UpdateLinkPosition(SceneObjectEntity sceneObjectEntity, AbstractLinkObjectInfo info)
	{
		LinkEntityData now = sceneObjectEntity.linkObject.Now;
		switch (now.LinkType)
		{
		case LinkEntityType.RPGBURSTASSAULTSUOLIAN:
		case LinkEntityType.BONEWILDRIFLEBALLLINE:
		case LinkEntityType.BONEWILDRIFLEBALLLINEPERISH:
		case LinkEntityType.DUSTSHOTGUNDRIVEWINDLINE:
		case LinkEntityType.DUSTSHOTGUNDRIVEWINDLINEANIME:
			InitBurstAssaultSkillSuolianLinkEntityPos(now, sceneObjectEntity);
			return;
		case LinkEntityType.STORMCONNECT:
		case LinkEntityType.MIRAGESICKLELINE:
		case LinkEntityType.HEROSANGZHONGHOOK:
			InitBurstAssaultSkillSuolianLinkEntityPos(now, sceneObjectEntity);
			sceneObjectEntity.linkObject.LerpStart.z += 120f;
			return;
		case LinkEntityType.RPGFIRINGBEAMLINE:
		case LinkEntityType.PISTOFROZEN:
		case LinkEntityType.PARASITICSNIPERIMPULSEWAVE:
		case LinkEntityType.SKINPISTOFROZEN:
		case LinkEntityType.PARASITICSNIPERIMPULSEWAVEFROST:
		case LinkEntityType.BLOCKDRAGONPISTOLFIRE:
		case LinkEntityType.FIREOFJUSTICEDRAGONBULLET:
		case LinkEntityType.STRIKEPISTOLLINE:
		case LinkEntityType.FIREOFJUSTICEDRAGONBULLETQINGLONG:
		case LinkEntityType.FIREOFJUSTICEDRAGONBULLETLIGHTNING:
		case LinkEntityType.FIREOFJUSTICEDRAGONBULLETFROZEN:
		case LinkEntityType.BLOCKDRAGONPISTOLFIREKING:
		case LinkEntityType.BLOCKDRAGONPISTOLFIREFREEDM:
		case LinkEntityType.TRANSMACHINEGUNRAYLINE:
		case LinkEntityType.TRANSMACHINEGUNSTRIKERAYLINE:
		case LinkEntityType.LIGHTSNIPERSPECIALBULLET:
		case LinkEntityType.LIGHTSNIPERELECTRICITY:
			InitFiringBeamLinkEntityPos(now, sceneObjectEntity, 1000f);
			return;
		case LinkEntityType.DAWNLIGHTSHOTGUNJIGUANG:
		case LinkEntityType.DAWNLIGHTSHOTGUN1JIGUANG:
		case LinkEntityType.DAWNLIGHTSHOTGUN2JIGUANG:
		case LinkEntityType.SKINDAWNLIGHTSHOTGUNJIGUANG:
			InitFiringBeamLinkEntityPos(now, sceneObjectEntity, 50f);
			return;
		case LinkEntityType.DAWNLIGHTSHOTGUN3JIGUANG:
		case LinkEntityType.SKINDAWNLIGHTSHOTGUNJIGUANGTWO:
			InitFiringBeamLinkEntityPos(now, sceneObjectEntity, 30f);
			return;
		case LinkEntityType.ARCELECTRICSHOTGUNSHANDIANLIANARC:
		case LinkEntityType.SKINARCELECTRICSHOTGUNSHANDIANLIANARC:
		case LinkEntityType.ARCELECTRICSHOTGUNSHANDIANLIANARCSKINPURE:
		case LinkEntityType.LASERHEROPISTOLLIGHTYELLOW:
		case LinkEntityType.LASERHEROPISTOLDARKYELLOW:
		case LinkEntityType.SKINLASERHEROPISTOLLIGHTYELLOWDARKSTONE:
		case LinkEntityType.SKINLASERHEROPISTOLDARKYELLOWDARKSTONE:
		case LinkEntityType.SKINLASERHEROPISTOLLIGHTYELLOWSOUL:
		case LinkEntityType.SKINLASERHEROPISTOLDARKYELLOWSOUL:
			InitFiringBeamLinkEntityPos(now, sceneObjectEntity, 300f);
			return;
		case LinkEntityType.BLOCKCOMBINEDCANNONPENHUO:
			InitFiringBeamLinkEntityPos(now, sceneObjectEntity, 150f);
			return;
		case LinkEntityType.SPIKERIFLEREDLINE:
		case LinkEntityType.SPIKERIFLEBLUELINE:
			initFiringLinkEntityPlayerPos(now, sceneObjectEntity);
			return;
		case LinkEntityType.MECHKINGFIRE:
			InitMechFiringBeamLinkEntityPos(now, sceneObjectEntity, 500f);
			return;
		case LinkEntityType.TPSJIGUANG:
		case LinkEntityType.TPSSUOLIAN:
			InitTpsLinkEntityPos(now, sceneObjectEntity);
			return;
		case LinkEntityType.RAINBOWPISTOLBLUELINE:
		case LinkEntityType.RAINBOWPISTOLPURPLELINE:
		case LinkEntityType.RAINBOWPISTOLBLUELINEPINK:
		case LinkEntityType.RAINBOWPISTOLPURPLELINEPINK:
			InitTrackLinkEntityPos(now, sceneObjectEntity);
			return;
		}
		if (info != null && info.isForecast)
		{
			UpdateForecas(info, sceneObjectEntity);
		}
		else
		{
			InitDefaultLinkEntityPos(now, sceneObjectEntity);
		}
	}

	private void UpdateForecas(AbstractLinkObjectInfo info, SceneObjectEntity sceneObjectEntity)
	{
		LinkEntityData now = sceneObjectEntity.linkObject.Now;
		string jointName = ((!string.IsNullOrEmpty(info.jointName)) ? info.jointName : null);
		switch (info.forecastType)
		{
		case 0:
			InitDefaultLinkEntityPos(now, sceneObjectEntity);
			break;
		case 1:
			InitTrackLinkEntityPos(now, sceneObjectEntity);
			break;
		case 2:
			InitFiringBeamLinkEntityPos(now, sceneObjectEntity, info.traceLength, isLeftFire: false, jointName);
			break;
		case 3:
			InitBurstAssaultSkillSuolianLinkEntityPos(now, sceneObjectEntity);
			break;
		case 4:
			InitFiringBeamLinkEntityPos(now, sceneObjectEntity, info.traceLength, isLeftFire: true, jointName);
			break;
		default:
			InitDefaultLinkEntityPos(now, sceneObjectEntity);
			break;
		}
		sceneObjectEntity.linkObject.LerpStart.z += info.LerpStartz;
		sceneObjectEntity.linkObject.LerpEnd.z += info.LerpEndz;
		if (info.StartBackLen != 0)
		{
			Vector3 vector = sceneObjectEntity.linkObject.LerpStart - sceneObjectEntity.linkObject.LerpEnd;
			vector.Normalize();
			vector *= (float)info.StartBackLen;
			sceneObjectEntity.linkObject.LerpStart += vector;
		}
	}

	private void InitDotToDot(LinkEntityData linkEntity, SceneObjectEntity sceneObjectEntity)
	{
		sceneObjectEntity.linkObject.LerpStart = new Vector3(linkEntity.X, linkEntity.Y, linkEntity.Z);
		sceneObjectEntity.linkObject.LerpEnd = new Vector3(linkEntity.LinkX, linkEntity.LinkY, linkEntity.LinkZ);
	}

	private void InitBurstAssaultSkillSuolianLinkEntityPos(LinkEntityData linkEntity, SceneObjectEntity sceneObjectEntity)
	{
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(linkEntity.UsePlayerId);
		PlayerEntity entityWithEntityId2 = _playerContext.GetEntityWithEntityId(linkEntity.LinkPlayerId);
		if (entityWithEntityId != null)
		{
			sceneObjectEntity.linkObject.LerpStart = entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex());
		}
		if (entityWithEntityId2 != null)
		{
			sceneObjectEntity.linkObject.LerpEnd = entityWithEntityId2.GetCompenstatePos(entityWithEntityId2.fpos.Change.GetPosIndex());
			if (!sceneObjectEntity.hasMoveObject && linkEntity.LinkType != LinkEntityType.DUSTSHOTGUNDRIVEWINDLINE && linkEntity.LinkType != LinkEntityType.DUSTSHOTGUNDRIVEWINDLINEANIME)
			{
				sceneObjectEntity.linkObject.LerpEnd.z += 120f;
			}
		}
		if (linkEntity.LinkType == LinkEntityType.DUSTSHOTGUNDRIVEWINDLINE || linkEntity.LinkType == LinkEntityType.DUSTSHOTGUNDRIVEWINDLINEANIME)
		{
			sceneObjectEntity.linkObject.LerpStart.z += 100f;
			sceneObjectEntity.linkObject.LerpEnd.z += 100f;
		}
	}

	private void InitTpsLinkEntityPos(LinkEntityData linkEntity, SceneObjectEntity sceneObjectEntity)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity != null && myPlayerEntity.GetId() == linkEntity.LinkPlayerId)
		{
			sceneObjectEntity.linkObject.LerpEnd = myPlayerEntity.GetCompenstatePos(myPlayerEntity.fpos.Change.GetPosIndex()) + VectorCoordConverter.UnityToSsjj(new Vector3(0f, ViewHeightUtility.GetViewHeight(myPlayerEntity) * 0.6f, 0f));
		}
		else if (myPlayerEntity != null && myPlayerEntity.GetId() == linkEntity.UsePlayerId)
		{
			sceneObjectEntity.linkObject.LerpStart = myPlayerEntity.GetCompenstatePos(myPlayerEntity.fpos.Change.GetPosIndex()) + VectorCoordConverter.UnityToSsjj(new Vector3(0f, ViewHeightUtility.GetViewHeight(myPlayerEntity) * 0.6f, 0f));
		}
	}

	private void InitDefaultLinkEntityPos(LinkEntityData linkEntity, SceneObjectEntity sceneObjectEntity)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity != null && myPlayerEntity.GetId() == linkEntity.LinkPlayerId)
		{
			sceneObjectEntity.linkObject.LerpEnd = myPlayerEntity.GetCompenstatePos(myPlayerEntity.fpos.Change.GetPosIndex());
		}
		else if (myPlayerEntity != null && myPlayerEntity.GetId() == linkEntity.UsePlayerId)
		{
			sceneObjectEntity.linkObject.LerpStart = myPlayerEntity.GetCompenstatePos(myPlayerEntity.fpos.Change.GetPosIndex());
		}
		ILinkObjectInfo info = sceneObjectEntity.linkObject.Info;
		if (info != null && !string.IsNullOrEmpty(info.Info.AssetName) && (info.Info.AssetName.Info.Contains("goldweaponskill_shandianlian") || info.Info.AssetName.Info.Contains("goldweaponskill_nengliangbo")))
		{
			sceneObjectEntity.linkObject.LerpStart.z += 120f;
			sceneObjectEntity.linkObject.LerpEnd.z += 120f;
		}
	}

	private void InitMechFiringBeamLinkEntityPos(LinkEntityData linkEntity, SceneObjectEntity sceneObjectEntity, float traceLength)
	{
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(linkEntity.UsePlayerId);
		if (entityWithEntityId == null)
		{
			return;
		}
		Transform transform = null;
		if (entityWithEntityId.hasFirstPersonUnityObjects)
		{
			transform = entityWithEntityId.firstPersonUnityObjects.HandCameraObject.transform;
		}
		else if (entityWithEntityId.hasThirdPersonUnityObjects)
		{
			transform = entityWithEntityId.thirdPersonUnityObjects.ThirdTran.HeadTransform;
		}
		if (!(transform != null))
		{
			return;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		Vector3 result = Vector3.zero;
		if (GetFirePos(entityWithEntityId, out result))
		{
			if (entityWithEntityId == cameraOwnerEntity)
			{
				Vector3 position = transform.InverseTransformPoint(result);
				Vector3 inv = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.transform.TransformPoint(position);
				sceneObjectEntity.linkObject.LerpStart = VectorCoordConverter.UnityToSsjj(inv);
			}
			else
			{
				sceneObjectEntity.linkObject.LerpStart = VectorCoordConverter.UnityToSsjj(result);
			}
		}
		if (entityWithEntityId == cameraOwnerEntity)
		{
			float num = 0f;
			float num2 = 0f;
			if (entityWithEntityId == _playerContext.myPlayerEntity)
			{
				num = (float)Contexts.sharedInstance.userCommand.commands.LastCameraYaw() / 100f;
				num2 = (float)Contexts.sharedInstance.userCommand.commands.LastCameraPitch() / 100f;
			}
			else
			{
				num = entityWithEntityId.basicInfo.Current.ViewYaw;
				num2 = entityWithEntityId.basicInfo.Current.ViewPitch;
			}
			Vector3D data = ShootingDirUtils.CalculateShotingDir(0, num, num2, 0.0, 0f, 0.0);
			TraceResult traceResult = FireUtility.BulletTraceNormal(entityWithEntityId, traceLength * 0.4f, VectorTypeConverter.Ssjj2Unity(data));
			sceneObjectEntity.linkObject.LerpEnd = new Vector3(traceResult.EndPos[0], traceResult.EndPos[1], traceResult.EndPos[2]);
		}
		else
		{
			float num3 = 0f;
			float num4 = 0f;
			num3 = entityWithEntityId.basicInfo.Current.ViewYaw;
			num4 = entityWithEntityId.basicInfo.Current.ViewPitch;
			Vector3 vector = VectorTypeConverter.Ssjj2Unity(ShootingDirUtils.CalculateShotingDir(0, num3, num4, 0.0, 0f, 0.0));
			sceneObjectEntity.linkObject.LerpEnd = sceneObjectEntity.linkObject.LerpStart + vector * traceLength * 0.2f;
		}
	}

	private void InitFiringBeamLinkEntityPos(LinkEntityData linkEntity, SceneObjectEntity sceneObjectEntity, float traceLength, bool isLeftFire = false, string jointName = null)
	{
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(linkEntity.UsePlayerId);
		if (entityWithEntityId == null)
		{
			return;
		}
		Transform transform = null;
		if (entityWithEntityId.hasFirstPersonUnityObjects)
		{
			transform = entityWithEntityId.firstPersonUnityObjects.HandCameraObject.transform;
		}
		else if (entityWithEntityId.hasThirdPersonUnityObjects)
		{
			transform = entityWithEntityId.thirdPersonUnityObjects.ThirdTran.HeadTransform;
		}
		if (!(transform != null))
		{
			return;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		Vector3 result = Vector3.zero;
		if (string.IsNullOrEmpty(jointName) ? GetFirePos(entityWithEntityId, out result, isLeftFire) : GetLinkPos(entityWithEntityId, out result, jointName))
		{
			if (entityWithEntityId == cameraOwnerEntity)
			{
				Vector3 position = transform.InverseTransformPoint(result);
				Vector3 inv = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.transform.TransformPoint(position);
				sceneObjectEntity.linkObject.LerpStart = VectorCoordConverter.UnityToSsjj(inv);
			}
			else
			{
				sceneObjectEntity.linkObject.LerpStart = VectorCoordConverter.UnityToSsjj(result);
			}
		}
		if (entityWithEntityId == cameraOwnerEntity)
		{
			float num = 0f;
			float num2 = 0f;
			if (entityWithEntityId == _playerContext.myPlayerEntity)
			{
				num = (float)Contexts.sharedInstance.userCommand.commands.LastCameraYaw() / 100f;
				num2 = (float)Contexts.sharedInstance.userCommand.commands.LastCameraPitch() / 100f;
			}
			else
			{
				num = entityWithEntityId.basicInfo.Current.ViewYaw;
				num2 = entityWithEntityId.basicInfo.Current.ViewPitch;
			}
			Vector3D data = ShootingDirUtils.CalculateShotingDir(0, num, num2, 0.0, 0f, 0.0);
			TraceResult traceResult = FireUtility.BulletTraceNormal(entityWithEntityId, traceLength, VectorTypeConverter.Ssjj2Unity(data));
			sceneObjectEntity.linkObject.LerpEnd = new Vector3(traceResult.EndPos[0], traceResult.EndPos[1], traceResult.EndPos[2]);
		}
	}

	private void InitTrackLinkEntityPos(LinkEntityData linkEntity, SceneObjectEntity sceneObjectEntity)
	{
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(linkEntity.UsePlayerId);
		if (entityWithEntityId == null)
		{
			return;
		}
		Transform transform = null;
		if (entityWithEntityId.hasFirstPersonUnityObjects)
		{
			transform = entityWithEntityId.firstPersonUnityObjects.HandCameraObject.transform;
		}
		else if (entityWithEntityId.hasThirdPersonUnityObjects)
		{
			transform = entityWithEntityId.thirdPersonUnityObjects.ThirdTran.HeadTransform;
		}
		if (!(transform != null))
		{
			return;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		Vector3 result = Vector3.zero;
		if (GetFirePos(entityWithEntityId, out result))
		{
			if (entityWithEntityId == cameraOwnerEntity)
			{
				Vector3 position = transform.InverseTransformPoint(result);
				Vector3 inv = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.transform.TransformPoint(position);
				sceneObjectEntity.linkObject.LerpStart = VectorCoordConverter.UnityToSsjj(inv);
			}
			else
			{
				sceneObjectEntity.linkObject.LerpStart = VectorCoordConverter.UnityToSsjj(result);
			}
		}
	}

	private void initFiringLinkEntityPlayerPos(LinkEntityData linkEntity, SceneObjectEntity sceneObjectEntity)
	{
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(linkEntity.UsePlayerId);
		PlayerEntity entityWithEntityId2 = _playerContext.GetEntityWithEntityId(linkEntity.LinkPlayerId);
		if (entityWithEntityId == null || entityWithEntityId2 == null)
		{
			return;
		}
		Transform transform = null;
		if (entityWithEntityId.hasFirstPersonUnityObjects)
		{
			transform = entityWithEntityId.firstPersonUnityObjects.HandCameraObject.transform;
		}
		else if (entityWithEntityId.hasThirdPersonUnityObjects)
		{
			transform = entityWithEntityId.thirdPersonUnityObjects.ThirdTran.HeadTransform;
		}
		if (!(transform != null))
		{
			return;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		Vector3 result = Vector3.zero;
		if (GetFirePos(entityWithEntityId, out result))
		{
			if (entityWithEntityId == cameraOwnerEntity)
			{
				Vector3 position = transform.InverseTransformPoint(result);
				Vector3 inv = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.transform.TransformPoint(position);
				sceneObjectEntity.linkObject.LerpStart = VectorCoordConverter.UnityToSsjj(inv);
			}
			else
			{
				sceneObjectEntity.linkObject.LerpStart = VectorCoordConverter.UnityToSsjj(result);
			}
		}
		sceneObjectEntity.linkObject.LerpEnd = entityWithEntityId2.GetCompenstatePos(entityWithEntityId2.fpos.Change.GetPosIndex());
		sceneObjectEntity.linkObject.LerpEnd.z += 120f;
	}

	private static void CalculateTrace(IPyEntity entity, double yaw, double pitch, Vector3 cameraOrg, ref TraceResult result)
	{
		Vector3D vector3D = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D2 = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D3 = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D4 = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D5 = TraceObjectPool.AllocateVector3D();
		float[] array = TraceObjectPool.AllocateFloat3();
		float[] array2 = TraceObjectPool.AllocateFloat3();
		float[] mins = TraceObjectPool.AllocateFloat3();
		float[] maxs = TraceObjectPool.AllocateFloat3();
		AngleUtils.AnglesToVectors2(yaw, pitch, vector3D3, vector3D4, vector3D5);
		vector3D3.Normalize();
		vector3D.SetTo(cameraOrg.x, cameraOrg.y, cameraOrg.z);
		Math3D.Vector3DMA(vector3D, 1000f, vector3D3, vector3D2);
		VectorUtils.Vector3DToFloat3(vector3D, array);
		VectorUtils.Vector3DToFloat3(vector3D2, array2);
		Trace trace = TraceObjectPool.AllocateTrace();
		PyEngineUtility.BulletTrace(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, trace, entity, array, array2, mins, maxs);
		result.CopyFrom(trace);
		TraceObjectPool.ReturnTrace(trace);
		TraceObjectPool.ReturnVector3D(vector3D);
		TraceObjectPool.ReturnVector3D(vector3D2);
		TraceObjectPool.ReturnVector3D(vector3D3);
		TraceObjectPool.ReturnVector3D(vector3D4);
		TraceObjectPool.ReturnVector3D(vector3D5);
		TraceObjectPool.ReturnFloat3(array);
		TraceObjectPool.ReturnFloat3(array2);
		TraceObjectPool.ReturnTrace(trace);
	}

	private bool GetFirePos(PlayerEntity playerEntity, out Vector3 result, bool isLeftFire = false)
	{
		result = Vector3.zero;
		Transform result3;
		if (playerEntity != _playerContext.cameraOwnerEntity)
		{
			if (WeaponUtility.GetThirdFireTransform(playerEntity, out var result2, isLeftFire))
			{
				result = result2.position;
				return true;
			}
		}
		else if (WeaponUtility.GetViewFireTransform(playerEntity, isLeftFire ? 1 : 0, out result3))
		{
			result = result3.position;
			return true;
		}
		return false;
	}

	private bool GetLinkPos(PlayerEntity playerEntity, out Vector3 result, string jointName)
	{
		result = Vector3.zero;
		Transform result3;
		if (playerEntity != _playerContext.cameraOwnerEntity)
		{
			if (WeaponUtility.GetThirdLinkTransform(playerEntity, out var result2, jointName))
			{
				result = result2.position;
				return true;
			}
		}
		else if (WeaponUtility.GetViewLinkTransform(playerEntity, out result3, jointName))
		{
			result = result3.position;
			return true;
		}
		return false;
	}
}
