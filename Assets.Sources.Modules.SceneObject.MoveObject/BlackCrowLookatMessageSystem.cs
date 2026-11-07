using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils;
using I2.Loc;
using NotifyEvent;
using SSJJPhysics;
using UnityEngine;
using physics;
using physics.trace;
using share;

namespace Assets.Sources.Modules.SceneObject.MoveObject;

public class BlackCrowLookatMessageSystem : IPlaybackSystem
{
	private readonly PlayerContext _playerContext;

	private readonly SceneObjectContext _sceneObjectContext;

	private readonly MessageContext _messageContext;

	public BlackCrowLookatMessageSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_sceneObjectContext = contexts.sceneObject;
		_messageContext = contexts.message;
	}

	public void OnPlayback()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity == null)
		{
			return;
		}
		int controlEntityId = cameraOwnerEntity.basicInfo.Current.ControlEntityId;
		SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(controlEntityId);
		if (entityWithEntityId != null && entityWithEntityId.hasMoveObject && cameraOwnerEntity.basicInfo.PlayerName == entityWithEntityId.moveObject.Current.ParentName)
		{
			IPyEngine uiPyEngine_PyEngine = UiIEventCondition.Get_uiPyEngine_PyEngine();
			Trace trace = new Trace();
			TraceResult traceResult = default(TraceResult);
			float[] array = new float[3];
			float[] array2 = new float[3];
			float[] mins = new float[3] { -25f, -25f, -25f };
			float[] maxs = new float[3] { 25f, 25f, 25f };
			Vector3D a = new Vector3D(entityWithEntityId.moveObject.Current.X, entityWithEntityId.moveObject.Current.Y, entityWithEntityId.moveObject.Current.Z);
			Vector3D a2 = new Vector3D(entityWithEntityId.moveObject.Current.X, entityWithEntityId.moveObject.Current.Y, entityWithEntityId.moveObject.Current.Z - 295f);
			VectorUtils.Vector3DToFloat3(a, array);
			VectorUtils.Vector3DToFloat3(a2, array2);
			PyEngineUtility.BulletTraceToWorld(uiPyEngine_PyEngine, trace, array, array2, mins, maxs);
			traceResult.CopyFrom(trace);
			if (trace.fraction == 1f)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BlackcrowFlyMaxheight"), 100);
				NotifyManager.ForceInvoke(38);
			}
			return;
		}
		if (entityWithEntityId != null && entityWithEntityId.hasCameraObject)
		{
			SceneObjectEntity entityWithEntityId2 = _sceneObjectContext.GetEntityWithEntityId(entityWithEntityId.cameraObject.Current.AttachId);
			if (entityWithEntityId2 != null && entityWithEntityId2.hasMoveObject && entityWithEntityId2.moveObject.Current.Name == "black_crow")
			{
				_messageContext.messageRemindData.SetMessage(string.Format(ScriptLocalization.Get("BlackcrowLookat"), entityWithEntityId2.moveObject.Current.ParentName), 100);
				NotifyManager.ForceInvoke(38);
				return;
			}
		}
		int entityId = cameraOwnerEntity.normalTrace.EntityId;
		if (entityId == -1 || entityId == -2)
		{
			return;
		}
		PlayerEntity entityWithEntityId3 = Contexts.sharedInstance.player.GetEntityWithEntityId(entityId);
		if (entityWithEntityId3 != null && entityWithEntityId3.basicInfo.Current.Team == cameraOwnerEntity.basicInfo.Current.Team && entityWithEntityId3.hasCurrentWeapon && entityWithEntityId3.GetCurrentWeaponName() == "black_crow" && entityWithEntityId3.GetCurrentWeaponLevel() == 3 && entityWithEntityId3.basicInfo.Cid != cameraOwnerEntity.basicInfo.Cid)
		{
			Vector3 compenstatePos = cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex());
			Vector3 compenstatePos2 = entityWithEntityId3.GetCompenstatePos(entityWithEntityId3.fpos.Change.GetPosIndex());
			if ((compenstatePos2.x - compenstatePos.x) * (compenstatePos2.x - compenstatePos.x) + (compenstatePos2.y - compenstatePos.y) * (compenstatePos2.y - compenstatePos.y) + (compenstatePos2.z - compenstatePos.z) * (compenstatePos2.z - compenstatePos.z) < 1000000f)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BlackcrowE"), 100);
				NotifyManager.ForceInvoke(38);
			}
		}
	}
}
