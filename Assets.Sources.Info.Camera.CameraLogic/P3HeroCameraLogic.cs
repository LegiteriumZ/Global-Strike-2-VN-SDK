using Assets.Sources.Components.Camera;
using Assets.Sources.Components.Player;
using Assets.Sources.Free.Data;
using Assets.Sources.Modules.Ui.UiEventCondition;
using SSJJBase.Constant;
using UnityEngine;
using share;

namespace Assets.Sources.Info.Camera.CameraLogic;

public class P3HeroCameraLogic : DefaultCameraLogic
{
	private Vector3 _position;

	private float _yaw;

	private float _pitch;

	private float _lockYaw;

	private float _lockPitch;

	private int _distance;

	private Vector3 _viewOrgPosition;

	private Vector3 _targetPosition;

	private Vector3 _cameraEndOffset;

	private bool _p3Remote = true;

	public override int Priority()
	{
		return 16;
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

	public override bool IsActive()
	{
		CameraDataComponent cameraData = Contexts.worldCamera.cameraData;
		PlayerEntity cameraOwnerEntity = Contexts.player.cameraOwnerEntity;
		_yaw = GetYaw(cameraData);
		_pitch = GetPitch(cameraData);
		_viewOrgPosition = cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()) + cameraOwnerEntity.ViewOrgOffset() + new Vector3(0f, 0f, ViewHeight(cameraOwnerEntity));
		_cameraEndOffset = Vector3.zero;
		cameraData.IsUsingXpSkill = false;
		int frameInterval = Contexts.time.time.FrameInterval;
		SkillComponent skill = Contexts.player.cameraOwnerEntity.skill;
		string uiMyPlayer_Career = UiIEventCondition.Get_uiMyPlayer_Career();
		string weaponState_WeaponName = UiIEventCondition.Get_weaponState_WeaponName();
		if (skill.Status != null && !string.IsNullOrEmpty(uiMyPlayer_Career) && uiMyPlayer_Career.Equals("p3hero"))
		{
			if (weaponState_WeaponName.Equals("p3hero_gun_weapon"))
			{
				cameraData.Fov = 90;
				cameraData.CameraYawAddValue = _yaw + 9f;
				cameraData.CameraPitchAddValue = _pitch;
				cameraData.TransTime = Mathf.Max(230, cameraData.TransTime + frameInterval);
				_viewOrgPosition.z += 8f;
				_distance = 286;
				_p3Remote = true;
			}
			else
			{
				cameraData.Fov = 90;
				cameraData.CameraYawAddValue = _yaw + 8f;
				cameraData.CameraPitchAddValue = _pitch;
				cameraData.TransTime = Mathf.Max(230, cameraData.TransTime + frameInterval);
				_viewOrgPosition.z += -30f;
				_distance = 300;
				_p3Remote = false;
			}
			cameraData.IsUsingXpSkill = true;
		}
		return cameraData.IsUsingXpSkill;
	}

	public override void Update()
	{
		CameraDataComponent cameraData = Contexts.worldCamera.cameraData;
		PlayerEntity myPlayerEntity = Contexts.player.myPlayerEntity;
		if (cameraData.IsUsingXpSkill)
		{
			if (_p3Remote)
			{
				_targetPosition = this.GetCalculateCameraEndPosP3HeroRemote(_viewOrgPosition, cameraData.CameraYawAddValue, cameraData.CameraPitchAddValue, _distance);
			}
			else
			{
				_targetPosition = this.GetCalculateCameraEndPos(_viewOrgPosition, cameraData.CameraYawAddValue, cameraData.CameraPitchAddValue, _distance);
			}
			_targetPosition -= _cameraEndOffset;
			if (myPlayerEntity != null && myPlayerEntity.fov.Fov != cameraData.Fov)
			{
				myPlayerEntity.fov.Fov = cameraData.Fov;
				myPlayerEntity.fov.DelayFov = cameraData.Fov;
			}
		}
		else
		{
			cameraData.TransTime = Mathf.Max(0, cameraData.TransTime - Contexts.time.time.FrameInterval / 1000);
		}
		if (cameraData.TransTime != 0)
		{
			InterpolateCamareDeadEndPos(_viewOrgPosition, _targetPosition, cameraData.TransTime);
		}
		else if (cameraData.IsUsingXpSkill)
		{
			cameraData.IsUsingXpSkill = false;
			if (myPlayerEntity != null && myPlayerEntity.fov.Fov != 90)
			{
				myPlayerEntity.fov.Fov = 90;
				myPlayerEntity.fov.DelayFov = 90;
			}
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
