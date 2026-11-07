using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Sound;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZStartDesModel : AbstractModel, IPlaybackSystem
{
	private BioChemical_ZStartDesViewModel _viewModel;

	private ActiveChip _centerActiveChip = new ActiveChip();

	private int timer_audio = 10;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioChemical_ZStartDesViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(125, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].TypeId == -13529)
			{
				_centerActiveChip.Time = tipsEvent[i].Time2 - (_timeComponent.ServerTime - tipsEvent[i].Time1);
				timer_audio = 10;
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	private void InitChips()
	{
		_centerActiveChip.Time = 0;
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.ShowShow = _centerActiveChip.Update(time);
		if (_centerActiveChip.Time / 1000 < 26 && _centerActiveChip.Time > 0)
		{
			int num = _centerActiveChip.Time / 1000;
			_viewModel.T_showShow = true;
			int num2 = num / 10;
			int num3 = num % 10;
			base.Loader.RetriveSprite("ui/biochemical_z", $"Assets/Res/Assets/ui/GameGUIRes/biochemical_z/Other/{num2}.png", delegate(Sprite sprite1)
			{
				_viewModel.TimerSprite1 = sprite1;
			});
			_viewModel.TimerShow1 = num2 != 0;
			base.Loader.RetriveSprite("ui/biochemical_z", $"Assets/Res/Assets/ui/GameGUIRes/biochemical_z/Other/{num3}.png", delegate(Sprite sprite1)
			{
				_viewModel.TimerSprite2 = sprite1;
			});
			if (timer_audio == num && timer_audio > 0)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/biogamestart", $"Assets/Res/Assets/sound/bioGameStart/{timer_audio}.mp3"), GameSoundManager.Config.AsideVolume);
				timer_audio--;
			}
		}
		else
		{
			_viewModel.T_showShow = false;
		}
	}
}
