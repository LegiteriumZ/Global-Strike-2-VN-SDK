using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Tests.PlayMode;
using NetData;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.BroadSword;

[GameUiTest]
public class BroadSwordScoreCellModel : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/BroadSword";
		_viewModel.ResourceAssetName = "BroadSwordIndividualScoreCell";
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		base.Listener.AddEvent<OneKillInfoData, int>("PlayerLevel", UiIEventCondition.Get_OneKillInfoData_PlayerLv, SetPlayerLevel, base.Index);
	}

	private void SetPlayerLevel(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.PlayerLevelString = StringCache.IntToString(newfs);
	}
}
