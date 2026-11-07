using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Sources.Utils;

public class PerformanceManager
{
	public static void OptimizeSkinedMesh(GameObject weaponObject)
	{
		if (weaponObject != null)
		{
			SkinnedMeshRenderer[] componentsInChildren = weaponObject.GetComponentsInChildren<SkinnedMeshRenderer>();
			foreach (SkinnedMeshRenderer obj in componentsInChildren)
			{
				obj.receiveShadows = false;
				obj.lightProbeUsage = LightProbeUsage.Off;
				obj.reflectionProbeUsage = ReflectionProbeUsage.Off;
				obj.shadowCastingMode = ShadowCastingMode.Off;
			}
		}
	}
}
