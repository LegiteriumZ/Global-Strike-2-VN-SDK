using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.UltimateChallenge;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.UltimateChallenge;

[GameUiTest]
public class SelfExtremewipeoutScoreCellModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, IPlayerScoreCell
{
	private SelfExtremewipeoutScoreCellViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private OneKillInfoData _updateScore;

	protected override IUiViewModel ViewModel => _viewModel;

	public GameObject Container { get; set; }

	public int Index { get; set; }

	public IListNotify Listener { get; set; }

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new SelfExtremewipeoutScoreCellViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
			if (_updateScore != null)
			{
				UpdateScore(_updateScore);
				_updateScore = null;
			}
		}
	}

	public bool HasSubscribed()
	{
		return true;
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ViewGameObjectShow = false;
		_viewModel.ViewGameObject.transform.SetParent(Container.transform);
		_viewModel.SelfExtremewipeoutScoreCellPosition = new Vector3(0f, 0f, 0f);
		_viewModel.rankNumString = (Index + 1).ToString();
		Listener.AddEvent<OneKillInfoData, string>("PlayerName", UiIEventCondition.Get_OneKillInfoData_PlayerName, SetPlayerName, Index);
		Listener.AddEvent<OneKillInfoData, int>("Ping", UiIEventCondition.Get_OneKillInfoData_Ping, SetPing, Index);
		Listener.AddEvent<OneKillInfoData, int>("KillNum", UiIEventCondition.Get_OneKillInfoData_KillNum, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, long>("Score", UiIEventCondition.Get_OneKillInfoData_Score, SetLongScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("AssistsNum", UiIEventCondition.Get_OneKillInfoData_AssistsNum, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("AllMoney", UiIEventCondition.Get_OneKillInfoData_hurt, SetScore, Index);
		Listener.AddEvent<OneKillInfoData, int>("lV", UiIEventCondition.Get_OneKillInfoData_Lv, SetScore, Index);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	private void SetLongScore(OneKillInfoData val, int idx, long oldfs, long newfs, ElementStatus status)
	{
		if (UiIEventCondition.Get_uiMyPlayer_PlayerId() == val.Id)
		{
			_updateScore = val;
		}
	}

	private void SetScore(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		if (UiIEventCondition.Get_uiMyPlayer_PlayerId() == val.Id)
		{
			_updateScore = val;
		}
	}

	protected virtual void UpdateScore(OneKillInfoData data)
	{
		_viewModel.PlayerScoreString1 = data.KillNum.ToString();
		_viewModel.PlayerScoreString2 = data.Score.ToString();
		_viewModel.PlayerScoreString3 = data.AssistsNum.ToString();
		_viewModel.PlayerHurtString = data.AllMoney.ToString();
		_viewModel.rankNumString = data.Lv.ToString();
	}

	private void SetPlayerName(OneKillInfoData val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		if (UiIEventCondition.Get_uiMyPlayer_PlayerId() == val.Id)
		{
			_viewModel.ViewGameObjectShow = true;
			_viewModel.PlayerNameString = newfs;
		}
	}

	private void SetPing(OneKillInfoData val, int idx, int oldfs, int newfs, ElementStatus status)
	{
		_viewModel.PlayerPingString = newfs.ToString();
	}

	public void SetPlayerContext(PlayerContext context)
	{
	}
}
