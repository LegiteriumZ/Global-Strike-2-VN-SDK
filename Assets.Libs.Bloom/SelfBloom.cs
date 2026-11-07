using UnityEngine;

namespace Assets.Libs.Bloom;

[RequireComponent(typeof(Camera))]
public class SelfBloom : MonoBehaviour
{
	[SerializeField]
	[Range(0f, 10f)]
	public float Threshold = 5f;

	[SerializeField]
	[Range(0f, 10f)]
	public float Iterations;

	[SerializeField]
	[Range(0f, 10f)]
	public float SampleScale;

	[SerializeField]
	[Range(0f, 10f)]
	public float Intensity;

	[SerializeField]
	[HideInInspector]
	private Shader _shader;

	private Material _material;

	private const int kMaxIterations = 16;

	private RenderTexture[] _blurBuffer1 = new RenderTexture[16];

	private RenderTexture[] _blurBuffer2 = new RenderTexture[16];

	private void OnEnable()
	{
		Shader shader = (_shader ? _shader : Shader.Find("Unlit/SelfBloomShader"));
		_material = new Material(shader);
		_material.hideFlags = HideFlags.DontSave;
		GetComponent<Camera>().allowHDR = true;
	}

	private void OnDisable()
	{
		Object.DestroyImmediate(_material);
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		int width = source.width / 2;
		int height = source.height / 2;
		_material.SetFloat("_Threshold", Threshold);
		_material.SetFloat("_SampleScale", SampleScale);
		_material.SetFloat("_Intensity", Intensity);
		RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.Default);
		int pass = 0;
		Graphics.Blit(source, temporary, _material, pass);
		RenderTexture renderTexture = temporary;
		for (int i = 0; (float)i < Iterations; i++)
		{
			_blurBuffer1[i] = RenderTexture.GetTemporary(renderTexture.width / 2, renderTexture.height / 2, 0, RenderTextureFormat.Default);
			pass = 1;
			Graphics.Blit(renderTexture, _blurBuffer1[i], _material, pass);
			renderTexture = _blurBuffer1[i];
		}
		_material.SetTexture("_BaseTex", source);
		pass = 2;
		Graphics.Blit(renderTexture, destination, _material, pass);
		for (int j = 0; j < 16; j++)
		{
			if (_blurBuffer1[j] != null)
			{
				RenderTexture.ReleaseTemporary(_blurBuffer1[j]);
			}
			if (_blurBuffer2[j] != null)
			{
				RenderTexture.ReleaseTemporary(_blurBuffer2[j]);
			}
			_blurBuffer1[j] = null;
			_blurBuffer2[j] = null;
		}
		RenderTexture.ReleaseTemporary(temporary);
	}
}
