using System.Collections.Generic;
using Assets.Sources.Free.Effect;
using NetData;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.UI;

public class FreeUIUtil
{
	private readonly List<IFreeComponent> _components;

	private readonly List<IShowStyle> _showStyles;

	private readonly List<IFreeEffect> _effects;

	private static FreeUIUtil _instance;

	private bool _isDestory;

	public FreeUIUtil()
	{
		_components = new List<IFreeComponent>();
		_showStyles = new List<IShowStyle>();
		_effects = new List<IFreeEffect>();
		_components.Add(new FreeImageComponent());
		_components.Add(new FreeTextComponent());
		_components.Add(new FreeNumberComponent());
		_components.Add(new FreeListComponent());
		_components.Add(new FreeRaderComponent());
		_components.Add(new FreeExpComponent());
		_components.Add(new FreeSmallMapComponent());
		_components.Add(new FreeRotationImageComponent());
		_components.Add(new FreeButtonComponent());
		_components.Add(new FreeCheckBoxComponent());
		_components.Add(new FreeDirectionComponent());
		_components.Add(new FreeScrollViewComponent());
		_components.Add(new FreeSliderComponent());
		_showStyles.Add(new ShowSimpleStyle());
		_effects.Add(new FreeSingleEffect());
		_effects.Add(new FreeParticleEffect());
		_effects.Add(new FreeParticleLinkEffect());
		_effects.Add(new FreeShaderEffect());
	}

	public static FreeUIUtil GetInstance()
	{
		if (_instance == null)
		{
			_instance = new FreeUIUtil();
		}
		return _instance;
	}

	public void DestoryTemplate()
	{
		if (!_isDestory)
		{
			_isDestory = true;
			Object.DestroyImmediate(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent().gameObject.gameObject);
		}
	}

	public IShowStyle GetShowStyle(SimpleProto sp)
	{
		for (int i = 0; i < _showStyles.Count; i++)
		{
			IShowStyle showStyle = _showStyles[i].Parse(sp);
			if (showStyle != null)
			{
				return showStyle;
			}
		}
		return null;
	}

	public IFreeEffect GetEffect(int type)
	{
		for (int i = 0; i < _effects.Count; i++)
		{
			IFreeEffect freeEffect = _effects[i];
			if (freeEffect.Type == type)
			{
				return freeEffect.Clone();
			}
		}
		return null;
	}

	public IFreeComponent GetComponent(int type)
	{
		for (int i = 0; i < _components.Count; i++)
		{
			IFreeComponent freeComponent = _components[i];
			if (freeComponent.Type == type)
			{
				return freeComponent.Clone();
			}
		}
		return null;
	}
}
