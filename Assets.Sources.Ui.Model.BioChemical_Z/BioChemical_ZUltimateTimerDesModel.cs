using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZUltimateTimerDesModel : AbstractModel, IPlaybackSystem
{
	private BioChemical_ZUltimateTimerDesViewModel _viewModel;

	private ActiveChip _centerActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioChemical_ZUltimateTimerDesViewModel();
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
		NotifyManager.MakeNotifyClass(125, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
		base.DoSubscribe();
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].TypeId == -13530)
			{
				_centerActiveChip.Time = tipsEvent[i].Time2 - (_timeComponent.ServerTime - tipsEvent[i].Time1);
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.ShowShow = _centerActiveChip.Update(time);
		_viewModel.timerString = string.Format("{0}:{1}", (_centerActiveChip.Time / 1000 / 60).ToString("00"), (_centerActiveChip.Time / 1000 % 60).ToString("00"));
	}
}
