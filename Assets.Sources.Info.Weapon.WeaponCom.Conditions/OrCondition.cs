using System.Collections.Generic;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom.Conditions;

public class OrCondition : IWeaponCondition
{
	public List<IWeaponCondition> Conditions = new List<IWeaponCondition>();

	public void AddCondition(IWeaponCondition condition)
	{
		Conditions.Add(condition);
	}

	public bool DoCondition(ref CommonWeaponArg arg)
	{
		foreach (IWeaponCondition condition in Conditions)
		{
			if (condition.DoCondition(ref arg))
			{
				return true;
			}
		}
		return false;
	}
}
