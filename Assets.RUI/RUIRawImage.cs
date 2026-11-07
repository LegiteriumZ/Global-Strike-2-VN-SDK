using System;
using System.Collections;
using Assets.Sources.Utils.AssetManager;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using SSJJUniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.RUI;

public class RUIRawImage : RawImage
{
	private IDisposable _subscribe;

	private AssetInfo _imageRes = AssetInfo.None;

	public AssetInfo ImageRes
	{
		get
		{
			return _imageRes;
		}
		set
		{
			if (!(_imageRes == value))
			{
				_imageRes = value;
				StartCoroutine(LoadImageRes());
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (base.texture == null)
		{
			Clear();
		}
	}

	private IEnumerator LoadImageRes()
	{
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(_imageRes, BaseAsyncManager.Instance);
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(_imageRes))
		{
			yield return null;
		}
		object orNull = SingletonInstance<AssetPool>.Instance.GetOrNull(_imageRes);
		if (orNull != null)
		{
			base.texture = orNull as Texture;
		}
		else
		{
			Clear();
		}
	}

	private void Clear()
	{
		base.texture = TextureUtility.GetTransparentTexture();
	}

	public void Subscribe<T>(IReactiveProperty<T> property, Action<T> onNext)
	{
		CancelSubscribe();
		_subscribe = property.Subscribe(onNext);
	}

	public void CancelSubscribe()
	{
		if (_subscribe != null)
		{
			_subscribe.Dispose();
			_subscribe = null;
		}
	}

	protected override void OnDestroy()
	{
		CancelSubscribe();
	}
}
