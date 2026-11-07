using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.EventLogic;

internal class RiderDouGunEventLogic : IEventLogic
{
	public void PlayEvent(PlayerEntity entity, int eventId)
	{
		switch (eventId)
		{
		case 1:
		case 11:
		{
			if (!WeaponUtility.HasMuzzleFlash(entity, eventId == 11) || entity.fov.Fov != 90)
			{
				break;
			}
			bool flag = false;
			if (entity.torseAnim != null && entity.torseAnim.TorsoAnimInfo != null)
			{
				flag = entity.torseAnim.TorsoAnimInfo.StateId == 40 || entity.torseAnim.TorsoAnimInfo.StateId == 39 || entity.torseAnim.TorsoAnimInfo.StateId == 46;
			}
			if (entity.hasThirdPersonUnityObjects)
			{
				if (flag)
				{
					WeaponUtility.Fire(entity.thirdPersonUnityObjects.RightFires, entity.GetCurrentWeaponSubType() != 0, "weapon_particle_fire_effect1");
				}
				else
				{
					WeaponUtility.Fire(entity.thirdPersonUnityObjects.RightFires, entity.GetCurrentWeaponSubType() != 0, "weapon_particle_fire_effect");
					WeaponUtility.Fire(entity.thirdPersonUnityObjects.LeftFires, entity.GetCurrentWeaponSubType() != 0, "weapon_left_particle_fire_effect");
				}
			}
			if (entity.hasFirstPersonUnityObjects)
			{
				if (flag)
				{
					WeaponUtility.Fire(entity.firstPersonUnityObjects.RightFires, entity.GetCurrentWeaponSubType() != 0, "weapon_particle_fire_effect1");
					break;
				}
				WeaponUtility.Fire(entity.firstPersonUnityObjects.RightFires, entity.GetCurrentWeaponSubType() != 0, "weapon_particle_fire_effect");
				WeaponUtility.Fire(entity.firstPersonUnityObjects.LeftFires, entity.GetCurrentWeaponSubType() != 0, "weapon_left_particle_fire_effect");
			}
			break;
		}
		case 59:
			if (WeaponUtility.HasMuzzleFlash(entity, secondaryFire: false) && entity.fov.Fov == 90)
			{
				WeaponUtility.Fire(entity.thirdPersonUnityObjects.RightFires, entity.GetCurrentWeaponSubType() != 0);
			}
			break;
		case 47:
			if (WeaponUtility.HasMuzzleFlash(entity, secondaryFire: false) && entity.fov.Fov == 90)
			{
				if (entity.hasThirdPersonUnityObjects)
				{
					WeaponUtility.Fire(entity.thirdPersonUnityObjects.LeftFires, entity.GetCurrentWeaponSubType() != 0);
				}
				if (entity.hasFirstPersonUnityObjects)
				{
					WeaponUtility.Fire(entity.firstPersonUnityObjects.LeftFires, entity.GetCurrentWeaponSubType() != 0);
				}
			}
			break;
		}
	}
}
