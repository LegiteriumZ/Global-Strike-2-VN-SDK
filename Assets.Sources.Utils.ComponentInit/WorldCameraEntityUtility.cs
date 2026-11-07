using UnityEngine;

namespace Assets.Sources.Utils.ComponentInit;

public class WorldCameraEntityUtility
{
	public static void InitCameraTransform(WorldCameraContext context)
	{
		if (!context.hasCameraTransform)
		{
			context.SetCameraTransform(0f, 0f, 0f, Vector3.zero, 90f);
		}
	}

	public static void InitCameraLogic(WorldCameraContext context)
	{
		if (!context.hasCameraLogic)
		{
			context.SetCameraLogic(0, null);
		}
	}
}
