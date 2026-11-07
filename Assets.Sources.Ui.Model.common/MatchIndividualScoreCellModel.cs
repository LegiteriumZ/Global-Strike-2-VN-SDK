using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils;
using Assets.Tests.PlayMode;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class MatchIndividualScoreCellModel : CommonIndividualScoreCellModel
{
	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/common";
		_viewModel.ResourceAssetName = "MatchIndividualScoreCell";
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		base.Listener.AddEvent<OneKillInfoData, int>("RankLv", UiIEventCondition.Get_OneKillInfoData_RankSect, SetRankSect, base.Index);
	}

	private void SetRankSect(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.PlayerRankHonorShow = false;
		base.Loader.RetriveSprite("ui/halfLoadedRes/playerRaceRankSect", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/playerRaceRankSect/raceranksect{newfs}.png", delegate(Sprite sprite)
		{
			_viewModel.PlayerRankHonorShow = true;
			_viewModel.PlayerRankHonorSprite = sprite;
		});
		_viewModel.PlayerRankHonorDesShow = true;
		int level = UiIEventCondition.Get_OneKillInfoData_RankLv(val, 0);
		_viewModel.PlayerRankHonorDesString = HonorUtility.GetRankLvName(newfs, level);
	}
}
