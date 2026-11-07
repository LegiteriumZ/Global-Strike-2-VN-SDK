using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Blast;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Blast;

public class BlastModelC4Model : AbstractModel, IPlaybackSystem
{
	private Blastmodelc4ViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Blastmodelc4ViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_viewModel.C4IconActiveImageShow)
		{
			_viewModel.C4IconActiveImageAlpha -= (float)((double)_timeComponent.FrameInterval * 0.001);
			if (_viewModel.C4IconActiveImageAlpha <= 0f)
			{
				_viewModel.C4IconActiveImageAlpha = 1f;
			}
		}
		else
		{
			_viewModel.C4IconActiveImageAlpha = 1f;
		}
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_c4Message_C4Flag, SetC4Flag, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_c4Message_HasC4, SetHasC4, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_inBreakpoint_InBreakpoint, SetInBreakpoint, null, initinvoke: true);
	}

	private void SetC4Flag(bool arg1, bool arg2)
	{
		_viewModel.PliersImageShow = arg2;
	}

	private void SetHasC4(bool arg1, bool arg2)
	{
		_viewModel.C4IconImageShow = arg2;
		if (!arg2)
		{
			_viewModel.C4IconActiveImageShow = false;
		}
	}

	private void SetInBreakpoint(bool arg1, bool arg2)
	{
		_viewModel.C4IconActiveImageShow = arg2;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
