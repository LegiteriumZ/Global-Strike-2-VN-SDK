using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.PveCommon;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJNetworking.BattleServer;
using UnityEngine;

namespace Assets.Sources.Ui.Model.PveCommon;

[GameUiTest]
public class PveShowNextSceneModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ICursorControl
{
	private PveShowNextSceneViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private ActiveChip _resultActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

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
		_viewModel = new PveShowNextSceneViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited && _resultActiveChip.Time > 0)
		{
			UpdateChips();
			if (_viewModel.ResultShow)
			{
				_viewModel.CountDownString = Mathf.FloorToInt((float)_resultActiveChip.Time / 1000f).ToString();
				return;
			}
			_viewModel.ShowShow = false;
			SendMessage(isContinue: true);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_gameMessageData_MessageData, SetMessageData, null, initinvoke: true);
		_viewModel.ButtonExitClicked.AddListener(delegate
		{
			bool isContinue2 = false;
			SendMessage(isContinue2);
			_viewModel.ShowShow = false;
		});
		_viewModel.ButtonContinueClicked.AddListener(delegate
		{
			bool isContinue = true;
			SendMessage(isContinue);
			_viewModel.ShowShow = false;
		});
	}

	private void SendMessage(bool isContinue)
	{
		IBattleServer server = Contexts.sharedInstance.battleServer.battleServer.Server;
		Continue message = new Continue
		{
			IsContinue = isContinue
		};
		server.SendTcpMessage(39, message);
	}

	private void SetMessageData(GameMessageData ov, GameMessageData messageData)
	{
		if (messageData == null)
		{
			return;
		}
		GameMessageType type = messageData.Type;
		if (type == GameMessageType.SHOWNEXTBATTLE)
		{
			if (!_battleRoomContext.roomData.IsObserver)
			{
				_resultActiveChip.Time = messageData.Time;
			}
			_viewModel.ShowShow = true;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		_viewModel.ResultShow = _resultActiveChip.Update(_timeComponent);
	}

	public int GetCursorState()
	{
		if (!_viewModel.ResultShow)
		{
			return 0;
		}
		return 32;
	}

	public int GetForbidButtons()
	{
		return 0;
	}
}
