using SSJJSceneLoader;
using UnityEngine;

namespace Assets.Tests.LookScene;

internal class LookSceneLoader : IMapAssetLoader
{
	public Texture2D GetTexture(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		foreach (SceneTextureData pixture in LookSceneManager.Instance.PixtureList)
		{
			Texture2D texture = pixture.texture;
			if ((object)texture != null && pixture.name == name)
			{
				return texture;
			}
		}
		return null;
	}

	public byte[] GetMapData()
	{
		return LookSceneManager.Instance.RealModelBytesData;
	}

	public void DestroyMapData()
	{
	}

	public byte[] GetBloomConfigData()
	{
		return null;
	}

	public string GetCombineData()
	{
		return null;
	}

	public Cubemap GetCubemap(string name)
	{
		return null;
	}

	public GameObject GetPrefab(string name)
	{
		return null;
	}

	public string GetSceneEffectConfigData()
	{
		return null;
	}

	public string GetSceneFogEffectConfigData()
	{
		return null;
	}

	public string GetSceneHomeGunGridConfigData()
	{
		return null;
	}

	public string GetSceneU3DConfigData()
	{
		return null;
	}

	public byte[] GetSceneWaterConfigData()
	{
		return null;
	}
}
