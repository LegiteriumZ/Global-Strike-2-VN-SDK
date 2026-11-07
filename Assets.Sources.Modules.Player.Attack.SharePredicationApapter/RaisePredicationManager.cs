using weapon.predicateSystem.implementSeparately;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class RaisePredicationManager : IPredicationManager
{
	public static RaisePredicationManager Instance = new RaisePredicationManager();

	public void OnPredicate(ICommonWeaponArgs weaponArgs)
	{
		if (Contexts.sharedInstance.weapon.currentWeaponEntity != null && Contexts.sharedInstance.weapon.lastWeaponEntity != null)
		{
			IWeaponPropertiesAdapter currentWeapon = weaponArgs.GetCurrentWeapon();
			if (currentWeapon != null && currentWeapon.GetPredicationConfig() != null && weaponArgs.GetCurrentWeapon().GetPredicationConfig() != null)
			{
				float raiseSpeed = 1f;
				currentWeapon.GetPredicationConfig().CheckInit();
				currentWeapon.GetPredicationConfig().GetRaisePredicationSystem().OnPredicate(weaponArgs, raiseSpeed);
			}
		}
	}

	public ISharedUtils GetUtils()
	{
		return SharedUtils.Instance;
	}
}
