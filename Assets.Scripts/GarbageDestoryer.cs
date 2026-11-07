using Assets.Sources.Utils.AssetManager;
using SSJJAsset.Asset;
using SSJJAsset.AssetBundle;
using SSJJBase.Singleton;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Scripts;

public class GarbageDestoryer : MonoBehaviourSingleton<GarbageDestoryer>
{
	public void ResourceUnLoad(Object obj)
	{
		Resources.UnloadAsset(obj);
	}

	public void RemoveLinker(AssetInfo assetInfo, bool isAlsoUnloadAb = false)
	{
		SingletonInstance<AssetPool>.Instance.Remove(assetInfo);
		if (isAlsoUnloadAb)
		{
			UnloadAssetBundle(assetInfo.BundleName);
		}
	}

	public void UnloadAssetBundle(string assetBundleName)
	{
		IgnoreCaseString assetBundleName2 = new IgnoreCaseString(assetBundleName);
		AssetBundleManager.UnloadAssetBundle(ref assetBundleName2);
	}
}
