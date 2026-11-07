using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Blast;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Blast;

public class C4StateProgressBarModel : AbstractModel, IPlaybackSystem
{
	private C4stateprogressbarViewModel _viewModel = new C4stateprogressbarViewModel();

	protected override IUiViewModel ViewModel => _viewModel;

	public void OnPlayback()
	{
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeNotify(11, UiIEventCondition.Get_gameProgressData_ProgressType, SetProgressType, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_gameProgressData_CurrentProgressTime, SetCurrentProgressTime, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_gameProgressData_ProgressTotalTime, SetProgressTotalTime, null, initinvoke: true);
	}

	private void SetProgressTotalTime(int arg1, int arg2)
	{
		UpdateProgress();
	}

	private void SetCurrentProgressTime(int arg1, int arg2)
	{
		UpdateProgress();
	}

	private void UpdateProgress()
	{
		if (UiIEventCondition.Get_gameProgressData_ProgressTotalTime() > 0)
		{
			float num = Mathf.Min((float)UiIEventCondition.Get_gameProgressData_CurrentProgressTime() / (float)UiIEventCondition.Get_gameProgressData_ProgressTotalTime(), 1f);
			_viewModel.ProgressFillamount = 0.57f * num;
			_viewModel.LightPosition = new Vector3(-146f + num * 290f, _viewModel.LightPosition.y);
		}
	}

	private void SetProgressType(ProgressType ov, ProgressType type)
	{
		if (UiIEventCondition.Get_gameProgressData_ProgressTotalTime() > 0)
		{
			switch (type)
			{
			case ProgressType.ACTIVE:
				_viewModel.PanelShow = true;
				_viewModel.ProgressTextTextcolor = Color.green;
				_viewModel.ProgressTextString = ScriptLocalization.Get("Placedc4");
				return;
			case ProgressType.DEMOLITION:
				_viewModel.PanelShow = true;
				_viewModel.ProgressTextTextcolor = Color.green;
				_viewModel.ProgressTextString = ScriptLocalization.Get("Dismantledc4");
				return;
			}
		}
		_viewModel.PanelShow = false;
	}
}
