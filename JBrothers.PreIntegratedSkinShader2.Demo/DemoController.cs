using System;
using UnityEngine;

namespace JBrothers.PreIntegratedSkinShader2.Demo;

public class DemoController : MonoBehaviour
{
	[Serializable]
	private class SkyboxSphere
	{
		public Material skybox;

		public Cubemap cube;
	}

	public Light sun;

	public ReflectionProbe reflectionProbe;

	public PreIntegratedSkinProfile[] profiles;

	public Material[] skyboxes;

	private SkyboxSphere[] skyboxSpheres;

	private Quaternion probeBakedWithSunRotation = Quaternion.identity;

	private SkyboxSphere probeBakedWithSkybox;

	private SkyboxSphere selectedSkybox;

	public Shader skyboxSphereShader;

	private Material skyboxSphereMaterial;

	public Shader profileSphereShader;

	private Material profileSphereMaterial;

	public Renderer meshRenderer;

	private Material materialCopy;

	private Material materialOrig;

	private int _MainTex;

	public float sphereSize = 64f;

	public int cubemapResolution = 64;

	private float scattering;

	private int _ScatteringPower;

	private void Start()
	{
		_MainTex = Shader.PropertyToID("_MainTex");
		_ScatteringPower = Shader.PropertyToID("_ScatteringPower");
		if (!skyboxSphereShader)
		{
			Debug.LogWarning("no skybox preview shader");
			base.enabled = false;
			return;
		}
		skyboxSphereMaterial = new Material(skyboxSphereShader);
		if (!profileSphereShader)
		{
			Debug.LogWarning("no profile preview shader");
			base.enabled = false;
			return;
		}
		profileSphereMaterial = new Material(profileSphereShader);
		profileSphereMaterial.SetTexture("_LookupDirectSM2", Resources.Load<Texture2D>("PSSLookupDirectSM2"));
		if (!meshRenderer)
		{
			Debug.LogWarning("no mesh renderer");
			base.enabled = false;
			return;
		}
		materialOrig = meshRenderer.sharedMaterial;
		materialCopy = meshRenderer.material;
		scattering = materialCopy.GetFloat(_ScatteringPower);
		profileSphereMaterial.SetFloat(_ScatteringPower, 0.4f);
		skyboxSpheres = new SkyboxSphere[skyboxes.Length];
		for (int i = 0; i < skyboxes.Length; i++)
		{
			Material material = skyboxes[i];
			SkyboxSphere skyboxSphere = new SkyboxSphere();
			if (!material)
			{
				Debug.LogWarning("no skybox material specified");
				base.enabled = false;
				return;
			}
			skyboxSphere.skybox = material;
			skyboxSphere.cube = bakeSkyboxMaterialToCube(cubemapResolution, material);
			skyboxSpheres[i] = skyboxSphere;
		}
		SelectSkybox(skyboxSpheres[0]);
		UpdateRelfectionProbeIfNecessary();
	}

	private void OnDestroy()
	{
		if (skyboxSpheres != null)
		{
			SkyboxSphere[] array = skyboxSpheres;
			for (int i = 0; i < array.Length; i++)
			{
				UnityEngine.Object.Destroy(array[i].cube);
			}
		}
		if ((bool)skyboxSphereMaterial)
		{
			UnityEngine.Object.Destroy(skyboxSphereMaterial);
		}
		if ((bool)materialCopy)
		{
			UnityEngine.Object.Destroy(materialCopy);
		}
	}

	private void SelectSkybox(SkyboxSphere sb)
	{
		selectedSkybox = sb;
		RenderSettings.skybox = sb.skybox;
	}

	private void Update()
	{
		UpdateRelfectionProbeIfNecessary();
	}

	private void OnGUI()
	{
		GUIStyle gUIStyle = new GUIStyle("label");
		gUIStyle.alignment = TextAnchor.MiddleCenter;
		gUIStyle.fontStyle = FontStyle.Bold;
		GUIStyle gUIStyle2 = new GUIStyle("label");
		gUIStyle2.alignment = TextAnchor.UpperLeft;
		gUIStyle2.fontStyle = FontStyle.Normal;
		int controlID = GUIUtility.GetControlID(FocusType.Passive);
		GUILayout.BeginVertical(GUI.skin.box);
		GUILayout.BeginHorizontal(GUILayout.ExpandWidth(expand: false));
		SkyboxSphere[] array = skyboxSpheres;
		foreach (SkyboxSphere skyboxSphere in array)
		{
			Rect rect = GUILayoutUtility.GetRect(sphereSize, sphereSize, GUILayout.ExpandWidth(expand: false));
			Rect rect2 = new Rect(rect.x, (float)Screen.height - rect.y - rect.height, rect.width, rect.height);
			bool flag = false;
			if (rect2.Contains(Input.mousePosition))
			{
				float num = rect.width * rect.height / 4f;
				flag = ((Vector2)Input.mousePosition - rect2.center).sqrMagnitude < num;
			}
			if (Event.current.type == EventType.Repaint)
			{
				float value = Mathf.Repeat(Time.time / 10f, 1f);
				skyboxSphereMaterial.SetFloat("_Alpha", flag ? 1f : 0.5f);
				skyboxSphereMaterial.SetFloat("_Radius", flag ? 0.5f : 0.4f);
				skyboxSphereMaterial.SetTexture("_Cube", skyboxSphere.cube);
				skyboxSphereMaterial.SetFloat("_Rotation", value);
				Graphics.DrawTexture(rect, Texture2D.whiteTexture, skyboxSphereMaterial);
			}
			if (flag)
			{
				GUI.Label(rect, skyboxSphere.skybox.name, gUIStyle);
			}
			if (flag && Input.GetMouseButtonDown(0))
			{
				SelectSkybox(skyboxSphere);
			}
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(GUILayout.ExpandWidth(expand: false));
		PreIntegratedSkinProfile[] array2 = profiles;
		foreach (PreIntegratedSkinProfile preIntegratedSkinProfile in array2)
		{
			Rect rect3 = GUILayoutUtility.GetRect(sphereSize, sphereSize, GUILayout.ExpandWidth(expand: false));
			Rect rect4 = new Rect(rect3.x, (float)Screen.height - rect3.y - rect3.height, rect3.width, rect3.height);
			bool flag2 = false;
			if (rect4.Contains(Input.mousePosition))
			{
				float num2 = rect3.width * rect3.height / 4f;
				flag2 = ((Vector2)Input.mousePosition - rect4.center).sqrMagnitude < num2;
			}
			if (Event.current.type.Equals(EventType.Repaint))
			{
				float value2 = Mathf.Repeat(Time.time / 10f, 1f);
				profileSphereMaterial.SetFloat("_Alpha", flag2 ? 1f : 0.5f);
				profileSphereMaterial.SetFloat("_Radius", flag2 ? 0.5f : 0.4f);
				profileSphereMaterial.SetFloat("_Rotation", value2);
				preIntegratedSkinProfile.ApplyProfile(profileSphereMaterial);
				Graphics.DrawTexture(rect3, Texture2D.whiteTexture, profileSphereMaterial);
			}
			if (flag2)
			{
				GUI.Label(rect3, preIntegratedSkinProfile.name, gUIStyle);
			}
			if (flag2 && Input.GetMouseButtonDown(0))
			{
				preIntegratedSkinProfile.ApplyProfile(materialCopy);
			}
		}
		GUILayout.EndHorizontal();
		sun.enabled = GUILayout.Toggle(sun.enabled, "Direct light");
		GUILayout.BeginVertical();
		GUILayout.Label("Ambient intensity", gUIStyle2);
		RenderSettings.ambientIntensity = GUILayout.HorizontalSlider(RenderSettings.ambientIntensity, 0f, 2f);
		GUILayout.EndVertical();
		GUILayout.BeginVertical();
		GUILayout.Label("Reflection intensity", gUIStyle2);
		reflectionProbe.intensity = GUILayout.HorizontalSlider(reflectionProbe.intensity, 0f, 2f);
		GUILayout.EndVertical();
		GUILayout.BeginVertical();
		GUILayout.Label("Scattering", gUIStyle2);
		float num3 = GUILayout.HorizontalSlider(scattering, 0f, 2f);
		if (num3 != scattering)
		{
			scattering = num3;
			materialCopy.SetFloat(_ScatteringPower, scattering);
		}
		GUILayout.EndVertical();
		bool flag3 = (object)materialCopy.GetTexture(_MainTex) != Texture2D.whiteTexture;
		bool flag4 = GUILayout.Toggle(flag3, "Use diffuse texture");
		if (flag4 != flag3)
		{
			if (flag4)
			{
				materialCopy.SetTexture(_MainTex, materialOrig.GetTexture(_MainTex));
			}
			else
			{
				materialCopy.SetTexture(_MainTex, Texture2D.whiteTexture);
			}
		}
		GUILayout.EndVertical();
		Rect lastRect = GUILayoutUtility.GetLastRect();
		switch (Event.current.GetTypeForControl(controlID))
		{
		case EventType.MouseDown:
			if (lastRect.Contains(Event.current.mousePosition))
			{
				GUIUtility.hotControl = controlID;
				Event.current.Use();
			}
			break;
		case EventType.MouseUp:
			if (GUIUtility.hotControl == controlID)
			{
				GUIUtility.hotControl = 0;
				Event.current.Use();
			}
			break;
		case EventType.MouseDrag:
			if (GUIUtility.hotControl == controlID)
			{
				Event.current.Use();
			}
			break;
		case EventType.ScrollWheel:
			if (lastRect.Contains(Event.current.mousePosition))
			{
				Event.current.Use();
			}
			break;
		case EventType.MouseMove:
		case EventType.KeyDown:
		case EventType.KeyUp:
			break;
		}
	}

	private void UpdateRelfectionProbeIfNecessary()
	{
		if ((bool)sun)
		{
			bool flag = false;
			if (probeBakedWithSkybox != selectedSkybox)
			{
				flag = true;
				probeBakedWithSkybox = selectedSkybox;
			}
			if (sun.transform.rotation != probeBakedWithSunRotation)
			{
				flag = true;
				probeBakedWithSunRotation = sun.transform.rotation;
			}
			if (flag && reflectionProbe.isActiveAndEnabled)
			{
				reflectionProbe.RenderProbe();
			}
		}
	}

	private Cubemap bakeSkyboxMaterialToCube(int size, Material skybox)
	{
		GameObject gameObject = new GameObject();
		try
		{
			gameObject.SetActive(value: false);
			gameObject.AddComponent<Skybox>().material = skybox;
			Cubemap cubemap = new Cubemap(size, TextureFormat.RGB24, mipChain: false);
			Camera camera = gameObject.AddComponent<Camera>();
			camera.enabled = false;
			camera.clearFlags = CameraClearFlags.Skybox;
			camera.renderingPath = RenderingPath.Forward;
			camera.cullingMask = 0;
			camera.RenderToCubemap(cubemap);
			cubemap.Apply(updateMipmaps: false, makeNoLongerReadable: true);
			return cubemap;
		}
		finally
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
