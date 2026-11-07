using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.BioEvolution;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.BioEvolution;

[GameUiTest]
public class BioEvolutionPickUpModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetPlayerContext, ISetMessageContext
{
	private BioEvolutionPickUpViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

	private MessageContext _messageContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

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
		_messageContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioEvolutionPickUpViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited && _messageContext.bioMessageData.PickTime > 0)
		{
			_messageContext.bioMessageData.PickTime -= _timeComponent.FrameInterval;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		SimpleNotify.Add(GetVisible, SetVisible);
		SimpleNotify.Add(GetProgress, SetProgress);
	}

	private void SetProgress(int arg1, int arg2)
	{
		_viewModel.TimeString = StringCache.IntToString(arg1 / 1000);
		_viewModel.ProgressFillamount = (float)arg1 / (float)_messageContext.bioMessageData.MaxTime;
	}

	private int GetProgress(int arg1)
	{
		if (_messageContext.bioMessageData.MaxTime <= 0)
		{
			return 0;
		}
		return _messageContext.bioMessageData.PickTime;
	}

	private void SetVisible(bool arg1, int arg2)
	{
		_viewModel.backShow = arg1;
	}

	private bool GetVisible(int arg1)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity == null)
		{
			return false;
		}
		if (myPlayerEntity.IsDead())
		{
			return false;
		}
		if (_messageContext.bioMessageData.MaxTime <= 0)
		{
			return false;
		}
		return true;
	}
}
