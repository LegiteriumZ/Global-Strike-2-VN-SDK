using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgShieldBrokenModel : AbstractModel, IPlaybackSystem
{
	private RpgShieldBrokenViewModel _viewModel;

	private float _topY;

	private float _rightY;

	private float _leftY;

	private int _startTime;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgShieldBrokenViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!_viewModel.MaskRootshow)
		{
			return;
		}
		if (_startTime < 1000)
		{
			int frameInterval = _timeComponent.FrameInterval;
			_startTime += frameInterval;
			_viewModel.TopImagePosition += new Vector3(0f, -frameInterval);
			_viewModel.LeftImagePosition += new Vector3(0f, -frameInterval);
			_viewModel.RightImagePosition += new Vector3(0f, -frameInterval);
			Color maskColor = _viewModel.MaskColor;
			if (_startTime < 500)
			{
				maskColor.a -= 0.0015f * (float)frameInterval;
			}
			else
			{
				maskColor.a = 0f;
			}
			_viewModel.MaskColor = maskColor;
		}
		else
		{
			_viewModel.MaskRootshow = false;
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.MaskRootshow = false;
		_topY = _viewModel.TopImagePosition.y;
		_rightY = _viewModel.RightImagePosition.y;
		_leftY = _viewModel.LeftImagePosition.y;
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_AngryFireScarSkillShifang, SetAngryFireScarSkillShifang, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_ShieldHp, SetShieldHp, null, initinvoke: true, isFrameSeparation: true);
	}

	private void SetShieldHp(long ov, long hp)
	{
		if (hp <= 0)
		{
			_viewModel.TopImagePosition = new Vector3(_viewModel.TopImagePosition.x, _topY);
			_viewModel.LeftImagePosition = new Vector3(_viewModel.LeftImagePosition.x, _leftY);
			_viewModel.RightImagePosition = new Vector3(_viewModel.RightImagePosition.x, _rightY);
			_viewModel.MaskColor = new Color(1f, 1f, 1f, 0.75f);
			_startTime = 0;
			_viewModel.MaskRootshow = false;
			_viewModel.MaskRootshow = true;
		}
		else
		{
			_viewModel.MaskColor = new Color(1f, 1f, 1f, 0f);
		}
	}

	private void SetAngryFireScarSkillShifang(bool ov, bool flag)
	{
		if (flag)
		{
			_viewModel.MaskColor = new Color(1f, 1f, 1f, 0f);
			_startTime = 1000;
			_viewModel.MaskRootshow = false;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
