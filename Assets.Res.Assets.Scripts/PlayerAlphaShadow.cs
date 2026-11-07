using System.Collections.Generic;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class PlayerAlphaShadow : MonoBehaviour
{
	public float Interval = 0.2f;

	private Shader _playerAlphaShader;

	public Texture MainTexture;

	public Color Color;

	public List<PlayerAlphaShadowItem> list;

	private Transform headJion;

	private void Awake()
	{
		_playerAlphaShader = Shader.Find("SSJJ/Diffuse");
		list = new List<PlayerAlphaShadowItem>();
	}

	public void Render(SkinnedMeshRenderer meshRender, PlayerEntity entity)
	{
		if (meshRender == null || !meshRender.isVisible || (entity.hasVisiable && !entity.visiable.IsVisiable && !entity.visiable.IsNear))
		{
			return;
		}
		PlayerAlphaShadowFactory.PlayerAlphaShadowAssembly orCreate = PlayerAlphaShadowFactory.Instance.GetOrCreate(entity, meshRender, _playerAlphaShader);
		if (orCreate == null)
		{
			return;
		}
		orCreate.Item.InitData(this, Interval, Color, orCreate.MeshRenderer, orCreate, entity);
		for (int i = 0; i < orCreate.Materials.Length; i++)
		{
			if (MainTexture != null)
			{
				orCreate.Block.SetTexture("_MainTex", MainTexture);
			}
			orCreate.Block.SetColor("_Color", Color);
			orCreate.MeshRenderer.SetPropertyBlock(orCreate.Block);
		}
		if (entity.hasThirdPersonUnityObjects && entity.thirdPersonUnityObjects.ThirdTran.HeadSize < 0.999f && headJion == null)
		{
			for (int j = 0; j < meshRender.bones.Length; j++)
			{
				if (meshRender.bones[j].name == "Bip01_Head")
				{
					headJion = meshRender.bones[j];
				}
			}
		}
		if (headJion != null)
		{
			headJion.transform.localScale = Vector3.one;
			meshRender.BakeMesh(orCreate.Mesh);
			headJion.transform.localScale = Vector3.one * entity.thirdPersonUnityObjects.ThirdTran.HeadSize;
		}
		else
		{
			meshRender.BakeMesh(orCreate.Mesh);
		}
		orCreate.Obj.transform.localScale = meshRender.transform.localScale;
		orCreate.Obj.transform.position = meshRender.transform.position;
		orCreate.Obj.transform.rotation = meshRender.transform.rotation;
		list.Add(orCreate.Item);
	}

	public void Release(PlayerAlphaShadowFactory.PlayerAlphaShadowAssembly playerAlphaShadowAssembly)
	{
		if (playerAlphaShadowAssembly != null)
		{
			PlayerAlphaShadowFactory.Instance.Release(playerAlphaShadowAssembly);
		}
	}
}
