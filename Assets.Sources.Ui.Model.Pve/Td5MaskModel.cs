using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.Sources.Utils.UIChip;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Pve;

public class Td5MaskModel : AbstractModel, IPlaybackSystem
{
	private Td5maskViewModel _viewModel;

	private TimeRangeInt _activechip = new TimeRangeInt();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Td5maskViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited && UiIEventCondition.Get_pveUIMessage_MaxSpiderEggNum() != 0 && UiIEventCondition.Get_pveUIMessage_CurSpiderEggNum() == UiIEventCondition.Get_pveUIMessage_MaxSpiderEggNum())
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.td5maskShow = false;
	}

	private void InitChips()
	{
		_activechip.Step = 1f;
		_activechip.Start = 0;
		_activechip.Mid = 700;
		_activechip.Target = 4000;
		_activechip.Time = 4000f;
	}

	private void UpdateChips()
	{
		_viewModel.td5maskShow = _activechip.Update(_timeComponent);
		if (_viewModel.td5maskShow)
		{
			if (_activechip.Time <= 1000f)
			{
				Color maskImgColor = _viewModel.maskImgColor;
				maskImgColor.a = (_activechip.Time - 700f) / 300f;
				_viewModel.maskImgColor = maskImgColor;
			}
			else if (_activechip.Time > 2000f)
			{
				Color maskImgColor2 = _viewModel.maskImgColor;
				maskImgColor2.a = 1f - (_activechip.Time - 2000f) / 300f;
				_viewModel.maskImgColor = maskImgColor2;
			}
			else
			{
				Color maskImgColor3 = _viewModel.maskImgColor;
				maskImgColor3.a = 1f;
				_viewModel.maskImgColor = maskImgColor3;
			}
		}
	}
}
