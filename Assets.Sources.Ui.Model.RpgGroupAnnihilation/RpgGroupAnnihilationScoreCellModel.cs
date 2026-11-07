using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;
using NetData;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.RpgGroupAnnihilation;

[GameUiTest]
public class RpgGroupAnnihilationScoreCellModel : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/RpgGroupAnnihilation";
		_viewModel.ResourceAssetName = "RpgGroupAnnihilationScoreCell";
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		base.Listener.AddEvent<OneKillInfoData, int>("Team", UiIEventCondition.Get_OneKillInfoData_Team, SetPlayerTeam, base.Index);
		base.Listener.AddEvent<OneKillInfoData, int>("PlayerLevel", UiIEventCondition.Get_OneKillInfoData_Lv, SetPlayerLevel, base.Index);
	}

	private void SetPlayerTeam(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.PlayerDuiwuString = StringCache.IntToString(newfs);
	}

	private void SetPlayerLevel(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.PlayerLevelString = StringCache.IntToString(newfs);
	}
}
