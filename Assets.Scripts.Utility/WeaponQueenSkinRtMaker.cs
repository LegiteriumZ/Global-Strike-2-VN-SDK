using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utility;

public class WeaponQueenSkinRtMaker : MonoBehaviour
{
	public List<RenderTexture> DynamicSkinTexture;

	public float Worn;

	public List<Texture2D> SkinTexture;

	public List<Texture2D> BaseTexture;

	public List<Texture2D> FinalTexture;

	public string WeaponSkinName;

	private bool _isInit;

	private void Start()
	{
	}

	private void OnApplicationFocus(bool isFocus)
	{
		if (isFocus)
		{
			ResetSkin();
		}
	}

	public void Init(string weaponSkinName, List<RenderTexture> dynamicSkinTexture, float worn, List<Texture2D> skinTexture2D, List<Texture2D> baseTexture2D)
	{
		if (!_isInit)
		{
			_isInit = true;
			DynamicSkinTexture = dynamicSkinTexture;
			Worn = worn;
			SkinTexture = skinTexture2D;
			BaseTexture = baseTexture2D;
			WeaponSkinName = weaponSkinName;
		}
	}

	public void ResetSkin()
	{
		if (FinalTexture == null)
		{
			DynamicSkinTexture = new List<RenderTexture>();
			FinalTexture = new List<Texture2D>();
			for (int i = 0; i < SkinTexture.Count; i++)
			{
				DynamicSkinTexture.Add(new RenderTexture(SkinTexture[i].width, SkinTexture[i].height, 0, RenderTextureFormat.Default));
				Material material = new Material(Shader.Find("SSJJ/WeaponWear"));
				material.SetTexture("_WearTex", SkinTexture[i]);
				material.SetFloat("_Degree", Worn);
				Graphics.Blit(BaseTexture[i], DynamicSkinTexture[i], material);
				FinalTexture.Add(new Texture2D(SkinTexture[i].width, SkinTexture[i].height, TextureFormat.RGBA32, mipChain: false));
				RenderTexture.active = DynamicSkinTexture[i];
				FinalTexture[i].ReadPixels(new Rect(0f, 0f, FinalTexture[i].width, FinalTexture[i].height), 0, 0);
				FinalTexture[i].name = SkinTexture[i].name;
				FinalTexture[i].Apply();
			}
			RenderTexture.active = null;
			if (DynamicSkinTexture != null)
			{
				for (int j = 0; j < DynamicSkinTexture.Count; j++)
				{
					DynamicSkinTexture[j].Release();
				}
				DynamicSkinTexture = null;
			}
			SkinTexture = null;
			BaseTexture = null;
			WeaponQueenSkinRtUtility.HasMadeRtList.Add(WeaponSkinName);
		}
		Renderer component = base.transform.GetComponent<Renderer>();
		for (int k = 0; k < component.materials.Length; k++)
		{
			bool flag = false;
			for (int l = 0; l < FinalTexture.Count; l++)
			{
				if (component.materials[k].name.Replace("(Instance)", "").Trim().Equals(FinalTexture[l].name))
				{
					flag = true;
					component.materials[k].mainTexture = FinalTexture[l];
					break;
				}
			}
			if (!flag && FinalTexture.Count > 0)
			{
				component.materials[k].mainTexture = FinalTexture[0];
			}
		}
	}
}
