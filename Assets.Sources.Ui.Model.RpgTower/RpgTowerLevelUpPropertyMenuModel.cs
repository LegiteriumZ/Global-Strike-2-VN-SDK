using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgTower;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJBase.Logger;
using SSJJBase.String;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.RpgTower;

[GameUiTest]
public class RpgTowerLevelUpPropertyMenuModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ICursorControl
{
	private RpgTowerLevelUpPropertyMenuViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

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
		_viewModel = new RpgTowerLevelUpPropertyMenuViewModel();
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
		_viewModel.ShowShow = false;
		_viewModel.CreateTriggerEntry(_viewModel.CloseTriggers, EventTriggerType.PointerClick, delegate
		{
			Close();
		});
		_viewModel.CreateTriggerEntry(_viewModel.MoveTriggers, EventTriggerType.PointerClick, delegate
		{
			Move();
		});
		_viewModel.CreateTriggerEntry(_viewModel.SaleTriggers, EventTriggerType.PointerClick, delegate
		{
			Sale();
		});
		_viewModel.CreateTriggerEntry(_viewModel.LevelUpTriggers, EventTriggerType.PointerClick, delegate
		{
			LevelUp();
		});
		NotifyManager.MakeTempNotify(GetShow, SetShow, null, initinvoke: true);
	}

	private bool GetShow()
	{
		return _gameRuleContext.rpgTower.RpgTowerSurfaceType == RpgTowerSurfaceType.LevelUpPropertyMain;
	}

	private void SetShow(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
		base.Loader.RetriveSprite("ui/rpgtowermodel", "Title" + (int)_gameRuleContext.rpgTower.TowerType + ".png", delegate(Sprite sprite)
		{
			_viewModel.TitleSprite = sprite;
		});
		_viewModel.CountString1 = StringCache.IntToString(_gameRuleContext.rpgTower.LevelUpProtertyHealth);
		_viewModel.CountString2 = StringCache.IntToString(_gameRuleContext.rpgTower.LevelUpProtertyAttackDamage);
		_viewModel.CountString3 = StringCache.IntToString(_gameRuleContext.rpgTower.LevelUpProtertyPower);
		_viewModel.CountString4 = StringCache.IntToString(_gameRuleContext.rpgTower.LevelUpProtertyCdTime);
		base.Loader.RetriveSprite("ui/rpgtowermodel", $"Skill{(int)_gameRuleContext.rpgTower.TowerType}_1.png", delegate(Sprite sprite)
		{
			_viewModel.SkillSprite1 = sprite;
			_viewModel.SkillNtvsize1();
		});
		base.Loader.RetriveSprite("ui/rpgtowermodel", $"Skill{(int)_gameRuleContext.rpgTower.TowerType}_2.png", delegate(Sprite sprite)
		{
			_viewModel.SkillSprite2 = sprite;
			_viewModel.SkillNtvsize2();
		});
		_viewModel.SkillShow2 = _gameRuleContext.rpgTower.LevelUpProtertyIsFullSkill;
	}

	private void Close()
	{
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.None;
	}

	private void Sale()
	{
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.LevelUpPropertySale;
	}

	private void Move()
	{
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.LevelUpPropertyMove;
	}

	private void LevelUp()
	{
		this.Info("LevelUpProperty > " + _gameRuleContext.rpgTower.TowerId);
		RpgTowerArgsData message = new RpgTowerArgsData
		{
			TowerId = _gameRuleContext.rpgTower.TowerId,
			ActionType = 4
		};
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(116, message);
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.None;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow)
		{
			return 0;
		}
		return 32768;
	}

	public int GetForbidButtons()
	{
		return 175;
	}
}
