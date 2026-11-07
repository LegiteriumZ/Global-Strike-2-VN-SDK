using System;
using System.Collections.Generic;
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
public class RpgTowerLevelUpPropertyModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ICursorControl
{
	private RpgTowerLevelUpPropertyViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private int _allType = 5;

	private int _nowPage = 1;

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
		_viewModel = new RpgTowerLevelUpPropertyViewModel();
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
		NotifyManager.MakeTempNotify(GetShow, SetShow, null, initinvoke: true);
		_viewModel.CreateTriggerEntry(_viewModel.CloseTriggers, EventTriggerType.PointerClick, delegate
		{
			Close();
		});
		_viewModel.CreateTriggerEntry(_viewModel.BeforeSingleTriggers, EventTriggerType.PointerClick, delegate
		{
			Before();
		});
		_viewModel.CreateTriggerEntry(_viewModel.BeforeAllTriggers, EventTriggerType.PointerClick, delegate
		{
			BeforeAll();
		});
		_viewModel.CreateTriggerEntry(_viewModel.NextSingleTriggers, EventTriggerType.PointerClick, delegate
		{
			Next();
		});
		_viewModel.CreateTriggerEntry(_viewModel.NextAllTriggers, EventTriggerType.PointerClick, delegate
		{
			NextAll();
		});
		_viewModel.CreateTriggerEntry(_viewModel.ComfirmTriggers, EventTriggerType.PointerClick, delegate
		{
			Comfirm();
		});
		_viewModel.CreateTriggerEntry(_viewModel.CancelTriggers, EventTriggerType.PointerClick, delegate
		{
			Cancel();
		});
	}

	private void Cancel()
	{
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.LevelUpPropertyMain;
	}

	private void Comfirm()
	{
		this.Info("Comfirm > " + _gameRuleContext.rpgTower.TowerId);
		RpgTowerArgsData message = new RpgTowerArgsData
		{
			TowerId = _gameRuleContext.rpgTower.TowerId,
			ActionType = 10 + _nowPage
		};
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(116, message);
		Close();
	}

	private void ShowDetail()
	{
		Dictionary<string, int> dictionary = null;
		foreach (Dictionary<string, int> levelUpPropDic in _gameRuleContext.rpgTower.LevelUpPropDics)
		{
			if (levelUpPropDic["type"] == _nowPage)
			{
				dictionary = levelUpPropDic;
				break;
			}
		}
		if (dictionary == null)
		{
			throw new Exception("Find No Equal PageType " + _nowPage);
		}
		_viewModel.CostString = StringCache.IntToString(dictionary["cost"]);
		ShowPage();
		base.Loader.RetriveSprite("ui/rpgtowermodel", "LevelUpTitle" + _nowPage + ".png", delegate(Sprite sprite)
		{
			_viewModel.TypeTitleSprite = sprite;
		});
		_viewModel.CommonTypeShow = !IsSpecalType(_nowPage);
		_viewModel.SpecailTypeShow = IsSpecalType(_nowPage);
		if (!IsSpecalType(_nowPage))
		{
			_viewModel.SetCommonLevelUpDesString(1, StringCache.IntToString(dictionary["Para1"]));
			_viewModel.SetCommonLevelUpDesString(2, StringCache.IntToString(dictionary["Para2"]));
			_viewModel.SetCommonLevelUpDesString(3, StringCache.IntToString(dictionary["CurrentLevel"]));
			_viewModel.CommonLevelUpBaiFenShow = _nowPage == 1 || _nowPage == 3;
			base.Loader.RetriveSprite("ui/rpgtowermodel", "LevelUpType" + _nowPage + ".png", delegate(Sprite sprite)
			{
				_viewModel.CommonSignTypeSprite = sprite;
				_viewModel.CommonSignTypeNtvsize();
				_viewModel.NextLevelSignTypeSprite = sprite;
				_viewModel.NextLevelSignTypeNtvsize();
			});
		}
		else
		{
			for (int i = 1; i <= 3; i++)
			{
				_viewModel.SetSpecailLevelupShow(i, _gameRuleContext.rpgTower.TowerType == (TowerType)i);
				_viewModel.SetNextLevelSpecailLevelupShow(i, _gameRuleContext.rpgTower.TowerType == (TowerType)i);
			}
			_viewModel.SetSpecailLevelUpDesString(3, StringCache.IntToString(dictionary["CurrentLevel"]));
			_viewModel.SetSpecailLevelUpDesString(2, StringCache.IntToString(dictionary["Para2"]));
			for (int j = 1; j <= 3; j++)
			{
				if (_gameRuleContext.rpgTower.TowerType == (TowerType)j)
				{
					_viewModel.SetDiffSpecailLevelUpDesString(j, StringCache.IntToString(dictionary["Para1"]));
				}
			}
		}
		RpgTowerLevelUpPropertyViewModel viewModel = _viewModel;
		RpgTowerLevelUpPropertyViewModel viewModel2 = _viewModel;
		bool flag2 = (_viewModel.CostShow = dictionary["Para2"] != dictionary["CurrentLevel"]);
		bool comfirmShow = (viewModel2.CostCoinShow = flag2);
		viewModel.ComfirmShow = comfirmShow;
	}

	private bool IsSpecalType(int index)
	{
		return index == 5;
	}

	private void ShowPage()
	{
		_viewModel.PageString = _nowPage + "/" + _allType;
		_viewModel.BeforeSingleShow = _nowPage > 1;
		_viewModel.BeforeAllShow = _nowPage > 1;
		_viewModel.NextAllShow = _nowPage < _allType;
		_viewModel.NextSingleShow = _nowPage < _allType;
	}

	private void BeforeAll()
	{
		_nowPage = 1;
		ShowDetail();
	}

	private void Before()
	{
		_nowPage--;
		ShowDetail();
	}

	private void NextAll()
	{
		_nowPage = _allType;
		ShowDetail();
	}

	private void Next()
	{
		_nowPage++;
		ShowDetail();
	}

	private void Close()
	{
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.None;
	}

	private bool GetShow()
	{
		return _gameRuleContext.rpgTower.RpgTowerSurfaceType == RpgTowerSurfaceType.LevelUpPropertyDetail;
	}

	private void SetShow(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
		if (arg2)
		{
			ShowDetail();
		}
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

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
