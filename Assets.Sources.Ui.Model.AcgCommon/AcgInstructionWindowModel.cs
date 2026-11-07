using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Sources.Utils.Timer;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgInstructionWindowModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private AcgInstructionWindowViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private TimeContext _timeContext;

	private ISSJJTimer _timer;

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
		_viewModel = new AcgInstructionWindowViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
			UpdateTime();
		}
	}

	private void UpdateTime()
	{
		if (_timeContext.commonTimer.CommonTimer.TryGetValue("ACG_READY_TIMER", out _timer))
		{
			_viewModel.TimeString = (_timer.LeftTime / 1000).ToString();
		}
		else if (_timeContext.commonTimer.CommonTimer.TryGetValue("ACG_GAME_START_COUNTDOWN", out _timer))
		{
			_viewModel.TimeString = (_timer.LeftTime / 1000).ToString();
		}
		else
		{
			_viewModel.StartBackShow = false;
		}
	}

	protected override void DoSubscribe()
	{
		_timeContext = Contexts.sharedInstance.time;
		_viewModel.StartBackShow = false;
		_viewModel.TradeShow = false;
		_viewModel.RefillShow = false;
		NotifyManager.MakeNotify(110, GetAcgInstruction, SetAcgInstruction, initinvoke: true);
	}

	public void SetAcgInstruction(int oldInt, int newInt)
	{
		if (_gameRuleContext.acgInstruction.instruction == null)
		{
			return;
		}
		switch (_gameRuleContext.acgInstruction.instruction.Type)
		{
		case AcgTipsType.VOTEREADY:
			_viewModel.ReadyShow = _gameRuleContext.acgInstruction.instruction.Prepare;
			_viewModel.NotReadyShow = !_viewModel.ReadyShow;
			break;
		case AcgTipsType.VOTEPREPARATION:
			_viewModel.StartBackShow = _gameRuleContext.acgInstruction.instruction.CanShow;
			_viewModel.ProgressShow = true;
			_viewModel.ProgressString = "(" + _gameRuleContext.acgInstruction.instruction.Num + "/" + _gameRuleContext.acgInstruction.instruction.MaxNum + ")";
			if (!_timeContext.commonTimer.CommonTimer.TryGetValue("ACG_READY_TIMER", out _timer))
			{
				SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "ACG_READY_TIMER", new SSJJTimer(_gameRuleContext.acgInstruction.instruction.Time));
			}
			break;
		case AcgTipsType.SHOPPURCHASETIP:
			_viewModel.TradeShow = _gameRuleContext.acgInstruction.instruction.CanShow;
			_viewModel.RefillShow = false;
			break;
		case AcgTipsType.CLIPPURCHASETIP:
			_viewModel.TradeShow = false;
			_viewModel.RefillShow = _gameRuleContext.acgInstruction.instruction.CanShow;
			break;
		case AcgTipsType.GAMEPREPARATION:
			_viewModel.StartBackShow = true;
			_viewModel.ProgressShow = false;
			_viewModel.ReadyShow = false;
			_viewModel.NotReadyShow = false;
			if (!_timeContext.commonTimer.CommonTimer.TryGetValue("ACG_GAME_START_COUNTDOWN", out _timer))
			{
				SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "ACG_GAME_START_COUNTDOWN", new SSJJTimer(_gameRuleContext.acgInstruction.instruction.Time));
			}
			break;
		case AcgTipsType.BOSSCOUNTDOWN:
			_viewModel.StartBackShow = true;
			_viewModel.ProgressShow = false;
			_viewModel.ReadyShow = false;
			_viewModel.NotReadyShow = false;
			if (!_timeContext.commonTimer.CommonTimer.TryGetValue("ACG_BOSS_COUNTDOWN", out _timer))
			{
				SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "ACG_BOSS_COUNTDOWN", new SSJJTimer(_gameRuleContext.acgInstruction.instruction.Time));
			}
			break;
		}
	}

	public int GetAcgInstruction()
	{
		return 0;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
