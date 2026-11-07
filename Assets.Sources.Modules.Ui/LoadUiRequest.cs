using System;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.Ui;

public class LoadUiRequest
{
	public delegate void LoadFinishDelegate(ref AssetInfo asset, UnityEngine.Object obj);

	private AssetInfo _assetInfo;

	private LoadFinishDelegate _afterLoading;

	private Action<UnityEngine.Object> _loadingAction;

	public AssetInfo AssetInfo => _assetInfo;

	public LoadUiRequest(AssetInfo assetInfo, LoadFinishDelegate action)
	{
		_assetInfo = assetInfo;
		_afterLoading = action;
		_loadingAction = null;
	}

	public LoadUiRequest(AssetInfo assetInfo, Action<UnityEngine.Object> action)
	{
		_assetInfo = assetInfo;
		_afterLoading = null;
		_loadingAction = action;
	}

	public void Invoke(UnityEngine.Object obj)
	{
		if (_afterLoading != null)
		{
			_afterLoading(ref _assetInfo, obj);
		}
		else if (_loadingAction != null)
		{
			_loadingAction(obj);
		}
	}
}
