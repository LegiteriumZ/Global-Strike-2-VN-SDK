using Assets.RUI;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.UI;
using Assets.Sources.Utils.Ui;
using SSJJAsset.Asset;
using SSJJBase.Thread;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Free.Utility;

public class UnityUiUtility
{
	public static void EnsureComponent<T>(GameObject obj) where T : MonoBehaviour
	{
		if (obj.GetComponent<T>() == null)
		{
			obj.AddComponent<T>();
		}
	}

	public static GameObject CreateCanvas(int width, int height)
	{
		GameObject gameObject = new GameObject("FreeCanvas");
		gameObject.AddComponent<RectTransform>().sizeDelta = new Vector2(width, height);
		gameObject.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
		gameObject.AddComponent<CanvasScaler>();
		gameObject.AddComponent<GraphicRaycaster>();
		return gameObject;
	}

	public static IUiObject CreateImageDisplayObject(AssetInfo assetInfo, int width, int height)
	{
		GameObject gameObject = new GameObject($"Image_{width}_{height}_{assetInfo.AssetName}");
		FreeBaseImage freeBaseImage = gameObject.AddComponent<FreeBaseImage>();
		freeBaseImage.sprite = TextureUtility.GetTransparentSprite();
		BaseAsyncManager.Instance.StartCoroutine(FreeResourceUtility.LoadImage(freeBaseImage, assetInfo, new FreeImageComponent.ImageComponentData(width, height, width, height)));
		return new UnityUiObject(gameObject)
		{
			Width = width,
			Height = height
		};
	}

	public static IUiObject CreateNumberTextDisplayObject(int fontIndex)
	{
		GameObject gameObject = new GameObject("Number");
		Text text = gameObject.AddComponent<Text>();
		text.horizontalOverflow = HorizontalWrapMode.Overflow;
		text.verticalOverflow = VerticalWrapMode.Overflow;
		text.alignment = TextAnchor.UpperLeft;
		BaseAsyncManager.Instance.StartCoroutine(FreeResourceUtility.LoadNumberFont(text, fontIndex));
		return new UnityUiObject(gameObject);
	}

	public static IUiObject CreateEmptyDisplayObject(string name = null)
	{
		GameObject gameObject = new GameObject(name);
		gameObject.AddComponent<RectTransform>();
		gameObject.AddComponent<CanvasRenderer>();
		return new UnityUiObject(gameObject);
	}

	public static void SetTexture(IUiObject uiObject, AssetInfo assetInfo, int width, int height)
	{
		FreeBaseImage component = uiObject.GameObject.GetComponent<FreeBaseImage>();
		if (!(component == null))
		{
			BaseAsyncManager.Instance.StartCoroutine(FreeResourceUtility.LoadImage(component, assetInfo, new FreeImageComponent.ImageComponentData(width, height, width, height)));
		}
	}

	public static void SetRectFullScreen(RectTransform rect)
	{
		if (!(rect == null))
		{
			rect.localPosition = Vector3.zero;
			rect.anchorMin = new Vector2(0f, 0f);
			rect.anchorMax = new Vector2(1f, 1f);
			rect.offsetMin = Vector2.zero;
			rect.offsetMax = Vector2.zero;
		}
	}
}
