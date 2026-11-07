namespace Assets.Sources.Info.MoveObject;

public class FlybombMoveEntityEffectRenderObject : MoveEntityEffectRenderObjectInfo
{
	protected override void UpdateRotationX(SceneObjectEntity entity)
	{
		entity.rotation.EulerAngles.x = 0f - entity.moveObject.PitchYawRoll.y;
	}

	protected override void UpdateRotationZ(SceneObjectEntity entity)
	{
		entity.rotation.EulerAngles.z = entity.moveObject.PitchYawRoll.z;
	}
}
