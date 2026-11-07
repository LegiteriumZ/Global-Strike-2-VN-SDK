using Assets.Sources.Constant;
using Entitas;
using SSJJBase.Constant;
using SSJJMath;
using UnityEngine;
using share;

namespace Assets.Sources.Info.Camera.CameraLogic;

public class DeadCameraLogic : ObserverLogic
{
	private Vector3D _enemyPos = new Vector3D();

	private Vector3D _eyePos = new Vector3D();

	private Vector3D _angle = new Vector3D();

	private int _deadTime;

	private Vector3 _deadEndPos;

	private IGroup<PlayerEntity> _groupToAdd;

	public override int Priority()
	{
		return 100;
	}

	public override float Yaw()
	{
		return (float)_angle.x;
	}

	public override float Pitch()
	{
		return (float)_angle.y;
	}

	public override Vector3 Position()
	{
		return VectorTypeConverter.Ssjj2Unity(_eyePos);
	}

	public override PlayerCameraModeEnum CameraMode()
	{
		return PlayerCameraModeEnum.Third;
	}

	public override bool IsActive()
	{
		if (_groupToAdd == null)
		{
			_groupToAdd = Contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.MyPlayer, PlayerMatcher.CameraOwner, PlayerMatcher.DeadCamera));
		}
		if (Contexts.player.cameraOwnerEntity.IsDead())
		{
			Contexts sharedInstance = Contexts.sharedInstance;
			if (sharedInstance.battleRoom.roomData.Data.RaceType == 25 && sharedInstance.snapshot.snapshots.NowSnapshot.ControlId > 0)
			{
				return false;
			}
			return _groupToAdd.count > 0;
		}
		foreach (PlayerEntity item in _groupToAdd)
		{
			item.RemoveDeadCamera();
		}
		return false;
	}

	public override void ReActive()
	{
		PlayerEntity playerEntity = null;
		foreach (PlayerEntity item in _groupToAdd)
		{
			if (playerEntity == null)
			{
				playerEntity = item;
				Vector3 vector = VectorCoordConverter.UnityToSsjj(Contexts.worldCamera.unityObjects.nodeEye.transform.position);
				VectorCoordConverter.Unity2Ssjj(ref _enemyPos, playerEntity.deadCamera.EnemyPos);
				VectorCoordConverter.Unity2Ssjj(ref _eyePos, vector);
				Maths.VectorToAngles(_enemyPos.Subtract(_eyePos), _angle);
				_deadEndPos = this.GetCalculateCameraEndPos(vector, Yaw(), Pitch());
			}
		}
		_deadTime = Contexts.time.time.ClientRealTime;
	}

	public override void Update()
	{
		PlayerEntity cameraOwnerEntity = Contexts.player.cameraOwnerEntity;
		Vector3 position = cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()) + cameraOwnerEntity.ViewOrgOffset() + new Vector3(0f, 0f, ViewHeight(cameraOwnerEntity));
		int num = Contexts.time.time.ClientRealTime - _deadTime;
		if (!RuleUtilty.IsCameraFrozenWhenDead(Contexts.battleRoom.roomData.Data.RaceType) && num > 5000)
		{
			_angle.x = this.GetCurrentCmdYaw();
			_angle.y = this.GetCurrentCmdPitch();
			Vector3 calculateCameraEndPos = this.GetCalculateCameraEndPos(position, Yaw(), Pitch());
			_eyePos.x = calculateCameraEndPos.x;
			_eyePos.y = calculateCameraEndPos.y;
			_eyePos.z = calculateCameraEndPos.z;
		}
		else
		{
			float num2 = Mathf.Clamp01((float)num / 400f);
			_eyePos.x = Maths.Lerp(position.x, _deadEndPos.x, num2);
			_eyePos.y = Maths.Lerp(position.y, _deadEndPos.y, num2);
			_eyePos.z = Maths.Lerp(position.z, _deadEndPos.z, num2);
		}
	}

	public override int ContentMask()
	{
		return 134217729;
	}
}
