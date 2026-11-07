using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using SSJJAnim.Parser;
using SSJJAsset.Asset;
using SSJJAsset.AssetManager;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Libs.SJAnimation.Parser;

public class SJAnimationLoader
{
	private SJAnimationAsset _result;

	private static LoggerAdapter _logger = new LoggerAdapter(typeof(SJAnimationLoader));

	private bool _loadFinish;

	private byte[] _data;

	public SJAnimationAsset Result => _result;

	public IEnumerator LoadAsync(AssetInfo assetInfo)
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync(assetInfo);
		if (loader.Result != null)
		{
			_data = loader.Result.bytes;
			Load(this);
			while (!_loadFinish)
			{
				yield return null;
			}
			Resources.UnloadAsset(loader.Result);
			loader.Result = null;
			_data = null;
		}
	}

	private static void Load(object context)
	{
		try
		{
			SJAnimationLoader sJAnimationLoader = (SJAnimationLoader)context;
			sJAnimationLoader._result = new SJAnimationAsset();
			List<ISJAnimationClip> clips = SJAnimationPaser.GenerateAnimations(sJAnimationLoader._data);
			sJAnimationLoader._result.Clips = clips;
			sJAnimationLoader._result.Length = sJAnimationLoader._data.Length;
			if (sJAnimationLoader._result == null)
			{
				_logger.Error("Failed to parse sjanimtion");
			}
			sJAnimationLoader._loadFinish = true;
			sJAnimationLoader._data = null;
		}
		catch (Exception message)
		{
			_logger.Error(message);
			throw;
		}
	}
}
