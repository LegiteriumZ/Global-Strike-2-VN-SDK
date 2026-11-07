namespace Assets.Sources.Info.MoveObject;

internal class FireBombMoveObjectInfo : MoveEntityEffectRenderObjectInfo
{
	protected override void UpdateRotationX(SceneObjectEntity entity)
	{
		entity.rotation.EulerAngles.x = 0f - entity.moveObject.PitchYawRoll.y;
	}

	protected override void UpdateRotationZ(SceneObjectEntity entity)
	{
		entity.rotation.EulerAngles.z = 90f + entity.moveObject.PitchYawRoll.z;
	}
}
