using Assets.Sources.Constant.Career;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Utils.Ui;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalPlayerScoreCellModel : CommonIndividualScoreCellModel
{
	private static AssetInfo _dounAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/killList/doun.png");

	private static AssetInfo _maternalAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/killList/maternal.png");

	private static AssetInfo _useItemMaternalAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/killList/useItemMaternal.png");

	private static AssetInfo _heroAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/killList/hero.png");

	private static AssetInfo _dominateAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/dominate.png");

	private static AssetInfo _survivorAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/survivor.png");

	private static AssetInfo _spreeAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/killList/spree.png");

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/biochemical";
		_viewModel.ResourceAssetName = "Biochemicalplayerscorecell";
	}

	protected override void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = data.Score.ToString();
		_viewModel.PlayerScoreString2 = data.BeKillNum.ToString();
	}

	protected override void SetCareer(OneKillInfoData val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		if (string.IsNullOrEmpty(newfs))
		{
			_viewModel.CareerImageShow = false;
		}
		else if (PlayerCareerConstantUtility.IsDoun(newfs))
		{
			_viewModel.CareerImageShow = true;
			this.GetLoader().RetriveSprite(_dounAsset, delegate(Sprite sprite)
			{
				_viewModel.CareerImageSprite = sprite;
			});
		}
		else if (PlayerCareerConstantUtility.IsEmpress(newfs))
		{
			_viewModel.CareerImageShow = true;
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(val.Id);
			if (entityWithEntityId != null && entityWithEntityId.hasSkill && entityWithEntityId.skill.Status.ContainsKey(PlayerInfoStatusConstant.BIOTEIM_ID_814.ID))
			{
				this.GetLoader().RetriveSprite(_useItemMaternalAsset, delegate(Sprite sprite)
				{
					_viewModel.CareerImageSprite = sprite;
				});
			}
			else
			{
				this.GetLoader().RetriveSprite(_maternalAsset, delegate(Sprite sprite)
				{
					_viewModel.CareerImageSprite = sprite;
				});
			}
		}
		else if (PlayerCareerConstantUtility.IsHero(newfs))
		{
			_viewModel.CareerImageShow = true;
			this.GetLoader().RetriveSprite(_heroAsset, delegate(Sprite sprite)
			{
				_viewModel.CareerImageSprite = sprite;
			});
		}
		else
		{
			_viewModel.CareerImageShow = false;
		}
	}

	protected override int UpdateHonoray(OneKillInfoData data)
	{
		int index = 1;
		index = SetHonoray(data.Ace, index, ref _dominateAsset);
		index = SetHonoray(data.Ace2, index, ref _survivorAsset);
		return SetHonoray(data.Ace3, index, ref _spreeAsset);
	}
}
