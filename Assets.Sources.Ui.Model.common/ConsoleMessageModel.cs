using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class ConsoleMessageModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private ConsoleMessageViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private MessageContext _messageContext;

	private const int CONTEXT_WIDTH = 780;

	private const int CONTEXT_HEIGHT_PER_LINE = 22;

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
		_viewModel = new ConsoleMessageViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		_messageContext = Contexts.sharedInstance.message;
		NotifyManager.MakeTempNotify(GetMessageCount, SetMessage, null, initinvoke: true, isFrameSeparation: true);
	}

	private void SetMessage(int oldInt, int newInt)
	{
		for (int i = oldInt; i < newInt; i++)
		{
			ConsoleMessageViewModel viewModel = _viewModel;
			viewModel.ContentString = viewModel.ContentString + _messageContext.consoleMessage.ConsoleMessage[i] + "\n";
		}
		_viewModel.ContentSize = new Vector2(780f, newInt * 22);
	}

	private int GetMessageCount()
	{
		if (_messageContext.consoleMessage.ConsoleMessage == null)
		{
			return 0;
		}
		return _messageContext.consoleMessage.ConsoleMessage.Count;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
