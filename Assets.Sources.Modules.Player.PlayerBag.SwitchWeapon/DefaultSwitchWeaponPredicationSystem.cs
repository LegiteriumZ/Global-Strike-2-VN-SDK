using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Utils.ComponentInit;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;
using SSJJUserCmd;
using share.constant;

namespace Assets.Sources.Modules.Player.PlayerBag.SwitchWeapon;

internal class DefaultSwitchWeaponPredicationSystem : IPredicateSystem
{
	private readonly PlayerBagContext _playerBagContext;

	private readonly WeaponContext _weaponContext;

	private readonly GameRuleContext _gameRuleContext;

	private readonly MessageContext _messageContext;

	private readonly WorldCameraContext _worldCameraContext;

	public DefaultSwitchWeaponPredicationSystem(Contexts contexts)
	{
		_playerBagContext = contexts.playerBag;
		_weaponContext = contexts.weapon;
		_gameRuleContext = contexts.gameRule;
		_messageContext = contexts.message;
		_worldCameraContext = contexts.worldCamera;
	}

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		int clientTime = player.clientTime.ClientTime;
		ChangeWeapon(player, cmd.Weapon, clientTime);
	}

	public bool IsSceneRenderEnabled()
	{
		if (_worldCameraContext.hasCameraEffect && _worldCameraContext.cameraEffect.HideScene)
		{
			return false;
		}
		return true;
	}

	private bool EnableLockWeapon(WeaponEntity targetWeapon)
	{
		if (targetWeapon == null)
		{
			if (_gameRuleContext.currentRule.Rule.GetLockWeapon())
			{
				if (_gameRuleContext.currentRule.Rule.IsLockWeaponTips())
				{
					_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("CurrentCannotChangeWeapon"), 1000);
					NotifyManager.ForceInvoke(38);
				}
			}
			else
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("ChangeWeaponFailure"), 1000);
				NotifyManager.ForceInvoke(38);
			}
			return false;
		}
		if (!targetWeapon.basicInfo.Data.CantChangeTip && targetWeapon.basicInfo.Data.Clip > 0)
		{
			return false;
		}
		return true;
	}

	private bool EnableBow(WeaponEntity targetWeapon, int slot)
	{
		if (slot > 3 && targetWeapon.clip.Clip <= 0 && _gameRuleContext.currentRule.Rule.GetLockWeapon())
		{
			if (slot == 4)
			{
				if (_gameRuleContext.currentRule.Rule.IsLockWeaponTips())
				{
					_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("ChangeWeaponFailure"), 1000);
					NotifyManager.ForceInvoke(38);
				}
				return false;
			}
			if (_gameRuleContext.currentRule.Rule.IsLockWeaponTips())
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("CurrentCannotChangeWeapon"), 1000);
				NotifyManager.ForceInvoke(38);
			}
		}
		return true;
	}

	protected virtual void ChangeWeapon(PlayerEntity player, int slot, int clientTime)
	{
		int currentBagId = player.basicInfo.Current.CurrentBagId;
		int index = player.currentWeapon.Index;
		PlayerBagEntity entityWithBagId = _playerBagContext.GetEntityWithBagId(currentBagId);
		if (entityWithBagId == null || RuleUtilty.IsAvatarUltimateChallenge() || PlayerCareerConstantUtility.IsNoHuMan(player.GetCareer()) || !IsSceneRenderEnabled() || ((slot == 1 || slot == 2 || slot == 3) && player.HasStatus(PlayerInfoStatusConstant.CANNOT_CHANGE_WEAPON_IN_ONE_BAG.ID)) || (slot == 5 && player.HasStatus(PlayerInfoStatusConstant.CANNOT_CHANGE_TACTICAL_WEAPON.ID)))
		{
			return;
		}
		WeaponEntity weaponAtSlot = WeaponUtility.GetWeaponAtSlot(player, currentBagId, slot, index);
		if (WeaponUtility.NonCuttingWeapon(weaponAtSlot) || !EnableLockWeapon(weaponAtSlot))
		{
			return;
		}
		if (WeaponUtility.IsBowCanSwitchToWeapon(player, entityWithBagId, slot))
		{
			if (WeaponUtility.CanSwitchToWeapon(player, currentBagId, weaponAtSlot))
			{
				if (WeaponUtility.WeaponCanBeChanged(player, currentBagId, weaponAtSlot) && EnableBow(weaponAtSlot, slot))
				{
					if (player.hasEventParticle)
					{
						player.eventParticle.EventParticles.Clear();
					}
					WeaponUtility.ChangeCurrentWeapon(player, _weaponContext.currentWeaponEntity, weaponAtSlot, slot);
					WeaponUtility.CopyToWeaponComponent(player.currentWeapon, weaponAtSlot);
					PlayerEntityUtility.CleanupFirstPersonUnityObjects(player);
					player.fov.Fov = 90;
					weaponAtSlot.special.IsRaise = true;
				}
			}
			else
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("PHOTO_SWORD_COMBINATION_USEKNIFE"), 1000);
				NotifyManager.ForceInvoke(38);
			}
		}
		else if (_gameRuleContext.currentRule.Rule.IsLockWeaponTips())
		{
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("ChangeWeaponFailure"), 1000);
			NotifyManager.ForceInvoke(38);
		}
	}
}
