using System.Collections.Generic;
using Assets.Sources.Framework;
using UnityEngine;

namespace Assets.Sources.Modules.Utility;

internal class UtilityGamobjectActiveSystem : IRenderSystem
{
	private UtilityContext _contexts;

	public UtilityGamobjectActiveSystem(Contexts contexts)
	{
		_contexts = contexts.utility;
		if (_contexts.hasGameObjectActive)
		{
			_contexts.gameObjectActive.Inited = true;
		}
		else
		{
			_contexts.SetGameObjectActive(new Dictionary<GameObject, bool>(128), newInited: true);
		}
	}

	public void OnRender()
	{
		if (!_contexts.hasGameObjectActive)
		{
			return;
		}
		Dictionary<GameObject, bool> activeDict = _contexts.gameObjectActive.ActiveDict;
		if (activeDict == null || activeDict.Count <= 0)
		{
			return;
		}
		foreach (KeyValuePair<GameObject, bool> item in activeDict)
		{
			if ((bool)item.Key && item.Key.gameObject.activeSelf != item.Value)
			{
				item.Key.gameObject.SetActive(item.Value);
			}
		}
		activeDict.Clear();
	}
}
