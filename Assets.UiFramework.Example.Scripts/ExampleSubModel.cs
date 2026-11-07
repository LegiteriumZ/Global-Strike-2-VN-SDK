using System;
using Assets.UiFramework.Libs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.UiFramework.Example.Scripts;

internal class ExampleSubModel : AbstractModel
{
	private ExampleSubViewModel _viewModel = new ExampleSubViewModel();

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void OnGameobjectInitialized()
	{
		base.OnGameobjectInitialized();
		Init();
	}

	private void Init()
	{
		_viewModel.ShowMyImage = true;
		_viewModel.ShowMyText = true;
		ExampleSubViewModel viewModel = _viewModel;
		viewModel.OnMyButtonClickListener = (Action<BaseEventData>)Delegate.Combine(viewModel.OnMyButtonClickListener, (Action<BaseEventData>)delegate
		{
			if ((double)_viewModel.Progress > 0.99)
			{
				_viewModel.Progress = 0f;
			}
			_viewModel.Progress += 0.2f;
		});
	}

	public void Update()
	{
		_viewModel.CurrentTime = Time.time.ToString("00:00");
	}
}
