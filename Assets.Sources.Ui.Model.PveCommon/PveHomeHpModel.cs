using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.PveCommon;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.PveCommon;

public class PveHomeHpModel : AbstractModel, IPlaybackSystem
{
	private PveHomeHpViewModel _viewModel;

	private int _time;

	private int _changeTime;

	private int _waitTime;

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
		_viewModel = new PveHomeHpViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_viewModel.ShowShow)
			{
				UpdateColor();
				UpdateEffect();
			}
		}
	}

	private void UpdateEffect()
	{
		_waitTime -= _timeComponent.FrameInterval;
		if (_waitTime <= 0)
		{
			float num = _viewModel.EffectFillamount - 0.0002f * (float)_timeComponent.FrameInterval;
			float progressFillamount = _viewModel.ProgressFillamount;
			_viewModel.EffectFillamount = ((num < progressFillamount) ? progressFillamount : num);
		}
	}

	private void UpdateColor()
	{
		_changeTime -= _timeComponent.FrameInterval;
		if (_changeTime >= 0)
		{
			_time += _timeComponent.FrameInterval;
			if (_time / 150 % 2 == 0)
			{
				_viewModel.ProgressColor = new Color(0.24f, 0.47f, 0.82f, 0.7f);
			}
			else
			{
				_viewModel.ProgressColor = new Color(0.4f, 0.84f, 0.99f, 0.7f);
			}
		}
		else
		{
			_viewModel.ProgressColor = new Color(0.57f, 0.21f, 0.78f, 0.7f);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_HomeHpPercent, SetHomeHpPercent, null, initinvoke: true);
	}

	private void SetHomeHpPercent(float ov, float percent)
	{
		if (percent > 0f && percent < 1f)
		{
			_showActiveChip.Time = 5000;
		}
		_viewModel.ProgressFillamount = percent;
		_changeTime = 1000;
		_waitTime = 100;
	}

	private void InitChips()
	{
		_showActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.ShowShow = _showActiveChip.Update(_timeComponent);
	}
}
