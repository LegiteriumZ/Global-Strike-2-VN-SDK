using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.Sources.Utils.UIChip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Pve;

public class PveBossHpModel : AbstractModel, IPlaybackSystem
{
	private PveBossHpViewModel _viewModel;

	private FloatChip _chip = new FloatChip();

	private float _waitTime;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PveBossHpViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		if (Contexts.sharedInstance.player.GetEntityWithEntityId(UiIEventCondition.Get_hpProgressData_BossId()) != null && UiIEventCondition.Get_hpProgressData_ShowBossHp())
		{
			_viewModel.PveBossHpShow = true;
			UpdateChips();
			if (_waitTime > 100f)
			{
				UpdateBossHpProgressEffect(_timeComponent.FrameInterval);
			}
			UpdateWaitTime(_timeComponent.FrameInterval);
		}
		else
		{
			_viewModel.PveBossHpShow = false;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_BossHpPercent, SetBossHpPercent, null, initinvoke: true);
	}

	private void InitChips()
	{
		_chip.Speed = 0.07f;
	}

	private void UpdateChips()
	{
	}

	private void UpdateBossHpProgressEffect(int frameinterval)
	{
		_chip.Start = _viewModel.hpeffectFillamount;
		_chip.Target = _viewModel.hpProgressFillamount2;
		_viewModel.hpeffectFillamount = _chip.Update(frameinterval);
	}

	private void SetBossHpPercent(float ov, float v)
	{
		_viewModel.hpProgressShow1 = true;
		_viewModel.hpProgressShow2 = true;
		if (v > 0.8f)
		{
			_viewModel.hpProgressColor1 = new Color(0.5f, 0.01f, 0.8f, 1f);
			_viewModel.hpProgressColor2 = new Color(0.08f, 0.57f, 0.83f, 1f);
			UpdateHpProgress((v - 0.8f) * 5f);
		}
		else if (v > 0.6f)
		{
			_viewModel.hpProgressColor1 = new Color(0.08f, 0.57f, 0.83f, 1f);
			_viewModel.hpProgressColor2 = new Color(0.2f, 0.6f, 0f, 1f);
			UpdateHpProgress((v - 0.6f) * 5f);
		}
		else if (v > 0.4f)
		{
			_viewModel.hpProgressColor1 = new Color(0.2f, 0.6f, 0f, 1f);
			_viewModel.hpProgressColor2 = new Color(0.84f, 0.47f, 0.11f, 1f);
			UpdateHpProgress((v - 0.4f) * 5f);
		}
		else if (v > 0.2f)
		{
			_viewModel.hpProgressColor1 = new Color(0.84f, 0.47f, 0.11f, 1f);
			_viewModel.hpProgressColor2 = new Color(0.75f, 0.2f, 0.2f, 1f);
			UpdateHpProgress((v - 0.2f) * 5f);
		}
		else if (v > 0f)
		{
			_viewModel.hpProgressColor1 = new Color(0.75f, 0.2f, 0.2f, 1f);
			_viewModel.hpProgressShow2 = false;
			UpdateHpProgress(v * 5f);
		}
		else
		{
			_viewModel.hpProgressShow1 = false;
			_viewModel.hpProgressShow2 = false;
			UpdateHpProgress(0f);
		}
	}

	private void UpdateHpProgress(float v)
	{
		_viewModel.hpProgressFillamount1 = v;
		_viewModel.hpProgressFillamount2 = 1f - v;
		_viewModel.hpeffectFillamount = 1f - v;
	}

	private void UpdateWaitTime(int frameinterval)
	{
		_waitTime += frameinterval;
		if (_viewModel.hpProgressFillamount1 < 0.0001f)
		{
			_waitTime = 0f;
		}
	}
}
