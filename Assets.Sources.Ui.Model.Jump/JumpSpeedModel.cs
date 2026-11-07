using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Jump;
using Assets.UiFramework.Libs;
using NetData;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Jump;

public class JumpSpeedModel : AbstractModel, IPlaybackSystem, ISetPlayerContext
{
	private JumpspeedViewModel _viewModel;

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new JumpspeedViewModel();
	}

	public void OnPlayback()
	{
		if (_playerContext.isMyPlayer)
		{
			Vector3DData velocity = _playerContext.myPlayerEntity.basicInfo.Current.Velocity;
			Vector3 b = new Vector3(velocity.X, velocity.Y, 0f);
			_viewModel.SpeedTextString = ((int)Vector3.Distance(Vector3.zero, b)).ToString();
		}
	}

	private void InitChips()
	{
	}
}
