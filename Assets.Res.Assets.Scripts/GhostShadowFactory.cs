using Assets.Sources.Components.Interface;
using SSJJBase.Pool;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class GhostShadowFactory
{
	public class GhostShadowAssembly
	{
		public GameObject Obj;

		public Mesh Mesh;

		public MeshRenderer MeshRenderer;

		public Material[] Materials;

		public GhostItem Item;

		public MaterialPropertyBlock Block;

		public GhostShadowAssembly(IPlayerEntity entity, SkinnedMeshRenderer goRender, Shader ghostShader)
		{
			Block = new MaterialPropertyBlock();
			Obj = new GameObject
			{
				hideFlags = HideFlags.HideAndDontSave
			};
			Mesh = new Mesh();
			Mesh.MarkDynamic();
			Obj.AddComponent<MeshFilter>().mesh = Mesh;
			MeshRenderer = Obj.AddComponent<MeshRenderer>();
			MeshRenderer.GetPropertyBlock(Block);
			Item = Obj.AddComponent<GhostItem>();
			Item.AssemblyData = this;
			Item.MeshRenderer = MeshRenderer;
		}

		public void Reset(SkinnedMeshRenderer goRender, Shader ghostShader)
		{
			Materials = new Material[goRender.materials.Length];
			for (int i = 0; i < goRender.materials.Length; i++)
			{
				Material material = Instance._ghostMatPool.GetOrNull();
				if (material == null)
				{
					material = Object.Instantiate(goRender.materials[i]);
					material.shader = ghostShader;
				}
				Materials[i] = material;
			}
			MeshRenderer.materials = Materials;
			Obj.SetObjectActive(isactive: true);
			Mesh.Clear(keepVertexLayout: false);
		}

		public void Collect()
		{
			Obj.SetObjectActive(isactive: false);
			Material[] materials = Materials;
			foreach (Material value in materials)
			{
				Instance._ghostMatPool.Add(value);
			}
		}
	}

	public static GhostShadowFactory Instance = new GhostShadowFactory();

	private readonly StackObjectPool<GhostShadowAssembly> _ghostAssemblyPool = new StackObjectPool<GhostShadowAssembly>();

	private readonly StackObjectPool<Material> _ghostMatPool = new StackObjectPool<Material>();

	public GhostShadowAssembly GetOrCreate(IPlayerEntity entity, SkinnedMeshRenderer goRender, Shader ghostShader)
	{
		GhostShadowAssembly ghostShadowAssembly = _ghostAssemblyPool.GetOrNull();
		if (ghostShadowAssembly == null)
		{
			ghostShadowAssembly = new GhostShadowAssembly(entity, goRender, ghostShader);
		}
		ghostShadowAssembly.Reset(goRender, ghostShader);
		return ghostShadowAssembly;
	}

	public void Release(GhostShadowAssembly assembly)
	{
		assembly.Collect();
		_ghostAssemblyPool.Add(assembly);
	}
}
