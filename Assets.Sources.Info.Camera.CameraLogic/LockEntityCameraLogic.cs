using Assets.Sources.Components.Interface;
using NetData;
using SSJJBase.Constant;
using SSJJMath;
using UnityEngine;
using share;
using share.constant;

namespace Assets.Sources.Info.Camera.CameraLogic;

public class LockEntityCameraLogic : DefaultCameraLogic
{
	private readonly Vector3D _angle = new Vector3D();

	private readonly Vector3D _eyePos = new Vector3D();

	public override PlayerCameraModeEnum CameraMode()
	{
		return PlayerCameraModeEnum.Third;
	}

	public override void ReActive()
	{
	}

	public override float Yaw()
	{
		return (float)_angle.x;
	}

	public override float Pitch()
	{
		return (float)_angle.y;
	}

	public override Vector3 Position()
	{
		return VectorTypeConverter.Ssjj2Unity(_eyePos);
	}

	public override bool IsActive()
	{
		PlayerEntity cameraOwnerEntity = Contexts.player.cameraOwnerEntity;
		ISnapshot snapshot = (Contexts.snapshot.hasSnapshots ? Contexts.snapshot.snapshots.NowSnapshot : null);
		if (cameraOwnerEntity != null && snapshot != null && snapshot.MainCameraId > 0 && cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.CAMERA_LOCK_ENTITY.ID))
		{
			return true;
		}
		return false;
	}

	public override void Update()
	{
		int mainCameraId = Contexts.snapshot.snapshots.NowSnapshot.MainCameraId;
		SceneObjectEntity entityWithEntityId = Contexts.sceneObject.GetEntityWithEntityId(mainCameraId);
		if (entityWithEntityId == null || !entityWithEntityId.hasCameraObject)
		{
			return;
		}
		CameraEntityData current = entityWithEntityId.cameraObject.Current;
		if (current != null)
		{
			SceneObjectEntity entityWithEntityId2 = Contexts.sceneObject.GetEntityWithEntityId(current.AttachedEntityId);
			if (entityWithEntityId2 != null)
			{
				Vector3 origin = entityWithEntityId2.position.Origin;
				_angle.x = this.GetCurrentCmdYaw();
				_angle.y = this.GetCurrentCmdPitch();
				Vector3 calculateCameraEndPos = this.GetCalculateCameraEndPos(origin, Yaw(), Pitch(), 1000f);
				_eyePos.x = calculateCameraEndPos.x;
				_eyePos.y = calculateCameraEndPos.y;
				_eyePos.z = calculateCameraEndPos.z;
			}
		}
	}
}
