using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Scripts.Asset;
using Assets.Scripts.Utility;
using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Constant;
using Assets.Sources.Info.Career;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Info.WeaponAnim;
using SSJJAnim.Parser;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using Spine.Unity;
using UnityEngine;

namespace Assets.Sources.Utils.Weapon;

public class SkinUtility
{
	private const string KeySkinTexture = "SkinTexture";

	private const string KeySkinTextureFlash = "SkinTextureFlash";

	private const string KeyBaseSkinTexture = "BaseSkinTexture";

	private const string KeySkinQuenchTexture = "SkinQuenchTexture";

	private const string KeySkinQuenchAlphaTexture = "SkinQuenchAlphaTexture";

	private static readonly List<string> KeySkinTextureList = new List<string>();

	private static readonly List<string> KeyBaseSkinTextureList = new List<string>();

	private static LoggerAdapter _logger = new LoggerAdapter(typeof(SkinUtility));

	public static void AddViewModelRequest(LoadRequests loadRequests, IEntitsWeaponInfo weaponInfo, WeaponSkinInfo skinInfo)
	{
		if (skinInfo != null && skinInfo.HasEffect)
		{
			loadRequests.Add("WeaponModel", new LoadRequest(skinInfo.GetViewModelAsset(weaponInfo.Name), typeof(FirstPersonWeapon)));
		}
		else
		{
			loadRequests.Add("WeaponModel", new LoadRequest(new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.ViewWeaponAssetName, typeof(GameObject)), typeof(FirstPersonWeapon)));
		}
		if (skinInfo != null && skinInfo.HasEffect)
		{
			loadRequests.AddAsset("WeaponAnim", skinInfo.GetViewAnimAsset(weaponInfo.Name));
		}
		else
		{
			loadRequests.AddAsset("WeaponAnim", new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.ViewWeaponAnimationAssetName, typeof(SJAnimationAsset)));
		}
		AddTextureRequests(loadRequests, weaponInfo, skinInfo);
	}

	public static void AddViewHandRequest(LoadRequests loadRequests, IEntitsWeaponInfo weaponInfo, WeaponSkinInfo weaponSkinInfo, PlayerSkinInfo playerSkinInfo)
	{
		if (weaponSkinInfo != null && weaponSkinInfo.HasEffect)
		{
			loadRequests.AddAsset("HandAnim", weaponSkinInfo.GetHandAnimAsset(weaponInfo.Name));
			loadRequests.AddAsset("ViewAnimConfig", weaponSkinInfo.GetHandAnimConfigAsset(weaponInfo.Name));
		}
		else
		{
			loadRequests.AddAsset("HandAnim", new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.ViewHandAnimationAssetName, typeof(SJAnimationAsset)));
			loadRequests.AddAsset("ViewAnimConfig", new AssetInfo(weaponInfo.AnimConfigBundleName, weaponInfo.ViewAnimConfigAssetName, typeof(WeaponAnimAsset)));
		}
		if (playerSkinInfo != null && playerSkinInfo.HasViewHandModel)
		{
			loadRequests["HandModel"] = new LoadRequest(playerSkinInfo.ViewHandModelAsset, typeof(FirstPersonHand));
			loadRequests.Remove("NormalTexture");
		}
	}

	public static void AddSceneModelRequest(LoadRequests loadRequests, IWeaponInfo weaponInfo, WeaponSkinInfo skinInfo)
	{
		if (skinInfo != null && skinInfo.HasEffect)
		{
			loadRequests.Add("WeaponModel", new LoadRequest(skinInfo.GetSceneModelAsset(weaponInfo.Name), typeof(SceneWeaponGameObject)));
		}
		else
		{
			loadRequests.Add("WeaponModel", new LoadRequest(new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.SceneAssetName, typeof(GameObject)), typeof(SceneWeaponGameObject)));
		}
		AddTextureRequests(loadRequests, weaponInfo, skinInfo);
	}

	public static void AddTextureRequests(LoadRequests loadRequests, IEntitsWeaponInfo weaponInfo, WeaponSkinInfo weaponSkinInfo)
	{
		if (weaponSkinInfo != null && weaponSkinInfo.HasSkinTexture && !WeaponQueenSkinRtUtility.HasMadeRtList.Contains(weaponSkinInfo.Name))
		{
			KeySkinTextureList.Clear();
			foreach (string multipleStr in weaponSkinInfo.MultipleStrs)
			{
				KeySkinTextureList.Add("SkinTexture" + multipleStr);
			}
			for (int i = 0; i < KeySkinTextureList.Count; i++)
			{
				loadRequests.AddAsset(KeySkinTextureList[i], weaponSkinInfo.SkinTextureAssetList[i]);
			}
		}
		if (weaponSkinInfo != null && weaponSkinInfo.HasBaseTexture && !WeaponQueenSkinRtUtility.HasMadeRtList.Contains(weaponSkinInfo.Name))
		{
			KeyBaseSkinTextureList.Clear();
			foreach (string multipleStr2 in weaponSkinInfo.MultipleStrs)
			{
				KeyBaseSkinTextureList.Add("BaseSkinTexture" + multipleStr2);
			}
			for (int j = 0; j < KeyBaseSkinTextureList.Count; j++)
			{
				loadRequests.AddAsset(KeyBaseSkinTextureList[j], weaponSkinInfo.BaseTextureAssetList[j]);
			}
		}
		if (weaponSkinInfo != null && weaponSkinInfo.HasQuench)
		{
			loadRequests.AddAsset("SkinQuenchTexture", weaponSkinInfo.SkinQuenchTextureAsset);
			loadRequests.AddAsset("SkinQuenchAlphaTexture", weaponSkinInfo.SkinQuenchAlphaTextureAsset);
		}
		if (weaponSkinInfo != null && weaponSkinInfo.HasFlashTexture())
		{
			loadRequests.AddAsset("SkinTextureFlash", weaponSkinInfo.SkinFlashTextureAsset);
		}
	}

	public static float GetWeaponWornDegree(float serverWorn, string skinName)
	{
		float min = 0f;
		float max = 1f;
		if (!string.IsNullOrEmpty(skinName) && skinName.Equals("skin_mikaduki_sword_dkl"))
		{
			max = 0.5f;
		}
		return Mathf.Clamp(serverWorn / 1000000f, min, max);
	}

	public static float GetWeaponQuenchX(int quenchId)
	{
		return Mathf.Clamp((float)(quenchId % 16) / 16f * 0.5f, 0f, 0.5f);
	}

	public static float GetWeaponQuenchY(int quenchId)
	{
		return Mathf.Clamp((float)(quenchId / 16) / 16f * 0.5f, 0f, 0.5f);
	}

	private static List<Texture2D> GetSkinTexture(LoadResults loadResults, List<string> keyList)
	{
		List<Texture2D> list = new List<Texture2D>();
		foreach (string key in keyList)
		{
			Texture2D item = loadResults[key].Object as Texture2D;
			list.Add(item);
		}
		return list;
	}

	private static Texture2D GetMatchSkinTexture(List<Texture2D> skinTextures, string originTextureName)
	{
		if (string.IsNullOrEmpty(originTextureName))
		{
			return skinTextures[0];
		}
		foreach (Texture2D skinTexture in skinTextures)
		{
			if (skinTexture != null && skinTexture.name.Equals(originTextureName))
			{
				return skinTexture;
			}
			if (skinTexture != null && skinTexture.name.Equals(originTextureName + "_base"))
			{
				return skinTexture;
			}
		}
		return skinTextures[0];
	}

	private static bool NotSetThird(WeaponSkinInfo skinInfo)
	{
		if (skinInfo != null && skinInfo.Name.Equals("skin_carbon_fiber_m4"))
		{
			return true;
		}
		return false;
	}

	public static bool InitSkin(ref GameObject weaponObj, LoadResults loadResults, float serverWorn, int quenchId, WeaponSkinInfo skinInfo = null)
	{
		string text = null;
		if (skinInfo != null)
		{
			text = skinInfo.Name;
		}
		bool flag = false;
		bool flag2 = false;
		if (KeySkinTextureList.Count > 0)
		{
			flag = loadResults.ContainsKey(KeySkinTextureList[0]);
		}
		if (KeyBaseSkinTextureList.Count > 0)
		{
			flag2 = loadResults.ContainsKey(KeyBaseSkinTextureList[0]);
		}
		if (skinInfo != null && WeaponQueenSkinRtUtility.HasMadeRtList.Contains(skinInfo.Name))
		{
			flag2 = (flag = true);
		}
		bool flag3 = loadResults.ContainsKey("SkinQuenchTexture");
		bool flag4 = loadResults.ContainsKey("SkinTextureFlash");
		if (flag)
		{
			List<Texture2D> skinTexture = GetSkinTexture(loadResults, KeySkinTextureList);
			WeaponGameObject component = weaponObj.GetComponent<WeaponGameObject>();
			if (component == null)
			{
				return false;
			}
			TextureList component2 = component.GetComponent<TextureList>();
			if (flag2)
			{
				List<Texture2D> skinTexture2 = GetSkinTexture(loadResults, KeyBaseSkinTextureList);
				if (component2 != null && skinTexture2.Count > 0)
				{
					component2.SetSkinWeaponTextures(skinTexture2[0]);
				}
				foreach (Renderer skinRenderer in component.GetSkinRenderers())
				{
					if (!(skinRenderer.sharedMaterial != null))
					{
						continue;
					}
					if (skinRenderer.sharedMaterial.shader.name == "Standard")
					{
						WeaponQueenSkinRtMaker obj = skinRenderer.gameObject.GetComponent<WeaponQueenSkinRtMaker>() ?? skinRenderer.gameObject.AddComponent<WeaponQueenSkinRtMaker>();
						obj.Init((skinInfo != null) ? skinInfo.Name : "", component.DynamicSkinTexture, GetWeaponWornDegree(serverWorn, text), skinTexture, skinTexture2);
						obj.ResetSkin();
						continue;
					}
					for (int i = 0; i < skinRenderer.materials.Length; i++)
					{
						Material material = skinRenderer.materials[i];
						if (flag4)
						{
							if (!NotSetThird(skinInfo))
							{
								Texture2D mainTexture = loadResults["SkinTextureFlash"].Object as Texture2D;
								material.mainTexture = mainTexture;
							}
							continue;
						}
						string originTextureName = null;
						if (skinRenderer.sharedMaterial.mainTexture != null)
						{
							originTextureName = skinRenderer.sharedMaterial.mainTexture.name.Replace("_base", "");
						}
						if (material.shader.name == "SSJJ/UvHuxi" || material.shader.name == "SSJJ/UvHuxiWorn")
						{
							material.shader = Shader.Find("SSJJ/UvHuxiWorn");
						}
						else if (material.shader.name == "SSJJ/UvLiuGuang" || material.shader.name == "SSJJ/UvLiuGuangWorn")
						{
							material.shader = Shader.Find("SSJJ/UvLiuGuangWorn");
						}
						else
						{
							material.shader = Shader.Find("SSJJ/WeaponWear");
						}
						material.mainTexture = GetMatchSkinTexture(skinTexture2, originTextureName);
						material.SetTexture("_WearTex", GetMatchSkinTexture(skinTexture, originTextureName));
						material.SetFloat("_Degree", GetWeaponWornDegree(serverWorn, text));
					}
				}
			}
			else if (flag3)
			{
				Texture2D value = loadResults["SkinQuenchAlphaTexture"].Object as Texture2D;
				Texture2D value2 = loadResults["SkinQuenchTexture"].Object as Texture2D;
				if (component2 != null && skinTexture.Count > 0)
				{
					component2.SetSkinWeaponTextures(skinTexture[0]);
				}
				foreach (Renderer skinRenderer2 in component.GetSkinRenderers())
				{
					if (skinRenderer2.sharedMaterial != null)
					{
						Material material2 = skinRenderer2.sharedMaterial.CreateInstance();
						string originTextureName2 = null;
						if (skinRenderer2.sharedMaterial.mainTexture != null)
						{
							originTextureName2 = skinRenderer2.sharedMaterial.mainTexture.name;
						}
						material2.shader = Shader.Find("SSJJ/WeaponWearQuench");
						material2.SetTexture("_MainTex", GetMatchSkinTexture(skinTexture, originTextureName2));
						material2.SetTexture("_QuenchTex", value2);
						material2.SetTexture("_AlphaTex", value);
						material2.SetFloat("_SampleMiddleX", GetWeaponQuenchX(quenchId));
						material2.SetFloat("_SampleMiddleY", GetWeaponQuenchY(quenchId));
						if (skinInfo != null && skinInfo.QuenchParaList != null && skinInfo.QuenchParaList.Count == 3)
						{
							material2.SetVector("_LightColorDir", new Vector4(skinInfo.QuenchParaList[0], skinInfo.QuenchParaList[1], skinInfo.QuenchParaList[2], 0f));
						}
						skinRenderer2.material = material2;
					}
				}
			}
			else
			{
				if (component2 != null && skinTexture.Count > 0)
				{
					component2.SetSkinWeaponTextures(skinTexture[0]);
				}
				foreach (Renderer skinRenderer3 in component.GetSkinRenderers())
				{
					Material[] sharedMaterials = skinRenderer3.sharedMaterials;
					for (int j = 0; j < sharedMaterials.Length; j++)
					{
						Uvlive2DEffect component3 = skinRenderer3.GetComponent<Uvlive2DEffect>();
						SkeletonAnimation component4 = skinRenderer3.GetComponent<SkeletonAnimation>();
						if (component3 != null || component4 != null)
						{
							continue;
						}
						if (skinInfo != null)
						{
							string originTextureName3 = skinInfo.Name;
							if (skinRenderer3.sharedMaterials[j].mainTexture != null)
							{
								originTextureName3 = skinRenderer3.sharedMaterials[j].mainTexture.name;
							}
							else if (text.Equals("skin_phantom_smg_cq"))
							{
								originTextureName3 = skinRenderer3.sharedMaterials[j].name.Replace(" (Instance)", "");
							}
							if (!text.Equals("skin_fan_legend_seasons") && !text.Equals("skin_light_darkness_submachinegun_twiilight") && !text.Equals("skin_dragon_aura_fire"))
							{
								skinRenderer3.materials[j].mainTexture = GetMatchSkinTexture(skinTexture, originTextureName3);
							}
							if (flag4)
							{
								Texture2D mainTexture2 = loadResults["SkinTextureFlash"].Object as Texture2D;
								skinRenderer3.materials[j].mainTexture = mainTexture2;
							}
						}
						else if (skinRenderer3.sharedMaterials[j].mainTexture != null)
						{
							string originTextureName4 = null;
							if (skinRenderer3.sharedMaterials[j].mainTexture != null)
							{
								originTextureName4 = skinRenderer3.sharedMaterials[j].mainTexture.name;
							}
							skinRenderer3.materials[j].mainTexture = GetMatchSkinTexture(skinTexture, originTextureName4);
							if (flag4)
							{
								Texture2D mainTexture3 = loadResults["SkinTextureFlash"].Object as Texture2D;
								skinRenderer3.materials[j].mainTexture = mainTexture3;
							}
						}
					}
				}
			}
		}
		else if (flag4)
		{
			foreach (Renderer skinRenderer4 in weaponObj.GetComponent<WeaponGameObject>().GetSkinRenderers())
			{
				if (skinRenderer4.sharedMaterial != null)
				{
					Texture2D mainTexture4 = loadResults["SkinTextureFlash"].Object as Texture2D;
					skinRenderer4.sharedMaterial.mainTexture = mainTexture4;
				}
			}
		}
		return false;
	}

	public static void InitSkinSpecailWithLight(GameObject weaponObj, WeaponSkinInfo skinInfo)
	{
	}

	public static void InitDyeingMaterial(ref GameObject gameobj, Texture2D mask1, Texture2D mask2, string dyeingColors)
	{
		SkinnedMeshRenderer[] componentsInChildren = gameobj.GetComponentsInChildren<SkinnedMeshRenderer>();
		Material material = null;
		SkinnedMeshRenderer[] array = componentsInChildren;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
		{
			Material sharedMaterial = skinnedMeshRenderer.sharedMaterial;
			if (sharedMaterial == null || sharedMaterial.shader == null)
			{
				continue;
			}
			bool flag = sharedMaterial.shader.name == "SSJJ/Diffuse_Dyeing" || sharedMaterial.shader.name == "SSJJ/Diffuse_DyeingHuxi";
			if (!string.IsNullOrEmpty(dyeingColors) && !flag)
			{
				material = UnityEngine.Object.Instantiate(sharedMaterial);
				string text = ((sharedMaterial.shader.name == "SSJJ/UvHuxi") ? "SSJJ/Diffuse_DyeingHuxi" : "SSJJ/Diffuse_Dyeing");
				material.shader = Shader.Find(text);
				material.SetTexture("_MaskTex", mask1);
				material.SetTexture("_MaskTex2", mask2);
				string[] array2 = dyeingColors.Split(',');
				float a = ((mask1 != null) ? 1f : 0f);
				material.SetColor("_ColorR", getColor((array2.Length != 0) ? array2[0] : "#ffffff", a));
				material.SetColor("_ColorG", getColor((array2.Length > 1) ? array2[1] : "#ffffff", a));
				material.SetColor("_ColorB", getColor((array2.Length > 2) ? array2[2] : "#ffffff", a));
				material.SetColor("_ColorA", getColor((array2.Length > 3) ? array2[3] : "#ffffff", a));
				a = ((mask2 != null) ? 1f : 0f);
				material.SetColor("_ColorR2", getColor((array2.Length > 4) ? array2[4] : "#ffffff", a));
				material.SetColor("_ColorG2", getColor((array2.Length > 5) ? array2[5] : "#ffffff", a));
				material.SetColor("_ColorB2", getColor((array2.Length > 6) ? array2[6] : "#ffffff", a));
				material.SetColor("_ColorA2", getColor((array2.Length > 7) ? array2[7] : "#ffffff", a));
				if (text == "SSJJ/Diffuse_DyeingHuxi")
				{
					material.SetTexture("_HuxiTex", sharedMaterial.GetTexture("_HuxiTex"));
				}
				skinnedMeshRenderer.material = material;
			}
			else if (string.IsNullOrEmpty(dyeingColors) && flag)
			{
				skinnedMeshRenderer.material = skinnedMeshRenderer.sharedMaterial;
			}
		}
	}

	public static Color getColor(string colstr, float a)
	{
		if (colstr != "")
		{
			int num = Convert.ToInt32("0x" + colstr.Substring(1, 2), 16);
			int num2 = Convert.ToInt32("0x" + colstr.Substring(3, 2), 16);
			int num3 = Convert.ToInt32("0x" + colstr.Substring(5, 2), 16);
			float r = (float)num / 255f;
			float g = (float)num2 / 255f;
			float b = (float)num3 / 255f;
			if (a >= 1f && colstr.Length >= 9)
			{
				a = (float)Convert.ToInt32("0x" + colstr.Substring(7, 2), 16) / 255f;
			}
			return new Color(r, g, b, a);
		}
		return new Color(0f, 0f, 0f, 0f);
	}

	public static void AddBackModelRequest(LoadRequests loadRequests, IWeaponInfo weaponInfo, WeaponSkinInfo skinInfo)
	{
		if (skinInfo != null && skinInfo.HasEffect)
		{
			loadRequests.Add("model", new LoadRequest(skinInfo.GetSceneModelAsset(weaponInfo.Name), typeof(BackWeaponGameObject)));
		}
		else
		{
			loadRequests.Add("model", new LoadRequest(new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.SceneAssetName, typeof(GameObject)), typeof(BackWeaponGameObject)));
		}
		AddTextureRequests(loadRequests, weaponInfo, skinInfo);
	}

	public static void AddThirdModelRequest(LoadRequests loadRequests, IEntitsWeaponInfo weaponInfo, WeaponSkinInfo skinInfo)
	{
		if (skinInfo != null && skinInfo.HasEffect)
		{
			loadRequests.Add("WeaponModel", new LoadRequest(skinInfo.GetThirdModelAsset(weaponInfo.Name), typeof(ThirdPersonWeaponGameObject)));
		}
		else
		{
			loadRequests.Add("WeaponModel", new LoadRequest(new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.ThirdAssetName, typeof(GameObject), optional: true), typeof(ThirdPersonWeaponGameObject)));
		}
		AddTextureRequests(loadRequests, weaponInfo, skinInfo);
	}

	public static void AddWeaponBodyMask1Request(LoadRequests loadRequests, IEntitsWeaponInfo weaponInfo, WeaponSkinInfo skinInfo)
	{
		if (skinInfo != null && skinInfo.HasDyeingTexture)
		{
			loadRequests.Add("weapon_body_mask1", new LoadRequest(new AssetInfo(skinInfo.AssetBundleName, GetWeaponResourcePath(skinInfo.Name, "bodymask/body_mask1.png"), typeof(Texture), optional: true)));
		}
		else
		{
			loadRequests.Add("weapon_body_mask1", new LoadRequest(new AssetInfo(weaponInfo.AssetBundleName, GetWeaponResourcePath(weaponInfo.Name, "bodymask/body_mask1.png"), typeof(Texture), optional: true)));
		}
	}

	private static string GetWeaponResourcePath(string weapon, string resourceName)
	{
		return $"Assets/Res/Assets/weapon/{weapon}/{resourceName}";
	}

	public static void AddCareerModelRequest(LoadRequests loadRequests, ICareerInfo career, PlayerSkinInfo playerSkinInfo, PlayerEntity player)
	{
		if (RuleUtilty.EnableAvater())
		{
			string bundleName = "player/" + career.Name;
			string assetName = $"Assets/Res/Assets/player/{career.Name}/Prefabs/root.prefab";
			loadRequests.Add("CareerModel", new LoadRequest(new AssetInfo(bundleName, assetName), typeof(ThirdPersonCareerGameObject)));
			string moduleNames = player.basicInfo.Current.ModuleNames;
			if (!string.IsNullOrEmpty(moduleNames))
			{
				string[] array = moduleNames.Split(':');
				foreach (string text in array)
				{
					string assetName2 = $"Assets/Res/Assets/player/{career.Name}/Prefabs/{text}.prefab";
					loadRequests.Add(text, new LoadRequest(new AssetInfo(bundleName, assetName2)));
				}
			}
		}
		else if (!loadRequests.ContainsKey("CareerModel"))
		{
			if (playerSkinInfo != null && playerSkinInfo.HasThirdModel)
			{
				loadRequests.Add("CareerModel", new LoadRequest(playerSkinInfo.ThirdModelAsset, typeof(ThirdPersonCareerGameObject)));
			}
			else
			{
				loadRequests.Add("CareerModel", new LoadRequest(new AssetInfo(career.PrefabBundleName, career.PrefabAssetName, typeof(GameObject)), typeof(ThirdPersonCareerGameObject)));
			}
		}
		if (playerSkinInfo != null && playerSkinInfo.HasHitBox)
		{
			loadRequests.Add("HitBox", new LoadRequest(playerSkinInfo.HitBoxAsset, typeof(HitHelpInfo)));
		}
		else
		{
			loadRequests.AddAsset("HitBox", new AssetInfo(career.PrefabBundleName, career.HitboxAssetName, typeof(HitHelpInfo), optional: true));
		}
		if (player.hasDyeingColor)
		{
			player.dyeingColor.thirdDyeingColors = player.GetDyeingColors();
		}
		else
		{
			player.AddDyeingColor("", player.GetDyeingColors());
		}
		if (player.GetDyeingColors() != "")
		{
			if (playerSkinInfo != null && playerSkinInfo.HasDyeing)
			{
				loadRequests.Add("body_mask1", new LoadRequest(playerSkinInfo.bodyMask1Asset, typeof(Texture)));
				loadRequests.Add("body_mask2", new LoadRequest(playerSkinInfo.bodyMask2Asset, typeof(Texture)));
			}
			else
			{
				loadRequests.AddAsset("body_mask1", new AssetInfo(career.PrefabBundleName, career.bodyMask1AssetName, typeof(Texture), optional: true));
				loadRequests.AddAsset("body_mask2", new AssetInfo(career.PrefabBundleName, career.bodyMask2AssetName, typeof(Texture), optional: true));
			}
		}
		if (RuleUtilty.EnableAvater())
		{
			string moduleNames2 = player.basicInfo.Current.ModuleNames;
			if (!string.IsNullOrEmpty(moduleNames2))
			{
				string[] array = moduleNames2.Split(':');
				foreach (string text2 in array)
				{
					string assetName3 = $"Assets/Res/Assets/avatarplayer/{text2}/textureconfig.xml";
					loadRequests.Add(text2 + "_TextureConfig", new LoadRequest(new AssetInfo("avatarplayer/" + text2, assetName3, typeof(TextureConfigInfo), optional: true)));
				}
			}
		}
		else if (playerSkinInfo != null && playerSkinInfo.HasTextureConfig)
		{
			loadRequests.Add("TextureConfig", new LoadRequest(playerSkinInfo.TextureConfigAsset, typeof(TextureConfigInfo)));
		}
		else
		{
			loadRequests.AddAsset("TextureConfig", new AssetInfo(career.PrefabBundleName, career.TextureConfigAssetName, typeof(TextureConfigInfo), optional: true));
		}
	}
}
