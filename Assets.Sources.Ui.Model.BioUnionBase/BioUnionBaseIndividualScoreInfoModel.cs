using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Ui.Model.BioUnionBase;

public class BioUnionBaseIndividualScoreInfoModel : CommonIndividualScoreInfoModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/biounionbase";
		_viewModel.ResourceAssetName = "BioUnionBaseIndividualScoreInfo";
		CellClass = typeof(BioUnionBasePlayerScoreCellModel);
	}

	protected override void SetMatchBack(bool ov, bool flag)
	{
		_viewModel.ResultBgShow = false;
	}

	protected override void SetPlayerNum(int idx)
	{
		_viewModel.PlayerNumberString = "人数：" + UiIEventCondition.Get_allKillInfo_AllCount() + "/" + UiIEventCondition.Get_uiRoomData_LimitNum();
	}
}
