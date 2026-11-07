using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.EventLogic;

internal class OppsiteDefaultEventLogic : IEventLogic
{
	public void PlayEvent(PlayerEntity entity, int eventId)
	{
		switch (eventId)
		{
		case 1:
		case 11:
			if (!WeaponUtility.HasMuzzleFlash(entity, eventId == 11) || entity.fov.Fov != 90)
			{
				break;
			}
			if (entity.hasThirdPersonUnityObjects)
			{
				if (WeaponUtility.IsAllFire(entity))
				{
					WeaponUtility.AllFire(entity.thirdPersonUnityObjects.LeftFires, entity.GetCurrentWeaponSubType() != 0);
				}
				else
				{
					WeaponUtility.Fire(entity.thirdPersonUnityObjects.LeftFires, entity.GetCurrentWeaponSubType() != 0);
				}
			}
			if (entity.hasFirstPersonUnityObjects)
			{
				if (WeaponUtility.IsAllFire(entity))
				{
					WeaponUtility.AllFire(entity.firstPersonUnityObjects.LeftFires, entity.GetCurrentWeaponSubType() != 0);
				}
				else
				{
					WeaponUtility.Fire(entity.firstPersonUnityObjects.LeftFires, entity.GetCurrentWeaponSubType() != 0);
				}
			}
			break;
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
					WeaponUtility.Fire(entity.thirdPersonUnityObjects.RightFires, entity.GetCurrentWeaponSubType() != 0);
				}
				if (entity.hasFirstPersonUnityObjects)
				{
					WeaponUtility.Fire(entity.firstPersonUnityObjects.RightFires, entity.GetCurrentWeaponSubType() != 0);
				}
			}
			break;
		}
	}
}
