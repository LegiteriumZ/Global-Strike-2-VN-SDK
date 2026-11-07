using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Weapon;

public class MaskEffectModel : AbstractModel, IPlaybackSystem
{
	private MaskEffectViewModel _viewModel;

	private int _time;

	private int _type;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new MaskEffectViewModel();
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
		if (_type == 0)
		{
			if (_time < 600)
			{
				_viewModel.ShowAlpha = 0.2f + (float)_time / 1000f;
			}
			else if (_time < 1000)
			{
				_viewModel.ShowAlpha = 0.8f - (float)(_time - 600) / 400f * 0.8f;
			}
			else
			{
				_viewModel.ShowAlpha = 0f;
			}
		}
		else if (_type == 1)
		{
			if (_time < 300)
			{
				_viewModel.ShowAlpha = 0.8f - (float)_time / 300f * 0.6f;
			}
			else if (_time < 5000)
			{
				_viewModel.ShowAlpha = 0.2f;
			}
			else
			{
				_viewModel.ShowAlpha = 0f;
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_SkyDeagleSkillShifang, SetSkyDeagleSkillShifang, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_RpgBurstAssaultSkillBz, SetRpgBurstAssaultSkillBz, null, initinvoke: true);
	}

	private void SetSkyDeagleSkillShifang(bool ov, bool flag)
	{
		_viewModel.ShowShow = flag;
		_time = 0;
		_type = 0;
	}

	private void SetRpgBurstAssaultSkillBz(bool ov, bool flag)
	{
		_viewModel.ShowShow = flag;
		_time = 0;
		_type = 1;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
