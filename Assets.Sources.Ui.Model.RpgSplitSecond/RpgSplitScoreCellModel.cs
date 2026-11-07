using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;
using NetData;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.RpgSplitSecond;

[GameUiTest]
public class RpgSplitScoreCellModel : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/RpgSplitSecond";
		_viewModel.ResourceAssetName = "RpgSplitSecondAllKillInfoScoreCell";
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		base.Listener.AddEvent<OneKillInfoData, long>("Team", UiIEventCondition.Get_OneKillInfoData_Score, SetPlayerTeam, base.Index);
		base.Listener.AddEvent<OneKillInfoData, int>("PlayerLevel", UiIEventCondition.Get_OneKillInfoData_PlayerLv, SetPlayerLevel, base.Index);
	}

	private void SetPlayerTeam(OneKillInfoData val, int idx, long oldfs, long newfs, ElementStatus status)
	{
		_viewModel.PlayerDuiwuString = StringCache.LongToString(newfs);
	}

	private void SetPlayerLevel(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.PlayerLevelString = StringCache.IntToString(newfs);
	}
}
