using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgTeamRace;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgTeamRace;

[GameUiTest]
public class RpgTeamRaceMessageModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private RpgTeamRaceMessageViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private int _lastMessaage;

	private ActiveChip _activeMessage;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = context.roomData.Data.RaceType;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgTeamRaceMessageViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		UnsetAllMessage();
		NotifyManager.MakeNotify(84, GetMessage, UpdateMessage, initinvoke: true);
	}

	private void UnsetAllMessage()
	{
		_viewModel.BlueAllBeKilledShow = false;
		_viewModel.BlueAllReviveShow = false;
		_viewModel.RedAllBeKilledShow = false;
		_viewModel.RedAllReviveShow = false;
		_viewModel.YellowAllBeKilledShow = false;
		_viewModel.YellowAllReviveShow = false;
		_lastMessaage = 0;
	}

	private bool GetMessage()
	{
		return true;
	}

	private void SetMessage(int messageId, bool isShow)
	{
		if (isShow)
		{
			SetMessageTime();
			_lastMessaage = messageId;
		}
		switch (messageId)
		{
		case -2535:
			_viewModel.RedAllBeKilledShow = isShow;
			break;
		case -2537:
			_viewModel.BlueAllBeKilledShow = isShow;
			break;
		case -2536:
			_viewModel.YellowAllBeKilledShow = isShow;
			break;
		}
	}

	private void UpdateMessage(bool arg1, bool arg2)
	{
		if (_gameRuleContext.hasTeamRaceUi)
		{
			SetMessage(_lastMessaage, isShow: false);
			SetMessage(_gameRuleContext.teamRaceUi.TeamRaceMessage, isShow: true);
		}
	}

	private void SetMessageTime()
	{
		_activeMessage.Time = 3000;
	}

	private void InitChips()
	{
		_activeMessage = new ActiveChip();
		_activeMessage.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.ShowShow = _activeMessage.Update(_timeComponent);
	}
}
