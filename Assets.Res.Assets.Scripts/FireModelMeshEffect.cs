using System;
using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class FireModelMeshEffect : IFireEffectControl, IFireModelMeshEffect
{
	private float _frameTime = 1f;

	private float _nextFrame;

	private readonly System.Random _random = new System.Random();

	private SkinnedMeshRenderer _skinnedMesh;

	private int _textureIdx;

	private bool _visable;

	public int MinMap = 1;

	public Texture[] Textures;

	public bool IsRotate;

	public bool HasSpecial;

	public int SpecialModeIndexOffect;

	public int FireLength = 4;

	public int IndexLength = 3;

	public int SpecialFireLengt = 4;

	public int SpecialIndexLength = 3;

	public const float OneFrame = 16.666666f;

	private Material material;

	public override bool Fire(bool special)
	{
		if (base.gameObject.activeInHierarchy)
		{
			if (special && HasSpecial)
			{
				Fire(SpecialIndexLength, SpecialFireLengt);
				return true;
			}
			Fire(IndexLength, FireLength);
			return true;
		}
		return false;
	}

	public override void SetRender(bool flag)
	{
		if (_skinnedMesh != null)
		{
			_skinnedMesh.enabled = flag;
		}
	}

	public override void SetNoUse()
	{
	}

	private void Awake()
	{
		_skinnedMesh = GetComponent<SkinnedMeshRenderer>();
		_textureIdx = 0;
		_nextFrame = 0f;
		if (Textures.Length != 0 && _skinnedMesh != null)
		{
			material = _skinnedMesh.material;
			material.mainTexture = Textures[0];
			material.SetInt("_ZWrite", 0);
			_skinnedMesh.enabled = false;
			material.SetInt("_CullAlphaEnable", 1);
			material.SetFloat("_CullAlpha", 0.5f);
		}
	}

	private void Update()
	{
		if (!(_skinnedMesh != null))
		{
			return;
		}
		if (!_visable)
		{
			_skinnedMesh.enabled = false;
		}
		else
		{
			_skinnedMesh.enabled = true;
			_frameTime -= Time.deltaTime * 1000f;
			_nextFrame -= Time.deltaTime * 1000f;
			if (_nextFrame <= 0f)
			{
				material.mainTexture = Textures[_textureIdx];
				_nextFrame += 16.666666f;
				_textureIdx = (_textureIdx + 1) % Textures.Length;
			}
		}
		if (_frameTime <= 0f)
		{
			_visable = false;
			_frameTime = 0f;
		}
	}

	public void Fire(int indexLength, int fireLength)
	{
		_textureIdx = (int)(_random.NextDouble() * (double)indexLength) + SpecialModeIndexOffect;
		_frameTime = (float)fireLength * 16.666666f;
		_nextFrame = 16.666666f;
		material.mainTexture = Textures[_textureIdx];
		if (IsRotate)
		{
			_skinnedMesh.rootBone.Rotate(Vector3.forward, _random.Next(0, 180));
		}
		_visable = true;
	}
}
