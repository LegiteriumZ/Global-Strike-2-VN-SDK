using Assets.Sources.Components.BattleRoom;
using SSJJBase.Constant;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Camera.CameraLogic;

public class ParasiticEntityLogic : DefaultCameraLogic
{
	public override int Priority()
	{
		return 60;
	}

	public override PlayerCameraModeEnum CameraMode()
	{
		return PlayerCameraModeEnum.Third;
	}

	public override bool IsActive()
	{
		PlayerEntity cameraOwnerEntity = Contexts.player.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.GetPlayerInfo().ParasiticId != 0 && Contexts.player.GetEntityWithEntityId(cameraOwnerEntity.GetPlayerInfo().ParasiticId) != null)
		{
			return true;
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
		Vector3 result = Vector3.zero;
		if (Contexts.battleRoom.hasPyEngine && Contexts.battleRoom.pyEngine.PyEngine != null)
		{
			PlayerEntity cameraOwnerEntity = Contexts.player.cameraOwnerEntity;
			if (cameraOwnerEntity != null)
			{
				result = cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()) + cameraOwnerEntity.ViewOrgOffset() + new Vector3(0f, 0f, ViewHeight(cameraOwnerEntity));
				SetParasiticViewOrg(ref result, cameraOwnerEntity);
				int num = 0;
				if (cameraOwnerEntity.skill.Status.ContainsKey(PlayerInfoStatusConstant.THIRD_CAMERA_BACKDIS.ID))
				{
					num = cameraOwnerEntity.skill.Status[PlayerInfoStatusConstant.THIRD_CAMERA_BACKDIS.ID].Number;
				}
				if (num == 0)
				{
					num = 300;
				}
				result = this.GetCalculateCameraEndPos(result, this.GetCurrentCmdYaw(), this.GetCurrentCmdPitch(), num);
			}
		}
		return result;
	}

	protected void SetParasiticViewOrg(ref Vector3 viewOrg, PlayerEntity cameraEntity)
	{
		int parasiticId = cameraEntity.GetPlayerInfo().ParasiticId;
		if (parasiticId != 0)
		{
			PlayerEntity entityWithEntityId = Contexts.player.GetEntityWithEntityId(parasiticId);
			if (entityWithEntityId != null)
			{
				PlayerInfoComponent.StatusDes value = null;
				cameraEntity.skill.Status.TryGetValue(PlayerInfoStatusConstant.THIRD_CAMERA_HEIGHT.ID, out value);
				int num = value?.Number ?? ((int)ViewHeight(Contexts.player.cameraOwnerEntity));
				viewOrg = this.GetCalculateCameraEndPos(entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex()), this.GetCurrentCmdYaw(), -90f, num);
			}
		}
	}
}
