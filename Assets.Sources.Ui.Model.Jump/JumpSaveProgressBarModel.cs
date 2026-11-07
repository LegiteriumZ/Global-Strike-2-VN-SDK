using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Jump;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Jump;

public class JumpSaveProgressBarModel : AbstractModel, IPlaybackSystem
{
	private JumpsaveprogressbarViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new JumpsaveprogressbarViewModel();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_gameProgressData_ProgressTotalTime, SetProgressTotalTime, null, initinvoke: true);
	}

	private void SetProgressTotalTime(int arg1, int arg2)
	{
		_viewModel.PanelShow = arg2 > 0;
		_viewModel.ProgressFillamount = 0f;
		_viewModel.LightImagePosition = new Vector3(-246f, 0f);
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_viewModel.PanelShow)
			{
				_viewModel.ProgressFillamount = (float)UiIEventCondition.Get_gameProgressData_CurrentProgressTime() / (float)UiIEventCondition.Get_gameProgressData_ProgressTotalTime();
				_viewModel.LightImagePosition = new Vector3(-246f + _viewModel.ProgressFillamount * 492f, 0f);
			}
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
