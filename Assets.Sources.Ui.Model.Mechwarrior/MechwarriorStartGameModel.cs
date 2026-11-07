using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Mechwarrior;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Mechwarrior;

public class MechwarriorStartGameModel : AbstractModel, IPlaybackSystem
{
	private MechwarriorStartGameViewModel _viewModel;

	private string _currImage;

	private bool _currShow;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new MechwarriorStartGameViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_viewModel.PanelShow)
			{
				_viewModel.PanelAlpha -= (float)_timeComponent.FrameInterval / 1000f;
			}
		}
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_NotMoveTime, SetNotMoveTime, null, initinvoke: true);
	}

	private void SetNotMoveTime(int arg1, int moveLimitTime)
	{
		string text = "";
		if (moveLimitTime > 3000)
		{
			_viewModel.PanelShow = false;
		}
		else if (moveLimitTime > 2000)
		{
			_viewModel.PanelShow = true;
			text = "gamestart3.png";
		}
		else if (moveLimitTime > 1000)
		{
			_viewModel.PanelShow = true;
			text = "gamestart2.png";
		}
		else if (moveLimitTime > 0)
		{
			_viewModel.PanelShow = true;
			text = "gamestart1.png";
		}
		else if (moveLimitTime > -1000)
		{
			_viewModel.PanelShow = true;
			text = "gamestart0.png";
		}
		else
		{
			_viewModel.PanelShow = false;
		}
		if (_currShow != _viewModel.PanelShow)
		{
			_currShow = _viewModel.PanelShow;
			if (_currShow)
			{
				_viewModel.PanelAlpha = 1f;
			}
		}
		if (!string.IsNullOrEmpty(text) && _currImage != text)
		{
			_currImage = text;
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/gamestart/" + text, delegate(Sprite sprite)
			{
				_viewModel.GameStartImageSprite = sprite;
				_viewModel.GameStartImageNtvsize();
				_viewModel.PanelAlpha = 1f;
			});
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
