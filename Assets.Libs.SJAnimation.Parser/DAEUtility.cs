using Assets.Sources.Constant;
using UnityEngine;

namespace Assets.Libs.SJAnimation.Parser;

public class DAEUtility
{
	public static void FixImportRotation(GameObject obj)
	{
		if (!RuleUtilty.EnableAvater())
		{
			Transform[] array = new Transform[obj.transform.childCount];
			for (int i = 0; i < obj.transform.childCount; i++)
			{
				array[i] = obj.transform.GetChild(i);
			}
			foreach (Transform transform in array)
			{
				GameObject gameObject = new GameObject("fix_" + transform.name);
				gameObject.transform.parent = transform.parent;
				gameObject.transform.localRotation = Quaternion.Euler(90f * Vector3.left);
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localScale = transform.localScale;
				transform.parent = gameObject.transform;
			}
		}
	}
}
