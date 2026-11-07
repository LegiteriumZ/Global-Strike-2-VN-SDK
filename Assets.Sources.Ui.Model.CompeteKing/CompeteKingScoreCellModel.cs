using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;
using NetData;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.CompeteKing;

[GameUiTest]
public class CompeteKingScoreCellModel : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/CompeteKing";
		_viewModel.ResourceAssetName = "CompeteKingIndividualScoreCell";
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		base.Listener.AddEvent<OneKillInfoData, long>("Score", UiIEventCondition.Get_OneKillInfoData_Score, SetPlayerScore, base.Index);
		base.Listener.AddEvent<OneKillInfoData, int>("FlagScore", UiIEventCondition.Get_OneKillInfoData_OpenPackNum, SetFlagScore, base.Index);
		base.Listener.AddEvent<OneKillInfoData, bool>("CompeteKing", UiIEventCondition.Get_OneKillInfoData_CompeteKing, base.SetAce, base.Index);
	}

	private void SetPlayerScore(OneKillInfoData val, int idx, long oldfs, long newfs, ElementStatus status)
	{
		_viewModel.PlayerScoreString1 = StringCache.LongToString(newfs);
	}

	private void SetFlagScore(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.PlayerScoreString4 = StringCache.IntToString(newfs);
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString2 = data.KillNum.ToString();
		_viewModel.PlayerScoreString3 = data.BeKillNum.ToString();
	}

	protected override int UpdateHonoray(OneKillInfoData data)
	{
		UiIEventCondition.Get_uiMyPlayer_Team();
		int index = 1;
		index = SetHonoray(data.Ace, index, ref CommonIndividualScoreCellModel.AceAsset);
		index = SetHonoray(data.Ace2, index, ref CommonIndividualScoreCellModel.Ace2Asset);
		index = SetHonoray(data.Ace3, index, ref CommonIndividualScoreCellModel.Ace3Asset);
		index = SetHonoray(data.KdKing, index, ref CommonIndividualScoreCellModel.KdKingAsset);
		index = SetHonoray(data.Mvp, index, ref CommonIndividualScoreCellModel.MvpAsset);
		index = SetHonoray(data.MaxHidePack, index, ref CommonIndividualScoreCellModel.MaxHidePackAsset);
		index = SetHonoray(data.MaxOpenPack, index, ref CommonIndividualScoreCellModel.MaxOpenPackAsset);
		return SetHonoray(data.CompeteKing, index, ref CommonIndividualScoreCellModel.CompeteKingAsset);
	}
}
