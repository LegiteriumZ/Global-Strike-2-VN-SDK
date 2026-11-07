using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class UvLiuGuangEffect : MonoBehaviour, IUvLiuGuangEffect
{
	public const string _LiuGuangTex = "_LiuGuangTex";

	public const string _LiuGuangAlpha = "_LiuGuangAlpha";

	private float _lastTime;

	private Renderer _mesh;

	private bool isHuxiEffect;

	public int MinMap = 1;

	public int Speed = 50;

	public Texture Texture;

	private Material _material;

	private void Awake()
	{
		_mesh = GetComponent<Renderer>();
		if (_mesh != null)
		{
			_lastTime = 0f;
			isHuxiEffect = false;
			_material = _mesh.material;
			_material.SetTexture("_LiuGuangTex", Texture);
			_material.SetFloat("_LiuGuangAlpha", 0f);
			isHuxiEffect = _material.shader.name.Equals("SSJJ/UvLiuGuang") || _material.shader.name.Equals("SSJJ/UvLiuGuangLouKong");
		}
	}

	private void Update()
	{
		if (isHuxiEffect)
		{
			_lastTime += Time.deltaTime * 1000f * 5E-06f * (float)Speed;
			_material.SetFloat("_LiuGuangAlpha", _lastTime);
		}
	}
}
