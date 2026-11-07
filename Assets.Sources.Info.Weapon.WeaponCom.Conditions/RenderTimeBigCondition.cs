using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom.Conditions;

public class RenderTimeBigCondition : IWeaponCondition
{
	public int NextExced;

	public RenderTimeBigCondition(int nextExced)
	{
		NextExced = nextExced;
	}

	public bool DoCondition(ref CommonWeaponArg arg)
	{
		return arg.ClientTime >= NextExced;
	}
}
