using Assets.Sources.Components.Message.Bochemical;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.BioEvolution;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioEvolution;

[GameUiTest]
public class BioEvolutionShortcutKeyModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetMessageContext, ISetPlayerContext
{
	private BioEvolutionShortcutKeyViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private BioMessageDataComponent _bioMessageDataComponent;

	private PlayerContext _playerContext;

	private ScaleChip _encourageChip;

	private ScaleChip _giveweaponScaleChip;

	private AlphaChip _alphaChip;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetMessageContext(MessageContext context)
	{
		_bioMessageDataComponent = context.bioMessageData;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioEvolutionShortcutKeyViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			_viewModel.encourageEffectScale = _encourageChip.Update(_timeComponent);
			_viewModel.giveweaponEffectScale = _giveweaponScaleChip.Update(_timeComponent);
			_viewModel.encourageEffectAlpha = _alphaChip.Update(_timeComponent);
			_viewModel.giveweaponEffectAlpha = _alphaChip.Update(_timeComponent);
			if (_viewModel.encourageEffectShow && _encourageChip.IsOver)
			{
				_encourageChip.IsOver = false;
				_encourageChip.Scale = Vector3.one * 1.2f;
				_alphaChip.Alpha = 1f;
				_alphaChip.IsOver = false;
			}
			if (_viewModel.giveweaponEffectShow && _giveweaponScaleChip.IsOver)
			{
				_giveweaponScaleChip.IsOver = false;
				_giveweaponScaleChip.Scale = Vector3.one * 1.2f;
				_alphaChip.Alpha = 1f;
				_alphaChip.IsOver = false;
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.encourageShow = false;
		_viewModel.giveweaponShow = false;
		NotifyManager.MakeTempNotify(GetWeaponVisable, SetWeaponVisable, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetEncourageVisable, SetEncourageVisable, null, initinvoke: true);
		_alphaChip = new AlphaChip
		{
			Alpha = 0f,
			Speed = -1.5f
		};
		_giveweaponScaleChip = new ScaleChip
		{
			Scale = Vector3.one * 1.2f,
			Speed = Vector3.one,
			TargetScale = Vector3.one * 3.6f
		};
		_encourageChip = new ScaleChip
		{
			Scale = Vector3.one * 1.2f,
			Speed = Vector3.one,
			TargetScale = Vector3.one * 3.6f
		};
	}

	private void SetEncourageVisable(bool arg1, bool arg2)
	{
		_viewModel.encourageShow = arg2;
		_viewModel.encourageEffectShow = arg2;
	}

	private bool GetEncourageVisable()
	{
		return _bioMessageDataComponent.Encourage;
	}

	private void SetWeaponVisable(bool arg1, bool arg2)
	{
		_viewModel.giveweaponShow = arg2;
		_viewModel.giveweaponEffectShow = arg2;
	}

	private bool GetWeaponVisable()
	{
		return _bioMessageDataComponent.CopyStatus;
	}
}
