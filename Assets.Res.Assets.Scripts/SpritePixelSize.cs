using UnityEngine;

namespace Assets.Res.Assets.Scripts;

[ExecuteInEditMode]
public class SpritePixelSize : MonoBehaviour
{
	public int Width;

	public int Height;

	private void OnEnable()
	{
		SpriteRenderer component = GetComponent<SpriteRenderer>();
		if (component != null && component.sprite != null)
		{
			base.transform.localScale = new Vector3((float)Width / (float)component.sprite.texture.width, (float)Height / (float)component.sprite.texture.height, 1f);
		}
	}
}
