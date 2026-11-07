using NetData;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Utils.Playback;

public class SnapshotUtils
{
	public Vector3 GetPlayerEntityPosition(PlayerEntityData nowEntity, PlayerEntityData nextEntity, float frameInterpolation, Vector3 vect)
	{
		if (nowEntity == null)
		{
			return Vector3.zero - vect;
		}
		if (nextEntity == null)
		{
			return new Vector3(nowEntity.X, nowEntity.Y, nowEntity.Z) - vect;
		}
		if (nowEntity.IsDead)
		{
			return new Vector3(nextEntity.X, nextEntity.Y, nextEntity.Z) - vect;
		}
		float x = InterpolateUtility.LinearInterpolate(nowEntity.X, nextEntity.X, frameInterpolation);
		float y = InterpolateUtility.LinearInterpolate(nowEntity.Y, nextEntity.Y, frameInterpolation);
		float z = InterpolateUtility.LinearInterpolate(nowEntity.Z, nextEntity.Z, frameInterpolation);
		return new Vector3(x, y, z) - vect;
	}
}
