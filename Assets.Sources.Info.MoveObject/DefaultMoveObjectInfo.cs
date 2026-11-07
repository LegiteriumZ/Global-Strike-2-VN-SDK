namespace Assets.Sources.Info.MoveObject;

public class DefaultMoveObjectInfo : MoveEntityEffectRenderObjectInfo
{
	protected override void UpdateRotationY(SceneObjectEntity entity)
	{
		entity.rotation.EulerAngles.y = 0f - PitchTrim - entity.moveObject.PitchYawRoll.y;
	}

	protected override void UpdateRotationZ(SceneObjectEntity entity)
	{
		entity.rotation.EulerAngles.z = YawTrim + entity.moveObject.PitchYawRoll.z;
	}
}
