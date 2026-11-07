using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Free.Effect;

public class FreeEffectManager
{
	private static FreeEffectManager _instance;

	private Dictionary<string, FreeRenderObject> effects;

	private Transform _effectParent;

	public Dictionary<string, FreeRenderObject> FreeEffects => effects;

	public FreeEffectManager()
	{
		effects = new Dictionary<string, FreeRenderObject>();
	}

	public Transform GetEffectParent()
	{
		if (_effectParent == null)
		{
			GameObject gameObject = new GameObject("FreeEffect");
			_effectParent = gameObject.transform;
		}
		return _effectParent;
	}

	public static FreeEffectManager GetInstance()
	{
		if (_instance == null)
		{
			_instance = new FreeEffectManager();
		}
		return _instance;
	}

	public FreeRenderObject GetEffect(string key)
	{
		effects.TryGetValue(key, out var value);
		return value;
	}

	public void RemoveEffect(FreeRenderObject effect)
	{
		if (effect != null)
		{
			effects.Remove(effect.Key);
		}
	}

	public void AddEffect(FreeRenderObject effect)
	{
		FreeRenderObject effect2 = GetEffect(effect.Key);
		if (effect2 != null)
		{
			effect2.Visible = false;
		}
		effects[effect.Key] = effect;
	}
}
