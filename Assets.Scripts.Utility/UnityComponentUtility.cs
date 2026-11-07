using UnityEngine;

namespace Assets.Scripts.Utility;

public static class UnityComponentUtility
{
	public static void RemoveAllComponents<T>(GameObject go) where T : Object
	{
		T[] componentsInChildren = go.GetComponentsInChildren<T>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Object.DestroyImmediate(componentsInChildren[i]);
		}
	}
}
