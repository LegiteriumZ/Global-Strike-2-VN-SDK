using System;
using System.Collections.Generic;
using SSJJMath;
using UnityEngine;

namespace Assets.Scripts.Fog;

public class SSJJFog : MonoBehaviour
{
	[Serializable]
	public class FogConfig
	{
		public int Id;

		[Range(0f, 1f)]
		public float Density;

		public Color Color = Color.white;

		public float Near = float.MaxValue;

		public float Far = float.MaxValue;

		public bool IsUseHeight;

		public float Height = float.MaxValue;

		public int HeightScale;

		public bool HasFogArea;

		public Vector3 FogAreaMin;

		public Vector3 FogAreaMax;

		public bool FogAreaCulling;

		public int FogQualityLevel;

		public FogConfig(int id)
		{
			Id = id;
		}

		public void Set(float density, Color color, float near, float far)
		{
			Density = density;
			Color = color;
			Near = near;
			Far = far;
		}
	}

	public List<FogConfig> Fogs = new List<FogConfig>();

	private Shader _fogShader;

	private Shader _heightShader;

	private Material _fogMaterial;

	private Material _fogHeightMaterial;

	private bool _isInit;

	private Camera _myCamera;

	private Vector3 topLeft;

	private Vector3 topRight;

	private Vector3 bottomLeft;

	private Vector3 bottomRight;

	private Vector3 toTop;

	private Vector3 toRight;

	private Vector3 toForward;

	public Material Material
	{
		get
		{
			if (_fogMaterial == null)
			{
				if (_fogShader == null)
				{
					InitFogShader();
				}
				_fogMaterial = new Material(_fogShader);
				_fogMaterial.hideFlags = HideFlags.DontSave;
				_fogMaterial.renderQueue = 2000;
			}
			return _fogMaterial;
		}
	}

	public Material HeightMaterial
	{
		get
		{
			if (_fogHeightMaterial == null)
			{
				if (_fogShader == null)
				{
					InitFogShader();
				}
				if (_heightShader != null)
				{
					_fogHeightMaterial = new Material(_heightShader);
					_fogHeightMaterial.hideFlags = HideFlags.DontSave;
					_fogHeightMaterial.renderQueue = 2000;
				}
			}
			return _fogHeightMaterial;
		}
	}

	public Camera Camera
	{
		get
		{
			if (_myCamera == null)
			{
				_myCamera = base.transform.GetComponent<Camera>();
			}
			return _myCamera;
		}
	}

	public Transform CameraTransform => Camera.transform;

	public void InitFogShader(FogConfig config = null)
	{
		if (!_isInit)
		{
			_isInit = true;
			if (config != null && config.IsUseHeight)
			{
				_heightShader = Shader.Find("SSJJ/FogWithDepth");
			}
			_fogShader = Shader.Find("SSJJ/Fog");
		}
	}

	private void OnEnable()
	{
		Camera.depthTextureMode |= DepthTextureMode.Depth;
	}

	private bool CheckIsInArea(Vector3 position, FogConfig config)
	{
		if (config.HasFogArea)
		{
			if (position.x > config.FogAreaMin.x && position.x < config.FogAreaMax.x && position.y > config.FogAreaMin.y && position.y < config.FogAreaMax.y && position.z > config.FogAreaMin.z && position.z < config.FogAreaMax.z)
			{
				if (config.FogAreaCulling)
				{
					return false;
				}
				return true;
			}
			if (!config.FogAreaCulling)
			{
				return false;
			}
			return true;
		}
		return true;
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Vector3 position = VectorCoordConverter.UnityToSsjj(base.transform.position);
		if (Material == null || Fogs.Count == 0 || Fogs[0] == null || !CheckIsInArea(position, Fogs[0]))
		{
			Graphics.Blit(source, destination);
			return;
		}
		if (Fogs[0].IsUseHeight)
		{
			Matrix4x4 identity = Matrix4x4.identity;
			float fieldOfView = Camera.fieldOfView;
			float nearClipPlane = Camera.nearClipPlane;
			float aspect = Camera.aspect;
			float num = nearClipPlane * Mathf.Tan(fieldOfView * 0.5f * ((float)Math.PI / 180f));
			toRight = base.transform.right * num * aspect;
			toTop = base.transform.up * num;
			toForward = base.transform.forward * nearClipPlane;
			topLeft = toForward + toTop - toRight;
			float num2 = topLeft.magnitude / nearClipPlane;
			topLeft.Normalize();
			topLeft *= num2;
			topRight = toForward + toRight + toTop;
			topRight.Normalize();
			topRight *= num2;
			bottomLeft = toForward - toTop - toRight;
			bottomLeft.Normalize();
			bottomLeft *= num2;
			bottomRight = toForward + toRight - toTop;
			bottomRight.Normalize();
			bottomRight *= num2;
			identity.SetRow(0, bottomLeft);
			identity.SetRow(1, bottomRight);
			identity.SetRow(2, topRight);
			identity.SetRow(3, topLeft);
			HeightMaterial.SetMatrix("_FrustumCornersRay", identity);
			HeightMaterial.SetFloat("_FogDensity", Fogs[0].Density);
			HeightMaterial.SetColor("_FogColor", Fogs[0].Color);
			HeightMaterial.SetFloat("_FogHeight", Fogs[0].Height);
			HeightMaterial.SetFloat("_FogScale", 1f / (float)Fogs[0].HeightScale);
			HeightMaterial.SetFloat("_FogStart", Fogs[0].Near);
			HeightMaterial.SetFloat("_FogEnd", Fogs[0].Far);
			Graphics.Blit(source, destination, HeightMaterial);
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			if (i < Fogs.Count)
			{
				if (!Mathf.Approximately(Fogs[i].Near, Fogs[i].Far) || !Mathf.Approximately(Fogs[i].Near, 0f))
				{
					Material.SetFloat("_FogDensity" + i, Fogs[i].Density);
					Material.SetColor("_FogColor" + i, Fogs[i].Color);
					Material.SetFloat("_FogStart" + i, Fogs[i].Near);
					Material.SetFloat("_FogEnd" + i, Fogs[i].Far);
				}
			}
			else
			{
				Material.SetFloat("_FogDensity" + i, 0f);
			}
		}
		Graphics.Blit(source, destination, Material);
	}
}
