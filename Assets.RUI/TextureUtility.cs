using UnityEngine;

namespace Assets.RUI;

public class TextureUtility
{
	private static Texture2D _transparentTexture;

	private static Sprite _transparentSprite;

	public static Texture2D GetTransparentTexture()
	{
		if (_transparentTexture == null)
		{
			Texture2D texture2D = new Texture2D(2, 2, TextureFormat.RGBA32, mipChain: false);
			Color color = new Color(1f, 1f, 1f, 0f);
			Color[] array = new Color[texture2D.width * texture2D.height];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = color;
			}
			texture2D.SetPixels(array);
			texture2D.Apply();
			_transparentTexture = texture2D;
		}
		return _transparentTexture;
	}

	public static Sprite GetTransparentSprite()
	{
		if (_transparentSprite == null)
		{
			Texture2D transparentTexture = GetTransparentTexture();
			_transparentSprite = Sprite.Create(transparentTexture, new Rect(0f, 0f, transparentTexture.width, transparentTexture.height), new Vector2(0.5f, 0.5f));
		}
		return _transparentSprite;
	}
}
