using Assets.Sources.Ui.Model.Common;
using NetData;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioUnionBase;

public class BioUnionBasePlayerScoreCellModel : CommonIndividualScoreCellModel
{
	private static AssetInfo _dominateAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/dominate.png");

	private static AssetInfo _survivorAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/survivor.png");

	private static AssetInfo _spreeAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/spree.png");

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/biounionbase";
		_viewModel.ResourceAssetName = "BioUnionBaseIndividualScoreCell";
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = data.KillNum.ToString();
		_viewModel.PlayerScoreString2 = data.BeKillNum.ToString();
		Vector3 position = _viewModel.oPlayerName.transform.position;
		position.Set(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y), Mathf.FloorToInt(position.z));
		_viewModel.oPlayerName.transform.position = position;
	}

	protected override int UpdateHonoray(OneKillInfoData data)
	{
		int index = 1;
		index = SetHonoray(data.Ace, index, ref _dominateAsset);
		index = SetHonoray(data.Ace2, index, ref _survivorAsset);
		return SetHonoray(data.Ace3, index, ref _spreeAsset);
	}
}
