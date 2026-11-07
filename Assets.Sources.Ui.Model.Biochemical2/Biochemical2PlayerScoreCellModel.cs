using Assets.Sources.Ui.Model.Biochemical;

namespace Assets.Sources.Ui.Model.Biochemical2;

public class Biochemical2PlayerScoreCellModel : BiochemicalPlayerScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/biochemical2";
		_viewModel.ResourceAssetName = "Biochemical2PlayerScoreCell";
	}
}
