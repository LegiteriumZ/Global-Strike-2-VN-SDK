using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class CustomUvHuxiEffect : MonoBehaviour
{
	private float nowAlpha;

	private float mulDir;

	public float Speed = 1f;

	public Vector2 UvSpeed;

	private Vector2 nowOffset;

	private MeshRenderer meshRender;

	private void OnEnable()
	{
		nowAlpha = 0f;
		mulDir = 1f;
		nowOffset = Vector2.zero;
		meshRender = base.gameObject.GetComponent<MeshRenderer>();
	}

	private void Update()
	{
		Material material = meshRender.material;
		if (material != null)
		{
			nowAlpha += Time.deltaTime * Speed * mulDir;
			nowOffset += Time.deltaTime * UvSpeed * mulDir;
			if (nowAlpha < 0f)
			{
				nowAlpha = 0f;
				mulDir = 1f;
				nowOffset = Vector2.zero;
			}
			else if (nowAlpha > 1f)
			{
				nowAlpha = 1f;
				mulDir = -1f;
			}
			Color color = material.GetColor("_Color");
			color.a = nowAlpha;
			material.SetColor("_Color", color);
			material.mainTextureOffset = nowOffset;
		}
	}
}
