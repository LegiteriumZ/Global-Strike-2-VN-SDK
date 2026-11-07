using System.Collections.Generic;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.GameRule.Biochemical3;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.HerofightingModel;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Extensions;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.HerofightingModel;

[GameUiTest]
public class HeroFightingSelectModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ISetPlayerContext, IKeyboardResponder
{
	private HeroFightingSelectViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	private int select = 1;

	private bool _isSelectVariant;

	private SelectZombieComponent _selectZombie;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
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
		_selectZombie = _gameRuleContext.selectZombie;
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
		_viewModel = new HeroFightingSelectViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
			if (_selectZombie.Time > 0)
			{
				_selectZombie.Time -= _timeComponent.FrameInterval;
				_viewModel.timerString = _selectZombie.Time / 1000 + "s";
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(120, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
		SimpleNotify.Add(GetCareer, SetCareer, 1);
		SimpleNotify.Add(GetCareer, SetCareer, 2);
		SimpleNotify.Add(GetCareer, SetCareer, 3);
		SimpleNotify.Add(GetVisible, SetVisible);
		SimpleNotify.Add(GetIsHero, EnergyShow);
		_viewModel.OverShow = false;
	}

	public bool GetIsHero(int arg1)
	{
		return PlayerCareerConstantUtility.IsHero(UiIEventCondition.Get_cameraOwnerData_Career());
	}

	public void EnergyShow(bool arg1, int arg2)
	{
		_viewModel.EnergyShow = false;
	}

	private bool GetVisible(int arg1)
	{
		if (_playerContext.isMyPlayer && (_isSelectVariant || Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 18023 || Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 134))
		{
			if (_selectZombie.Time > 0)
			{
				return _selectZombie.Time <= 10000;
			}
			return false;
		}
		return false;
	}

	private void SetVisible(bool arg1, int arg2)
	{
		_viewModel.PanelShow = arg1;
		if (arg1)
		{
			for (int i = 1; i < 4; i++)
			{
				int idx = i;
				if (i == select)
				{
					_viewModel.SetselectShow(i, value: true);
					base.Loader.RetriveSprite("ui/herofightingmodel", "Assets/Res/Assets/ui/GameGUIRes/herofightingmodel/selecthero/numbg.png", delegate(Sprite sprite)
					{
						_viewModel.SetselectNumSprite(idx, sprite);
					});
				}
				else
				{
					_viewModel.SetselectShow(i, value: false);
					base.Loader.RetriveSprite("ui/herofightingmodel", "Assets/Res/Assets/ui/GameGUIRes/herofightingmodel/selecthero/numbg_back.png", delegate(Sprite sprite)
					{
						_viewModel.SetselectNumSprite(idx, sprite);
					});
				}
			}
			_viewModel.EnergyShow = false;
		}
		else if (!PlayerCareerConstantUtility.IsHero(UiIEventCondition.Get_cameraOwnerData_Career()))
		{
			SetMinHead(show: true);
		}
	}

	private string GetCareer(int index)
	{
		SelectZombieData data = _selectZombie.Data;
		if (data != null)
		{
			switch (index)
			{
			case 1:
				return data.Career1;
			case 2:
				return data.Career2;
			case 3:
				return data.Career3;
			}
		}
		return "";
	}

	private void SetCareer(string career, int index)
	{
		if (string.IsNullOrEmpty(career))
		{
			_viewModel.SetnoheroShow(index, value: true);
			_viewModel.SetheroShow(index, value: false);
			return;
		}
		_viewModel.SetnoheroShow(index, value: false);
		_viewModel.SetheroShow(index, value: true);
		_viewModel.SetheroShow(index, base.Loader.RetriveSprite("ui/herofightingmodel", $"Assets/Res/Assets/ui/GameGUIRes/herofightingmodel/selecthero/{career}.png", delegate(Sprite sprite)
		{
			_viewModel.SetheroSprite(index, sprite);
		}));
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].TypeId != -13500)
			{
				continue;
			}
			if (_viewModel.PanelShow || PlayerCareerConstantUtility.IsHero(UiIEventCondition.Get_cameraOwnerData_Career()))
			{
				_viewModel.EnergyShow = false;
			}
			else
			{
				SetMinHead(tipsEvent[i].Show);
				if (tipsEvent[i].Time1 >= tipsEvent[i].Time2)
				{
					_viewModel.OverShow = true;
				}
				else
				{
					_viewModel.OverShow = false;
				}
			}
			if (tipsEvent[i].Time2 > 0)
			{
				_viewModel.EnergyTimeString = ((int)((float)tipsEvent[i].Time1 * 100f / (float)tipsEvent[i].Time2)).ToString();
				_viewModel.EnergyProgressFillamount = (float)tipsEvent[i].Time1 * 1f / (float)tipsEvent[i].Time2;
			}
			tipsEvent.RemoveAt(i);
			i--;
		}
	}

	public void SetMinHead(bool show)
	{
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType != 134)
		{
			_viewModel.EnergyShow = show;
		}
		_viewModel.headShow = true;
		string arg = GetCareer(select) + "_head";
		base.Loader.RetriveSprite("ui/herofightingmodel", $"Assets/Res/Assets/ui/GameGUIRes/herofightingmodel/selecthero/{arg}.png", delegate(Sprite sprite)
		{
			_viewModel.headSprite = sprite;
		});
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (!_isSelectVariant && key == KeyCode.M && _selectZombie.Time > 5000)
		{
			_isSelectVariant = true;
			_selectZombie.Time = 5000;
		}
		if (_viewModel.PanelShow)
		{
			int alphaOrKeypadDiff = key.GetAlphaOrKeypadDiff();
			IntData intData = new IntData();
			intData.Data = alphaOrKeypadDiff;
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(113, intData);
			if (alphaOrKeypadDiff >= 1 && alphaOrKeypadDiff <= 3 && !_viewModel.GetnoheroShow(alphaOrKeypadDiff))
			{
				_selectZombie.Time = 0;
				_isSelectVariant = false;
				select = alphaOrKeypadDiff;
			}
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
