using SSJJSceneLoader;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Effect;

public class ExplosionBlurEffect : MonoBehaviour
{
	public float Duration = 1f;

	public float AlphaMin = 0.2f;

	private GameObject _uiEffect;

	private RawImage _image;

	public static void CreateOnce()
	{
		new GameObject(typeof(ExplosionBlurEffect).ToString()).AddComponent<ExplosionBlurEffect>();
	}

	private void Awake()
	{
		_uiEffect = new GameObject("ExplosionBlurEffectUI");
		_uiEffect.transform.SetParent(base.transform);
		Canvas canvas = _uiEffect.AddComponent<Canvas>();
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		canvas.sortingOrder = -1000;
		_uiEffect.AddComponent<CanvasScaler>();
		GameObject gameObject = new GameObject("Image");
		gameObject.transform.SetParent(_uiEffect.transform, worldPositionStays: false);
		gameObject.AddComponent<CanvasRenderer>();
		_image = gameObject.AddComponent<RawImage>();
	}

	private void Start()
	{
		Camera[] allCameras = Camera.allCameras;
		RenderTexture renderTexture = new RenderTexture(Camera.main.pixelWidth, Camera.main.pixelHeight, 24);
		Camera[] array = allCameras;
		foreach (Camera camera in array)
		{
			if (!(camera == null))
			{
				camera.targetTexture = renderTexture;
			}
		}
		GameObject gameObject = GameObject.FindGameObjectWithTag("SceneMap");
		if (gameObject != null)
		{
			BaseSceneRender component = gameObject.GetComponent<BaseSceneRender>();
			if (component != null)
			{
				component.DrawScene();
			}
		}
		array = allCameras;
		foreach (Camera camera2 in array)
		{
			if (!(camera2 == null))
			{
				camera2.Render();
				camera2.targetTexture = null;
			}
		}
		if (_image != null)
		{
			_image.gameObject.SetObjectActive(isactive: true);
			_image.texture = renderTexture;
			Color color = _image.color;
			color.a = 1f - AlphaMin;
			_image.color = color;
			_image.SetNativeSize();
		}
	}

	private void Update()
	{
		if (_image != null)
		{
			float deltaTime = Time.deltaTime;
			Color color = _image.color;
			color.a -= deltaTime * ((1f - AlphaMin) / Duration);
			if (color.a < 0f)
			{
				color.a = 1f - AlphaMin;
				_image.color = color;
				Object.Destroy(base.gameObject);
			}
			else
			{
				_image.color = color;
			}
		}
	}

	private void OnDestroy()
	{
		if (_uiEffect != null)
		{
			Object.Destroy(_uiEffect);
		}
	}
}
