using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.UiFramework.Example.Scripts;

internal class ExampleModel : AbstractModel
{
	private ExampleViewModel _viewModel = new ExampleViewModel();

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void OnGameobjectInitialized()
	{
		base.OnGameobjectInitialized();
		Init();
	}

	private void Init()
	{
		_viewModel.PlayFlyAnim();
	}

	public void Update()
	{
		if ((int)Time.time % 6 > 3)
		{
			_viewModel.PlayFlyAnim();
		}
		else
		{
			_viewModel.StopFlyAnim();
		}
	}
}
