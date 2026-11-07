using System.Collections;
using Assets.Scripts.BattleLoading;
using SSJJAsset.AssetBundle;
using SSJJBase.String;
using SSJJSceneLoader;
using UnityEngine;

namespace Assets.Tests;

public class TestPvs : MonoBehaviour
{
	public int MapId = 12;

	public bool RenderRealTime = true;

	private IEnumerator Start()
	{
		while (!GameController.Instance.InitFinish)
		{
			yield return null;
		}
		yield return LoadMap(MapId);
	}

	public IEnumerator LoadMap(int mapId)
	{
		IgnoreCaseString assetBundleName = new IgnoreCaseString("maps/map" + mapId);
		AssetBundleLoadAssetOperation operation = AssetBundleManager.LoadAllAssetsAsync(ref assetBundleName);
		yield return operation;
		SSJJMapLoader.ConvertMap(new MapAssetLoader(operation.GetAllAssets(), ""), RenderRealTime, null).transform.SetParent(base.transform, worldPositionStays: false);
	}
}
