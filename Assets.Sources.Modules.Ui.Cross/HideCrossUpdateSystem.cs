using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Ui.UiEventCondition;
using NetData;
using careerConfigPackage;
using share.constant;

namespace Assets.Sources.Modules.Ui.Cross;

public class HideCrossUpdateSystem : IPlaybackSystem
{
	private CrossContext _crossContext;

	private PlayerContext _playerContext;

	private WeaponContext _weaponContext;

	private MessageContext _messageContext;

	private bool _isRpgSurvivalPvp;

	private bool _isCrazyBigHead;

	private WeaponEntity _weaponEntity;

	private PlayerEntity _cameraOwner;

	private HashSet<string> _specialMoveHideCross = new HashSet<string> { "m60e6bloodanger2", "whitetiger", "whitetiger1" };

	private HashSet<string> _specialModeHideCross = new HashSet<string> { "awm_legend_ct", "awm_legend_t" };

	private HashSet<string> _weaponHideCross = new HashSet<string> { "hormone_injection", "hormone_injection1", "hormone_injection2" };

	private HashSet<string> _weaponShowCross = new HashSet<string> { "light_with_shadow", "shadow_demon", "shadow_demon_bayonet", "shadow_demon_archer", "shadow_demon_sickle", "p3hero_gun_weapon", "thunder_submachinegun_legend1", "thunder_submachinegun_legend2" };

	private HashSet<string> _careerShowCross = new HashSet<string> { "p3hero" };

	public HideCrossUpdateSystem(Contexts contexts)
	{
		_crossContext = contexts.cross;
		_playerContext = contexts.player;
		_weaponContext = contexts.weapon;
		_messageContext = contexts.message;
		_isCrazyBigHead = contexts.battleRoom.roomData.Data.RaceType == 120;
		_isRpgSurvivalPvp = contexts.battleRoom.roomData.Data.RaceType == 15006;
	}

	public void OnPlayback()
	{
		if (_playerContext.isCameraOwner && _weaponContext.isCurrentWeapon)
		{
			_weaponEntity = _weaponContext.currentWeaponEntity;
			if (_weaponEntity.hasBasicInfo)
			{
				_cameraOwner = _playerContext.cameraOwnerEntity;
				_crossContext.isHideCross = CheckHideCrossVisible();
			}
		}
	}

	private bool CheckHideCrossVisible()
	{
		if (UiIEventCondition.Get_pveState_UltrasonicTime() > 0)
		{
			return true;
		}
		string career = _cameraOwner.GetCareer();
		string uiCross_WeaponName = UiIEventCondition.Get_uiCross_WeaponName();
		PlayerCareerConfig config = CareerConfigManager.GetInstance().GetConfig(career);
		if (!string.IsNullOrEmpty(career) && _cameraOwner.isThirdPersonView && _cameraOwner.GetPlayerInfo().ParasiticId == 0 && config != null && !config.isMech2 && !PlayerCareerUtil.IsAnimal(career) && !_isCrazyBigHead && !_isRpgSurvivalPvp && !_weaponShowCross.Contains(uiCross_WeaponName) && !_careerShowCross.Contains(career) && !PlayerCareerUtil.IsTPS(career))
		{
			return true;
		}
		switch (uiCross_WeaponName)
		{
		case "block_combined_jet":
		case "notdistinguish":
		case "notdistinguish1":
		case "notdistinguish2":
			if ((UiIEventCondition.Get_uiCross_EffectLevel() & 1) > 0)
			{
				return true;
			}
			break;
		}
		if (_weaponHideCross.Contains(uiCross_WeaponName))
		{
			return true;
		}
		if (_specialMoveHideCross.Contains(uiCross_WeaponName) && UiIEventCondition.Get_uiCross_SpecialMode() && _cameraOwner.move.Moving)
		{
			return true;
		}
		if (_specialModeHideCross.Contains(uiCross_WeaponName) && !_crossContext.isAwpCross && UiIEventCondition.Get_uiCross_SpecialMode() && AwmLegendBaseAction.IsMiaoZhun(_weaponEntity))
		{
			return true;
		}
		if (_messageContext.floatingMessage.DragoonData != null && _messageContext.floatingMessage.DragoonData.Open && _messageContext.floatingMessage.DragoonData.SkillType != FloatingSkillType.USEDRAGOON)
		{
			return true;
		}
		if (_cameraOwner.HasStatus(PlayerInfoStatusConstant.DEAD_EYE_FLAG.ID) || _cameraOwner.HasStatus(PlayerInfoStatusConstant.SKIN_DEAD_EYE_FLAG_PURPLESURGE.ID))
		{
			return true;
		}
		BaseWeaponData data = Contexts.sharedInstance.weapon.currentWeaponEntity.basicInfo.Data;
		if (data != null && data.HideCross)
		{
			return true;
		}
		return false;
	}
}
