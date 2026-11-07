using System;
using SSJJAsset.Asset;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UiFramework.Libs;

public interface IUiResourcesLoader
{
	void Load(string bundleName, string assetName, Action<UnityEngine.Object> callback);

	void Load(string bundleName, string assetName, Action<UnityEngine.Object> callback, Type assetType);

	bool isLoading(AssetInfo info);

	Sprite RetriveSprite(AssetInfo info, Image img, bool autosetnative = false, bool autodefault = false);

	Sprite RetriveSprite(string bundleName, string assetName, Image img, bool autosetnative = false, bool autodefault = false);

	Sprite RetriveSprite(string bundleName, string assetName, Action<Sprite> callback = null);

	TextAsset GetConfig(string bundleName, string assetName, Action<TextAsset> callback = null);
}
