using weapon.predicateSystem.implementSeparately;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class ReloadPredicationManager : IPredicationManager
{
	public static ReloadPredicationManager Instance = new ReloadPredicationManager();

	public void OnPredicate(ICommonWeaponArgs weaponArgs)
	{
		IWeaponPropertiesAdapter currentWeapon = weaponArgs.GetCurrentWeapon();
		if (currentWeapon != null && currentWeapon.GetPredicationConfig() != null)
		{
			currentWeapon.GetPredicationConfig().CheckInit();
			currentWeapon.GetPredicationConfig().GetReloadPredicationSystem().OnPredicate(weaponArgs);
		}
	}

	public ISharedUtils GetUtils()
	{
		return SharedUtils.Instance;
	}
}
