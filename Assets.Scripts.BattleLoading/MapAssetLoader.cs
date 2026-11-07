using System.Collections.Generic;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJSceneLoader;
using UnityEngine;

namespace Assets.Scripts.BattleLoading;

public class MapAssetLoader : IMapAssetLoader
{
	private Object[] _assets;

	private IgnoreCaseString _bundleName;

	public MapAssetLoader(Object[] assets, IgnoreCaseString bundleName)
	{
		_assets = assets;
		_bundleName = bundleName;
	}

	public byte[] GetMapData()
	{
		Object[] assets = _assets;
		foreach (Object @object in assets)
		{
			if (@object is TextAsset && @object.name == "model.bsp.raw")
			{
				return (@object as TextAsset).bytes;
			}
		}
		return null;
	}

	public string GetSceneEffectConfigData()
	{
		Object[] assets = _assets;
		foreach (Object @object in assets)
		{
			if (@object is TextAsset && @object.name == "sceneEffectConfig")
			{
				return (@object as TextAsset).text;
			}
		}
		return null;
	}

	public string GetSceneHomeGunGridConfigData()
	{
		Object[] assets = _assets;
		foreach (Object @object in assets)
		{
			if (@object is TextAsset && @object.name == "homeGunGrid")
			{
				return (@object as TextAsset).text;
			}
		}
		return null;
	}

	public string GetSceneFogEffectConfigData()
	{
		Object[] assets = _assets;
		foreach (Object @object in assets)
		{
			if (@object is TextAsset && @object.name == "fogEffectConfig")
			{
				return (@object as TextAsset).text;
			}
		}
		return null;
	}

	public string GetSceneU3DConfigData()
	{
		Object[] assets = _assets;
		foreach (Object @object in assets)
		{
			if (@object is TextAsset && @object.name == "SpecialU3D")
			{
				return (@object as TextAsset).text;
			}
		}
		return null;
	}

	public byte[] GetBloomConfigData()
	{
		Object[] assets = _assets;
		foreach (Object @object in assets)
		{
			if (@object is TextAsset && @object.name == "Bloom")
			{
				return (@object as TextAsset).bytes;
			}
		}
		return null;
	}

	public byte[] GetSceneWaterConfigData()
	{
		Object[] assets = _assets;
		foreach (Object @object in assets)
		{
			if (@object is TextAsset && @object.name == "water")
			{
				return (@object as TextAsset).bytes;
			}
		}
		return null;
	}

	public Texture2D GetTexture(string name)
	{
		if (!string.IsNullOrEmpty(name))
		{
			Object[] assets = _assets;
			foreach (Object @object in assets)
			{
				if (@object is Texture2D && @object.name == name)
				{
					return @object as Texture2D;
				}
			}
		}
		return null;
	}

	public Cubemap GetCubemap(string name)
	{
		if (!string.IsNullOrEmpty(name))
		{
			Object[] assets = _assets;
			foreach (Object @object in assets)
			{
				if (@object is Cubemap && @object.name == name)
				{
					return @object as Cubemap;
				}
			}
		}
		return null;
	}

	public GameObject GetPrefab(string name)
	{
		if (!string.IsNullOrEmpty(name))
		{
			Object[] assets = _assets;
			foreach (Object @object in assets)
			{
				if (@object is GameObject && @object.name == name)
				{
					return @object as GameObject;
				}
			}
		}
		return null;
	}

	public void DestroyMapData()
	{
		Object @object = null;
		Object[] assets = _assets;
		foreach (Object object2 in assets)
		{
			if (object2 is TextAsset && object2.name == "model.bsp.raw")
			{
				@object = object2;
			}
		}
		if (!(@object != null))
		{
			return;
		}
		TextAsset obj = (TextAsset)@object;
		MonoBehaviourSingleton<GarbageDestoryer>.Instance.ResourceUnLoad(obj);
		List<Object> list = new List<Object>(_assets);
		for (int j = 0; j < list.Count; j++)
		{
			if (list[j] == null || list[j] == @object)
			{
				list.RemoveAt(j);
				j--;
			}
		}
		_assets = list.ToArray();
	}

	public string GetCombineData()
	{
		Object[] assets = _assets;
		foreach (Object @object in assets)
		{
			if (@object is TextAsset && @object.name == "Combine")
			{
				return (@object as TextAsset).text;
			}
		}
		return null;
	}
}
