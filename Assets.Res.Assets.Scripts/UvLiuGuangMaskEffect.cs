using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class UvLiuGuangMaskEffect : MonoBehaviour, IUvLiuGuangEffect
{
	public const string _EffectTex = "_EffectTex";

	public const string _MaskTex = "_MaskTex";

	public const string _Alpha = "_Alpha";

	public const string _LiuGuangSpeedX = "_LiuGuangSpeedX";

	public const string _LiuGuangSpeedY = "_LiuGuangSpeedY";

	public const string _EffectColor = "_EffectColor";

	public const string _Blend = "_Blend";

	public int blend;

	private float lastTime;

	private Renderer mesh;

	public Texture effectTexture;

	public Texture maskTexture;

	public Color32 effectColor;

	public Vector2 speed = new Vector2(0.5f, 0.5f);

	public float waitTime;

	public float hxSpeed;

	public float alpha = 1f;

	private Material material;

	private void Awake()
	{
		mesh = GetComponent<Renderer>();
		if (mesh != null)
		{
			lastTime = 0f;
			material = mesh.material;
			material.SetTexture("_EffectTex", effectTexture);
			material.SetTexture("_MaskTex", maskTexture);
			material.SetFloat("_Alpha", alpha);
			material.SetFloat("_LiuGuangSpeedX", speed.x);
			material.SetFloat("_LiuGuangSpeedY", speed.y);
			material.SetFloat("_Blend", blend);
			material.SetColor("_EffectColor", effectColor);
		}
	}

	public void Update()
	{
		if (waitTime > 0f || hxSpeed > 0f)
		{
			float num = 0f;
			lastTime += Time.deltaTime * 1000f;
			if (lastTime > waitTime + 2f * hxSpeed)
			{
				lastTime -= waitTime + 2f * hxSpeed;
			}
			num = ((lastTime > waitTime && lastTime <= waitTime + hxSpeed) ? ((lastTime - waitTime) / hxSpeed) : ((!(lastTime > waitTime + hxSpeed) || !(lastTime < waitTime + 2f * hxSpeed)) ? 0f : ((waitTime + 2f * hxSpeed - lastTime) / hxSpeed)));
			material.SetFloat("_Alpha", num);
		}
	}
}
