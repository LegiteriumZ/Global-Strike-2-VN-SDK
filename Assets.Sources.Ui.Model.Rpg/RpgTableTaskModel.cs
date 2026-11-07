using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgTableTaskModel : AbstractModel, IPlaybackSystem
{
	private RpgTableTaskViewModel _viewModel;

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private int MaxNum = 8;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgTableTaskViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_notifyGroup.Add(NotifyManager.MakeNotifyClass(10, UiIEventCondition.Get_task_TaskList, SetTaskList, initinvoke: true));
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_allKillInfo_IndividualVisible, SetIndividualVisible, null, initinvoke: true);
		if (RuleUtilty.isCyberSpace(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType) || RuleUtilty.isHuntTre(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			MaxNum = 3;
		}
	}

	private void SetIndividualVisible(bool ov, bool flag)
	{
		_viewModel.PanelShow = flag;
		_notifyGroup.SetSuspend(!flag);
	}

	private void SetTaskList(List<TaskInfo> ov, List<TaskInfo> list)
	{
		int i;
		for (i = 1; i <= list.Count && i <= MaxNum; i++)
		{
			TaskInfo taskInfo = list[i - 1];
			_viewModel.SetTaskItemShow(i, value: true);
			_viewModel.SetCurCountString(i, StringCache.IntToString(taskInfo.Progress));
			_viewModel.SetTotalCountString(i, StringCache.IntToString(taskInfo.Total));
			_viewModel.SetTaskNameString(i, taskInfo.Name);
			_viewModel.SetProgressFillamount(i, (taskInfo.Total > 0) ? ((float)taskInfo.Progress / (float)taskInfo.Total) : 0f);
		}
		_viewModel.BgSize = new Vector3(250f, 30 + 60 * i);
		for (; i <= 10; i++)
		{
			_viewModel.SetTaskItemShow(i, value: false);
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
