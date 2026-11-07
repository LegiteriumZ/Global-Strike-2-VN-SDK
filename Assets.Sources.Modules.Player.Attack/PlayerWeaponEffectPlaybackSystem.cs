using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Attack;

internal class PlayerWeaponEffectPlaybackSystem : IPlaybackSystem
{
	private IGroup<PlayerEntity> _viewEntities;

	private IGroup<PlayerEntity> _thirdEntities;

	private BattleRoomContext _battleContext;

	private WeaponContext _weaponContext;

	public PlayerWeaponEffectPlaybackSystem(Contexts contexts)
	{
		_battleContext = contexts.battleRoom;
		_weaponContext = contexts.weapon;
		_viewEntities = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.FirstPersonUnityObjects, PlayerMatcher.CurrentWeapon));
		_thirdEntities = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.CurrentWeapon));
	}

	public void OnPlayback()
	{
		int raceType = _battleContext.roomData.Data.RaceType;
		foreach (PlayerEntity viewEntity in _viewEntities)
		{
			if (!_weaponContext.isCurrentWeapon || !viewEntity.currentWeapon.Name.Equals(_weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName) || !viewEntity.firstPersonUnityObjects.WeaponName.Equals(viewEntity.currentWeapon.WeaponInfo.Name))
			{
				continue;
			}
			foreach (IViewWeaponEffectLogic viewWeaponEffectLogic in viewEntity.currentWeapon.WeaponInfo.ViewWeaponEffectLogics)
			{
				if (!viewWeaponEffectLogic.Inited)
				{
					viewWeaponEffectLogic.Init(viewEntity);
				}
				viewWeaponEffectLogic.Update(viewEntity, _weaponContext.currentWeaponEntity, raceType);
			}
		}
		foreach (PlayerEntity thirdEntity in _thirdEntities)
		{
			if (!thirdEntity.thirdPersonUnityObjects.WeaponInfo.Name.Equals(thirdEntity.currentWeapon.WeaponInfo.Name))
			{
				continue;
			}
			foreach (IThirdWeaponEffectLogic thirdWeaponEffectLogic in thirdEntity.currentWeapon.WeaponInfo.ThirdWeaponEffectLogics)
			{
				if (!thirdWeaponEffectLogic.Inited)
				{
					thirdWeaponEffectLogic.Init(thirdEntity);
				}
				thirdWeaponEffectLogic.Update(thirdEntity, raceType);
			}
		}
	}
}
