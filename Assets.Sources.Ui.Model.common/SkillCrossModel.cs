using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class SkillCrossModel : AbstractModel, IPlaybackSystem
{
	private SkillcrossViewModel _viewModel;

	private AlphaChip _lockCrossAlphaChip = new AlphaChip();

	private ScaleChip _lockCrossScaleChip = new ScaleChip();

	private RotationChip _crossBackRotationChip = new RotationChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new SkillcrossViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_Fov, SetFov, null, initinvoke: true);
	}

	private void SetFov(int arg1, int arg2)
	{
		if (arg2 != 90)
		{
			_viewModel.PanelShow = false;
		}
	}

	private void InitChips()
	{
		_lockCrossAlphaChip.Alpha = 0f;
		_lockCrossAlphaChip.Speed = 1f;
		_lockCrossScaleChip.Scale = new Vector3(2f, 2f, 2f);
		_lockCrossScaleChip.TargetScale = new Vector3(1f, 1f, 1f);
		_lockCrossScaleChip.Speed = new Vector3(1f, 1f, 0f);
		_crossBackRotationChip.Rotation = new Vector3(0f, 0f, 0f);
		_crossBackRotationChip.TargetRotation = new Vector3(0f, 0f, 360f);
		_crossBackRotationChip.Speed = new Vector3(0f, 0f, 360f);
	}

	private void UpdateChips()
	{
		_viewModel.LockCrossAlpha = _lockCrossAlphaChip.Update(_timeComponent);
		_viewModel.LockCrossScale = _lockCrossScaleChip.Update(_timeComponent);
		_viewModel.CrossBackRotation = _crossBackRotationChip.Update(_timeComponent);
	}
}
