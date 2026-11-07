using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Utils.PlayerAnim;
using Entitas;

namespace Assets.Sources.Modules.Player.Attack;

internal class PlayerWeaponParticleEffectPlaybackSystem : IPlaybackSystem
{
	private IGroup<PlayerEntity> _viewEntities;

	private IGroup<PlayerEntity> _thirdEntities;

	private WeaponContext _weaponContext;

	public PlayerWeaponParticleEffectPlaybackSystem(Contexts contexts)
	{
		_weaponContext = contexts.weapon;
		_viewEntities = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.FirstPersonUnityObjects, PlayerMatcher.CurrentWeapon, PlayerMatcher.BasicInfo));
		_thirdEntities = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.CurrentWeapon));
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity viewEntity in _viewEntities)
		{
			if (!_weaponContext.isCurrentWeapon || !viewEntity.basicInfo.Current.CurrentWeaponName.Equals(_weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName) || !viewEntity.firstPersonUnityObjects.WeaponName.Equals(viewEntity.basicInfo.Current.CurrentWeaponName))
			{
				continue;
			}
			foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> firstPersonPatricle in viewEntity.GetFirstPersonPatricles())
			{
				IPaticlePrefabInstancecs value = firstPersonPatricle.Value;
				bool flag = true;
				if (viewEntity.hasViewAnim && viewEntity.viewAnim.ViewAnimInfo != null)
				{
					int stateId = viewEntity.viewAnim.ViewAnimInfo.StateId;
					int remainTime = viewEntity.viewAnim.RemainTime;
					if (!value.getAnimationEffectConfig().IsRange(stateId, remainTime, 1))
					{
						flag = false;
					}
				}
				if (value.getVisibleState() == 0)
				{
					if (value.getAnimationEffectConfig().IsEffect())
					{
						value.SetInsActive(flag);
					}
				}
				else
				{
					value.SetInsActive(flag && (viewEntity.GetCurrentWeaponEffectLevel() & (1 << (int)(value.getVisibleState() - 1))) > 0);
				}
			}
		}
		foreach (PlayerEntity thirdEntity in _thirdEntities)
		{
			if (!thirdEntity.thirdPersonUnityObjects.WeaponInfo.Name.Equals(thirdEntity.currentWeapon.WeaponInfo.Name))
			{
				continue;
			}
			foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> thirdPersonPatricle in thirdEntity.GetThirdPersonPatricles())
			{
				IPaticlePrefabInstancecs value2 = thirdPersonPatricle.Value;
				bool flag2 = true;
				if (thirdEntity.hasTorseAnim && thirdEntity.torseAnim.TorsoAnimInfo != null)
				{
					int stateId2 = thirdEntity.torseAnim.TorsoAnimInfo.StateId;
					int eclipsedTime = thirdEntity.torseAnim.EclipsedTime;
					int torseAnimDuration = PlayerAnimationUtility.GetTorseAnimDuration(thirdEntity, stateId2);
					if (torseAnimDuration != 0)
					{
						eclipsedTime %= torseAnimDuration;
						if (!value2.getAnimationEffectConfig().IsRange(stateId2, torseAnimDuration - eclipsedTime, 2))
						{
							flag2 = false;
						}
					}
				}
				if (value2.getVisibleState() == 0)
				{
					if (value2.getAnimationEffectConfig().IsEffect())
					{
						value2.SetInsActive(flag2);
					}
				}
				else
				{
					value2.SetInsActive(flag2 && (thirdEntity.GetCurrentWeaponEffectLevel() & (1 << (int)(value2.getVisibleState() - 1))) > 0);
				}
			}
		}
	}
}
