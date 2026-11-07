using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Sources.Utils;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgDamageRankBoardModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private AcgDamageRankBoardViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	private TimeContext _timeContext;

	private ISSJJTimer _timer;

	private string _timeStr;

	protected NotifyGroup _notifyGroup = new NotifyGroup();

	protected IPlayerScoreCell[] _playerCells;

	protected Type CellClass;

	protected int TeamMemberNum = 3;

	protected bool _hasSubscribed;

	private List<PlayerEntity> _players;

	private PriorityQueue<int, int> _pq;

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
		_viewModel = new AcgDamageRankBoardViewModel();
		CellClass = typeof(AcgDamageProgressGridModel);
	}

	public void OnPlayback()
	{
		if (_viewModel == null || !_viewModel.IsInited)
		{
			return;
		}
		UpdateChips(_timeComponent);
		GetLargestScore();
		SetPassedTime();
		_hasSubscribed = true;
		IPlayerScoreCell[] playerCells = _playerCells;
		foreach (IPlayerScoreCell obj in playerCells)
		{
			obj.OnPlayback();
			if (!obj.HasSubscribed())
			{
				_hasSubscribed = false;
			}
		}
		_notifyGroup.SetSuspend(!_hasSubscribed);
	}

	protected override void DoSubscribe()
	{
		_playerContext = Contexts.sharedInstance.player;
		_timeContext = Contexts.sharedInstance.time;
		_viewModel.ExtendedShow = true;
		_viewModel.FoldedShow = false;
		_viewModel.GridShow = true;
		_pq = new PriorityQueue<int, int>();
		_gameRuleContext.acgSkill.DamageRank = new Dictionary<int, int>();
		_timeStr = ScriptLocalization.Get("ACG_DAMAGE_RANK_TIME");
		CreateCells();
		_viewModel.ExtendedButton.onClick.AddListener(delegate
		{
			_viewModel.ExtendedShow = false;
			_viewModel.FoldedShow = true;
			_viewModel.GridShow = false;
		});
		_viewModel.FoldedButton.onClick.AddListener(delegate
		{
			_viewModel.ExtendedShow = true;
			_viewModel.FoldedShow = false;
			_viewModel.GridShow = true;
		});
	}

	private void SetPassedTime()
	{
		if (_timeContext.commonTimer.CommonTimer.TryGetValue("ACG_GAME_TIMER", out _timer))
		{
			int passedTime = _timer.GetPassedTime();
			string text = (passedTime % 60000 % 1000 / 10).ToString();
			text = ((text.Length == 1) ? (text + "0") : text);
			_viewModel.TimeString = string.Format(_timeStr, passedTime / 60000, passedTime % 60000 / 1000, text);
		}
	}

	protected virtual void CreateCells()
	{
		_playerCells = new IPlayerScoreCell[TeamMemberNum];
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_AcgAllPlayerEntity);
		for (int i = 0; i < _playerCells.Length; i++)
		{
			_playerCells[i] = (IPlayerScoreCell)Activator.CreateInstance(CellClass);
			_playerCells[i].Container = _viewModel.GridObj;
			_playerCells[i].Listener = listNotify;
			_playerCells[i].Index = i;
			_playerCells[i].SetPlayerContext(_playerContext);
			_playerCells[i].Initialize();
		}
		_notifyGroup.Add(listNotify.Id);
		_notifyGroup.SetSuspend(suspend: true);
	}

	private void GetLargestScore()
	{
		_players = UiIEventCondition.Get_AcgAllPlayerEntity();
		_pq.Clear();
		foreach (PlayerEntity player in _players)
		{
			_pq.Enqueue(player.basicInfo.Current.Id, player.basicInfo.Current.AcgDamage);
		}
		_gameRuleContext.acgSkill.DamageRank.Clear();
		int count = _pq.Count;
		for (int i = 0; i < count; i++)
		{
			if (i == count - 1)
			{
				_gameRuleContext.acgSkill.TopDamage = _pq.PeekPriority();
			}
			_gameRuleContext.acgSkill.DamageRank.Add(_pq.Dequeue(), count - 1 - i);
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
