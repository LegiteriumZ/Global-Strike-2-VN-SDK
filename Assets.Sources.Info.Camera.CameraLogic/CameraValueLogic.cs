using System;
using System.Collections.Generic;
using Assets.Sources.Components.Camera;
using SSJJBase.Constant;
using UnityEngine;

namespace Assets.Sources.Info.Camera.CameraLogic;

public class CameraValueLogic : DefaultCameraLogic
{
	private Vector3 _position;

	private float _yaw;

	private float _pitch;

	private List<float> v = new List<float> { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };

	public override int Priority()
	{
		return 90;
	}

	public override PlayerCameraModeEnum CameraMode()
	{
		return PlayerCameraModeEnum.First;
	}

	public override float Yaw()
	{
		return _yaw;
	}

	public override float Pitch()
	{
		return _pitch;
	}

	public override Vector3 Position()
	{
		return _position;
	}

	public override bool IsActive()
	{
		if (Contexts.worldCamera.hasCameraValue)
		{
			return Contexts.worldCamera.cameraValue.Value.Camera;
		}
		return false;
	}

	public override void ReActive()
	{
		List<float> pos = GetPos(Contexts.worldCamera.cameraValue.Value);
		Vector3 position = new Vector3(pos[0], pos[1], pos[2]);
		float yaw = pos[3];
		float pitch = pos[4];
		_position = position;
		_yaw = yaw;
		_pitch = pitch;
	}

	public override void Update()
	{
	}

	private List<float> GetPos(CameraValueComponent.CameraValue value)
	{
		for (int i = 0; i < v.Count; i++)
		{
			v[i] = 0f;
		}
		int renderTime = Contexts.time.time.RenderTime;
		if (value.Type == 1 || value.Type == 2)
		{
			float num = 100f;
			if (renderTime - value.Start < value.Total)
			{
				num = 100f * (float)(renderTime - value.Start) / (float)value.Total;
			}
			if (value.Type == 1)
			{
				for (int j = 0; j < 5; j++)
				{
					v[j] = value.View[j];
				}
			}
			else if (value.Type == 2)
			{
				for (int k = 0; k < 5; k++)
				{
					v[k] = value.View[k] + num * (value.Des[k] - value.View[k]) / 100f;
				}
				if (value.MoveForword)
				{
					v[4] = GetYaw(value.View[0], value.View[1], value.View[2], value.Des[0], value.Des[1], value.Des[2]);
					v[3] = GetPitch(value.View[0], value.View[1], value.View[2], value.Des[0], value.Des[1], value.Des[2]);
				}
			}
		}
		return v;
	}

	private float GetYaw(float x1, float y1, float z1, float x2, float y2, float z2)
	{
		return (float)Math.Atan((double)(z2 - z1) / Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2))) * 180f / (float)Math.PI;
	}

	private float GetPitch(float x1, float y1, float z1, float x2, float y2, float z2)
	{
		return (float)Math.Atan2(y2 - y1, x2 - x1) * 180f / (float)Math.PI;
	}
}
