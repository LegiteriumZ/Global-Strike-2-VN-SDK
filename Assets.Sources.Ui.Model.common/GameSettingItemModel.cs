using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class GameSettingItemModel : AbstractModel, IPlaybackSystem
{
	private GameSettingItemViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public GameObject Container { get; set; }

	public new GameSettingItemViewModel GetViewModel()
	{
		return _viewModel;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new GameSettingItemViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ViewGameObject.transform.SetParent(Container.transform);
		base.DoSubscribe();
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
