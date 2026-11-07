using Assets.Sources.Constant.Career;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BigHead;

[GameUiTest]
public class BigheadIndividualScoreCellModel : CommonIndividualScoreCellModel
{
	private static AssetInfo _bighead1 = new AssetInfo("ui/halfloadedres/bigHead2", "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/bigHead2/3.png");

	private static AssetInfo _bighead2 = new AssetInfo("ui/halfloadedres/bigHead2", "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/bigHead2/4.png");

	private static AssetInfo _bighead3 = new AssetInfo("ui/halfloadedres/bigHead2", "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/bigHead2/5.png");

	protected static AssetInfo HeroAsset = new AssetInfo("ui/bigheadmodel", "Assets/Res/Assets/ui/GameGUIRes/bigheadModel/killList/hero.png");

	public static AssetInfo NurseAsset = new AssetInfo("ui/bigheadmodel", "Assets/Res/Assets/ui/GameGUIRes/bigheadModel/killList/wet.png");

	public static AssetInfo OverloadAsset = new AssetInfo("ui/bigheadmodel", "Assets/Res/Assets/ui/GameGUIRes/bigheadModel/killList/bigheadKing.png");

	public static AssetInfo TerminatorAsset = new AssetInfo("ui/bigheadmodel", "Assets/Res/Assets/ui/GameGUIRes/bigheadModel/killList/killBigheadKing.png");

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/bighead";
		_viewModel.ResourceAssetName = "BigheadIndividualScoreCell";
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		base.Listener.AddEvent<OneKillInfoData, int>("lv", UiIEventCondition.Get_OneKillInfoData_PlayerLv, SetLV, base.Index);
	}

	private void SetLV(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 126 && newfs > 2)
		{
			_viewModel.BigHeadImageShow = true;
			if (newfs == 3)
			{
				this.GetLoader().RetriveSprite(_bighead1, delegate(Sprite sprite)
				{
					_viewModel.BigHeadImageSprite = sprite;
				});
			}
			if (newfs == 4)
			{
				this.GetLoader().RetriveSprite(_bighead2, delegate(Sprite sprite)
				{
					_viewModel.BigHeadImageSprite = sprite;
				});
			}
			if (newfs == 5)
			{
				this.GetLoader().RetriveSprite(_bighead3, delegate(Sprite sprite)
				{
					_viewModel.BigHeadImageSprite = sprite;
				});
			}
		}
		else
		{
			_viewModel.BigHeadImageShow = false;
		}
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = StringCache.LongToString(data.Score);
		_viewModel.PlayerScoreString2 = StringCache.IntToString(data.KillNum);
		_viewModel.PlayerScoreString3 = StringCache.IntToString(data.BeKillNum);
		_viewModel.PlayerScoreString4 = StringCache.IntToString(data.TreatmentScore);
		_viewModel.PlayerScoreString5 = StringCache.IntToString(data.AssistsNum);
	}

	protected override void SetCareer(OneKillInfoData val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		_viewModel.CareerImageShow = !string.IsNullOrEmpty(newfs) && PlayerCareerConstantUtility.IsHero(newfs);
	}

	protected override int UpdateHonoray(OneKillInfoData data)
	{
		int index = 1;
		index = SetHonoray(data.Ace, index, ref CommonIndividualScoreCellModel.AceAsset);
		index = SetHonoray(data.Ace2, index, ref CommonIndividualScoreCellModel.Ace2Asset);
		index = SetHonoray(data.Ace3, index, ref CommonIndividualScoreCellModel.Ace3Asset);
		index = SetHonoray(data.KdKing, index, ref CommonIndividualScoreCellModel.KdKingAsset);
		index = SetHonoray(data.Mvp, index, ref CommonIndividualScoreCellModel.MvpAsset);
		index = SetHonoray(data.Nurse, index, ref NurseAsset);
		index = SetHonoray(data.Overload, index, ref OverloadAsset);
		return SetHonoray(data.Terminator, index, ref TerminatorAsset);
	}
}
