using UnityEngine;
using UnityEngine.UI;

public class RModel3DImage : MonoBehaviour
{
	public RawImage Image;

	public Camera ModelCamera;

	public int TextureSize = 256;

	private RenderTexture _renderTexture;

	private void Update()
	{
		if (ModelCamera != null && ModelCamera.targetTexture == null)
		{
			if (_renderTexture == null)
			{
				_renderTexture = new RenderTexture(TextureSize, TextureSize, 8);
			}
			ModelCamera.targetTexture = _renderTexture;
			Image.texture = _renderTexture;
		}
	}
}
