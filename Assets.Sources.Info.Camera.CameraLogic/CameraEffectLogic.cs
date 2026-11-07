using System;
using SSJJBase.Constant;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.Camera.CameraLogic;

public class CameraEffectLogic : DefaultCameraLogic
{
	public override int Priority()
	{
		return 80;
	}

	public override float Yaw()
	{
		return (float)(Contexts.worldCamera.cameraEffect.Rotation.z * 180.0 / Math.PI);
	}

	public override float Pitch()
	{
		return (float)(Contexts.worldCamera.cameraEffect.Rotation.y * 180.0 / Math.PI);
	}

	public override float Roll()
	{
		return (float)(Contexts.worldCamera.cameraEffect.Rotation.x * 180.0 / Math.PI);
	}

	public override Vector3 Position()
	{
		return VectorTypeConverter.Ssjj2Unity(Contexts.worldCamera.cameraEffect.Position);
	}

	public override float Fov()
	{
		return 90f;
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
		if (Contexts.worldCamera.hasCameraEffect)
		{
			return Contexts.worldCamera.cameraEffect.Playing;
		}
		return false;
	}

	public override void ReActive()
	{
	}
}
