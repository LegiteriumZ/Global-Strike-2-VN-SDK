using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Info.Quest;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Sources.Utils.Timer;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgQuestGridModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, IPlayerScoreCell, ISetPlayerContext
{
	private AcgQuestGridViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	private TimeContext _timeContext;

	protected Vector2 _posCache;

	protected const int ONE_GRID_Y = -35;

	private ISSJJTimer _timer;

	private string _questName;

	public GameObject Container { get; set; }

	public int Index { get; set; }

	public IListNotify Listener { get; set; }

	protected override IUiViewModel ViewModel => _viewModel;

	public bool HasSubscribed()
	{
		return true;
	}

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

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
		_timeContext = Contexts.sharedInstance.time;
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgQuestGridViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel == null || !_viewModel.IsInited)
		{
			return;
		}
		UpdateChips(_timeComponent);
		if (!string.IsNullOrEmpty(_questName) && _timeContext.commonTimer.CommonTimer.TryGetValue(_questName, out _timer))
		{
			if (_viewModel.ClearedShow)
			{
				_viewModel.QuestNameString = "0";
			}
			else
			{
				_viewModel.QuestNameString = string.Format(ScriptLocalization.Get(_questName), (_timer.LeftTime / 1000).ToString());
			}
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ViewGameObject.transform.SetParent(Container.transform);
		_viewModel.AcgQuestGridShow = false;
		_posCache = default(Vector2);
		Listener.AddEvent<AcgQuest, int>("QuestName", UiIEventCondition.Get_AcgQuestId, SetQuest, Index);
		Listener.AddEvent<AcgQuest, bool>("QuestStatus", UiIEventCondition.Get_AcgQuestStatus, SetQuestStatus, Index);
	}

	private void SetQuestStatus(AcgQuest quest, int idx, bool oldBool, bool newBool, ElementStatus status)
	{
		_viewModel.ClearedShow = newBool;
		_viewModel.NotClearedShow = !newBool;
	}

	private void SetQuest(AcgQuest quest, int idx, int oldInt, int newInt, ElementStatus status)
	{
		_questName = "ACG_QUEST" + quest.id;
		if (quest.time != 0)
		{
			_viewModel.QuestNameString = string.Format(ScriptLocalization.Get(_questName), quest.time.ToString());
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, _questName, new SSJJTimer(quest.time));
		}
		else
		{
			_viewModel.QuestNameString = ScriptLocalization.Get(_questName);
		}
		_viewModel.AcgQuestGridShow = true;
		_viewModel.ClearedShow = quest.isCleared;
		_viewModel.NotClearedShow = !quest.isCleared;
		_posCache.x = 0f;
		_posCache.y = idx * -35;
		_viewModel.AcgQuestGridAnchoredposition = _posCache;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
