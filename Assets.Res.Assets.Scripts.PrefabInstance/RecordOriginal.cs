using System;
using UnityEngine;

namespace Assets.Res.Assets.Scripts.PrefabInstance;

public class RecordOriginal
{
	private float _alpha = 1f;

	private Renderer _renderer;

	private string _shaderName;

	private Action<float> _alhpaUpdateAction;

	private string _colorAttribute;

	private float _currAlpha = 1f;

	public float Alpha => _alpha;

	public Renderer Renderer => _renderer;

	public RecordOriginal(Renderer render)
	{
		_renderer = render;
		if (_renderer.material != null)
		{
			_shaderName = _renderer.material.shader.name;
			switch (_shaderName)
			{
			case "Particles/Additive":
			case "Particles/SSJJ/Additive":
			case "Particles/SSJJ/Additive/Billboard":
			case "Particles/SSJJ/Alpha Blended":
			case "Particles/SSJJ/Alpha Blended/Billboard":
				_colorAttribute = "_TintColor";
				_alpha = (_currAlpha = _renderer.material.GetColor(_colorAttribute).a);
				_alhpaUpdateAction = UpdateAlpha;
				break;
			case "SSJJ/Diffuse":
				_colorAttribute = "_Color";
				_alpha = (_currAlpha = _renderer.material.GetColor(_colorAttribute).a);
				_alhpaUpdateAction = UpdateAlpha;
				break;
			}
		}
	}

	private void UpdateAlpha(float alpha)
	{
		alpha = Alpha * alpha;
		if (Mathf.Approximately(_currAlpha, alpha) || string.IsNullOrEmpty(_colorAttribute))
		{
			return;
		}
		_currAlpha = alpha;
		Color color = _renderer.material.GetColor(_colorAttribute);
		color.a = alpha;
		_renderer.material.SetColor(_colorAttribute, color);
		if (color.a < 1f)
		{
			if (_renderer.material.renderQueue < 3000)
			{
				_renderer.material.renderQueue += 1200;
			}
		}
		else if (_renderer.material.renderQueue > 3000)
		{
			_renderer.material.renderQueue -= 1200;
		}
	}

	public void SetAlpha(float alpha)
	{
		if (_alhpaUpdateAction != null)
		{
			_alhpaUpdateAction(alpha);
		}
	}
}
