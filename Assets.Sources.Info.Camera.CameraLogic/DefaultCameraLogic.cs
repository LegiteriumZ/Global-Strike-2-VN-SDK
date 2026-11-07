using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Camera;
using Assets.Sources.Free.Data;
using Assets.Sources.Utils;
using SSJJBase.Constant;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Camera.CameraLogic;

public abstract class DefaultCameraLogic : ICameraLogic
{
	protected Contexts Contexts = Contexts.sharedInstance;

	protected bool EnableSmooth;

	protected Vector3? LastSmoothPos;

	public virtual int Priority()
	{
		return int.MinValue;
	}

	public virtual bool IsActive()
	{
		return true;
	}

	public virtual float ViewHeight(PlayerEntity player)
	{
		ISnapshot snapshot = (Contexts.snapshot.hasSnapshots ? Contexts.snapshot.snapshots.NowSnapshot : null);
		if (snapshot != null && snapshot.ControlId > 0)
		{
			return PlayerConf.ColliderZ();
		}
		return ViewHeightUtility.GetViewHeight(player);
	}

	public virtual float Yaw()
	{
		float result = 0f;
		if (Contexts.player.cameraOwnerEntity != null)
		{
			result = this.GetPlayerYaw(Contexts.player.cameraOwnerEntity);
		}
		return result;
	}

	public virtual float Pitch()
	{
		float result = 0f;
		if (Contexts.player.cameraOwnerEntity != null)
		{
			result = this.GetPlayerPitch(Contexts.player.cameraOwnerEntity);
		}
		return result;
	}

	public virtual float Roll()
	{
		float result = 0f;
		if (Contexts.player.cameraOwnerEntity != null)
		{
			result = Contexts.player.cameraOwnerEntity.basicInfo.Current.PunchRoll + GameModelLocator.GetInstance().GameModel.ShakeAngleOffect.z;
		}
		return result;
	}

	public virtual float Fov()
	{
		BattleRoomContext battleRoom = Contexts.battleRoom;
		if ((battleRoom.roomData.IsObserver || this.IsSpecialThirdObserver(battleRoom)) && Contexts.worldCamera.hasCameraMode && Contexts.worldCamera.cameraMode.Mode != 0)
		{
			return 90f;
		}
		if (Contexts.player.cameraOwnerEntity != null)
		{
			return Contexts.player.cameraOwnerEntity.fov.Fov;
		}
		return 90f;
	}

	public abstract Vector3 Position();

	public abstract PlayerCameraModeEnum CameraMode();

	public abstract void ReActive();

	public abstract void Update();

	public virtual int ContentMask()
	{
		return 33619977;
	}
}
