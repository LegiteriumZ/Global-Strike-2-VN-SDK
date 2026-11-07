using Assets.Sources.Components.Camera;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Framework.System;

public class FrameExecuteSystem
{
	public int AllFrame { get; set; }

	public int FrameExecute => 2;

	protected virtual bool Frame(int equal = 0)
	{
		AllFrame++;
		return isJump(equal);
	}

	protected virtual bool isJump(int equal = 0)
	{
		if (FrameExecute > 0)
		{
			if (AllFrame % FrameExecute == equal)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	protected virtual bool isJump(PlayerEntity entity)
	{
		if (entity.GetTeam() == Contexts.sharedInstance.player.cameraOwnerEntity.GetTeam())
		{
			if (isJump(1))
			{
				return true;
			}
		}
		else
		{
			Vector3 compenstatePos = entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex());
			compenstatePos.z += 90f;
			Vector3 position = Contexts.sharedInstance.worldCamera.cameraTransform.position;
			Vector3 inv = compenstatePos - position;
			CameraTransformComponent cameraTransform = Contexts.sharedInstance.worldCamera.cameraTransform;
			Vector3 vector = Quaternion.Euler(YawPitchUtility.SsjjYawPitchRollToUnityEularAngle(cameraTransform.Yaw, cameraTransform.Pitch, cameraTransform.Roll)) * new Vector3(0f, 0f, 1f);
			if (Vector3.Distance(vector * Vector3.Dot(VectorCoordConverter.SsjjToUnity(inv), vector) + VectorCoordConverter.SsjjToUnity(position), VectorCoordConverter.SsjjToUnity(compenstatePos)) > 200f && isJump(1))
			{
				return true;
			}
		}
		return false;
	}
}
