using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgShieldRecoveryModel : AbstractModel, IPlaybackSystem
{
	private RpgShieldRecoveryViewModel _viewModel;

	private PingPongChip _showPingPongChip = new PingPongChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgShieldRecoveryViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_viewModel.ShowRootshow)
			{
				_viewModel.ShowAlpha = _showPingPongChip.Update(_timeComponent);
				_viewModel.LeftImageSize = new Vector3(_viewModel.LeftImageRect.height * 133f / 350f, 0f);
				_viewModel.RightImageSize = new Vector3(_viewModel.RightImageRect.height * 133f / 350f, 0f);
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_RpgShieldRecorvery, SetRpgShieldRecorvery, null, initinvoke: true);
	}

	private void SetRpgShieldRecorvery(bool ov, bool flag)
	{
		_viewModel.ShowRootshow = false;
		_viewModel.ShowRootshow = flag;
		if (flag)
		{
			_showPingPongChip.RunTime = 0;
		}
	}

	private void InitChips()
	{
		_showPingPongChip.From = 0.3f;
		_showPingPongChip.To = 1f;
		_showPingPongChip.Time = 600;
	}

	private void UpdateChips()
	{
	}
}
