using Assets.Sources.Components.Camera;
using Assets.Sources.Components.Player;
using Assets.Sources.Free.Data;
using SSJJBase.Constant;
using SSJJMath;
using UnityEngine;
using share;
using share.constant;

namespace Assets.Sources.Info.Camera.CameraLogic;

public class UsingXpSkillLogic : DefaultCameraLogic
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

	public override int Priority()
	{
		return 30;
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
		if (UseXpSkillCanRotateCamera())
		{
			return this.GetCurrentCmdYaw();
		}
		if (data.IsUsingXpSkill)
		{
			return data.CameraYawXP + GameModelLocator.GetInstance().GameModel.ShakeAngleOffect.x;
		}
		return base.Yaw();
	}

	private float GetPitch(CameraDataComponent data)
	{
		if (UseXpSkillCanRotateCamera())
		{
			return this.GetCurrentCmdPitch();
		}
		if (data.IsUsingXpSkill)
		{
			return data.CameraPitchXP + GameModelLocator.GetInstance().GameModel.ShakeAngleOffect.y;
		}
		return base.Pitch();
	}

	public override bool IsActive()
	{
		CameraDataComponent cameraData = Contexts.worldCamera.cameraData;
		bool isUsingXpSkill = cameraData.IsUsingXpSkill;
		PlayerEntity cameraOwnerEntity = Contexts.player.cameraOwnerEntity;
		_yaw = GetYaw(cameraData);
		_pitch = GetPitch(cameraData);
		_viewOrgPosition = cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()) + cameraOwnerEntity.ViewOrgOffset() + new Vector3(0f, 0f, ViewHeight(cameraOwnerEntity));
		_cameraEndOffset = Vector3.zero;
		cameraData.IsUsingXpSkill = false;
		int frameInterval = Contexts.time.time.FrameInterval;
		SkillComponent skill = Contexts.player.cameraOwnerEntity.skill;
		if (skill.Info.InXPSkill)
		{
			cameraData.Fov = 75;
			cameraData.CameraYawAddValue = _yaw + 15f;
			cameraData.CameraPitchAddValue = _pitch;
			cameraData.TransTime = Mathf.Max(230, cameraData.TransTime + frameInterval);
			_viewOrgPosition.z += 20f;
			_distance = 300;
			cameraData.IsUsingXpSkill = true;
			cameraData.CameraYawXP = _yaw;
			cameraData.CameraPitchXP = _pitch;
		}
		else if (skill.Status != null && skill.Status.ContainsKey(PlayerInfoStatusConstant.SKY_DEAGLE_SKILL_SHIFANGSHIJIAO.ID))
		{
			cameraData.Fov = 90;
			cameraData.CameraYawAddValue = _yaw;
			cameraData.CameraPitchAddValue = _pitch;
			cameraData.TransTime = Mathf.Max(230, cameraData.TransTime + frameInterval);
			_viewOrgPosition.z += 20f;
			_distance = 800;
			cameraData.IsUsingXpSkill = true;
			cameraData.CameraYawXP = _yaw;
			cameraData.CameraPitchXP = _pitch;
		}
		else if (skill.Status != null && skill.Status.ContainsKey(PlayerInfoStatusConstant.ANGERFIRESCARSKILL_SHIFANGSHIJIAO.ID))
		{
			cameraData.Fov = 75;
			cameraData.CameraYawAddValue = _yaw;
			cameraData.CameraPitchAddValue = _pitch;
			cameraData.TransTime = Mathf.Max(230, cameraData.TransTime + frameInterval);
			_viewOrgPosition.z += 20f;
			_distance = 1100;
			cameraData.IsUsingXpSkill = true;
			cameraData.CameraYawXP = _yaw;
			cameraData.CameraPitchXP = _pitch;
		}
		else if (skill.Status != null && skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_XP1004_SHIFANGSHIJIAO.ID))
		{
			cameraData.Fov = 75;
			cameraData.CameraYawAddValue = _yaw - 15f;
			cameraData.CameraPitchAddValue = _pitch;
			cameraData.TransTime = Mathf.Max(230, cameraData.TransTime + frameInterval);
			_viewOrgPosition.z += 20f;
			_distance = 500;
			cameraData.IsUsingXpSkill = true;
			cameraData.CameraYawXP = _yaw;
			cameraData.CameraPitchXP = _pitch;
		}
		else if (skill.Status != null && skill.Status.ContainsKey(PlayerInfoStatusConstant.HERO_COLD_DEATH_SKILL.ID))
		{
			cameraData.Fov = 90;
			cameraData.TransTime = Mathf.Max(230, cameraData.TransTime + frameInterval);
			_distance = 800;
			if (!isUsingXpSkill)
			{
				_lockYaw = _yaw;
				_lockPitch = -30f;
			}
			cameraData.CameraYawAddValue = _lockYaw;
			cameraData.CameraPitchAddValue = _lockPitch;
			cameraData.IsUsingXpSkill = true;
			cameraData.CameraYawXP = _lockYaw;
			cameraData.CameraPitchXP = _lockPitch;
		}
		else if (skill.Status != null && skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_XP1002_SKILL.ID))
		{
			cameraData.Fov = 75;
			cameraData.CameraYawAddValue = _yaw + 15f;
			cameraData.CameraPitchAddValue = _pitch;
			cameraData.TransTime = Mathf.Max(230, cameraData.TransTime + frameInterval);
			_viewOrgPosition.z += 20f;
			_distance = 300;
			cameraData.IsUsingXpSkill = true;
			cameraData.CameraYawXP = _yaw;
			cameraData.CameraPitchXP = _pitch;
		}
		else if (skill.Status != null && skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_XP1003_SKILL.ID))
		{
			cameraData.Fov = 90;
			cameraData.TransTime = Mathf.Max(230, cameraData.TransTime + frameInterval);
			_distance = 800;
			if (!isUsingXpSkill)
			{
				_lockYaw = _yaw;
				_lockPitch = _pitch;
			}
			_viewOrgPosition.z -= 20f;
			cameraData.CameraYawAddValue = _lockYaw + 35f;
			cameraData.CameraPitchAddValue = _lockPitch / 2f;
			Vector3 vector = AngleUtility.AnglesToVector(_yaw, 0f);
			vector.Normalize();
			_cameraEndOffset.x = (0f - vector.x) * 150f;
			_cameraEndOffset.y = (0f - vector.y) * 150f;
			cameraData.IsUsingXpSkill = true;
			cameraData.CameraYawXP = cameraData.CameraYawAddValue;
			cameraData.CameraPitchXP = cameraData.CameraPitchAddValue;
		}
		else if (skill.Status != null && skill.Status.ContainsKey(PlayerInfoStatusConstant.ROLE_SKILL_10.ID))
		{
			cameraData.Fov = 90;
			cameraData.CameraYawAddValue = _yaw;
			cameraData.CameraPitchAddValue = _pitch;
			cameraData.TransTime = Mathf.Max(230, cameraData.TransTime + frameInterval);
			_viewOrgPosition.z += 20f;
			_distance = 300;
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
			_targetPosition = this.GetCalculateCameraEndPos(_viewOrgPosition, cameraData.CameraYawAddValue, cameraData.CameraPitchAddValue, _distance);
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

	private bool UseXpSkillCanRotateCamera()
	{
		SkillComponent skill = Contexts.player.cameraOwnerEntity.skill;
		if (skill.Status != null && skill.Status.ContainsKey(PlayerInfoStatusConstant.ROLE_SKILL_10.ID))
		{
			return true;
		}
		return false;
	}
}
