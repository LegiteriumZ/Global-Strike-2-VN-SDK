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
public class AcgPlayerInfoGridModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, IPlayerScoreCell, ISetPlayerContext
{
	private AcgPlayerInfoGridViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	protected PlayerContext _playerContext;

	private const float GRID_HEIGHT = 88f;

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
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgPlayerInfoGridViewModel();
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
		_viewModel.ViewGameObject.transform.SetParent(Container.transform);
		_viewModel.ViewGameObject.transform.localPosition = new Vector2(0f, (float)(-Index) * 88f);
		_viewModel.ShowShow = false;
		_viewModel.DeadIconShow = false;
		Listener.AddEvent<PlayerEntity, string>("PlayerName", UiIEventCondition.Get_PlayerEntity_PlayerName, SetPlayerName, Index);
		Listener.AddEvent<PlayerEntity, bool>("PlayerDead", UiIEventCondition.Get_PlayerEntity_IsDead, SetPlayerIsDead, Index);
		Listener.AddEvent<PlayerEntity, int>("PlayerDamage", UiIEventCondition.Get_PlayerEntity_AcgPlayerDamage, SetPlayerDamage, Index);
		Listener.AddEvent<PlayerEntity, int>("PlayerCoin", UiIEventCondition.Get_PlayerEntity_AcgPlayerCoin, SetPlayerCoin, Index);
		Listener.AddEvent<PlayerEntity, int>("PlayerCommonPU", UiIEventCondition.Get_PlayerEntity_AcgPlayerCommonPU, SetCommonPUNum, Index);
		Listener.AddEvent<PlayerEntity, int>("PlayerCharacterPU", UiIEventCondition.Get_PlayerEntity_AcgPlayerCharacterPU, SetCharacterPUNum, Index);
		Listener.AddEvent<PlayerEntity, int>("PlayerWeaponPU", UiIEventCondition.Get_PlayerEntity_AcgPlayerWeaponPU, SetWeaponPUNum, Index);
	}

	private void SetPlayerIsDead(PlayerEntity player, int idx, bool oldBool, bool newBool, ElementStatus status)
	{
		_viewModel.DeadIconShow = newBool;
	}

	private void SetPlayerName(PlayerEntity player, int idx, string oldName, string newName, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_viewModel.ShowShow = true;
			_viewModel.PlayerNameString = newName;
			base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/TabWindow/" + player.basicInfo.Current.CurrentWeaponName + ".png", delegate(Sprite sprite)
			{
				_viewModel.WeaponIconImage.sprite = sprite;
			});
			base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/PlayerIcon/" + player.basicInfo.Current.Career + ".png", delegate(Sprite sprite)
			{
				_viewModel.PlayerIconImage.sprite = sprite;
			});
		}
		else
		{
			_viewModel.ShowShow = false;
		}
	}

	private void SetPlayerDamage(PlayerEntity player, int idx, int oldInt, int newInt, ElementStatus status)
	{
		_viewModel.DamageNumberString = newInt.ToString();
	}

	private void SetPlayerCoin(PlayerEntity player, int idx, int oldInt, int newInt, ElementStatus status)
	{
		_viewModel.CoinNumberString = newInt.ToString();
	}

	private void SetCommonPUNum(PlayerEntity player, int idx, int oldInt, int newInt, ElementStatus status)
	{
		_viewModel.SetNumberString(0, "X" + newInt);
	}

	private void SetCharacterPUNum(PlayerEntity player, int idx, int oldInt, int newInt, ElementStatus status)
	{
		_viewModel.SetNumberString(1, "X" + newInt);
	}

	private void SetWeaponPUNum(PlayerEntity player, int idx, int oldInt, int newInt, ElementStatus status)
	{
		_viewModel.SetNumberString(2, "X" + newInt);
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
