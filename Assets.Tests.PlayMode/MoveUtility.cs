using Assets.Sources.Utils;
using UnityEngine;
using physics;
using physics.trace;
using share;

namespace Assets.Tests.PlayMode;

public static class MoveUtility
{
	public static Vector3 TryMove(IPyEngine pyEngine, Vector3 start0, Vector3 end0)
	{
		float[] mins = new float[3] { -10f, -10f, -10f };
		float[] maxs = new float[3] { 10f, 10f, 10f };
		Trace trace = TraceObjectPool.AllocateTrace();
		Vector3D vector3D = TraceObjectPool.AllocateVector3D();
		Vector3D vector3D2 = TraceObjectPool.AllocateVector3D();
		float[] array = TraceObjectPool.AllocateFloat3();
		float[] array2 = TraceObjectPool.AllocateFloat3();
		Vector3 vector = end0;
		try
		{
			vector3D.SetTo(start0.x, start0.y, start0.z);
			vector3D2.SetTo(end0.x, end0.y, end0.z);
			VectorUtils.Vector3DToFloat3(vector3D, array);
			VectorUtils.Vector3DToFloat3(vector3D2, array2);
			PyEngineUtility.BulletTraceToWorld(pyEngine, trace, array, array2, mins, maxs);
			vector = new Vector3(trace.endPos[0], trace.endPos[1], trace.endPos[2]);
			if (vector != end0)
			{
				vector = start0;
			}
		}
		finally
		{
			TraceObjectPool.ReturnTrace(trace);
			TraceObjectPool.ReturnVector3D(vector3D);
			TraceObjectPool.ReturnVector3D(vector3D2);
			TraceObjectPool.ReturnFloat3(array);
			TraceObjectPool.ReturnFloat3(array2);
		}
		return vector;
	}
}
