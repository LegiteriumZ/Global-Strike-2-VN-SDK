using SSJJMath;
using UnityEngine;
using physics.data;
using physics.trace;
using share;

namespace Assets.Sources.Modules.Player.HitBox;

internal static class DebugDrawUtility
{
	public static void DrawHitBoxBrush(HitBoxBrush hitBoxBrush)
	{
	}

	public static void DrawBoundBox(Vector3D min, Vector3D max, Matrix3D bmatrix)
	{
		Vector3[] array = new Vector3[8]
		{
			new Vector3((float)min.x, (float)min.y, (float)min.z),
			new Vector3((float)max.x, (float)min.y, (float)min.z),
			new Vector3((float)max.x, (float)max.y, (float)min.z),
			new Vector3((float)min.x, (float)max.y, (float)min.z),
			new Vector3((float)min.x, (float)min.y, (float)max.z),
			new Vector3((float)max.x, (float)min.y, (float)max.z),
			new Vector3((float)max.x, (float)max.y, (float)max.z),
			new Vector3((float)min.x, (float)max.y, (float)max.z)
		};
		Vector3[] array2 = new Vector3[8];
		Vector3D vector3D = TraceObjectPool.AllocateVector3D();
		Vector3D dest = TraceObjectPool.AllocateVector3D();
		for (int i = 0; i < 8; i++)
		{
			bmatrix.Transform(VectorTypeConverter.Unity2Ssjj(array[i]), vector3D);
			VectorCoordConverter.SsjjToUnity(vector3D, out dest);
			array2[i] = VectorTypeConverter.Ssjj2Unity(dest);
		}
		TraceObjectPool.ReturnVector3D(vector3D);
		TraceObjectPool.ReturnVector3D(dest);
		Color red = Color.red;
		Debug.DrawLine(array2[0], array2[4], red);
		Debug.DrawLine(array2[1], array2[5], red);
		Debug.DrawLine(array2[2], array2[6], red);
		Debug.DrawLine(array2[3], array2[7], red);
		Debug.DrawLine(array2[0], array2[1], red);
		Debug.DrawLine(array2[4], array2[5], red);
		Debug.DrawLine(array2[3], array2[2], red);
		Debug.DrawLine(array2[6], array2[7], red);
		Debug.DrawLine(array2[0], array2[3], red);
		Debug.DrawLine(array2[1], array2[2], red);
		Debug.DrawLine(array2[4], array2[7], red);
		Debug.DrawLine(array2[5], array2[6], red);
	}

	public static void DrawTrace(Trace results, Vector3D start)
	{
	}
}
