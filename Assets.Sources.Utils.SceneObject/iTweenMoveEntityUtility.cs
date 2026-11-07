using SSJJMath;
using math;
using share;
using wooduanITween;

namespace Assets.Sources.Utils.SceneObject;

public static class iTweenMoveEntityUtility
{
	public static void Update(SceneObjectEntity entity, int frameInterval, int serverTime)
	{
		Vector3D vector3D = null;
		Vector3D vector3D2 = null;
		ITweenEntity moveToTweenEntity = entity.iTweenMove.MoveToTweenEntity;
		if (moveToTweenEntity != null)
		{
			moveToTweenEntity.TweenUpdate(frameInterval, serverTime);
			vector3D = moveToTweenEntity.GetOutData();
		}
		if (entity.iTweenMove.RotateToTweenEntity != null)
		{
			entity.iTweenMove.RotateToTweenEntity.TweenUpdate(frameInterval, serverTime);
			vector3D2 = entity.iTweenMove.RotateToTweenEntity.GetOutData();
		}
		if (entity.iTweenMove.PathTweenEntity != null)
		{
			entity.iTweenMove.PathTweenEntity.TweenUpdate(frameInterval, serverTime);
			vector3D = entity.iTweenMove.PathTweenEntity.GetOutData();
			vector3D2 = new Vector3D();
			AngleUtils.VectorToAngles(entity.iTweenMove.PathTweenEntity.GetPathLookTargetData().Subtract(vector3D), vector3D2);
			double x = vector3D2.x;
			vector3D2.SetTo(0.0, 0.0, 0.0);
			vector3D2.z = x;
		}
		if (vector3D != null)
		{
			entity.position.Origin = VectorTypeConverter.Ssjj2Unity(vector3D);
		}
		if (vector3D2 != null)
		{
			entity.rotation.EulerAngles = VectorTypeConverter.Ssjj2Unity(vector3D2);
		}
	}
}
