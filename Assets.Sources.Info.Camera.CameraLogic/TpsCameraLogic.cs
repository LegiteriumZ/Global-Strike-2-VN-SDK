using Assets.Sources.Components.Camera;
using Assets.Sources.Components.Time;
using Assets.Sources.Free.Data;
using Assets.Sources.Modules.Ui.UiEventCondition;
using SSJJBase.Constant;
using SSJJMath;
using UnityEngine;
using share;
using share.constant;

namespace Assets.Sources.Info.Camera.CameraLogic;

public class TpsCameraLogic : DefaultCameraLogic
{
	private Vector3 _position;

	private float _yaw;

	private float _pitch;

	private float _lockYaw;

	private float _lockPitch;

	private float _distance;

	private Vector3 _viewOrgPosition;

	private Vector3 _targetPosition;

	private Vector3 _cameraEndOffset;

	private bool _p3Remote = true;

	private const float farthestDistance = 250f;

	private const float nearestDistance = 100f;

	private const float aimAcceleration = 0.05f;

	private int startAimTime;

	private int exitAimTime;

	private float currentDistance;

	public override int Priority()
	{
		return 101;
	}

	public override float Yaw()
	{
		return _yaw;
	}

	public override float Pitch()
	{
		return _pitch;
	}

	public override float Roll()
	{
		float result = 0f;
		CameraDataComponent cameraData = Contexts.worldCamera.cameraData;
		if (cameraData != null && cameraData.IsUsingXpSkill)
		{
			result = GameModelLocator.GetInstance().GameModel.ShakeAngleOffect.z;
		}
		return result;
	}

	public override float Fov()
	{
		return Contexts.worldCamera.cameraData.Fov;
	}

	public override Vector3 Position()
	{
		return _position;
	}

	public override PlayerCameraModeEnum CameraMode()
	{
		return PlayerCameraModeEnum.Third;
	}

	public override void ReActive()
	{
	}

	private float GetYaw(CameraDataComponent data)
	{
		return this.GetCurrentCmdYaw();
	}

	private float GetPitch(CameraDataComponent data)
	{
		return this.GetCurrentCmdPitch();
	}

	private bool GetIsSecondAttackOn(CameraDataComponent data)
	{
		return this.GetCurrentCmdSecondAttack();
	}

	public override bool IsActive()
	{
		CameraDataComponent cameraData = Contexts.worldCamera.cameraData;
		PlayerEntity cameraOwnerEntity = Contexts.player.cameraOwnerEntity;
		_yaw = Contexts.player.cameraOwnerEntity.orientation.Yaw;
		_pitch = Contexts.player.cameraOwnerEntity.orientation.Pitch;
		_viewOrgPosition = cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()) + cameraOwnerEntity.ViewOrgOffset() + new Vector3(0f, 0f, ViewHeight(cameraOwnerEntity));
		_cameraEndOffset = Vector3.zero;
		int frameInterval = Contexts.time.time.FrameInterval;
		string uiMyPlayer_Career = UiIEventCondition.Get_uiMyPlayer_Career();
		UiIEventCondition.Get_weaponState_WeaponName();
		if (!string.IsNullOrEmpty(uiMyPlayer_Career) && PlayerCareerUtil.IsTPS(uiMyPlayer_Career))
		{
			cameraData.Fov = 90;
			cameraData.CameraYawAddValue = _yaw;
			cameraData.CameraPitchAddValue = _pitch;
			cameraData.TransTime = Mathf.Max(230, cameraData.TransTime + frameInterval);
			cameraData.IsTps = true;
		}
		return cameraData.IsTps;
	}

	public override void Update()
	{
		CameraDataComponent cameraData = Contexts.worldCamera.cameraData;
		PlayerEntity myPlayerEntity = Contexts.player.myPlayerEntity;
		if (myPlayerEntity.IsUsingBigSkill())
		{
			_distance = 250f;
			startAimTime = 0;
			exitAimTime = 0;
		}
		if (startAimTime == 0 && exitAimTime == 0)
		{
			_distance = 250f;
		}
		TimeComponent time = Contexts.time.time;
		if (GetIsSecondAttackOn(cameraData) && startAimTime == 0 && exitAimTime == 0)
		{
			startAimTime = time.ClientRealTime;
		}
		else if (!GetIsSecondAttackOn(cameraData) && startAimTime != 0)
		{
			startAimTime = 0;
			exitAimTime = time.ClientRealTime;
		}
		if (exitAimTime > 0)
		{
			int frameInterval = time.FrameInterval;
			float num = 0f + 0.05f * (float)(time.ClientRealTime - exitAimTime);
			_distance += num * (float)frameInterval;
			if (_distance >= 250f)
			{
				_distance = 250f;
				exitAimTime = 0;
			}
		}
		if (startAimTime > 0)
		{
			int frameInterval2 = time.FrameInterval;
			float num2 = 0f + 0.05f * (float)(time.ClientRealTime - startAimTime);
			_distance -= num2 * (float)frameInterval2;
			if (_distance < 100f)
			{
				_distance = 100f;
			}
		}
		if (cameraData.IsTps)
		{
			_targetPosition = this.GetCalculateCameraEndPos(_viewOrgPosition, cameraData.CameraYawAddValue, cameraData.CameraPitchAddValue, _distance);
			Vector3D vector3D = new Vector3D();
			Vector3D vector3D2 = new Vector3D();
			Vector3D vector3D3 = new Vector3D();
			AngleUtility.AnglesToVectors2(_yaw, _pitch, vector3D, vector3D2, vector3D3);
			vector3D.Normalize();
			vector3D2.Normalize();
			vector3D3.Normalize();
			vector3D2.ScaleBy(50f);
			_targetPosition = this.GetCalculateCameraEndPos(_targetPosition, cameraData.CameraYawAddValue + 90f, 0f, 50f);
			if (myPlayerEntity != null && myPlayerEntity.fov.Fov != cameraData.Fov)
			{
				myPlayerEntity.fov.Fov = cameraData.Fov;
				myPlayerEntity.fov.DelayFov = cameraData.Fov;
			}
		}
		if (cameraData.TransTime != 0)
		{
			InterpolateCamareDeadEndPos(_viewOrgPosition, _targetPosition, cameraData.TransTime);
		}
	}

	public void InterpolateCamareDeadEndPos(Vector3 start, Vector3 end, int time)
	{
		float num = Mathf.Clamp01((float)time / 400f);
		_position.x = (float)Maths.Lerp(start.x, end.x, num);
		_position.y = (float)Maths.Lerp(start.y, end.y, num);
		_position.z = (float)Maths.Lerp(start.z, end.z, num);
	}
}
