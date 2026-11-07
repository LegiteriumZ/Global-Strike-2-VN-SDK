using UnityEngine;

namespace Assets.Sources.Free.Render;

public interface IUiObject
{
	int Width { get; set; }

	int Height { get; set; }

	bool ActiveVisible { get; set; }

	bool InHierarchyVisible { get; }

	float PosX { get; set; }

	float PosY { get; set; }

	float Alpha { get; set; }

	float ScaleX { get; set; }

	float ScaleY { get; set; }

	float Rotation { get; set; }

	Vector2 Anchor { get; set; }

	GameObject GameObject { get; set; }

	Transform Parent { get; set; }

	string GetParentPath();

	void AddChild(IUiObject child);

	T FindComponentInChildren<T>() where T : MonoBehaviour;

	T GetComponent<T>() where T : MonoBehaviour;

	void ResetData();
}
