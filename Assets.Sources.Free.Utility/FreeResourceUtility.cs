using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Assets.RUI;
using Assets.Sources.Free.Data;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.UI;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Assets.Sources.Utils.AssetManager;
using Assets.Sources.Utils.Ui;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Assets.Sources.Free.Utility;

public class FreeResourceUtility
{
	public class SpriteRef
	{
		public int Width;

		public int Height;

		public string ResPath;

		public bool CheckisSame(int width, int height, string resPath)
		{
			if (Width == width && Height == height)
			{
				return resPath.Equals(ResPath);
			}
			return false;
		}
	}

	private static readonly LoggerAdapter Logger = new LoggerAdapter(typeof(FreeResourceUtility));

	private static Dictionary<SpriteRef, Sprite> SpriteDirs = new Dictionary<SpriteRef, Sprite>();

	private static readonly string[] EffectMatchUrlStr = new string[6] { "common", "halfLoadedRes", "noload", "pvecommon", "halfloadeffect", "spary" };

	public static IEnumerator LoadButtonSprite(Action<Sprite, string> callback, string imageUrl, string componentName = null, float width = 0f, float height = 0f)
	{
		AssetInfo assetPath = GetUiAssetPath(imageUrl, componentName);
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(assetPath, BaseAsyncManager.Instance);
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetPath))
		{
			yield return null;
		}
		object orNull = SingletonInstance<AssetPool>.Instance.GetOrNull(assetPath);
		if (orNull == null)
		{
			Logger.ErrorFormat("failed to load image {0}", assetPath);
			yield break;
		}
		Sprite sprite = null;
		if (orNull is Texture2D)
		{
			Texture2D texture2D = orNull as Texture2D;
			if (Mathf.Approximately(width, 0f))
			{
				width = texture2D.width;
			}
			if (Mathf.Approximately(height, 0f))
			{
				height = texture2D.height;
			}
			float num = (float)texture2D.height - height;
			sprite = Sprite.Create(texture2D, new Rect(0f, num, (width > (float)texture2D.width) ? ((float)texture2D.width) : width, (num + height > (float)texture2D.height) ? ((float)texture2D.height - num) : height), new Vector2(0f, 1f), 100f, 0u, SpriteMeshType.FullRect);
		}
		else if (orNull is Sprite)
		{
			sprite = orNull as Sprite;
		}
		if (sprite != null)
		{
			callback(sprite, imageUrl);
		}
	}

	public static bool CheckSetImage(FreeBaseImage image, AssetInfo assetPath, FreeImageComponent.ImageComponentData componentData)
	{
		if (SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetPath))
		{
			SetImage(assetPath, image, componentData);
			return true;
		}
		return false;
	}

	private static void SetImage(AssetInfo assetPath, FreeBaseImage image, FreeImageComponent.ImageComponentData componentData)
	{
		object orNull = SingletonInstance<AssetPool>.Instance.GetOrNull(assetPath);
		if (orNull == null)
		{
			Logger.ErrorFormat("failed to load image {0}", assetPath);
		}
		else
		{
			if (image == null)
			{
				return;
			}
			if (orNull is Texture2D)
			{
				Texture2D texture2D = orNull as Texture2D;
				if (componentData.ImageWidth == 0)
				{
					componentData.ImageWidth = texture2D.width;
				}
				if (componentData.ImageHeight == 0)
				{
					componentData.ImageHeight = texture2D.height;
				}
				image.SetOpacityUvOnce((float)componentData.ImageWidth / (float)texture2D.width, (float)componentData.ImageHeight / (float)texture2D.height);
				Sprite sprite = null;
				foreach (KeyValuePair<SpriteRef, Sprite> spriteDir in SpriteDirs)
				{
					if (spriteDir.Key.CheckisSame(componentData.ImageWidth, componentData.ImageHeight, assetPath.AssetName.Info))
					{
						sprite = spriteDir.Value;
					}
				}
				if (sprite == null)
				{
					sprite = Sprite.Create(texture2D, image.GetTextureRect(texture2D), new Vector2(0f, 1f), 100f, 0u, SpriteMeshType.FullRect);
					SpriteRef spriteRef = new SpriteRef();
					spriteRef.Height = componentData.ImageHeight;
					spriteRef.Width = componentData.ImageWidth;
					spriteRef.ResPath = assetPath.AssetName.Info;
					SpriteDirs.Add(spriteRef, sprite);
				}
				image.SpriteDirs[assetPath.AssetName] = sprite;
				image.SetSpriteForTexture(assetPath.AssetName, componentData);
				image.SetOriginUv(texture2D.width, texture2D.height, componentData);
			}
			else if (orNull is Sprite)
			{
				Sprite sprite2 = orNull as Sprite;
				if (componentData.ImageWidth == 0)
				{
					componentData.ImageWidth = (int)sprite2.rect.width;
				}
				if (componentData.ImageHeight == 0)
				{
					componentData.ImageHeight = (int)sprite2.rect.height;
				}
				image.sprite = sprite2;
				image.rectTransform.anchorMax = image.rectTransform.anchorMin;
				image.SetOriginUv(image.rectTransform.sizeDelta.x, image.rectTransform.sizeDelta.y, componentData);
			}
		}
	}

	public static IEnumerator LoadTexture2D(AssetInfo assetPath, Action<Texture2D> callback)
	{
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(assetPath, BaseAsyncManager.Instance);
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetPath))
		{
			yield return null;
		}
		object orNull = SingletonInstance<AssetPool>.Instance.GetOrNull(assetPath);
		if (orNull is Texture2D)
		{
			callback(orNull as Texture2D);
		}
	}

	public static IEnumerator LoadImage(FreeBaseImage image, AssetInfo assetPath, FreeImageComponent.ImageComponentData componentData = null)
	{
		if (componentData == null)
		{
			componentData = new FreeImageComponent.ImageComponentData();
		}
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(assetPath, BaseAsyncManager.Instance);
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetPath))
		{
			yield return null;
		}
		SetImage(assetPath, image, componentData);
	}

	public static IEnumerator LoadNumberFont(Text text, int fontIndex)
	{
		string bundleName = "number";
		string assetName = fontIndex.ToString();
		AssetInfo assetPath = new AssetInfo(bundleName, assetName);
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(assetPath, BaseAsyncManager.Instance);
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetPath))
		{
			yield return null;
		}
		object orNull = SingletonInstance<AssetPool>.Instance.GetOrNull(assetPath);
		if (orNull == null)
		{
			Logger.ErrorFormat("failed to load font {0}", assetPath);
		}
		else if (!(text == null))
		{
			text.font = orNull as Font;
		}
	}

	public static IEnumerator LoadEffectModel(IEffectModel3D effect, string modelUrl, Action action, bool createmat = true)
	{
		if (!string.IsNullOrEmpty(modelUrl))
		{
			AssetInfo assetPath = GetEffectAssetPath(modelUrl);
			SingletonInstance<AssetPool>.Instance.LoadAndAdd(assetPath, BaseAsyncManager.Instance);
			while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetPath))
			{
				yield return null;
			}
			action?.Invoke();
			object orNull = SingletonInstance<AssetPool>.Instance.GetOrNull(assetPath);
			if (orNull == null)
			{
				Logger.ErrorFormat("failed to load effect model {0}", assetPath);
				yield break;
			}
			if (effect.GameObject == null)
			{
				yield break;
			}
			GameObject gameObject = (orNull as GameObject).CreateInstance();
			gameObject.transform.parent = effect.GameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			MeshRenderer componentInChildren = gameObject.GetComponentInChildren<MeshRenderer>();
			componentInChildren.shadowCastingMode = ShadowCastingMode.Off;
			effect.MeshRender = componentInChildren;
		}
		else
		{
			action?.Invoke();
			GameObject gameObject2 = effect.GameObject;
			GameObject gameObject3 = new GameObject("Sprite");
			gameObject3.transform.parent = gameObject2.transform;
			gameObject3.transform.localPosition = Vector3.zero;
			gameObject3.transform.localScale = new Vector3(1f, -1f, 1f);
			gameObject3.transform.localEulerAngles = new Vector3(90f, 270f, 0f);
			SpriteRenderer meshRender = gameObject3.AddComponent<SpriteRenderer>();
			effect.MeshRender = meshRender;
		}
		Material material = null;
		if (createmat || (effect.MeshRender != null && effect.MeshRender.sharedMaterial == null))
		{
			material = new Material(Shader.Find("SSJJ/Diffuse"));
		}
		else if (effect.MeshRender != null)
		{
			material = effect.MeshRender.sharedMaterial;
		}
		if ((bool)material)
		{
			if (effect.DepthMode == 0 || effect.DepthMode == 1)
			{
				material.SetInt("_ZTest", 4);
			}
			else
			{
				material.SetInt("_ZTest", 8);
			}
			if (effect.DepthMode == 0 || effect.DepthMode == 2)
			{
				material.SetInt("_ZWrite", 1);
			}
			else
			{
				material.SetInt("_ZWrite", 0);
			}
			material.SetInt("_Cull", effect.Culling);
			material.mainTexture = TextureUtility.GetTransparentTexture();
			material.renderQueue = 3001;
			effect.Material = material;
		}
	}

	public static IEnumerator LoadEffectTexture(IEffectModel3D effect, string imageUrl, FreeEffectLoadModel effectLoadModel, string propertyname = "_MainTex")
	{
		if (FreeBaseComponent.IsNullString(imageUrl))
		{
			yield break;
		}
		while (effectLoadModel != null && !effectLoadModel.IsModelLoadOk)
		{
			yield return null;
		}
		AssetInfo assetPath = GetEffectAssetPath(imageUrl);
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(assetPath, BaseAsyncManager.Instance);
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetPath))
		{
			yield return null;
		}
		Texture2D texture2D = SingletonInstance<AssetPool>.Instance.GetOrNull(assetPath) as Texture2D;
		if (texture2D == null)
		{
			Logger.ErrorFormat("Failed to load free effect texture {0} ", assetPath);
		}
		else
		{
			if (effect.MeshRender == null)
			{
				yield break;
			}
			if (effect.MeshRender is SpriteRenderer)
			{
				int width = texture2D.width;
				int height = texture2D.height;
				(effect.MeshRender as SpriteRenderer).sprite = Sprite.Create(texture2D, new Rect(0f, 0f, width, height), new Vector2(0.5f, 0.5f), 100f, 0u, SpriteMeshType.FullRect);
				if (width > height)
				{
					Vector3 localScale = effect.MeshRender.transform.localScale;
					localScale.x = (float)height / (float)width;
					effect.MeshRender.transform.localScale = localScale;
				}
				else
				{
					Vector3 localScale2 = effect.MeshRender.transform.localScale;
					localScale2.y = 0f - (float)width / (float)height;
					effect.MeshRender.transform.localScale = localScale2;
				}
			}
			else
			{
				effect.Material.SetTexture(propertyname, texture2D);
			}
		}
	}

	public static IEnumerator LoadParticle(IEffectModel3D effect, string url, float scaleX)
	{
		AssetInfo assetPath = GetParticleAssetPath(url);
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(assetPath, BaseAsyncManager.Instance);
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetPath))
		{
			yield return null;
		}
		object orNull = SingletonInstance<AssetPool>.Instance.GetOrNull(assetPath);
		if (orNull == null)
		{
			Logger.ErrorFormat("failed to load particle {0}", assetPath);
		}
		else
		{
			if (effect.GameObject == null)
			{
				yield break;
			}
			GameObject gameObject = (orNull as GameObject).CreateInstance();
			gameObject.transform.parent = effect.GameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			gameObject.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
			Component[] componentsInChildren = gameObject.GetComponentsInChildren<Component>(includeInactive: true);
			foreach (Component component in componentsInChildren)
			{
				if (!(component == null))
				{
					component.gameObject.layer = gameObject.layer;
					if (component is ParticleSystem)
					{
						ParticleSystem.MainModule main = (component as ParticleSystem).main;
						main.scalingMode = ParticleSystemScalingMode.Hierarchy;
					}
				}
			}
		}
	}

	public static IEnumerator LoadScrollViewItem(Action<GameObject> callBackAction)
	{
		AssetInfo assetPath = GetUiScrollViewItem();
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(assetPath, BaseAsyncManager.Instance);
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetPath))
		{
			yield return null;
		}
		object orNull = SingletonInstance<AssetPool>.Instance.GetOrNull(assetPath);
		if (orNull == null)
		{
			Logger.ErrorFormat("failed to load ScrollViewItem {0}", assetPath);
			yield break;
		}
		GameObject obj = (orNull as GameObject).CreateInstance();
		callBackAction(obj);
	}

	public static IEnumerator LoadSlider(Action<GameObject> callBackAction)
	{
		AssetInfo assetPath = GetUiSlider();
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(assetPath, BaseAsyncManager.Instance);
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetPath))
		{
			yield return null;
		}
		object orNull = SingletonInstance<AssetPool>.Instance.GetOrNull(assetPath);
		if (orNull == null)
		{
			Logger.ErrorFormat("failed to load Slider {0}", assetPath);
			yield break;
		}
		GameObject obj = (orNull as GameObject).CreateInstance();
		callBackAction(obj);
	}

	public static IEnumerator LoadScrollView(Action<GameObject> callBackAction)
	{
		AssetInfo assetPath = GetUiScrollView();
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(assetPath, BaseAsyncManager.Instance);
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetPath))
		{
			yield return null;
		}
		object orNull = SingletonInstance<AssetPool>.Instance.GetOrNull(assetPath);
		if (orNull == null)
		{
			Logger.ErrorFormat("failed to load ScrollView {0}", assetPath);
			yield break;
		}
		GameObject obj = (orNull as GameObject).CreateInstance();
		callBackAction(obj);
	}

	private static AssetInfo GetUiScrollView()
	{
		return new AssetInfo("uiprefabs/free", "Assets/Res/Assets/uiprefabs/free/FreeScrollView.prefab");
	}

	private static AssetInfo GetUiSlider()
	{
		return new AssetInfo("uiprefabs/free", "Assets/Res/Assets/uiprefabs/free/FreeSlider.prefab");
	}

	private static AssetInfo GetUiScrollViewItem()
	{
		return new AssetInfo("uiprefabs/free", "Assets/Res/Assets/uiprefabs/free/FreeScrollViewItem.prefab");
	}

	public static AssetInfo GetUiAssetPath(string url, string componentName = null)
	{
		if (url.EndsWith(".atf"))
		{
			url = url.Replace(".atf", ".png");
		}
		if (url.IndexOf("/weapon", StringComparison.Ordinal) == 0)
		{
			Group group = new Regex("\\/weapon\\/(\\w+)").Match(url).Groups[1];
			return new AssetInfo("weapon/" + group, $"Assets/Res/Assets{url}");
		}
		if (url.IndexOf("/ui", StringComparison.Ordinal) == 0)
		{
			Group group2 = new Regex("\\/ui\\/(\\w+)").Match(url).Groups[1];
			return new AssetInfo("ui/" + group2, $"Assets/Res/Assets{url}");
		}
		if (url.IndexOf("commonfree/", StringComparison.Ordinal) == 0)
		{
			return new AssetInfo("ui/commonfree", $"Assets/Res/Assets/ui/GameGUIRes/{url}");
		}
		if (url.IndexOf("common/", StringComparison.Ordinal) == 0)
		{
			return new AssetInfo("ui/common", $"Assets/Res/Assets/ui/GameGUIRes/{url}");
		}
		if (url.IndexOf("halfLoadedRes/", StringComparison.Ordinal) == 0)
		{
			string text = url.Substring("halfLoadedRes/".Length);
			int num = text.IndexOf('/');
			if (num == -1)
			{
				return default(AssetInfo);
			}
			return new AssetInfo("ui/halfloadedres/" + text.Substring(0, num), $"Assets/Res/Assets/ui/GameGUIRes/{url}");
		}
		if (url.IndexOf("promiseModel/", StringComparison.Ordinal) == 0)
		{
			return new AssetInfo("ui/promiseModel", $"Assets/Res/Assets/ui/GameGUIRes/{url}");
		}
		if (!FreeBaseComponent.IsNullString(componentName))
		{
			return new AssetInfo($"ui/{componentName}Model", $"Assets/Res/Assets/ui/GameGUIRes/{componentName}Model/{url}");
		}
		return new AssetInfo($"ui/{UIDataManager.Instance.FreeType}Model", $"Assets/Res/Assets/ui/GameGUIRes/{UIDataManager.Instance.FreeType}Model/{url}");
	}

	public static AssetInfo GetEffectAssetPath(string url)
	{
		url = url.Replace(".atf", ".png").Replace(".wmdl", ".prefab").Replace(".FBX", ".prefab");
		if (url.IndexOf("commonfree", StringComparison.Ordinal) == 0)
		{
			url = "common" + url.Substring(10);
			return new AssetInfo("effect/common", $"Assets/Res/Assets/effect/{url}");
		}
		for (int i = 0; i < EffectMatchUrlStr.Length; i++)
		{
			if (url.IndexOf(EffectMatchUrlStr[i], StringComparison.Ordinal) == 0)
			{
				return new AssetInfo("effect/" + EffectMatchUrlStr[i], $"Assets/Res/Assets/effect/{url}");
			}
		}
		return new AssetInfo($"effect/{UIDataManager.Instance.FreeType}Mode", $"Assets/Res/Assets/effect/{UIDataManager.Instance.FreeType}Mode/{url}");
	}

	public static AssetInfo GetParticleAssetPath(string url)
	{
		string fileName = Path.GetFileName(url);
		if (!ParticleManager.Instance().TryGetParticle<EffectConfig>(fileName, out var result))
		{
			result = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/invlidParticleEffect/Prefab/invlidParticleEffect.prefab");
		}
		return result;
	}

	public static float GetSmallMapScale(string assetNameInfo)
	{
		if (assetNameInfo.EndsWith("nextSafe.png"))
		{
			return 1f;
		}
		if (!(UIDataManager.Instance.FreeType != "survive"))
		{
			return 1f;
		}
		return 0.5f;
	}

	public static float GetRadarScale(string assetNameInfo)
	{
		if (!(UIDataManager.Instance.FreeType != "survive"))
		{
			return 1f;
		}
		return 0.5f;
	}

	public static bool GetRadarFixPos(string assetNameInfo)
	{
		if (!assetNameInfo.EndsWith("/air.png") && !assetNameInfo.EndsWith("/yellowAris.png") && !assetNameInfo.EndsWith("/whiteAris.png"))
		{
			return assetNameInfo.EndsWith("/nextSafe.png");
		}
		return true;
	}
}
