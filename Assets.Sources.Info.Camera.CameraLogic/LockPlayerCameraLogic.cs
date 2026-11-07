using SSJJBase.Constant;
using SSJJMath;
using UnityEngine;
using share;
using share.constant;

namespace Assets.Sources.Info.Camera.CameraLogic;

internal class LockPlayerCameraLogic : DefaultCameraLogic
{
	private readonly Vector3D _angle = new Vector3D();

	private readonly Vector3D _eyePos = new Vector3D();

	public override PlayerCameraModeEnum CameraMode()
	{
		return PlayerCameraModeEnum.Third;
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

	public override void ReActive()
	{
	}

	public override bool IsActive()
	{
		if (Contexts.player.myPlayerEntity != null)
		{
			return Contexts.player.myPlayerEntity.HasStatus(PlayerInfoStatusConstant.ON_AIR_JUMP.ID);
		}
		return false;
	}

	public override void Update()
	{
		Vector3 compenstatePos = Contexts.player.myPlayerEntity.GetCompenstatePos(Contexts.player.myPlayerEntity.fpos.Change.GetPosIndex());
		_angle.x = this.GetCurrentCmdYaw();
		_angle.y = this.GetCurrentCmdPitch();
		Vector3 calculateCameraEndPos = this.GetCalculateCameraEndPos(compenstatePos, Yaw(), Pitch());
		_eyePos.x = calculateCameraEndPos.x;
		_eyePos.y = calculateCameraEndPos.y;
		_eyePos.z = calculateCameraEndPos.z;
	}
}
