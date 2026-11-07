using Assets.Sources.Components.Interface;
using SSJJBase.Constant;
using UnityEngine;

namespace Assets.Sources.Info.Camera.CameraLogic;

public class ControlEntityLogic : DefaultCameraLogic
{
	public override int Priority()
	{
		return 70;
	}

	public override float Yaw()
	{
		return this.GetCurrentCmdYaw();
	}

	public override float Pitch()
	{
		return this.GetCurrentCmdPitch();
	}

	public override PlayerCameraModeEnum CameraMode()
	{
		return PlayerCameraModeEnum.Third;
	}

	public override void Update()
	{
	}

	public override bool IsActive()
	{
		PlayerEntity cameraOwnerEntity = Contexts.player.cameraOwnerEntity;
		ISnapshot snapshot = (Contexts.snapshot.hasSnapshots ? Contexts.snapshot.snapshots.NowSnapshot : null);
		if (cameraOwnerEntity != null && snapshot != null && snapshot.Observer == 0 && snapshot.ControlId > 0)
		{
			return true;
		}
		return false;
	}

	public override void ReActive()
	{
	}

	public override int ContentMask()
	{
		return 33619977;
	}

	public override Vector3 Position()
	{
		return GetObserverViewOrg(Contexts.player.cameraOwnerEntity);
	}

	protected Vector3 GetObserverViewOrg(PlayerEntity player)
	{
		Vector3 vector = Contexts.worldCamera.cameraTransform.position;
		if (player != null)
		{
			int controlEntityId = Contexts.player.cameraOwnerEntity.basicInfo.Current.ControlEntityId;
			SceneObjectEntity entityWithEntityId = Contexts.sceneObject.GetEntityWithEntityId(controlEntityId);
			if (entityWithEntityId != null && entityWithEntityId.hasPosition)
			{
				vector = entityWithEntityId.position.Origin + new Vector3(0f, 0f, 1f);
				float distance = ViewHeight(player);
				vector = this.GetCalculateCameraEndPos(vector, 0f, -90f, distance, 1f);
				if (!entityWithEntityId.hasCameraObject || entityWithEntityId.cameraObject.Current == null || !entityWithEntityId.cameraObject.Current.CanMove)
				{
					vector = this.GetCalculateCameraEndPos(vector, this.GetCurrentCmdYaw(), this.GetCurrentCmdPitch());
				}
			}
		}
		return vector;
	}
}
