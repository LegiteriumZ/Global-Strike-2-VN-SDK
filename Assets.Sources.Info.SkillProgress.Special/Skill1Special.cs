namespace Assets.Sources.Info.SkillProgress.Special;

public class Skill1Special : NoneSpecial
{
	public override bool GetSpecial(WeaponEntity currentWeapon)
	{
		if (currentWeapon.hasBasicInfo)
		{
			return (currentWeapon.basicInfo.Data.WeaponFlag & 2) > 0;
		}
		return false;
	}
}
