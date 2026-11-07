namespace Assets.Sources.Info.MoveObject;

internal class DefaultMoveObjectInfo2 : MoveEntityEffectRenderObjectInfo
{
	protected override void UpdateRotationY(SceneObjectEntity entity)
	{
		entity.rotation.EulerAngles.y = 0f - entity.moveObject.PitchYawRoll.y + 90f;
	}

	protected override void UpdateRotationZ(SceneObjectEntity entity)
	{
		entity.rotation.EulerAngles.z = entity.moveObject.PitchYawRoll.z - 90f;
	}
}
