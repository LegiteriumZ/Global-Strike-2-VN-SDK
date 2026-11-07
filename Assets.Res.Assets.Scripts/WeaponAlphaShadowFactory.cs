using Assets.Sources.Components.Interface;
using SSJJBase.Pool;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class WeaponAlphaShadowFactory
{
	public class WeaponAlphaShadowAssembly
	{
		public GameObject Obj;

		public Mesh Mesh;

		public MeshRenderer MeshRenderer;

		public Material[] Materials;

		public MaterialPropertyBlock Block;

		public WeaponAlphaShadowItem Item;

		public WeaponAlphaShadowAssembly(IPlayerEntity entity, SkinnedMeshRenderer goRender, Shader ghostShader)
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
			Item = Obj.AddComponent<WeaponAlphaShadowItem>();
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
				}
				material.renderQueue = 3300;
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

	public static WeaponAlphaShadowFactory Instance = new WeaponAlphaShadowFactory();

	private readonly StackObjectPool<WeaponAlphaShadowAssembly> _weaponAlphaAssemblyPool = new StackObjectPool<WeaponAlphaShadowAssembly>();

	private readonly StackObjectPool<Material> _ghostMatPool = new StackObjectPool<Material>();

	public WeaponAlphaShadowAssembly GetOrCreate(IPlayerEntity entity, SkinnedMeshRenderer goRender, Shader ghostShader)
	{
		WeaponAlphaShadowAssembly weaponAlphaShadowAssembly = _weaponAlphaAssemblyPool.GetOrNull();
		if (weaponAlphaShadowAssembly == null)
		{
			weaponAlphaShadowAssembly = new WeaponAlphaShadowAssembly(entity, goRender, ghostShader);
		}
		weaponAlphaShadowAssembly.Reset(goRender, ghostShader);
		return weaponAlphaShadowAssembly;
	}

	public void Release(WeaponAlphaShadowAssembly assembly)
	{
		assembly.Collect();
		_weaponAlphaAssemblyPool.Add(assembly);
	}
}
