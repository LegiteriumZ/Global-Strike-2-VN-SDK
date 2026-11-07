using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgSkillBoardModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private AcgSkillBoardViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private TimeContext _timeContext;

	private ISSJJTimer _timer;

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
		_viewModel = new AcgSkillBoardViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
			UpdateTime();
		}
	}

	private void UpdateTime()
	{
		if (_timeContext.hasCommonTimer)
		{
			if (_timeContext.commonTimer.CommonTimer.TryGetValue("ACG_CHARACTER_SKILL", out _timer))
			{
				_viewModel.CharacterTimeShow = true;
				_viewModel.CharacterCoolingShow = true;
				_viewModel.CharacterReadyShow = false;
				_viewModel.CharacterTimeString = (_timer.LeftTime / 1000).ToString();
				_viewModel.CharacterProgressFillamount = (float)_timer.LeftTime / (float)_timer.Length;
			}
			else
			{
				_viewModel.CharacterTimeShow = false;
				_viewModel.CharacterCoolingShow = false;
				_viewModel.CharacterReadyShow = true;
				_viewModel.CharacterProgressFillamount = 0f;
			}
			if (_timeContext.commonTimer.CommonTimer.TryGetValue("ACG_WEAPON_SKILL", out _timer))
			{
				_viewModel.WeaponTimeShow = true;
				_viewModel.WeaponCoolingShow = true;
				_viewModel.WeaponReadyShow = false;
				_viewModel.WeaponTimeString = (_timer.LeftTime / 1000).ToString();
				_viewModel.WeaponProgressFillamount = (float)_timer.LeftTime / (float)_timer.Length;
			}
			else
			{
				_viewModel.WeaponTimeShow = false;
				_viewModel.WeaponCoolingShow = false;
				_viewModel.WeaponReadyShow = true;
				_viewModel.WeaponProgressFillamount = 0f;
			}
		}
	}

	protected override void DoSubscribe()
	{
		_timeContext = Contexts.sharedInstance.time;
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_AcgCharacterSkillName, SetCharcterSkill, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_AcgWeaponSkillName, SetWeaponSkill, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_AcgCharacterEnergy, SetCharcterEnergy, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_AcgWeaponEnergy, SetWeaponEnergy, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_AcgCharacterSilented, SetCharacterSilented, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_AcgWeaponSilented, SetWeaponSilented, null, initinvoke: true);
	}

	private void SetCharacterSilented(bool oldBool, bool newbool)
	{
		_viewModel.CharacterSilenceShow = newbool;
	}

	private void SetWeaponSilented(bool oldBool, bool newbool)
	{
		_viewModel.WeaponSilenceShow = newbool;
	}

	private void SetCharcterEnergy(int oldInt, int newInt)
	{
		_viewModel.CharacterEnergyString = newInt.ToString();
	}

	private void SetWeaponEnergy(int oldInt, int newInt)
	{
		_viewModel.WeaponEnergyString = newInt.ToString();
	}

	private void SetCharcterSkill(int oldInt, int newInt)
	{
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/SkillIcons/" + newInt + ".png", delegate(Sprite sprite)
		{
			_viewModel.CharacterReadyImage.sprite = sprite;
		});
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/SkillIcons/" + newInt + "C.png", delegate(Sprite sprite)
		{
			_viewModel.CharacterCoolingImage.sprite = sprite;
		});
	}

	private void SetWeaponSkill(int oldInt, int newInt)
	{
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/SkillIcons/" + newInt + ".png", delegate(Sprite sprite)
		{
			_viewModel.WeaponReadyImage.sprite = sprite;
		});
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/SkillIcons/" + newInt + "C.png", delegate(Sprite sprite)
		{
			_viewModel.WeaponCoolingImage.sprite = sprite;
		});
		_viewModel.WeaponEnergyString = _gameRuleContext.acgSkill.AcgWeaponSkill.Energy.ToString();
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
