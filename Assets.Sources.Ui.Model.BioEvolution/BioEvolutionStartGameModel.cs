using System;
using Assets.Generated.Table;
using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.Sources.Utils.Sound;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioEvolution;

public class BioEvolutionStartGameModel : BiochemicalStartGameModel, ISetBattleRoomContext
{
	private BattleRoomContext _battleRoomContext;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	protected override void SetPassed(int ov, int passed)
	{
		BiochemicalstartgameViewModel viewModel = ViewModel as BiochemicalstartgameViewModel;
		if (viewModel == null)
		{
			return;
		}
		if (passed > 0)
		{
			int num = 20000 - passed;
			if (num >= 0)
			{
				viewModel.PanelShow = true;
				int num2 = (int)Math.Floor((double)num * 0.001);
				if (LastCount != num2)
				{
					LastCount = num2;
					base.Loader.RetriveSprite("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/gamestart.png", delegate(Sprite sprite)
					{
						viewModel.GameStartImageSprite = sprite;
						viewModel.GameStartImageNtvsize();
					});
					viewModel.TimeTextString = StringCache.IntToString(num2);
					if (LastCount >= 1 && LastCount <= 10)
					{
						MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/biogamestart", $"Assets/Res/Assets/sound/bioGameStart/{LastCount}.mp3"), GameSoundManager.Config.AsideVolume);
					}
				}
				return;
			}
		}
		viewModel.PanelShow = false;
	}
}
