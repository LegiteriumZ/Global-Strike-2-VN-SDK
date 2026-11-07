using Assets.Sources.Components.Interface;
using SSJJBase.Pool;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class PlayerAlphaShadowFactory
{
	public class PlayerAlphaShadowAssembly
	{
		public GameObject Obj;

		public Mesh Mesh;

		public MeshRenderer MeshRenderer;

		public Material[] Materials;

		public MaterialPropertyBlock Block;

		public PlayerAlphaShadowItem Item;

		public PlayerAlphaShadowAssembly(IPlayerEntity entity, SkinnedMeshRenderer goRender, Shader ghostShader)
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
			Item = Obj.AddComponent<PlayerAlphaShadowItem>();
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
				material.renderQueue = 2301;
				Materials[i] = material;
			}
			MeshRenderer.materials = Materials;
			Obj.SetObjectActive(isactive: true);
			Mesh.Clear(keepVertexLayout: false);
		}

		public void Collect()
		{
			Obj.SetObjectActive(isactive: false);
			Item.Stop();
			Material[] materials = Materials;
			foreach (Material value in materials)
			{
				Instance._ghostMatPool.Add(value);
			}
		}
	}

	public static PlayerAlphaShadowFactory Instance = new PlayerAlphaShadowFactory();

	private readonly StackObjectPool<PlayerAlphaShadowAssembly> _playerAlphaAssemblyPool = new StackObjectPool<PlayerAlphaShadowAssembly>();

	private readonly StackObjectPool<Material> _ghostMatPool = new StackObjectPool<Material>();

	public PlayerAlphaShadowAssembly GetOrCreate(IPlayerEntity entity, SkinnedMeshRenderer goRender, Shader ghostShader)
	{
		PlayerAlphaShadowAssembly playerAlphaShadowAssembly = _playerAlphaAssemblyPool.GetOrNull();
		if (playerAlphaShadowAssembly == null)
		{
			playerAlphaShadowAssembly = new PlayerAlphaShadowAssembly(entity, goRender, ghostShader);
		}
		playerAlphaShadowAssembly.Reset(goRender, ghostShader);
		return playerAlphaShadowAssembly;
	}

	public void Release(PlayerAlphaShadowAssembly assembly)
	{
		assembly.Collect();
		_playerAlphaAssemblyPool.Add(assembly);
	}
}
