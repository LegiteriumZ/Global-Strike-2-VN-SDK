using Assets.Sources.Components.Interface;
using NetData;
using SSJJBase.Constant;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Camera.CameraLogic;

internal class MainControlCameraLogic : DefaultCameraLogic
{
	public override int Priority()
	{
		return 25;
	}

	public override float Yaw()
	{
		return this.GetCurrentCmdYaw();
	}

	public override float Pitch()
	{
		return this.GetCurrentCmdPitch();
	}

	public override int ContentMask()
	{
		if (CameraMode() == PlayerCameraModeEnum.Third)
		{
			return 167837705;
		}
		return 33619977;
	}

	public override Vector3 Position()
	{
		int mainCameraId = Contexts.snapshot.snapshots.NowSnapshot.MainCameraId;
		SceneObjectEntity entityWithEntityId = Contexts.sceneObject.GetEntityWithEntityId(mainCameraId);
		if (entityWithEntityId != null && entityWithEntityId.hasCameraObject)
		{
			CameraEntityData current = entityWithEntityId.cameraObject.Current;
			if (current != null)
			{
				SceneObjectEntity entityWithEntityId2 = Contexts.sceneObject.GetEntityWithEntityId(current.AttachedEntityId);
				if (entityWithEntityId2 != null)
				{
					return entityWithEntityId2.position.Origin;
				}
			}
		}
		PlayerEntity cameraOwnerEntity = Contexts.player.cameraOwnerEntity;
		return cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()) + cameraOwnerEntity.ViewOrgOffset() + new Vector3(0f, 0f, ViewHeight(cameraOwnerEntity));
	}

	public override PlayerCameraModeEnum CameraMode()
	{
		return PlayerCameraModeEnum.Third;
	}

	public override void ReActive()
	{
	}

	public override bool IsActive()
	{
		PlayerEntity cameraOwnerEntity = Contexts.player.cameraOwnerEntity;
		ISnapshot snapshot = (Contexts.snapshot.hasSnapshots ? Contexts.snapshot.snapshots.NowSnapshot : null);
		if (cameraOwnerEntity != null && snapshot != null && snapshot.MainCameraId > 0 && !cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.CAMERA_LOCK_ENTITY.ID))
		{
			return true;
		}
		return false;
	}

	public override void Update()
	{
	}
}
