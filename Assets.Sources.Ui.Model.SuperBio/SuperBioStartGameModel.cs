using System;
using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.Sources.Utils.Ui;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.SuperBio;

public class SuperBioStartGameModel : BiochemicalStartGameModel
{
	private const int Supertimecomeon = 50;

	private const int Supertime = 40;

	private const int Nightmarecomeon = 115;

	private const int Nightmaretime = 105;

	private static AssetInfo _gamestartAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/gamestart.png");

	private static AssetInfo _waitsupertimecomeonAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/waitsupertimecomeon.png");

	private static AssetInfo _waitnightmaretimecomeonAsset = new AssetInfo("ui/superbiomodel", "Assets/Res/Assets/ui/GameGUIRes/superbioModel/message/waitnightmaretimecomeon.png");

	private AssetInfo _currAsset;

	protected override void SetPassed(int ov, int passed)
	{
		BiochemicalstartgameViewModel viewModel = ViewModel as BiochemicalstartgameViewModel;
		if (viewModel == null)
		{
			return;
		}
		viewModel.PanelShow = false;
		if (passed <= 0)
		{
			return;
		}
		long num = 15000 - passed;
		if (num >= 0)
		{
			viewModel.PanelShow = true;
			if (_currAsset != _gamestartAsset)
			{
				_currAsset = _gamestartAsset;
				this.GetLoader().RetriveSprite(_gamestartAsset, delegate(Sprite sprite)
				{
					viewModel.GameStartImageSprite = sprite;
					viewModel.GameStartImageNtvsize();
				});
			}
			viewModel.TimeTextString = string.Concat(Math.Floor((double)num * 0.001));
		}
		else if (num > 40 && num < 50)
		{
			viewModel.PanelShow = true;
			if (_currAsset != _waitsupertimecomeonAsset)
			{
				this.GetLoader().RetriveSprite(_waitsupertimecomeonAsset, delegate(Sprite sprite)
				{
					viewModel.GameStartImageSprite = sprite;
					viewModel.GameStartImageNtvsize();
				});
			}
			viewModel.TimeTextString = string.Concat(Math.Floor((double)num * 0.001 - 40.0));
		}
		else if (num > 105 && num < 115)
		{
			viewModel.PanelShow = true;
			if (_currAsset != _waitnightmaretimecomeonAsset)
			{
				this.GetLoader().RetriveSprite(_waitnightmaretimecomeonAsset, delegate(Sprite sprite)
				{
					viewModel.GameStartImageSprite = sprite;
					viewModel.GameStartImageNtvsize();
				});
			}
			viewModel.TimeTextString = string.Concat(Math.Floor((double)num * 0.001 - 105.0));
		}
		else
		{
			viewModel.PanelShow = false;
		}
	}
}
