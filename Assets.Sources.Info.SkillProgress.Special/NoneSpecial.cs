using Assets.Generated.Table;
using Sharpen;

namespace Assets.Sources.Info.SkillProgress.Special;

public class NoneSpecial : ISpecial
{
	public void GetBackImage(string[] backImage, WeaponSkillTable.Row config, WeaponEntity currentWeapon, bool isSpecial, int raceType, int level, bool isOver)
	{
		int num = (currentWeapon.hasSpecial ? currentWeapon.special.EffectLevel : 0);
		backImage[0] = config.Name;
		if (isOver)
		{
			if (config.SpecialBack != null && isSpecial)
			{
				backImage[1] = config.SpecialBack.GetLast();
			}
			else if (config.CanUse == WeaponSkillTable.CanUseType.EffectLevel)
			{
				int num2 = num * 2 + 1;
				if (num2 < config.Back.Length)
				{
					backImage[1] = config.Back[num2];
				}
				else
				{
					backImage[1] = config.Back.GetLast();
				}
			}
			else
			{
				backImage[1] = config.Back.GetLast();
			}
		}
		else if (config.SpecialBack != null && isSpecial)
		{
			backImage[1] = config.SpecialBack.GetFirst();
		}
		else if (config.CanUse == WeaponSkillTable.CanUseType.EffectLevel)
		{
			int num3 = num * 2;
			if (num3 < config.Back.Length)
			{
				backImage[1] = config.Back[num3];
			}
			else
			{
				backImage[1] = config.Back.GetFirst();
			}
		}
		else
		{
			backImage[1] = config.Back.GetFirst();
		}
	}

	public void GetIcon(string[] icon, WeaponSkillTable.Row config, WeaponEntity currentWeapon, bool isSpecial, int level, bool isOver)
	{
		int num = (currentWeapon.hasSpecial ? currentWeapon.special.EffectLevel : 0);
		icon[0] = config.Name;
		if (isOver)
		{
			if (config.SpecialIcon != null && isSpecial)
			{
				icon[1] = ((level > config.SpecialIcon.Length) ? config.SpecialIcon.Last() : ((level == 0) ? config.SpecialIcon[level] : config.SpecialIcon[level - 1]));
			}
			else if (config.CanUse == WeaponSkillTable.CanUseType.EffectLevel && config.Icon != null)
			{
				icon[1] = ((num == config.Icon.Length) ? config.Icon.Last() : config.Icon[num]);
			}
			else if (config.Icon != null)
			{
				icon[1] = ((level >= config.Icon.Length) ? config.Icon.Last() : ((level == 0) ? config.Icon[level] : config.Icon[level - 1]));
			}
			else
			{
				icon[0] = "";
			}
		}
		else
		{
			icon[1] = config.DisabledIcon;
		}
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
