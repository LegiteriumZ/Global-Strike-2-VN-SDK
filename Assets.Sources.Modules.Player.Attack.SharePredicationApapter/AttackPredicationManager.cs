using weapon.predicateSystem.implementSeparately;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class AttackPredicationManager : IPredicationManager
{
	public static AttackPredicationManager Instance = new AttackPredicationManager();

	public void OnPredicate(ICommonWeaponArgs weaponArgs)
	{
		if (weaponArgs.GetCurrentWeapon().GetPredicationConfig() != null)
		{
			IWeaponPropertiesAdapter currentWeapon = weaponArgs.GetCurrentWeapon();
			currentWeapon.GetPredicationConfig().CheckInit();
			currentWeapon.GetPredicationConfig().GetAttackPredicationSystem().OnPredicate(weaponArgs);
		}
	}

	public ISharedUtils GetUtils()
	{
		return SharedUtils.Instance;
	}
}
