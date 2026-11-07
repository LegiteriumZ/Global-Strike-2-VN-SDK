using UnityEngine;

public class TrailController : MonoBehaviour
{
	public bool isFading;

	public float fadingTime = 1f;

	public float startAlpha = 1f;

	private TrailRenderer trailRenderer;

	private Renderer _Render;

	public void SetAlpha(float alpha)
	{
		startAlpha = alpha;
		if ((bool)_Render)
		{
			_Render.material.SetColor("_Color", new Color(1f, 1f, 1f, alpha));
		}
	}

	private void OnEnable()
	{
		if ((bool)_Render)
		{
			_Render.material.SetColor("_Color", new Color(1f, 1f, 1f, startAlpha));
		}
	}

	private void Awake()
	{
		_Render = base.gameObject.GetComponent<Renderer>();
		trailRenderer = base.gameObject.GetComponent<TrailRenderer>();
	}

	private void Update()
	{
		if ((bool)trailRenderer && (bool)_Render)
		{
			Color color = trailRenderer.material.color;
			if (color.a > 0f && isFading)
			{
				float a = color.a - Time.deltaTime / fadingTime * startAlpha;
				_Render.material.SetColor("_Color", new Color(color.r, color.g, color.b, a));
			}
		}
	}
}
