using UnityEngine;

namespace Assets.Sources.Free.Render;

public interface IObject3D
{
	float PosX { get; set; }

	float PosY { get; set; }

	float PosZ { get; set; }

	float ScaleX { get; set; }

	float ScaleY { get; set; }

	float ScaleZ { get; set; }

	float RotationX { get; set; }

	float RotationY { get; set; }

	float RotationZ { get; set; }

	float Alpha { get; set; }

	bool Visible { get; set; }

	GameObject GameObject { get; }

	void Destory();

	void AddChild(IObject3D child);
}
