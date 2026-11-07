using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Blast;

public class BlastGameOverModel : CommonGameOverModel
{
	private static AssetInfo _singleWinningAsset = new AssetInfo("ui/blastmodel", "Assets/Res/Assets/ui/GameGUIRes/blastModel/gameover/singledvictory.png");

	private static AssetInfo _amultiWinningAsset = new AssetInfo("ui/blastmodel", "Assets/Res/Assets/ui/GameGUIRes/blastModel/gameover/onewinmore.png");

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotify(50, UiIEventCondition.Get_blastMessageData_GameOverGuiChanged, SetGameOverGuiChanged, initinvoke: true);
	}

	private void SetGameOverGuiChanged(bool ov, bool flag)
	{
		if (!flag)
		{
			return;
		}
		CommongameoverViewModel viewModel = ViewModel as CommongameoverViewModel;
		if (viewModel == null)
		{
			return;
		}
		if (UiIEventCondition.Get_blastMessageData_Type() == C4MessageType.SINGLEDWINNING)
		{
			viewModel.GameOverImageSprite = ((UiResourcesLoader)base.Loader).RetriveSprite(_singleWinningAsset, delegate(Sprite sprite)
			{
				viewModel.GameOverImageSprite = sprite;
				viewModel.GameOverImageNtvsize();
			});
			GameOverTime = TimeUtility.UnixTimeNow();
			SetChips();
		}
		else if (UiIEventCondition.Get_blastMessageData_Type() == C4MessageType.AMULTIWIN)
		{
			viewModel.GameOverImageSprite = ((UiResourcesLoader)base.Loader).RetriveSprite(_amultiWinningAsset, delegate(Sprite sprite)
			{
				viewModel.GameOverImageSprite = sprite;
				viewModel.GameOverImageNtvsize();
			});
			GameOverTime = TimeUtility.UnixTimeNow();
			SetChips();
		}
	}
}
