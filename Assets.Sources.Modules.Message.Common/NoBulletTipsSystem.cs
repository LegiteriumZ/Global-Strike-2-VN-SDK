using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.Logger;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Message.Common;

public class NoBulletTipsSystem : IMessagePlaybackSystem, IPlaybackSystem
{
	private PlayerContext _playerContext;

	private WeaponContext _weaponContext;

	private GameRuleContext _gameRuleContext;

	private UserCommandContext _userCommandContext;

	private MessageContext _messageContext;

	private TimeComponent _timeComponent;

	public static HashSet<string> _noBulletIgnore = new HashSet<string> { "mk14_redflash", "mk14_redflash1", "mk14_redflash_ether", "mk14_redflash_ether1", "mk14_redflash_rose", "mk14_redflash_rose1", "mk14_redflash_wolfram", "mk14_redflash_wolfram1", "rifle_opticor" };

	private HashSet<string> _checkPower = new HashSet<string> { "rpg_7", "rpg_7_1", "rpg_7_2", "fire_demon_rpg", "fire_demon_rpg1", "fire_demon_rpg2", "pistol_electric" };

	private int _sendTipsEvent;

	public NoBulletTipsSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_weaponContext = contexts.weapon;
		_gameRuleContext = contexts.gameRule;
		_userCommandContext = contexts.userCommand;
		_messageContext = contexts.message;
		_timeComponent = contexts.time.time;
	}

	private bool IsNoBullet()
	{
		if (!_playerContext.isCameraOwner)
		{
			return false;
		}
		if (!_weaponContext.isCurrentWeapon)
		{
			return false;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (_checkPower.Contains(UiIEventCondition.Get_weaponState_WeaponName()))
		{
			if (currentWeaponEntity.hasPower)
			{
				return currentWeaponEntity.power.Power <= 0;
			}
			return false;
		}
		if (!cameraOwnerEntity.hasCurrentWeapon)
		{
			return false;
		}
		if (cameraOwnerEntity.currentWeapon.WeaponInfo == null)
		{
			return false;
		}
		if (!cameraOwnerEntity.currentWeapon.WeaponInfo.Name.Equals(UiIEventCondition.Get_weaponState_WeaponName()))
		{
			return false;
		}
		if (!cameraOwnerEntity.basicInfo.Current.CurrentWeaponName.Equals(UiIEventCondition.Get_weaponState_WeaponName()))
		{
			return false;
		}
		if (cameraOwnerEntity.basicInfo.Current.CurrentWeapon > 2)
		{
			return false;
		}
		if (UiIEventCondition.Get_weaponState_CurrentClip1() > 0 || UiIEventCondition.Get_weaponState_CarryClip1() > 0)
		{
			return false;
		}
		if (UiIEventCondition.Get_weaponState_ClipCount() > 1 && (UiIEventCondition.Get_weaponState_CurrentClip2() > 0 || UiIEventCondition.Get_weaponState_CarryClip2() > 0))
		{
			return false;
		}
		if (!_weaponContext.isCurrentWeapon)
		{
			this.LogError("IsNoBullet() : !_weaponContext.isCurrentWeapon");
			return false;
		}
		WeaponEntity currentWeaponEntity2 = _weaponContext.currentWeaponEntity;
		if (_noBulletIgnore.Contains(currentWeaponEntity2.basicInfo.Data.WeaponName) && currentWeaponEntity2.hasSpecial && currentWeaponEntity2.special.SpecialMode)
		{
			return false;
		}
		return true;
	}

	public void OnPlayback()
	{
		if (IsNoBullet())
		{
			if (_gameRuleContext.currentRule.Rule.IsRpg())
			{
				_sendTipsEvent += _timeComponent.FrameInterval;
				if (_sendTipsEvent > 1000 && !_checkPower.Contains(UiIEventCondition.Get_weaponState_WeaponName()))
				{
					_messageContext.gameTipsShow.TipsEvent.Add(new RpgTipsEventData
					{
						TypeId = -2527
					});
					NotifyManager.ForceInvoke(14);
				}
			}
			if (_userCommandContext.commands.CommandList.Last != null)
			{
				UserCmd value = _userCommandContext.commands.CommandList.Last.Value;
				if (value != null && value.IsAttackOn && UiIEventCondition.Get_cameraOwnerData_Observer() == 0)
				{
					_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("WeaponNoClip"), 1000);
					NotifyManager.ForceInvoke(38);
					IsNoBullet();
				}
			}
		}
		else
		{
			_sendTipsEvent = 0;
		}
	}

	public bool NeedStart(Contexts contexts)
	{
		return true;
	}
}
