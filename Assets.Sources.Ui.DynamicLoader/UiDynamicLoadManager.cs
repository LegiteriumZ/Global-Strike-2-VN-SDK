using System;
using System.Collections.Generic;
using Assets.Sources.Modules.Ui;
using Assets.UiFramework.Libs;
using SSJJAsset.Asset;
using SSJJBase.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.DynamicLoader;

public class UiDynamicLoadManager : BattleSingletonInstance<UiDynamicLoadManager>
{
	public class LoadCounter
	{
		public bool IsUnRegister;

		public Action CallBackAction;

		public int CompleteCount;

		public int AllCount;

		public List<Image> CompleteCache = new List<Image>();

		public LoadCounter(int allCount)
		{
			AllCount = allCount;
		}

		public bool IsComplete()
		{
			return CompleteCount == AllCount;
		}

		public void Caculate(Image completeImage)
		{
			if (!CompleteCache.Contains(completeImage))
			{
				CompleteCache.Add(completeImage);
				CompleteCount++;
			}
			if (CompleteCount == AllCount && !IsUnRegister && CallBackAction != null)
			{
				CallBackAction();
			}
		}

		public void Register(Action callBAction)
		{
			IsUnRegister = false;
			CallBackAction = callBAction;
		}

		public void DoUnRegister()
		{
			IsUnRegister = true;
		}
	}

	private UiResourcesLoader _loader;

	public Dictionary<string, Dictionary<string, Image>> ImageCache = new Dictionary<string, Dictionary<string, Image>>();

	public Dictionary<string, LoadCounter> CompleteCache = new Dictionary<string, LoadCounter>();

	public void Init(IUiResourcesLoader loader)
	{
		if (_loader == null)
		{
			_loader = loader as UiResourcesLoader;
		}
	}

	public void InitDynLoader(string viewModeName, Transform tran)
	{
		if (!BattleSingletonInstance<UiAssetReferenceLoader>.Instance.AssetCache.ContainsKey(viewModeName))
		{
			return;
		}
		Dictionary<string, Image> dictionary = new Dictionary<string, Image>();
		foreach (KeyValuePair<string, AssetInfo> item in BattleSingletonInstance<UiAssetReferenceLoader>.Instance.AssetCache[viewModeName])
		{
			GameObject gameObject = tran.FindForeachByName(item.Key);
			if (gameObject != null)
			{
				dictionary.Add(item.Key, gameObject.GetComponent<Image>());
			}
		}
		ImageCache.Add(viewModeName, dictionary);
		CompleteCache.Add(viewModeName, new LoadCounter(dictionary.Count));
	}

	public void Register(string viewModeName, Action callback)
	{
		if (!BattleSingletonInstance<UiAssetReferenceLoader>.Instance.AssetCache.ContainsKey(viewModeName))
		{
			return;
		}
		Dictionary<string, AssetInfo> dictionary = BattleSingletonInstance<UiAssetReferenceLoader>.Instance.AssetCache[viewModeName];
		Dictionary<string, Image> dictionary2 = ImageCache[viewModeName];
		LoadCounter loadCounter = CompleteCache[viewModeName];
		loadCounter.Register(callback);
		if (loadCounter.IsComplete())
		{
			callback();
			return;
		}
		foreach (KeyValuePair<string, AssetInfo> item in dictionary)
		{
			Image image = null;
			if (!dictionary2.TryGetValue(item.Key, out image))
			{
				continue;
			}
			AssetInfo assetInfo = new AssetInfo(item.Value.BundleName, item.Value.AssetName);
			_loader.RetriveSprite(assetInfo, delegate(Sprite sprite)
			{
				if (image.sprite == null)
				{
					image.sprite = sprite;
				}
				CompleteCache[viewModeName].Caculate(image);
			});
		}
	}

	public void UnRegister(string viewModeName)
	{
		if (BattleSingletonInstance<UiAssetReferenceLoader>.Instance.AssetCache.ContainsKey(viewModeName) && CompleteCache.ContainsKey(viewModeName))
		{
			CompleteCache[viewModeName].DoUnRegister();
		}
	}

	public override void Clear()
	{
		foreach (Dictionary<string, Image> value in ImageCache.Values)
		{
			value.Clear();
		}
		ImageCache.Clear();
		CompleteCache.Clear();
		_loader = null;
	}
}
