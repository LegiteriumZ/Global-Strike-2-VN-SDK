using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.UiFramework.Libs;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class FullScreenModel : AbstractModel, IPlaybackSystem, ICursorControl
{
	private readonly FullscreenViewModel _fullScreenViewModel = new FullscreenViewModel();

	private bool _uivisible;

	private bool _isInit;

	private bool UIVisible
	{
		get
		{
			return _uivisible;
		}
		set
		{
			_uivisible = value;
		}
	}

	protected override IUiViewModel ViewModel => _fullScreenViewModel;

	public int CloseDelay { get; set; }

	public void OnPlayback()
	{
		if (_isInit)
		{
			UIVisible = false;
			_fullScreenViewModel.ShowShow = false;
			return;
		}
		UIVisible = true;
		_fullScreenViewModel.ShowShow = UIVisible;
		if (Input.GetMouseButton(0))
		{
			UIVisible = false;
		}
		if (!Cursor.visible && Cursor.lockState == CursorLockMode.Locked)
		{
			_isInit = true;
		}
	}

	public int GetCursorState()
	{
		if (!UIVisible)
		{
			return 0;
		}
		return 2;
	}

	public int GetForbidButtons()
	{
		return 0;
	}
}
