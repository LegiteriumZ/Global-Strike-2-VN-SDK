using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class VoiceShieldCellModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ICellModel
{
	private VoiceShieldCellViewModel _viewModel;

	private PlayerContext _playerContext;

	public GameObject Container { get; set; }

	public int Index { get; set; }

	public IListNotify Listener { get; set; }

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetContainerAndListener(GameObject container, IListNotify listener, int index)
	{
		Container = container;
		Index = index;
		Listener = listener;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void Show()
	{
		if (_viewModel.IsInited)
		{
			_viewModel.VoiceShieldCellShow = true;
		}
	}

	public void Hide()
	{
		if (_viewModel.IsInited)
		{
			_viewModel.VoiceShieldCellShow = false;
		}
	}

	public bool CheckToggleIsOn()
	{
		if (!_viewModel.IsInited)
		{
			return false;
		}
		return _viewModel.VoiceShieldCellOn;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new VoiceShieldCellViewModel();
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
		_viewModel.VoiceShieldCellObj.transform.SetParent(Container.transform);
		_viewModel.VoiceShieldCellObj.transform.localScale = Vector3.one;
		Listener.AddEvent<PlayerEntity, string>("ShieldPlayerName", UiIEventCondition.Get_OnePlayerEntityName_Shield, SetPlayerName, Index);
		Listener.AddEvent<PlayerEntity, bool>("ShieldIs", UiIEventCondition.Get_OnePlayerEntityIsShield_Shield, SetShield, Index);
	}

	private void SetPlayerName(PlayerEntity playerEntity, int idx, string oldfs, string newfs, ElementStatus status)
	{
		_viewModel.NameLabelString1 = newfs;
	}

	private void SetShield(PlayerEntity playerEntity, int idx, bool oldfs, bool newfs, ElementStatus status)
	{
		_viewModel.VoiceShieldCellOn = newfs;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
