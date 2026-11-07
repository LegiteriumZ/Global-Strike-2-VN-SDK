using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgDamageProgressGridModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, IPlayerScoreCell, ISetPlayerContext
{
	private AcgDamageProgressGridViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	protected int _id;

	protected int _damage;

	protected bool _hasSubscribed;

	private const float INTERVAL_HEIGHT = 5f;

	private const float PROGRESS_BAR_HEIGHT = 16f;

	public GameObject Container { get; set; }

	public int Index { get; set; }

	public IListNotify Listener { get; set; }

	protected override IUiViewModel ViewModel => _viewModel;

	public bool HasSubscribed()
	{
		return _hasSubscribed;
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
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgDamageProgressGridViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			SetRank();
		}
	}

	private void SetRank()
	{
		if (_id != 0)
		{
			_viewModel.AcgDamageProgressGridFillamount = ((_gameRuleContext.acgSkill.TopDamage == 0) ? 0f : ((float)_damage / (float)_gameRuleContext.acgSkill.TopDamage));
			if (_gameRuleContext.acgSkill.DamageRank.ContainsKey(_id))
			{
				_viewModel.ViewGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f - (5f + (float)_gameRuleContext.acgSkill.DamageRank[_id] * 21f));
			}
		}
	}

	protected override void DoSubscribe()
	{
		SetGameRuleContext(Contexts.sharedInstance.gameRule);
		_viewModel.ViewGameObject.transform.SetParent(Container.transform);
		_viewModel.ViewGameObjectShow = false;
		_viewModel.ViewGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f - (5f + (float)Index * 21f));
		Listener.AddEvent<PlayerEntity, string>("PlayerNameB", UiIEventCondition.Get_PlayerEntity_PlayerName, SetPlayerName, Index);
		Listener.AddEvent<PlayerEntity, int>("PlayerDamageB", UiIEventCondition.Get_PlayerEntity_AcgPlayerDamage, SetPlayerDamage, Index);
		_hasSubscribed = true;
	}

	private void SetPlayerName(PlayerEntity player, int idx, string oldName, string newName, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_viewModel.PlayerNameString = newName;
			_viewModel.ViewGameObjectShow = true;
			_id = player.basicInfo.Current.Id;
		}
		else
		{
			_viewModel.ViewGameObjectShow = false;
		}
	}

	private void SetPlayerDamage(PlayerEntity player, int idx, int oldInt, int newInt, ElementStatus status)
	{
		_viewModel.PlayerDamageString = newInt.ToString();
		_damage = newInt;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
