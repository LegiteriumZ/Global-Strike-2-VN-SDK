using Assets.Generated.Table;
using Assets.Sources.Constant;
using Sharpen;

namespace Assets.Sources.Info.SkillProgress.Special;

public class Type91DaggerSpecial : ISpecial
{
	public void GetBackImage(string[] backImage, WeaponSkillTable.Row config, WeaponEntity currentWeapon, bool isSpecial, int raceType, int level, bool isOver)
	{
		backImage[0] = config.Name;
		if (isOver)
		{
			if (config.SpecialBack != null && !RuleUtilty.IsGeneralPve(raceType))
			{
				backImage[1] = config.SpecialBack.GetLast();
			}
			else
			{
				backImage[1] = config.Back.GetLast();
			}
		}
		else if (config.SpecialBack != null && !RuleUtilty.IsGeneralPve(raceType))
		{
			backImage[1] = config.SpecialBack.GetFirst();
		}
		else
		{
			backImage[1] = config.Back.GetFirst();
		}
	}

	public void GetIcon(string[] icon, WeaponSkillTable.Row config, WeaponEntity currentWeapon, bool isSpecial, int level, bool isOver)
	{
	}

	public virtual bool GetSpecial(WeaponEntity currentWeapon)
	{
		if (currentWeapon.hasSpecial)
		{
			return currentWeapon.special.SpecialMode;
		}
		return false;
	}
}
