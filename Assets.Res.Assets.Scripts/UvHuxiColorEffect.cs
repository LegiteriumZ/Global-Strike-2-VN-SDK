using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class UvHuxiColorEffect : MonoBehaviour
{
	public const string _HusuAlpha = "_HusuAlpha";

	public const string _HuxiTex = "_HuxiTex";

	private float _lastTime;

	private SkinnedMeshRenderer _skinnedMesh;

	private bool isHuxiEffect;

	public int MinMap = 1;

	public int Speed = 50;

	public Texture Texture;

	public int WaitTime = 50;

	public void SetEffectTime(float time)
	{
		_lastTime = time;
	}

	private void Awake()
	{
		_skinnedMesh = GetComponent<SkinnedMeshRenderer>();
		if (_skinnedMesh != null)
		{
			_lastTime = 0f;
			isHuxiEffect = false;
			Material material = _skinnedMesh.material;
			material.SetTexture("_HuxiTex", Texture);
			material.SetFloat("_HusuAlpha", 0f);
			isHuxiEffect = material.shader.name.Equals("SSJJ/UvHuxi") || material.shader.name.Equals("SSJJ/UvHuxiWorn");
		}
	}

	private void Update()
	{
		if (isHuxiEffect)
		{
			float num = 0f;
			_lastTime += Time.deltaTime * 1000f;
			if (_lastTime > (float)(WaitTime + 2 * Speed))
			{
				_lastTime -= WaitTime + 2 * Speed;
			}
			num = ((_lastTime > (float)WaitTime && _lastTime <= (float)(WaitTime + Speed)) ? ((_lastTime - (float)WaitTime) / (float)Speed) : ((!(_lastTime > (float)(WaitTime + Speed)) || !(_lastTime < (float)(WaitTime + 2 * Speed))) ? 0f : (((float)(WaitTime + 2 * Speed) - _lastTime) / (float)Speed)));
			_skinnedMesh.material.SetFloat("_HusuAlpha", num);
		}
	}
}
