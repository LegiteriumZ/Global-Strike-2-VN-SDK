using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalGameOverModel : CommonGameOverModel
{
	private static AssetInfo _winAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitywin.png");

	private static AssetInfo _loseAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/variantswin.png");

	protected override void UpdateGameOver()
	{
		CommongameoverViewModel viewModel = ViewModel as CommongameoverViewModel;
		if (viewModel == null)
		{
			return;
		}
		viewModel.PanelShow = true;
		viewModel.WinnerNameShow = false;
		if (UiIEventCondition.Get_gameOverData_IsWin())
		{
			viewModel.GameOverImageSprite = this.GetLoader().RetriveSprite(_winAsset, delegate(Sprite sprite)
			{
				viewModel.GameOverImageSprite = sprite;
				viewModel.GameOverImageNtvsize();
			});
		}
		else
		{
			viewModel.GameOverImageSprite = this.GetLoader().RetriveSprite(_loseAsset, delegate(Sprite sprite)
			{
				viewModel.GameOverImageSprite = sprite;
				viewModel.GameOverImageNtvsize();
			});
		}
		SetChips();
	}
}
