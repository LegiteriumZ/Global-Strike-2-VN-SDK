using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class Uvlive2DEffect : MonoBehaviour, IUvLiuGuangEffect
{
	public Texture liuguangTexture;

	public Texture maskTexture;

	private float maskFactor = 1f;

	private float mutilFactor = 1f;

	private float factorSpeed = 5f;

	public int maskUseTime;

	private Material _material;

	private bool _hasLiuguang;

	private bool hasChanges = true;

	public bool hasLiuguang
	{
		get
		{
			return _hasLiuguang;
		}
		set
		{
			if (_hasLiuguang != value)
			{
				_hasLiuguang = value;
				hasChanges = true;
			}
		}
	}

	private void Awake()
	{
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			_material = component.material;
			updateMaterial();
			_material.SetFloat("_MaskFactor", maskFactor);
		}
	}

	private void Update()
	{
		updateMaskFactor();
		updateMaterial();
	}

	private void updateMaskFactor()
	{
		if (mutilFactor > 0f && maskFactor < 1f)
		{
			maskFactor += Time.deltaTime * factorSpeed;
			maskFactor = Mathf.Min(maskFactor, 1f);
			_material.SetFloat("_MaskFactor", maskFactor);
		}
		else if (mutilFactor < 0f && maskFactor > 0f)
		{
			maskFactor -= Time.deltaTime * factorSpeed;
			maskFactor = Mathf.Max(maskFactor, 0f);
			_material.SetFloat("_MaskFactor", maskFactor);
		}
	}

	private void updateMaterial()
	{
		if (hasChanges && (bool)_material)
		{
			hasChanges = false;
			if (_hasLiuguang)
			{
				_material.SetTexture("_LiuGuangTex", liuguangTexture);
			}
			else
			{
				_material.SetTexture("_LiuGuangTex", null);
			}
		}
	}

	public void tweenFactor(float value)
	{
		if (value > maskFactor)
		{
			mutilFactor = 1f;
		}
		else if (value < maskFactor)
		{
			mutilFactor = -1f;
		}
	}
}
