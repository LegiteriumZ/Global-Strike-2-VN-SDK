using Assets.Sources.Free.Data;
using SSJJBase.Constant;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Camera.CameraLogic;

public class NormalCameraLogic : DefaultCameraLogic
{
	public override int Priority()
	{
		return 10;
	}

	public override float Yaw()
	{
		return Contexts.player.cameraOwnerEntity.orientation.Yaw + Contexts.player.cameraOwnerEntity.punchSmooth.TempPunchYaw + GameModelLocator.GetInstance().GameModel.ShakeAngleOffect.x;
	}

	public override float Pitch()
	{
		return Contexts.player.cameraOwnerEntity.orientation.Pitch + Contexts.player.cameraOwnerEntity.punchSmooth.TempPunchPitch + GameModelLocator.GetInstance().GameModel.ShakeAngleOffect.y;
	}

	public override int ContentMask()
	{
		return 33619977;
	}

	public override Vector3 Position()
	{
		Vector3 zero = Vector3.zero;
		PlayerEntity cameraOwnerEntity = Contexts.player.cameraOwnerEntity;
		if (cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.HAN_SWOED_HIT.ID))
		{
			return this.SetSkillCameraViewOrg(Roll(), Yaw(), Pitch(), cameraOwnerEntity);
		}
		float num = cameraOwnerEntity.move.ViewHeightBase + cameraOwnerEntity.viewHeight.ViewHeightSmoothRemain;
		num *= 1f + cameraOwnerEntity.GetScale();
		return cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()) + cameraOwnerEntity.ViewOrgOffset() + new Vector3(0f, 0f, num);
	}

	public override PlayerCameraModeEnum CameraMode()
	{
		return PlayerCameraModeEnum.First;
	}

	public override void ReActive()
	{
	}

	public override bool IsActive()
	{
		return Contexts.player.cameraOwnerEntity != null;
	}

	public override void Update()
	{
	}
}
