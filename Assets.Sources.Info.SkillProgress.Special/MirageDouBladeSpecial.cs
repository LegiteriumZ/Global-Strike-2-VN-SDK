using Assets.Generated.Table;
using Assets.Sources.Constant;
using Sharpen;

namespace Assets.Sources.Info.SkillProgress.Special;

public class MirageDouBladeSpecial : ISpecial
{
	public void GetBackImage(string[] backImage, WeaponSkillTable.Row config, WeaponEntity currentWeapon, bool isSpecial, int raceType, int level, bool isOver)
	{
		if (isSpecial)
		{
			backImage[0] = config.Name;
			if ((currentWeapon.special.EffectLevel & 2) > 0)
			{
				if (isOver)
				{
					if ((currentWeapon.special.EffectLevel & 0x10) > 0 && (currentWeapon.special.EffectLevel & 0x20) > 0 && (RuleUtilty.IsPveModel(raceType) || RuleUtilty.IsBigHeadModel(raceType) || RuleUtilty.IsBioMode(raceType)))
					{
						backImage[1] = config.SpecialBack[5];
					}
					else
					{
						backImage[1] = config.SpecialBack[3];
					}
				}
				else if ((currentWeapon.special.EffectLevel & 0x10) > 0 && (currentWeapon.special.EffectLevel & 0x20) > 0 && (RuleUtilty.IsPveModel(raceType) || RuleUtilty.IsBigHeadModel(raceType) || RuleUtilty.IsBioMode(raceType)))
				{
					backImage[1] = config.SpecialBack[4];
				}
				else
				{
					backImage[1] = config.SpecialBack[2];
				}
			}
			else if (isOver)
			{
				backImage[1] = config.SpecialBack[1];
			}
			else
			{
				backImage[1] = config.SpecialBack[0];
			}
		}
		else
		{
			backImage[0] = config.Name;
			if (isOver)
			{
				backImage[1] = config.Back[1];
			}
			else
			{
				backImage[1] = config.Back[0];
			}
		}
	}

	public void GetIcon(string[] icon, WeaponSkillTable.Row config, WeaponEntity currentWeapon, bool isSpecial, int level, bool isOver)
	{
		if (isOver)
		{
			if (config.SpecialIcon != null && isSpecial)
			{
				icon[0] = config.Name;
				icon[1] = ((level > config.SpecialIcon.Length) ? config.SpecialIcon.Last() : ((level == 0) ? config.SpecialIcon[level] : config.SpecialIcon[level - 1]));
			}
			else if (config.Icon != null)
			{
				icon[0] = config.Name;
				icon[1] = ((level > config.Icon.Length) ? config.Icon.Last() : ((level == 0) ? config.Icon[level] : config.Icon[level - 1]));
			}
		}
		else
		{
			icon[0] = config.Name;
			icon[1] = config.DisabledIcon;
		}
	}

	public bool GetSpecial(WeaponEntity currentWeapon)
	{
		if (currentWeapon.hasSpecial)
		{
			return (currentWeapon.special.EffectLevel & 0x20) > 0;
		}
		return false;
	}
}
