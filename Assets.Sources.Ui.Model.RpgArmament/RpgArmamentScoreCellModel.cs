using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;
using NetData;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.RpgArmament;

[GameUiTest]
public class RpgArmamentScoreCellModel : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/RpgArmament";
		_viewModel.ResourceAssetName = "RpgArmamentAllKillInfoScoreCell";
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		base.Listener.AddEvent<OneKillInfoData, int>("PlayerLevel", UiIEventCondition.Get_OneKillInfoData_PlayerLv, SetPlayerLevel, base.Index);
	}

	private void SetPlayerScore(OneKillInfoData val, int idx, long oldfs, long newfs, ElementStatus status)
	{
		_viewModel.PlayerScoreString3 = StringCache.LongToString(newfs);
	}

	private void SetPlayerLevel(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.PlayerLevelString = StringCache.IntToString(newfs);
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = data.KillNum.ToString();
		_viewModel.PlayerScoreString2 = data.BeKillNum.ToString();
		_viewModel.PlayerScoreString3 = data.AssistsNum.ToString();
		_viewModel.PlayerDuiwuString = data.Score.ToString();
	}
}
