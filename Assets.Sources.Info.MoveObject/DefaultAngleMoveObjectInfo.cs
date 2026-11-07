namespace Assets.Sources.Info.MoveObject;

public class DefaultAngleMoveObjectInfo : DefaultMoveObjectInfo
{
	protected override void UpdateRotationY(SceneObjectEntity entity)
	{
		entity.rotation.EulerAngles.x = 0f - entity.moveObject.PitchYawRoll.y;
	}

	protected override void UpdateRotationZ(SceneObjectEntity entity)
	{
		entity.rotation.EulerAngles.z = 90f + YawTrim + entity.moveObject.PitchYawRoll.z;
	}
}
