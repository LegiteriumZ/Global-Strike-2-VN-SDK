using System;
using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Utils.AssetManager;
using Assets.UiFramework.Libs;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJBase.Thread;
using SSJJRunTimeDataSample;
using SSJJUIEditor.RunTime;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Modules.Ui;

public class UiResourcesLoader : IResourceLoadSystem, IUiResourcesLoader, IUiEditorResourcesLoader
{
	private struct LoadResData : IEquatable<LoadResData>
	{
		public Image image;

		public bool setnativesize;

		public bool setdefault;

		public Vector2 oldsize;

		public LoadResData(Image img, bool sn, bool sd, Vector2 old)
		{
			image = img;
			setnativesize = sn;
			setdefault = sd;
			oldsize = old;
		}

		public bool Equals(LoadResData other)
		{
			if (image != other.image)
			{
				return false;
			}
			if (setnativesize != other.setnativesize)
			{
				return false;
			}
			if (setdefault != other.setdefault)
			{
				return false;
			}
			if (oldsize != other.oldsize)
			{
				return false;
			}
			return true;
		}
	}

	private readonly IAssetPool _assetPool;

	private readonly LinkedList<LoadUiRequest> _loadingAssets = new LinkedList<LoadUiRequest>();

	private Dictionary<AssetInfo, Sprite> _spriteDict = new Dictionary<AssetInfo, Sprite>();

	private Dictionary<AssetInfo, List<LoadResData>> _loadedImgs = new Dictionary<AssetInfo, List<LoadResData>>();

	private static Sprite _defaultSprite;

	public static Sprite DefaultSprite => _defaultSprite;

	public UiResourcesLoader(Contexts contexts)
	{
		_assetPool = contexts.battleRoom.assetPool.Pool;
	}

	public bool isLoading(AssetInfo info)
	{
		for (LinkedListNode<LoadUiRequest> linkedListNode = _loadingAssets.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
		{
			if (linkedListNode.Value.AssetInfo.Equals(info))
			{
				return true;
			}
		}
		return false;
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		LinkedListNode<LoadUiRequest> linkedListNode = _loadingAssets.First;
		while (linkedListNode != null)
		{
			LoadUiRequest value = linkedListNode.Value;
			object orNull = _assetPool.GetOrNull(value.AssetInfo);
			if (orNull != null || _assetPool.IsLoadFailed(value.AssetInfo))
			{
				if (orNull != null)
				{
					value.Invoke(orNull as UnityEngine.Object);
					if (SingletonInstance<DataSampleContexts>.Instance.GameObjectExistRefreshAction != null)
					{
						SingletonInstance<DataSampleContexts>.Instance.GameObjectExistRefreshAction(orNull as UnityEngine.Object, value.AssetInfo);
					}
				}
				else
				{
					_assetPool.IsLoadFailed(value.AssetInfo);
				}
				LinkedListNode<LoadUiRequest> node = linkedListNode;
				linkedListNode = linkedListNode.Next;
				_loadingAssets.Remove(node);
			}
			else
			{
				_assetPool.LoadAndAdd(value.AssetInfo, coRoutineManager);
				linkedListNode = linkedListNode.Next;
			}
		}
	}

	public void Load(LoadUiRequest request)
	{
		_loadingAssets.AddLast(request);
	}

	public void Load(string bundleName, string assetName, Action<UnityEngine.Object> callback)
	{
		LoadUiRequest request = new LoadUiRequest(new AssetInfo(bundleName, assetName), callback);
		Load(request);
	}

	public void Load(string bundleName, string assetName, Action<UnityEngine.Object> callback, Type assetType)
	{
		LoadUiRequest request = new LoadUiRequest(new AssetInfo(bundleName, assetName, assetType), callback);
		Load(request);
	}

	private void AddTex(ref AssetInfo assetInfo, object tex)
	{
		Sprite sprite = null;
		if (tex is Sprite)
		{
			sprite = tex as Sprite;
		}
		else if (tex is Texture2D)
		{
			sprite = Sprite.Create(tex as Texture2D, new Rect(0f, 0f, (tex as Texture2D).width, (tex as Texture2D).height), Vector2.zero);
		}
		_spriteDict[assetInfo] = sprite;
		SetImgInfo(ref assetInfo, sprite);
	}

	private bool SetImgInfo(ref AssetInfo assetInfo, Sprite spr)
	{
		if (_loadedImgs.TryGetValue(assetInfo, out var value))
		{
			foreach (LoadResData item in value)
			{
				if (item.image != null)
				{
					item.image.sprite = spr;
					if (item.setnativesize)
					{
						item.image.SetNativeSize();
					}
					else
					{
						item.image.rectTransform.sizeDelta = item.oldsize;
					}
				}
			}
			_loadedImgs.Remove(assetInfo);
			return true;
		}
		return false;
	}

	private void CallBack(Action<Sprite> callback, Sprite sprite)
	{
		callback?.Invoke(sprite);
	}

	public Sprite RetriveSprite(AssetInfo assetInfo, Action<Sprite> callback = null)
	{
		if (_defaultSprite == null)
		{
			Texture2D texture2D = new Texture2D(1, 1);
			texture2D.SetPixel(0, 0, Color.clear);
			texture2D.Apply();
			_defaultSprite = Sprite.Create(texture2D, new Rect(0f, 0f, 1f, 1f), Vector2.zero);
		}
		if (string.IsNullOrEmpty(assetInfo.BundleName) || string.IsNullOrEmpty(assetInfo.AssetName))
		{
			return _defaultSprite;
		}
		Sprite sprite = null;
		if (!_spriteDict.ContainsKey(assetInfo))
		{
			object tex = SingletonInstance<AssetPool>.Instance.GetOrNull(assetInfo);
			if (tex != null)
			{
				AddTex(ref assetInfo, tex);
				sprite = _spriteDict[assetInfo];
				CallBack(callback, sprite);
			}
			else
			{
				Load(new LoadUiRequest(assetInfo, delegate(ref AssetInfo loadassetinfo, UnityEngine.Object obj)
				{
					tex = obj;
					if (tex != null)
					{
						AddTex(ref loadassetinfo, tex);
						CallBack(callback, _spriteDict[loadassetinfo]);
					}
					else
					{
						this.LogErrorFormat("Asset type is illegal : {0}, should be Texture2D or Sprite", obj.GetType());
						CallBack(callback, null);
					}
				}));
			}
		}
		else
		{
			sprite = _spriteDict[assetInfo];
			SetImgInfo(ref assetInfo, sprite);
			CallBack(callback, sprite);
		}
		if (!_spriteDict.ContainsKey(assetInfo))
		{
			return _defaultSprite;
		}
		return _spriteDict[assetInfo];
	}

	public T GetAsset<T>(AssetInfo assetInfo, Action<T> callback = null) where T : UnityEngine.Object
	{
		object orNull = SingletonInstance<AssetPool>.Instance.GetOrNull(assetInfo);
		if (orNull != null)
		{
			if (callback != null)
			{
				callback(orNull as T);
			}
			return orNull as T;
		}
		Load(new LoadUiRequest(assetInfo, delegate(UnityEngine.Object obj)
		{
			if (callback != null)
			{
				callback(obj as T);
			}
		}));
		return null;
	}

	public TextAsset GetConfig(AssetInfo assetInfo, Action<TextAsset> callback = null)
	{
		return GetAsset(assetInfo, callback);
	}

	public TextAsset GetConfig(string bundleName, string assetName, Action<TextAsset> callback = null)
	{
		return GetConfig(new AssetInfo(bundleName, assetName), callback);
	}

	public Sprite RetriveSprite(AssetInfo assetInfo, Image img, bool autosetnative = false, bool autodefault = false)
	{
		if (_spriteDict.TryGetValue(assetInfo, out var value))
		{
			img.sprite = value;
			if (autosetnative)
			{
				img.SetNativeSize();
			}
			return value;
		}
		if (_loadedImgs.TryGetValue(assetInfo, out var value2))
		{
			value2.Add(new LoadResData(img, autosetnative, autodefault, img.rectTransform.sizeDelta));
		}
		else
		{
			_loadedImgs.Add(assetInfo, new List<LoadResData>
			{
				new LoadResData(img, autosetnative, autodefault, img.rectTransform.sizeDelta)
			});
		}
		if (autodefault)
		{
			img.rectTransform.sizeDelta = Vector2.zero;
		}
		return RetriveSprite(assetInfo);
	}

	public Sprite RetriveSprite(string bundleName, string assetName, Image img, bool autosetnative = false, bool autodefault = false)
	{
		AssetInfo assetInfo = default(AssetInfo);
		assetInfo.BundleName = new IgnoreCaseString(bundleName);
		assetInfo.AssetName = new IgnoreCaseString(assetName);
		AssetInfo assetInfo2 = assetInfo;
		if (_spriteDict.TryGetValue(assetInfo2, out var value))
		{
			img.sprite = value;
			if (autosetnative)
			{
				img.SetNativeSize();
			}
			return value;
		}
		if (_loadedImgs.TryGetValue(assetInfo2, out var value2))
		{
			value2.Add(new LoadResData(img, autosetnative, autodefault, img.rectTransform.sizeDelta));
		}
		else
		{
			_loadedImgs.Add(assetInfo2, new List<LoadResData>
			{
				new LoadResData(img, autosetnative, autodefault, img.rectTransform.sizeDelta)
			});
		}
		if (autodefault)
		{
			img.rectTransform.sizeDelta = Vector2.zero;
		}
		return RetriveSprite(assetInfo2);
	}

	public Sprite RetriveSprite(string bundleName, string assetName, bool v)
	{
		AssetInfo assetInfo = default(AssetInfo);
		assetInfo.BundleName = new IgnoreCaseString(bundleName);
		assetInfo.AssetName = new IgnoreCaseString(assetName);
		assetInfo.Optional = v;
		AssetInfo assetInfo2 = assetInfo;
		return RetriveSprite(assetInfo2);
	}

	public Sprite RetriveSprite(string bundleName, string assetName, Action<Sprite> callback = null)
	{
		AssetInfo assetInfo = default(AssetInfo);
		assetInfo.BundleName = new IgnoreCaseString(bundleName);
		assetInfo.AssetName = new IgnoreCaseString(assetName);
		assetInfo.Optional = false;
		AssetInfo assetInfo2 = assetInfo;
		return RetriveSprite(assetInfo2, callback);
	}

	private void AddTexByRef(ref AssetInfo assetInfo, object tex)
	{
		if (tex is Sprite)
		{
			_spriteDict[assetInfo] = tex as Sprite;
		}
		else if (tex is Texture2D)
		{
			_spriteDict[assetInfo] = Sprite.Create(tex as Texture2D, new Rect(0f, 0f, (tex as Texture2D).width, (tex as Texture2D).height), Vector2.zero);
		}
	}

	public Sprite RetriveSpriteByRef(ref AssetInfo assetInfo, Action<Sprite> callback = null)
	{
		if (_defaultSprite == null)
		{
			Texture2D texture2D = new Texture2D(1, 1);
			texture2D.SetPixel(0, 0, Color.clear);
			texture2D.Apply();
			_defaultSprite = Sprite.Create(texture2D, new Rect(0f, 0f, 1f, 1f), Vector2.zero);
		}
		if (string.IsNullOrEmpty(assetInfo.BundleName) || string.IsNullOrEmpty(assetInfo.AssetName))
		{
			return _defaultSprite;
		}
		if (!_spriteDict.ContainsKey(assetInfo))
		{
			object tex = SingletonInstance<AssetPool>.Instance.GetOrNull(assetInfo);
			if (tex != null)
			{
				AddTexByRef(ref assetInfo, tex);
				CallBack(callback, _spriteDict[assetInfo]);
				return _spriteDict[assetInfo];
			}
			AssetInfo info = assetInfo;
			Load(new LoadUiRequest(assetInfo, delegate(UnityEngine.Object obj)
			{
				tex = obj;
				if (tex != null)
				{
					AddTexByRef(ref info, tex);
					CallBack(callback, _spriteDict[info]);
				}
				else
				{
					this.LogErrorFormat("Asset type is illegal : {0}, should be Texture2D or Sprite", obj.GetType());
					CallBack(callback, null);
				}
			}));
			return _defaultSprite;
		}
		CallBack(callback, _spriteDict[assetInfo]);
		return _spriteDict[assetInfo];
	}
}
