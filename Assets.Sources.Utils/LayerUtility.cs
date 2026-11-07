using UnityEngine;

namespace Assets.Sources.Utils;

public class LayerUtility
{
	public static void SetLayerRecursively(GameObject obj, int layerMask)
	{
		obj.layer = layerMask;
		int childCount = obj.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			SetLayerRecursively(obj.transform.GetChild(i).gameObject, layerMask);
		}
	}
}
