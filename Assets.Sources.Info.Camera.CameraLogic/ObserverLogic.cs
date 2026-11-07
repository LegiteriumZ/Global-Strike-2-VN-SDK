using Assets.Sources.Free.Data;
using SSJJBase.Constant;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Camera.CameraLogic;

public class ObserverLogic : DefaultCameraLogic
{
	public override int Priority()
	{
		return 50;
	}

	public override float Yaw()
	{
		if (CameraMode() == PlayerCameraModeEnum.First)
		{
			return Contexts.player.cameraOwnerEntity.orientation.Yaw + Contexts.player.cameraOwnerEntity.punchSmooth.TempPunchYaw + GameModelLocator.GetInstance().GameModel.ShakeAngleOffect.x;
		}
		return base.Yaw();
	}

	public override float Pitch()
	{
		if (CameraMode() == PlayerCameraModeEnum.First)
		{
			return Contexts.player.cameraOwnerEntity.orientation.Pitch + Contexts.player.cameraOwnerEntity.punchSmooth.TempPunchPitch + GameModelLocator.GetInstance().GameModel.ShakeAngleOffect.y;
		}
		return base.Pitch();
	}

	public override PlayerCameraModeEnum CameraMode()
	{
		if (Contexts.battleRoom.gameStateEntity.isObserverFirstMode)
		{
			return PlayerCameraModeEnum.First;
		}
		return PlayerCameraModeEnum.Third;
	}

	public override bool IsActive()
	{
		PlayerEntity myPlayerEntity = Contexts.player.myPlayerEntity;
		BattleRoomContext battleRoom = Contexts.battleRoom;
		if (battleRoom.roomData.IsObserver || this.IsSpecialThirdObserver(battleRoom) || (myPlayerEntity != null && !myPlayerEntity.IsDead() && myPlayerEntity.HasState(131072)))
		{
			return true;
		}
		if (!Contexts.player.cameraOwnerEntity.isMyPlayer)
		{
			return !battleRoom.gameStateEntity.isObserverFirstMode;
		}
		return false;
	}

	public override void ReActive()
	{
	}

	public override void Update()
	{
	}

	public override Vector3 Position()
	{
		Vector3 vector = Vector3.zero;
		if (Contexts.battleRoom.hasPyEngine && Contexts.battleRoom.pyEngine.PyEngine != null)
		{
			PlayerEntity cameraOwnerEntity = Contexts.player.cameraOwnerEntity;
			if (cameraOwnerEntity.HasStatus(PlayerInfoStatusConstant.HAN_SWOED_HIT.ID))
			{
				vector = this.SetSkillCameraViewOrg(Roll(), Yaw(), Pitch(), cameraOwnerEntity);
			}
			else
			{
				vector = cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()) + cameraOwnerEntity.ViewOrgOffset() + new Vector3(0f, 0f, ViewHeight(cameraOwnerEntity));
				if (CameraMode() == PlayerCameraModeEnum.Third)
				{
					int num = 0;
					if (cameraOwnerEntity.skill.Status.ContainsKey(PlayerInfoStatusConstant.THIRD_CAMERA_BACKDIS.ID))
					{
						num = cameraOwnerEntity.skill.Status[PlayerInfoStatusConstant.THIRD_CAMERA_BACKDIS.ID].Number;
					}
					if (num == 0)
					{
						num = 300;
					}
					vector = this.GetCalculateCameraEndPos(vector, this.GetCurrentCmdYaw(), this.GetCurrentCmdPitch(), num);
				}
			}
		}
		return vector;
	}
}
