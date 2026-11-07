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
public class RpgTowerLevelUpTypeDetailModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ICursorControl
{
	private RpgTowerLevelUpTypeDetailViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private int _allType = 3;

	private int _nowPage = 1;

	private Dictionary<int, int> _desCountDir;

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
		_desCountDir = new Dictionary<int, int>();
		_desCountDir.Add(1, 4);
		_desCountDir.Add(2, 2);
		_desCountDir.Add(3, 4);
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgTowerLevelUpTypeDetailViewModel();
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
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.LevelUpTypeMain;
	}

	private void Comfirm()
	{
		this.Info("Comfirm > " + _gameRuleContext.rpgTower.TowerId);
		RpgTowerArgsData message = new RpgTowerArgsData
		{
			TowerId = _gameRuleContext.rpgTower.TowerId,
			ActionType = 1000 + _nowPage
		};
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(116, message);
		Close();
	}

	private void ShowDetail()
	{
		Dictionary<string, int> dictionary = null;
		foreach (Dictionary<string, int> levelUpTypeDic in _gameRuleContext.rpgTower.LevelUpTypeDics)
		{
			if (levelUpTypeDic["type"] == _nowPage)
			{
				dictionary = levelUpTypeDic;
				break;
			}
		}
		if (dictionary == null)
		{
			throw new Exception("Find No Equal PageType " + _nowPage);
		}
		_viewModel.CostString = StringCache.IntToString(dictionary["cost"]);
		ShowPage();
		base.Loader.RetriveSprite("ui/rpgtowermodel", "Title" + _nowPage + ".png", delegate(Sprite sprite)
		{
			_viewModel.TypeTitleSprite = sprite;
		});
		for (int i = 1; i <= _allType; i++)
		{
			_viewModel.SetTypeShow(i, _nowPage == i);
		}
		int num = _desCountDir[_nowPage];
		for (int j = 1; j <= num; j++)
		{
			int index = j + 10 * _nowPage;
			_viewModel.SetSkillTypeDesString(index, StringCache.IntToString(dictionary["Para" + j]));
		}
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
		return _gameRuleContext.rpgTower.RpgTowerSurfaceType == RpgTowerSurfaceType.LevelUpTypeDetail;
	}

	private void SetShow(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
		_nowPage = 1;
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
