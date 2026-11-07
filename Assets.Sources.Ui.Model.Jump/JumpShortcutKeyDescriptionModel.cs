using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Jump;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Jump;

public class JumpShortcutKeyDescriptionModel : AbstractModel, IPlaybackSystem, ISetSnapShotContext, ISetPlayerContext
{
	private JumpshortcutkeydescriptionViewModel _viewModel;

	private PlayerContext _playerContext;

	private SnapshotContext _snapshotContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetSnapShotContext(SnapshotContext context)
	{
		_snapshotContext = context;
	}

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
		_viewModel = new JumpshortcutkeydescriptionViewModel();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(GetDescriptType, SetDescriptType, null, initinvoke: true);
	}

	private int GetDescriptType()
	{
		if (_snapshotContext.hasSnapshots)
		{
			if (_snapshotContext.snapshots.NowSnapshot != null && _snapshotContext.snapshots.NowSnapshot.ControlId > 0)
			{
				return 3;
			}
			if (_playerContext.isMyPlayer && _playerContext.myPlayerEntity.HasState(524288))
			{
				return 2;
			}
		}
		return 1;
	}

	private void SetDescriptType(int ov, int nv)
	{
		_viewModel.DescriptionImageSprite = base.Loader.RetriveSprite("ui/jumpmodel", $"Assets/Res/Assets/ui/GameGUIRes/jumpModel/shortcutkeydescription/state{nv}.png", delegate(Sprite sprite)
		{
			_viewModel.DescriptionImageSprite = sprite;
			_viewModel.DescriptionImageNtvsize();
		});
	}

	public void OnPlayback()
	{
	}

	private void InitChips()
	{
	}
}
