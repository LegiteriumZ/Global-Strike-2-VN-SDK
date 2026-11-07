using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom.Conditions;

public class NotCondition : IWeaponCondition
{
	private readonly IWeaponCondition _condition;

	public NotCondition(IWeaponCondition condition)
	{
		_condition = condition;
	}

	public bool DoCondition(ref CommonWeaponArg arg)
	{
		if (_condition == null)
		{
			return false;
		}
		return !_condition.DoCondition(ref arg);
	}
}
