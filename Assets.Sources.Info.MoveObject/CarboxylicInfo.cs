namespace Assets.Sources.Info.MoveObject;

public class CarboxylicInfo : MoveEntityEffectRenderObjectInfo
{
	protected override void UpdateRotationY(SceneObjectEntity entity)
	{
		entity.rotation.EulerAngles.y = 0f - entity.moveObject.PitchYawRoll.y;
	}

	protected override void UpdateRotationZ(SceneObjectEntity entity)
	{
		entity.rotation.EulerAngles.z = entity.moveObject.PitchYawRoll.z;
	}
}
