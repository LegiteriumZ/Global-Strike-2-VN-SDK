using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;
using NetData;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.RpgStealExpert;

[GameUiTest]
public class RpgStealExpertScoreCellMode : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/RpgStealExpert";
		_viewModel.ResourceAssetName = "RpgStealExpertAllKillInfoScoreCell";
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		base.Listener.AddEvent<OneKillInfoData, long>("Score", UiIEventCondition.Get_OneKillInfoData_Score, SetPlayerScore, base.Index);
		base.Listener.AddEvent<OneKillInfoData, int>("PlayerLevel", UiIEventCondition.Get_OneKillInfoData_PlayerLv, SetPlayerLevel, base.Index);
		base.Listener.AddEvent<OneKillInfoData, int>("Team", UiIEventCondition.Get_OneKillInfoData_Team, SetPlayerTeam, base.Index);
	}

	private void SetPlayerScore(OneKillInfoData val, int idx, long oldfs, long newfs, ElementStatus status)
	{
		_viewModel.PlayerDuiwuString = StringCache.LongToString(newfs);
	}

	private void SetPlayerLevel(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.PlayerLevelString = StringCache.IntToString(newfs);
	}

	private void SetPlayerTeam(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.PlayerScoreString3 = StringCache.IntToString(newfs);
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = data.KillNum.ToString();
		_viewModel.PlayerScoreString2 = data.AssistsNum.ToString();
	}
}
