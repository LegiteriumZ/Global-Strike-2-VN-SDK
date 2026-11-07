using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Attack;

internal class PlayerWeaponLogicEffectPlaybackSystem : IPlaybackSystem
{
	private IGroup<PlayerEntity> _viewEntities;

	private IGroup<PlayerEntity> _thirdEntities;

	private WeaponContext _weaponContext;

	public PlayerWeaponLogicEffectPlaybackSystem(Contexts contexts)
	{
		_weaponContext = contexts.weapon;
		_viewEntities = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.FirstPersonUnityObjects, PlayerMatcher.CurrentWeapon));
		_thirdEntities = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.CurrentWeapon));
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity viewEntity in _viewEntities)
		{
			if (_weaponContext.isCurrentWeapon && viewEntity.currentWeapon.Name.Equals(_weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName) && viewEntity.firstPersonUnityObjects.WeaponName.Equals(viewEntity.currentWeapon.WeaponInfo.Name))
			{
				viewEntity.firstPersonUnityObjects.ParticleLogicAsset?.ViewWeaponOnFrame(viewEntity, _weaponContext.currentWeaponEntity, null);
			}
		}
		foreach (PlayerEntity thirdEntity in _thirdEntities)
		{
			if (thirdEntity.thirdPersonUnityObjects.WeaponInfo.Name.Equals(thirdEntity.currentWeapon.WeaponInfo.Name))
			{
				thirdEntity.thirdPersonUnityObjects.ParticleLogicAsset?.ThirdWeaponOnFrame(thirdEntity, null, null);
			}
		}
	}
}
