using Assets.Sources.Constant;
using SSJJSceneLoader;
using UnityEngine;
using physics.data;
using share;

namespace Assets.Sources.Utils.Ui;

public static class InScreenUtils
{
	private static Vector3D mins = new Vector3D();

	private static Vector3D maxs = new Vector3D();

	public static bool InScreen(Vector3 targetPos, HitPreliminaryGeo hitPreliminaryGeo, SSJJSceneLoader.CPlane[] cameraPlanes)
	{
		Vector3D pos = hitPreliminaryGeo.pos;
		int num = hitPreliminaryGeo.r * 2;
		mins.SetTo((double)(-num) + pos.x + (double)targetPos.x, (double)(-num) + pos.y + (double)targetPos.y, (double)(-num) + pos.z + (double)targetPos.z);
		maxs.SetTo((double)num + pos.x + (double)targetPos.x, (double)num + pos.y + (double)targetPos.y, (double)num + pos.z + (double)ViewHeight.GetNormalViewHeight("") + (double)targetPos.z);
		return Math3DEx.cullingVisible(15, mins, maxs, cameraPlanes);
	}

	public static float InScreen(Vector3 targetPos, Camera cam)
	{
		Vector3 vector = targetPos - cam.transform.position;
		return Vector3.Dot(cam.transform.forward, vector.normalized);
	}

	public static float CheckInScreenAccury(Vector3 targetPos, Camera cam)
	{
		Vector3 vector = cam.WorldToViewportPoint(targetPos);
		if (vector.z <= 0f)
		{
			return -1f;
		}
		if (vector.x > 0f && vector.x < 1f && vector.y > 0f && vector.y < 1f)
		{
			return 1f;
		}
		return -1f;
	}
}
