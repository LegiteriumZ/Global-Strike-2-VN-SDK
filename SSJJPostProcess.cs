using UnityEngine;

public class SSJJPostProcess : MonoBehaviour
{
	public Material PostProcessMaterial;

	private void Awake()
	{
		PostProcessMaterial = new Material(Shader.Find("SSJJ/PostProcess"));
		base.transform.GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
	}

	private void Update()
	{
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, PostProcessMaterial);
	}
}
