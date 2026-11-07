using System;
using Assets.UiFramework.Libs;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using SSJJAsset.Asset;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UiFramework.Example.Scripts;

public class Main : MonoBehaviour
{
	private class Loader : IUiResourcesLoader
	{
		public void Load(string bundle, string name, Action<UnityEngine.Object> callback)
		{
			UnityEngine.Object obj = Resources.Load(name);
			callback(obj);
		}

		public TextAsset GetConfig(string bundle, string asset, Action<TextAsset> callback = null)
		{
			return Resources.Load<TextAsset>(asset);
		}

		public Sprite RetriveSprite(string bundle, string asset, Action<Sprite> callback = null)
		{
			Texture2D texture2D = Resources.Load<Texture2D>(asset);
			return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), Vector2.zero);
		}

		public void Load(string bundleName, string assetName, Action<UnityEngine.Object> callback, Type assetType)
		{
			UnityEngine.Object obj = Resources.Load(assetName);
			callback(obj);
		}

		public Sprite RetriveSprite(string bundleName, string assetName, Image img)
		{
			img.sprite = RetriveSprite(bundleName, assetName);
			return img.sprite;
		}

		public bool isLoading(AssetInfo info)
		{
			throw new NotImplementedException();
		}

		public Sprite RetriveSprite(AssetInfo info, Image img, bool autosetnative = false, bool autodefault = false)
		{
			throw new NotImplementedException();
		}

		public Sprite RetriveSprite(string bundleName, string assetName, Image img, bool autosetnative = false)
		{
			throw new NotImplementedException();
		}

		public Sprite RetriveSprite(string bundleName, string assetName, Image img, bool autosetnative = false, bool autodefault = false)
		{
			throw new NotImplementedException();
		}
	}

	private ExampleModel _exampleModel;

	private ExampleSubModel _exampleSubModel;

	private void Awake()
	{
		InitLoxodon();
		AbstractModel.SetUiResourceLoader(new Loader());
		_exampleModel = new ExampleModel();
		_exampleSubModel = new ExampleSubModel();
		_exampleModel.Initialize();
		_exampleSubModel.Initialize();
	}

	private void InitLoxodon()
	{
		new BindingServiceBundle(Context.GetApplicationContext().GetContainer()).Start();
	}

	public void Update()
	{
		_exampleModel.Update();
		_exampleSubModel.Update();
	}
}
