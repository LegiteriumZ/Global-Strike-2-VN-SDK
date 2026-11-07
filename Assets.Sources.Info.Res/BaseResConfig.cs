using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Info.Res;

internal abstract class BaseResConfig
{
	private readonly AssetInfo _info;

	public AssetInfo Info => _info;

	protected BaseResConfig(string bundleName, string assetName)
	{
		_info = new AssetInfo(bundleName, assetName, typeof(GameObject));
	}
}
