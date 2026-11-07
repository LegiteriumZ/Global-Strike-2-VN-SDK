using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgDialogueModel : AbstractModel, IPlaybackSystem
{
	private RpgDialogueViewModel _viewModel;

	private List<PlotDialogData> _list = new List<PlotDialogData>();

	private int _updateTime;

	private ActiveChip _showActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgDialogueViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		_updateTime -= _timeComponent.FrameInterval;
		if (_list.Count > 0 && _updateTime <= 0)
		{
			PlotDialogData plotDialogData = _list[0];
			_list.RemoveAt(0);
			_updateTime = plotDialogData.ShowTime + plotDialogData.NextTime;
			_showActiveChip.Time = plotDialogData.ShowTime;
			_viewModel.NameString = plotDialogData.PlayerName;
			_viewModel.ContextString = plotDialogData.Context;
			_viewModel.IconSprite = base.Loader.RetriveSprite("ui/halfloadedres/bossTitle", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/bossTitle/" + plotDialogData.PlayerIcon + ".png", delegate(Sprite sprite)
			{
				_viewModel.IconSprite = sprite;
			});
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_dialogue_PlotData, SetPlotData, null, initinvoke: true);
	}

	private void SetPlotData(PlotData ov, PlotData data)
	{
		if (data != null)
		{
			_list.Clear();
			for (int i = 0; i < data.PlotDialogDataList.Count; i++)
			{
				_list.Add(data.PlotDialogDataList[i]);
			}
			_updateTime = 0;
		}
	}

	private void InitChips()
	{
		_showActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.ShowRootshow = _showActiveChip.Update(_timeComponent);
	}
}
