using UnityEngine;

namespace Assets.Sources.Utils;

public static class SSJJCoordinate
{
	private static GameObject _root;

	public static GameObject Root
	{
		get
		{
			if (_root == null)
			{
				_root = new GameObject(typeof(SSJJCoordinate).Name);
				Object.DontDestroyOnLoad(_root);
				_root.transform.localScale = Vector3.one * 0.01f;
			}
			return _root;
		}
	}

	public static void Add(GameObject obj)
	{
		obj.transform.SetParent(Root.transform, worldPositionStays: false);
	}
}
