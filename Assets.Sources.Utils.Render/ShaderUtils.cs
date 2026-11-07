using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Utils.Render;

public class ShaderUtils
{
	private static LoggerAdapter _logger = new LoggerAdapter(typeof(ShaderUtils));

	public const string MobileTransparent = "MobileTransparent";

	public const string MobileDiffuse = "MobileDiffuse";

	public const string BlockingOut = "BlockingOut";

	public const string BodyMask = "BodyMask";

	public static void InitShader(GameObject characterGameObject, Shader shader, string shaderName)
	{
		if (!shader.isSupported)
		{
			_logger.Error("Shader not supported: " + shader);
		}
		SkinnedMeshRenderer[] componentsInChildren = characterGameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Material[] materials = componentsInChildren[i].materials;
			foreach (Material material in materials)
			{
				if (!material.shader.name.Contains("Particle") && !material.shader.name.Contains("AlphaGlow") && !material.shader.name.Contains("FrameAnimation") && !material.shader.name.Contains("UVMove") && !material.shader.name.Contains("BreathEffect"))
				{
					Texture mainTexture = material.mainTexture;
					material.shader = shader;
					material.mainTexture = mainTexture;
					if (shaderName == "MobileDiffuse")
					{
						material.color = Color.white;
					}
				}
			}
		}
	}
}
