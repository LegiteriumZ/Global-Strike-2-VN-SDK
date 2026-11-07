using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.PveCommon;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.PveCommon;

public class PveMaskModel : AbstractModel, IPlaybackSystem
{
	private PveMaskViewModel _viewModel;

	private ActiveChip _imageActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PveMaskViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_viewModel.ImageShow)
		{
			if (_imageActiveChip.Time > 4800)
			{
				_viewModel.ImageAlpha = (float)(5000 - _imageActiveChip.Time) / 200f * 0.45f;
			}
			else if (_imageActiveChip.Time <= 4700 && _imageActiveChip.Time > 4200)
			{
				_viewModel.ImageAlpha = (float)(_imageActiveChip.Time - 4200) / 500f;
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_EventUltrasonic, SetEventUltrasonic, null, initinvoke: true);
	}

	private void SetEventUltrasonic(bool ov, bool flag)
	{
		if (flag)
		{
			_imageActiveChip.Time = 5000;
		}
	}

	private void InitChips()
	{
		_imageActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.ImageShow = _imageActiveChip.Update(_timeComponent);
	}
}
