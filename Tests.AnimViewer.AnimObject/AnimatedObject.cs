using System.Collections.Generic;
using SSJJAnim.Animator;
using Tests.AnimViewer.AnimSource;
using UnityEngine;

namespace Tests.AnimViewer.AnimObject;

public class AnimatedObject
{
	private GameObject _go;

	private SJAnimator _animator;

	public List<AnimLayer> layers;

	public AnimatedObject(GameObject go)
	{
		_go = go;
		layers = new List<AnimLayer>();
	}

	public IMethodsExecuter AddSource(IAnimSource source)
	{
		if (_go.GetComponent<SJAnimator>() == null)
		{
			_go.AddComponent<SJAnimator>();
		}
		_animator = _go.GetComponent<SJAnimator>();
		if (source.Asset != null)
		{
			_animator.AddLayer(layers.Count, 1f);
			_animator.AddAnimationClips(layers.Count, source.Asset.Clips);
			AnimLayer animLayer = new AnimLayer(_go.name, source);
			layers.Add(animLayer);
			return animLayer;
		}
		return null;
	}

	public void PlayAnim(float frameTime)
	{
		float playSpeed = GUIController.instance.GetPlaySpeed();
		frameTime *= playSpeed;
		for (int i = 0; i < layers.Count; i++)
		{
			string stateName = GUIController.instance.GetStateName(layers[i].index);
			if (!string.IsNullOrEmpty(stateName))
			{
				float time = layers[i].UpdateLayerTime(frameTime);
				_animator.PlayAtFixedTime(i, stateName, time, 1f, isLoop: true, isReverse: false, 0.1f);
			}
		}
	}

	public string GetName(int index)
	{
		return _go.name;
	}
}
