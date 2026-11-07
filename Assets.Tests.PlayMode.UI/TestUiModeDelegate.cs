using System;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.Mode;
using Assets.UiFramework.Libs;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI;

public class TestUiModeDelegate<T> : IPlaybackSystem, IResourceInitSystem, IResourceLoadSystem where T : AbstractMode
{
	private readonly Contexts _contexts;

	private readonly UiResourcesLoader _resourcesLoader;

	private AbstractMode _uiMode;

	private TimeComponent _timeComponent;

	public TestUiModeDelegate(Contexts contexts)
	{
		_contexts = contexts;
		_resourcesLoader = new UiResourcesLoader(contexts);
		_timeComponent = contexts.time.time;
		AbstractModel.SetUiResourceLoader(_resourcesLoader);
	}

	public void OnInitResources()
	{
		if (_uiMode == null)
		{
			_uiMode = (T)Activator.CreateInstance(typeof(T), _contexts);
			_uiMode.Initialize();
		}
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		_resourcesLoader.OnLoadResources(coRoutineManager);
	}

	public void OnPlayback()
	{
		if (_uiMode != null)
		{
			_timeComponent.FrameInterval = (int)(Time.deltaTime * 1000f);
			_timeComponent.ClientRealTime += (int)(Time.deltaTime * 1000f);
			_uiMode.OnPlayback();
		}
	}
}
