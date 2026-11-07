using Assets.Sources.Components.Time;

public class rpk_domination_WeaponExtraDefineProvider : Abstractrpk_domination_WeaponExtraDefineProvider
{
	private int icon1;

	private int power;

	private int maxPower;

	public override void OnFrame(TimeComponent time)
	{
		WeaponEntity currentWeaponEntity = Contexts.sharedInstance.weapon.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			power = currentWeaponEntity.power.Power;
			maxPower = currentWeaponEntity.power.MaxPower;
			icon1 = currentWeaponEntity.basicInfo.Data.Icon1;
		}
	}

	public override string updateSkillENum()
	{
		return getNumIcon(icon1);
	}

	public override string updateLeft0Num()
	{
		return getNumIcon(power / 10);
	}

	public override string updateLeft1Num()
	{
		return getNumIcon(power % 10);
	}

	public override string updateRight0Num()
	{
		if (maxPower < 10)
		{
			return getNumIcon(maxPower);
		}
		return getNumIcon(maxPower / 10);
	}

	public override string updateRight1Num()
	{
		return getNumIcon(maxPower % 10);
	}

	private string getNumIcon(int num)
	{
		return "/weapon/rpk_domination/ui/num_" + num;
	}
}
