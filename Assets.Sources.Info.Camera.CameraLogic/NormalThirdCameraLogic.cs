using Assets.Sources.Free.Data;
using SSJJBase.Constant;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Camera.CameraLogic;

internal class NormalThirdCameraLogic : DefaultCameraLogic
{
	public override int Priority()
	{
		return 15;
	}

	public override float Yaw()
	{
		return Contexts.player.cameraOwnerEntity.orientation.Yaw + Contexts.player.cameraOwnerEntity.punchSmooth.TempPunchYaw + GameModelLocator.GetInstance().GameModel.ShakeAngleOffect.x;
	}

	public override float Pitch()
	{
		return Contexts.player.cameraOwnerEntity.orientation.Pitch + Contexts.player.cameraOwnerEntity.punchSmooth.TempPunchPitch + GameModelLocator.GetInstance().GameModel.ShakeAngleOffect.y;
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
		if (cameraOwnerEntity != null)
		{
			if (cameraOwnerEntity.GetPlayerInfo().InChaos || cameraOwnerEntity.GetPlayerInfo().InFear)
			{
				return true;
			}
			bool flag = false;
			if (cameraOwnerEntity.hasBasicInfo && cameraOwnerEntity.basicInfo.Current != null)
			{
				flag = cameraOwnerEntity.basicInfo.Current.IsThirdMode;
			}
			return cameraOwnerEntity.GetPlayerInfo().ThirdMode || flag;
		}
		return false;
	}

	public override void Update()
	{
	}

	public override Vector3 Position()
	{
		Vector3 result = Vector3.zero;
		if (Contexts.battleRoom.hasPyEngine && Contexts.battleRoom.pyEngine.PyEngine != null)
		{
			PlayerEntity cameraOwnerEntity = Contexts.player.cameraOwnerEntity;
			if (cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.HAN_SWOED_HIT.ID))
			{
				result = this.SetSkillCameraViewOrg(Roll(), Yaw(), Pitch(), cameraOwnerEntity);
			}
			else
			{
				float z = cameraOwnerEntity.move.ViewHeightBase + cameraOwnerEntity.viewHeight.ViewHeightSmoothRemain;
				result = cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()) + cameraOwnerEntity.ViewOrgOffset() + new Vector3(0f, 0f, z);
				if (cameraOwnerEntity.GetPlayerInfo().ThirdMode && !cameraOwnerEntity.IsDead())
				{
					if (cameraOwnerEntity.GetPlayerInfo().IsGhostRiderSkill)
					{
						result = this.GetCalculateCameraEndPos(result, this.GetCurrentCmdYaw() - 30f, this.GetCurrentCmdPitch() - 15f, 500f);
					}
					else if (!cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.TWINS_INFINITE_CAMERA_SPECIAL.ID))
					{
						result = (cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.TWINS_INFINITE_CAMERA.ID) ? this.GetCalculateCameraEndPos(result, this.GetCurrentCmdYaw(), this.GetCurrentCmdPitch()) : (cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.THUNDER_LEGEND_IN_CONTROL.ID) ? this.GetCalculateCameraEndPos(result, this.GetCurrentCmdYaw() + 15f, this.GetCurrentCmdPitch() - 10f, 250f) : (cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.KUNLUNGONGZHU_SHIFT_USING.ID) ? this.GetCalculateCameraEndPos(result, this.GetCurrentCmdYaw(), this.GetCurrentCmdPitch(), 1200f) : (PlayerCareerUtil.CareerUseHigherCamera(cameraOwnerEntity.GetCareer()) ? this.GetCalculateCameraEndPos(result, this.GetCurrentCmdYaw(), this.GetCurrentCmdPitch(), 400f) : ((!cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.STAR_DEBRIS_SPECIAL_MODE.ID)) ? this.GetCalculateCameraEndPos(result, this.GetCurrentCmdYaw(), this.GetCurrentCmdPitch(), 500f) : this.GetCalculateCameraEndPos(result, this.GetCurrentCmdYaw() + 17f, this.GetCurrentCmdPitch() - 4f, 140f))))));
					}
					else
					{
						result.z += 70f;
						result = this.GetCalculateCameraEndPos(result, this.GetCurrentCmdYaw(), 30f, 600f);
					}
				}
				else
				{
					result = this.GetCalculateCameraEndPos(result, this.GetCurrentCmdYaw(), this.GetCurrentCmdPitch());
				}
			}
		}
		return result;
	}
}
