using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgXpSkillModel : AbstractModel, IPlaybackSystem
{
	private RpgXpSkillViewModel _viewModel;

	private int _type;

	private int _time;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgXpSkillViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!_viewModel.ShowShow)
		{
			return;
		}
		_time += _timeComponent.FrameInterval;
		if (_type == 1)
		{
			Color blueColor = _viewModel.BlueColor;
			_viewModel.BlueShow = true;
			_viewModel.WhiteShow = false;
			if (_time < 300)
			{
				blueColor.a = 0.25f * (float)_time / 300f;
				_viewModel.BlueColor = blueColor;
			}
			else if (_time < 500)
			{
				blueColor.a = 0.25f + 0.75f * (float)(_time - 300) / 200f;
				_viewModel.BlueColor = blueColor;
			}
			else if (_time < 3000)
			{
				blueColor.a = 0.1f;
				_viewModel.BlueColor = blueColor;
			}
			else
			{
				_viewModel.ShowShow = false;
			}
		}
		else if (_type == 2)
		{
			_viewModel.BlueShow = true;
			_viewModel.WhiteShow = true;
			if (_time < 200)
			{
				Color blueColor2 = _viewModel.BlueColor;
				blueColor2.a = 0.1f - 0.1f * (float)_time / 200f;
				_viewModel.BlueColor = blueColor2;
				blueColor2 = _viewModel.WhiteColor;
				blueColor2.a = 0.9f - 0.9f * (float)_time / 200f;
				_viewModel.WhiteColor = blueColor2;
			}
			else
			{
				_viewModel.ShowShow = false;
			}
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ShowShow = false;
		base.DoSubscribe();
		NotifyManager.MakeNotify(8, UiIEventCondition.Get_uiSkill_RpgXpShifang, SetRpgXpShifang);
		NotifyManager.MakeNotify(9, UiIEventCondition.Get_uiSkill_RpgXpMingzhong, SetRpgXpMingzhong);
	}

	private void SetRpgXpShifang(bool ov, bool flag)
	{
		if (flag)
		{
			_time = 0;
			_type = 1;
			_viewModel.ShowShow = true;
		}
	}

	private void SetRpgXpMingzhong(bool ov, bool flag)
	{
		if (flag)
		{
			_time = 0;
			_type = 2;
			_viewModel.ShowShow = true;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
