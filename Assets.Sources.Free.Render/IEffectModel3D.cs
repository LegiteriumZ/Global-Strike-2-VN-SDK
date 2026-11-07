using UnityEngine;

namespace Assets.Sources.Free.Render;

public interface IEffectModel3D
{
	IObject3D Model3D { get; }

	GameObject GameObject { get; }

	Renderer MeshRender { get; set; }

	Material Material { get; set; }

	float Alpha { get; set; }

	string ResUrl { get; set; }

	string ModelName { get; set; }

	string TextureName { get; set; }

	int GeometryType { get; set; }

	int DepthMode { get; set; }

	int Culling { get; set; }

	string ShaderName { get; set; }

	void Frame(ref FrameParams data);

	void Destory();
}
