using System.Collections;
using SSJJAsset.AssetManager;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Tests;

public class TestLoadAsset : MonoBehaviour
{
	public string bundleName;

	public string assetName;

	public void Load()
	{
		if (GameController.Instance.InitFinish)
		{
			BaseAsyncManager.Instance.StartCoRoutine(SingleLoad());
		}
	}

	private IEnumerator SingleLoad()
	{
		AssetAsyncLoader<GameObject> loader = new AssetAsyncLoader<GameObject>();
		yield return loader.LoadAsync(bundleName, assetName);
		loader.Instantiate();
	}
}
