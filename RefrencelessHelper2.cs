using System;
using Assets.Sources.Modules.Ui;
using SSJJAsset.Asset;
using UnityEngine;
using UnityEngine.UI;

public class RefrencelessHelper2 : MonoBehaviour
{
	public string AssetPath;

	public string BundlePath;

	private UiResourcesLoader _loader;

	private bool _init;

	public void SetLoader(UiResourcesLoader loader)
	{
		_loader = loader;
	}

	public void Enable(Action callBack)
	{
		if (_init || _loader == null || string.IsNullOrEmpty(AssetPath) || string.IsNullOrEmpty(BundlePath))
		{
			callBack();
			return;
		}
		_init = true;
		AssetInfo assetInfo = new AssetInfo(BundlePath, AssetPath);
		Image image = GetComponent<Image>();
		_loader.RetriveSprite(assetInfo, delegate(Sprite sprite)
		{
			image.sprite = sprite;
			callBack();
		});
	}
}
