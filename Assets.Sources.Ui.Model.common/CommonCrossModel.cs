using Assets.Generated.Table;
using Assets.Sources.Constant;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Common;

public class CommonCrossModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetPlayerContext, ISetWeaponContext
{
	private CommonCrossViewModel _viewModel;

	private int _raceType;

	private WeaponCrossTable.Row _crossConfig;

	private GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new CommonCrossViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			CanvasScaler component = _viewModel.ShowObj.transform.root.GetComponent<CanvasScaler>();
			if (Display.main.systemHeight < 768)
			{
				component.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
				return;
			}
			component.uiScaleMode = AbstractModel.BestScaleMode;
			component.referenceResolution = AbstractModel.BestScreenSize;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_AddHp, SetAddHp, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiCross_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_AwpVisible, SetAwpVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_WeaponType, SetWeaponType, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_SpecialMode, SetSpecialMode, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_HideCross, SetHideCross, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_CrossType, SetCrossType, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_CrossColor, SetCrossColor, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_ChangRedCrossTime, SetChangRedCrossTime, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_Left, SetLeft, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_Right, SetRight, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_Up, SetUp, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_Down, SetDown, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_Scale, SetScale, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_PollutionShielding, SetPollutionShielding, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetActThirdMove, SetActThirdMove, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponState_CurrentClip2, SetChangePower, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_WeaponState_SniperGuard, SpecialSetCross, null, initinvoke: true, isFrameSeparation: true);
	}

	private void SpecialSetCross(bool arg1, bool arg2)
	{
		if (UiIEventCondition.Get_uiCross_AddHp() || !(UiIEventCondition.Get_uiCross_WeaponName() == "sniper_guardian"))
		{
			return;
		}
		if (arg2)
		{
			if (RuleUtilty.IsPveModel(_raceType) || RuleUtilty.IsBioMode(_raceType) || RuleUtilty.IsBigHeadModel(_raceType))
			{
				_viewModel.ShowShow = true;
			}
			else
			{
				_viewModel.ShowShow = false;
			}
		}
		else
		{
			_viewModel.ShowShow = false;
		}
	}

	private void SetChangePower(int arg1, int arg2)
	{
		if (!UiIEventCondition.Get_uiCross_AddHp() && UiIEventCondition.Get_uiCross_WeaponName() == "crystal_bow")
		{
			if (UiIEventCondition.Get_uiCross_SpecialMode() || ((UiIEventCondition.Get_uiCross_EffectLevel() & 1) > 0 && UiIEventCondition.Get_weaponState_CurrentClip2() >= UiIEventCondition.Get_weaponState_CarryClip2()))
			{
				_viewModel.ShowShow = true;
			}
			else
			{
				_viewModel.ShowShow = false;
			}
		}
	}

	private void SetPollutionShielding(bool arg1, bool arg2)
	{
		CheckVisible();
	}

	private void SetActThirdMove(bool arg1, bool arg2)
	{
		CheckVisible();
	}

	private bool GetActThirdMove()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.hasMove)
		{
			return !cameraOwnerEntity.move.ActThirdMove;
		}
		return false;
	}

	private void SetHideCross(bool ov, bool hideCross)
	{
		CheckVisible();
	}

	private void SetScale(float ov, float value)
	{
		int num = UiIEventCondition.Get_uiCross_CrossType() + 1;
		if (num == 4 || num == 5)
		{
			_viewModel.SetCycleScale(num, new Vector3(value, value, 1f));
		}
	}

	private void SetRight(int ov, int value)
	{
		int num = UiIEventCondition.Get_uiCross_CrossType() + 1;
		switch (num)
		{
		case 6:
			_viewModel.SetRightPosition(num, new Vector3(value, -value, 0f));
			break;
		case 1:
		case 2:
		case 3:
			_viewModel.SetRightPosition(num, new Vector3(value, 0f, 0f));
			break;
		}
	}

	private void SetUp(int ov, int value)
	{
		int num = UiIEventCondition.Get_uiCross_CrossType() + 1;
		switch (num)
		{
		case 6:
			_viewModel.SetUpPosition(num, new Vector3(value, value));
			break;
		case 1:
		case 2:
		case 3:
			_viewModel.SetUpPosition(num, new Vector3(0f, value));
			break;
		}
	}

	private void SetDown(int ov, int value)
	{
		int num = UiIEventCondition.Get_uiCross_CrossType() + 1;
		switch (num)
		{
		case 6:
			_viewModel.SetDownPosition(num, new Vector3(value, value));
			break;
		case 1:
		case 2:
		case 3:
			_viewModel.SetDownPosition(num, new Vector3(0f, value));
			break;
		}
	}

	private void SetLeft(int ov, int value)
	{
		int num = UiIEventCondition.Get_uiCross_CrossType() + 1;
		switch (num)
		{
		case 6:
			_viewModel.SetLeftPosition(num, new Vector3(value, -value, 0f));
			break;
		case 1:
		case 2:
		case 3:
			_viewModel.SetLeftPosition(num, new Vector3(value, 0f, 0f));
			break;
		}
	}

	private void SetSpecialMode(bool ov, bool value)
	{
		CheckVisible();
	}

	private void SetWeaponType(int ov, int type)
	{
		CheckVisible();
	}

	private void SetChangRedCrossTime(int ov, int time)
	{
		SetColor();
	}

	private void SetCrossColor(int ov, int color)
	{
		SetColor();
	}

	private void SetColor()
	{
		Color color = CrossColor.Colors[UiIEventCondition.Get_uiCross_CrossColor()];
		_viewModel.SetCenterColor(2, color);
		_viewModel.SetCenterColor(4, (UiIEventCondition.Get_uiCross_ChangRedCrossTime() > 0) ? Color.red : color);
		_viewModel.SetCenterColor(5, (UiIEventCondition.Get_uiCross_ChangRedCrossTime() > 0) ? Color.red : color);
		_viewModel.SetCenterColor(6, color);
		_viewModel.SetCycleColor(4, (UiIEventCondition.Get_uiCross_ChangRedCrossTime() > 0) ? Color.red : color);
		_viewModel.SetCycleColor(5, (UiIEventCondition.Get_uiCross_ChangRedCrossTime() > 0) ? Color.red : color);
		_viewModel.SetLeftColor(1, color);
		_viewModel.SetRightColor(1, color);
		_viewModel.SetDownColor(1, color);
		_viewModel.SetUpColor(1, color);
		_viewModel.SetLeftColor(2, color);
		_viewModel.SetRightColor(2, color);
		_viewModel.SetDownColor(2, color);
		_viewModel.SetUpColor(2, color);
		_viewModel.SetLeftColor(3, color);
		_viewModel.SetRightColor(3, color);
		_viewModel.SetDownColor(3, color);
		_viewModel.SetUpColor(3, color);
		_viewModel.SetLeftColor(6, color);
		_viewModel.SetRightColor(6, color);
		_viewModel.SetDownColor(6, color);
		_viewModel.SetUpColor(6, color);
	}

	private void SetCrossType(int ov, int type)
	{
		int num = type + 1;
		for (int i = 1; i <= 6; i++)
		{
			_viewModel.SetTypeShow(i, value: false);
			_viewModel.SetLeftShow(i, value: false);
			_viewModel.SetRightShow(i, value: false);
			_viewModel.SetUpShow(i, value: false);
			_viewModel.SetDownShow(i, value: false);
			_viewModel.SetCenterShow(i, value: false);
			_viewModel.SetCycleShow(i, value: true);
		}
		_viewModel.SetTypeShow(num, value: true);
		if (num == 2 || num == 4 || num == 5 || num == 6)
		{
			_viewModel.SetCenterShow(num, value: true);
		}
		else
		{
			_viewModel.SetCenterShow(num, value: false);
		}
		if (num == 4 || num == 5)
		{
			_viewModel.SetCycleShow(num, value: true);
		}
		else
		{
			_viewModel.SetCycleShow(num, value: false);
		}
		if (num == 1 || num == 2 || num == 3 || num == 6)
		{
			_viewModel.SetLeftShow(num, value: true);
			_viewModel.SetRightShow(num, value: true);
			_viewModel.SetDownShow(num, value: true);
			_viewModel.SetUpShow(num, value: true);
		}
		else
		{
			_viewModel.SetLeftShow(num, value: false);
			_viewModel.SetRightShow(num, value: false);
			_viewModel.SetDownShow(num, value: false);
			_viewModel.SetUpShow(num, value: false);
		}
		SetLeft(0, UiIEventCondition.Get_uiCross_Left());
		SetRight(0, UiIEventCondition.Get_uiCross_Right());
		SetUp(0, UiIEventCondition.Get_uiCross_Up());
		SetDown(0, UiIEventCondition.Get_uiCross_Down());
		SetScale(0f, UiIEventCondition.Get_uiCross_Scale());
	}

	private void SetAwpVisible(bool ov, bool awpShow)
	{
		CheckVisible();
	}

	private void SetWeaponName(string ov, string weaponName)
	{
		_crossConfig = (string.IsNullOrEmpty(weaponName) ? null : WeaponCrossLoader.Instance.Table.Find_Name(weaponName));
		CheckVisible();
	}

	private void SetAddHp(bool ov, bool addHp)
	{
		CheckVisible();
	}

	private void CheckVisible()
	{
		if (UiIEventCondition.Get_pveState_PollutionShielding())
		{
			_viewModel.ShowShow = false;
			return;
		}
		if (UiIEventCondition.Get_uiCross_HideCross() && UiIEventCondition.Get_uiCross_WeaponName() != "night_owl_submachinegun")
		{
			_viewModel.ShowShow = false;
			return;
		}
		if (UiIEventCondition.Get_uiCross_AddHp())
		{
			_viewModel.ShowShow = false;
			return;
		}
		if (UiIEventCondition.Get_uiCross_AwpVisible())
		{
			if (_crossConfig != null && _crossConfig.SniperCross != WeaponCrossTable.SniperCrossType.Normal)
			{
				_viewModel.ShowShow = false;
				return;
			}
		}
		else
		{
			if (_crossConfig != null && _crossConfig.SpecialCross != WeaponCrossTable.CrossType.Normal && _crossConfig.SpecialCross != 0)
			{
				_viewModel.ShowShow = false;
				return;
			}
			if (IsInfraredGuid())
			{
				_viewModel.ShowShow = false;
				return;
			}
		}
		if (UiIEventCondition.Get_uiCross_WeaponType() == 5)
		{
			if (UiIEventCondition.Get_uiCross_WeaponName() == "sniper_guardian")
			{
				_viewModel.ShowShow = UiIEventCondition.Get_WeaponState_SniperGuard();
				return;
			}
			if (UiIEventCondition.Get_uiCross_WeaponName() == "crystal_bow")
			{
				if (UiIEventCondition.Get_uiCross_SpecialMode() || ((UiIEventCondition.Get_uiCross_EffectLevel() & 1) > 0 && UiIEventCondition.Get_weaponState_CurrentClip2() >= UiIEventCondition.Get_weaponState_CarryClip2()))
				{
					_viewModel.ShowShow = true;
				}
				else
				{
					_viewModel.ShowShow = false;
				}
				return;
			}
			if (UiIEventCondition.Get_uiCross_WeaponName() == "fireofjustice" || UiIEventCondition.Get_uiCross_WeaponName() == "fireofjustice1" || UiIEventCondition.Get_uiCross_WeaponName() == "fireofjustice2")
			{
				if (_gameRuleContext.currentRule.Rule.IsBio())
				{
					_viewModel.ShowShow = true;
					return;
				}
			}
			else if (UiIEventCondition.Get_uiCross_WeaponName() == "core_sniper" || UiIEventCondition.Get_uiCross_WeaponName() == "core_sniper1" || UiIEventCondition.Get_uiCross_WeaponName() == "core_sniper2")
			{
				if (_gameRuleContext.currentRule.Rule.IsBio() || _gameRuleContext.currentRule.Rule.IsPve() || _gameRuleContext.currentRule.Rule.IsBighead())
				{
					_viewModel.ShowShow = true;
					return;
				}
			}
			else if (UiIEventCondition.Get_uiCross_WeaponName() == "gaia_sniper")
			{
				if ((UiIEventCondition.Get_uiCross_EffectLevel() & 0x40) > 0)
				{
					_viewModel.ShowShow = true;
					return;
				}
			}
			else if (UiIEventCondition.Get_uiCross_WeaponName() == "light_sniper")
			{
				if (_gameRuleContext.currentRule.Rule.IsBio() || _gameRuleContext.currentRule.Rule.IsPve())
				{
					_viewModel.ShowShow = true;
					return;
				}
			}
			else if (UiIEventCondition.Get_uiCross_WeaponName() == "vinesheart_sniper")
			{
				if ((_gameRuleContext.currentRule.Rule.IsBio() || _gameRuleContext.currentRule.Rule.IsPve() || _gameRuleContext.currentRule.Rule.IsBighead()) && !UiIEventCondition.Get_uiCross_SpecialMode())
				{
					_viewModel.ShowShow = true;
				}
				else
				{
					_viewModel.ShowShow = false;
				}
				return;
			}
			if (UiIEventCondition.Get_uiCross_WeaponName() == "end_bow" && (UiIEventCondition.Get_uiCross_SpecialMode() || ((UiIEventCondition.Get_uiCross_EffectLevel() & 0x40) > 0 && (UiIEventCondition.Get_uiCross_EffectLevel() & 4) > 0)))
			{
				_viewModel.ShowShow = true;
				return;
			}
			if (_crossConfig != null && !IsShowSniperCross() && _crossConfig.SpecialCross != WeaponCrossTable.CrossType.Normal)
			{
				_viewModel.ShowShow = false;
				return;
			}
		}
		if (UiIEventCondition.Get_uiCross_WeaponName() == "mechbomberman2")
		{
			if (GetActThirdMove())
			{
				_viewModel.ShowShow = false;
				return;
			}
		}
		else if (UiIEventCondition.Get_uiCross_WeaponName() == "rainbow_pistol")
		{
			if ((UiIEventCondition.Get_uiCross_EffectLevel() & 0x20) > 0 && (UiIEventCondition.Get_uiCross_EffectLevel() & 2) > 0)
			{
				_viewModel.ShowShow = false;
				return;
			}
		}
		else if (UiIEventCondition.Get_uiCross_WeaponName() == "trans_machinegun")
		{
			if (UiIEventCondition.Get_uiCross_SpecialMode())
			{
				_viewModel.ShowShow = false;
				return;
			}
		}
		else if (UiIEventCondition.Get_uiCross_WeaponName() == "prism_shotgun")
		{
			_viewModel.ShowShow = false;
			return;
		}
		_viewModel.ShowShow = true;
	}

	private bool IsInfraredGuid()
	{
		if (_crossConfig != null && _crossConfig.InfraredGuid)
		{
			return UiIEventCondition.Get_uiCross_SpecialMode();
		}
		return false;
	}

	private bool IsShowSniperCross()
	{
		if (_crossConfig.SpecialModel && UiIEventCondition.Get_uiCross_SpecialMode())
		{
			return true;
		}
		if (_crossConfig.SpecialPve && _gameRuleContext.currentRule.Rule.IsPve())
		{
			return true;
		}
		if (_crossConfig.SpecialBio && _gameRuleContext.currentRule.Rule.IsBio())
		{
			return true;
		}
		if (_weaponContext.currentWeaponEntity.hasSpecial && (_weaponContext.currentWeaponEntity.special.EffectLevel & _crossConfig.EffectLevel) > 0)
		{
			return true;
		}
		return false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}
