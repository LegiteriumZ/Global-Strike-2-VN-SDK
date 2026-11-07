using Assets.Sources.Framework;
using Assets.Sources.Ui.Model.Rpg;
using Assets.UiFramework.Libs;

namespace Assets.Sources.Ui.Model.AcgCommon;

public class AcgStateProgressModel : RpgStateProgressModel, IPlaybackSystem, ISetGameRuleContext, ISetBattleRoomContext
{
	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceAssetName = "AcgStateProgress";
		_viewModel.ResourceBundleName = "uiprefabs/AcgCommon";
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
