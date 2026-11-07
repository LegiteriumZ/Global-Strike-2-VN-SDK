using System.Collections.Generic;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class WeaponAlphaShadow : MonoBehaviour
{
	public int maxCount = 1;

	public float ShowTime = 99f;

	public float Interval = 100f;

	public float _time;

	private Shader _weaponAlphaShader;

	public Texture MainTexture;

	public Color Color;

	public List<WeaponAlphaShadowItem> list;

	private PlayerEntity myPlayerEntity;

	private SkinnedMeshRenderer[] _skinnedMeshRenderers;

	private void Awake()
	{
		_weaponAlphaShader = Shader.Find("SSJJ/Diffuse");
		list = new List<WeaponAlphaShadowItem>();
		_skinnedMeshRenderers = GetComponents<SkinnedMeshRenderer>();
		MainTexture = _skinnedMeshRenderers[0].material.mainTexture;
	}

	private void Start()
	{
		myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
	}

	public void Update()
	{
		if (myPlayerEntity.currentWeapon.Name == "bone_wild_rifle")
		{
			SkinnedMeshRenderer[] skinnedMeshRenderers = _skinnedMeshRenderers;
			foreach (SkinnedMeshRenderer meshRender in skinnedMeshRenderers)
			{
				Render(meshRender, myPlayerEntity);
			}
		}
		else
		{
			for (int j = 0; j < list.Count; j++)
			{
				list[j].Interval = 0f;
			}
		}
	}

	public void Render(SkinnedMeshRenderer meshRender, PlayerEntity entity)
	{
		_time += Time.deltaTime;
		if (_time < Interval)
		{
			return;
		}
		_time = 0f;
		if (list.Count >= maxCount)
		{
			list[0].Interval = 0f;
		}
		if (meshRender == null || (entity.hasVisiable && !entity.visiable.IsVisiable && !entity.visiable.IsNear))
		{
			return;
		}
		WeaponAlphaShadowFactory.WeaponAlphaShadowAssembly orCreate = WeaponAlphaShadowFactory.Instance.GetOrCreate(entity, meshRender, _weaponAlphaShader);
		if (orCreate != null)
		{
			orCreate.Item.InitData(this, ShowTime, Color, orCreate.MeshRenderer, orCreate, entity);
			for (int i = 0; i < orCreate.Materials.Length; i++)
			{
				orCreate.Materials[i].mainTexture = null;
				orCreate.Block.SetColor("_Color", Color);
				orCreate.MeshRenderer.SetPropertyBlock(orCreate.Block);
			}
			meshRender.BakeMesh(orCreate.Mesh);
			orCreate.Obj.transform.localScale = new Vector3(1f / meshRender.transform.lossyScale.x, 1f / meshRender.transform.lossyScale.y, 1f / meshRender.transform.lossyScale.z);
			orCreate.Obj.transform.position = meshRender.transform.position;
			orCreate.Obj.transform.rotation = meshRender.transform.rotation;
			orCreate.Obj.transform.SetParent(meshRender.transform.parent, worldPositionStays: false);
			orCreate.Obj.layer = LayerMask.NameToLayer("FPSArmWeapon");
			list.Add(orCreate.Item);
		}
	}

	public void Release(WeaponAlphaShadowFactory.WeaponAlphaShadowAssembly weaponAlphaShadowAssembly)
	{
		if (weaponAlphaShadowAssembly != null)
		{
			WeaponAlphaShadowFactory.Instance.Release(weaponAlphaShadowAssembly);
		}
	}
}
