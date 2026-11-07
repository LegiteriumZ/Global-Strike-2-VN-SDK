using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.Sources.Utils.UIChip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Extensions;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Pve;

public class DiestrikeuitrasonicModel : AbstractModel, IPlaybackSystem
{
	private DiestrikeuitrasonicViewModel _viewModel;

	private const float MaxAlpha = 0.45f;

	private const int HideTime = 5000;

	private Time3Rangefloat _alphachip = new Time3Rangefloat();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new DiestrikeuitrasonicViewModel();
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
		NotifyManager.MakeNotify(54, UiIEventCondition.Get_pveState_UltrasonicTime, SetUltrasonicTime, initinvoke: true);
	}

	private void InitChips()
	{
		_alphachip.Start = 0f;
		_alphachip.MidStart = 200f;
		_alphachip.MidEnd = 300f;
		_alphachip.Target = 800f;
		_alphachip.Time = 5000f;
		_alphachip.Step = 1f;
	}

	private void UpdateChips()
	{
		if (_alphachip.Time < 5000f && _viewModel.diestrikeuitrasonicShow)
		{
			Color backimgColor = _viewModel.backimgColor;
			backimgColor.a = _alphachip.Update(_timeComponent) * 0.45f;
			_viewModel.backimgColor = backimgColor;
		}
		else
		{
			SetVisible(show: false);
		}
	}

	private void SetUltrasonicTime(int ov, int value)
	{
		if (value == 5000)
		{
			SetVisible(show: true);
			_alphachip.Time = 5000f;
		}
	}

	private void SetVisible(bool show)
	{
		if (_viewModel.diestrikeuitrasonicShow != show)
		{
			if (show)
			{
				_viewModel.diestrikeuitrasonicObj.HideEverythingExceptGameObject();
			}
			else
			{
				_viewModel.diestrikeuitrasonicObj.RecoveryEverything();
			}
		}
		_viewModel.diestrikeuitrasonicShow = show;
	}
}
