using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

internal class ModeTitleModel : AbstractModel, IPlaybackSystem
{
	private ModeTitleViewModel _viewModel = new ModeTitleViewModel();

	private ActiveChip _showActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_modeImageData_Changed, SetChanged, null, initinvoke: true);
		NotifyManager.MakeNotifyClass(14, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
	}

	private void SetChanged(RoomData ov, RoomData data)
	{
		if (data == null)
		{
			return;
		}
		_showActiveChip.Time = 3000;
		AssetInfo modeResourceConfigAssetInfo = UiAssetBundleUtils.GetModeResourceConfigAssetInfo(Contexts.sharedInstance.gameRule.currentRule.Rule.GetModeConfig);
		base.Loader.GetConfig(modeResourceConfigAssetInfo.BundleName, modeResourceConfigAssetInfo.AssetName, delegate(TextAsset textAsset)
		{
			if (!(textAsset == null))
			{
				ModeResourcesConfig modeResourcesConfig = ModeResourcesConfigParser.ParseConfig(textAsset.text);
				if (modeResourcesConfig.Inited && !string.IsNullOrEmpty(modeResourcesConfig.ModeImage))
				{
					if (UiIEventCondition.Get_uiMyPlayer_Team() == 2)
					{
						AssetInfo modeNameAssetInfo = UiAssetBundleUtils.GetModeNameAssetInfo(modeResourcesConfig.ModeTitleTeam2);
						_viewModel.TitleImageSprite = base.Loader.RetriveSprite("ui/halfloadedres/gameModeTitle", string.Concat("Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/gameModeTitle/", modeNameAssetInfo.AssetName, ".png"), delegate(Sprite sprite)
						{
							_viewModel.TitleImageSprite = sprite;
							_viewModel.TitleImageNtvsize();
						});
					}
					else
					{
						AssetInfo modeNameAssetInfo2 = UiAssetBundleUtils.GetModeNameAssetInfo(modeResourcesConfig.ModeTitleTeam1);
						_viewModel.TitleImageSprite = base.Loader.RetriveSprite("ui/halfloadedres/gameModeTitle", string.Concat("Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/gameModeTitle/", modeNameAssetInfo2.AssetName, ".png"), delegate(Sprite sprite)
						{
							_viewModel.TitleImageSprite = sprite;
							_viewModel.TitleImageNtvsize();
						});
					}
				}
			}
		});
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			RpgTipsEventData rpgTipsEventData = tipsEvent[i];
			if (rpgTipsEventData.TypeId == -13356)
			{
				_showActiveChip.Time = rpgTipsEventData.Time1;
				tipsEvent.Remove(rpgTipsEventData);
				break;
			}
		}
	}

	public void OnPlayback()
	{
		UpdateChips();
	}

	private void InitChips()
	{
		_showActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.ShowShow = _showActiveChip.Update(_timeComponent);
	}
}
