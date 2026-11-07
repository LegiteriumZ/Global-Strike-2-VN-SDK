using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;
using NetData;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.GunFight;

[GameUiTest]
public class GunFightScoreCellModel : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/GunFight";
		_viewModel.ResourceAssetName = "GunFightIndividualScoreCell";
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		base.Listener.AddEvent<OneKillInfoData, long>("Score", UiIEventCondition.Get_OneKillInfoData_Score, SetPlayerScore, base.Index);
		base.Listener.AddEvent<OneKillInfoData, int>("FlagScore", UiIEventCondition.Get_OneKillInfoData_OpenPackNum, SetFlagScore, base.Index);
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
}
