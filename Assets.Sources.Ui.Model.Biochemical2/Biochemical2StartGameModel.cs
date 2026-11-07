using System;
using Assets.Generated.Table;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.Sources.Utils.Sound;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical2;

public class Biochemical2StartGameModel : AbstractModel, IPlaybackSystem
{
	private BiochemicalstartgameViewModel _viewModel = new BiochemicalstartgameViewModel();

	protected int LastCount;

	protected override IUiViewModel ViewModel => _viewModel;

	public void OnPlayback()
	{
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Passed, SetPassed, null, initinvoke: true);
	}

	private void SetPassed(int arg1, int arg2)
	{
		OnGameStart(arg2);
	}

	protected virtual void OnGameStart(int passed)
	{
		if (passed > 0)
		{
			long afterTime = GetAfterTime(passed);
			if (afterTime >= 0)
			{
				_viewModel.PanelShow = true;
				int num = (int)Math.Floor((double)afterTime * 0.001);
				if (LastCount != num)
				{
					LastCount = num;
					_viewModel.TimeTextString = LastCount.ToString();
					_viewModel.GameStartImageSprite = base.Loader.RetriveSprite("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/gamestart.png", delegate(Sprite v)
					{
						_viewModel.GameStartImageSprite = v;
						_viewModel.GameStartImageNtvsize();
					});
					if (LastCount >= 1 && LastCount <= 10)
					{
						MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/biogamestart", $"Assets/Res/Assets/sound/bioGameStart/{LastCount}.mp3"), GameSoundManager.Config.AsideVolume);
					}
				}
				return;
			}
		}
		_viewModel.PanelShow = false;
	}

	protected virtual long GetAfterTime(int passed)
	{
		return 25000 - passed;
	}
}
