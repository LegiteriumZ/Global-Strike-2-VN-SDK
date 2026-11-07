using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.Weapon.Logic.CdTimeLogic;

internal class ScarLegendCdTimeLogic : ICdTimeLogic, IParamParse
{
	public int GetCdTime(string weaponName, int raceType, int subRaceType)
	{
		if (RuleUtilty.IsBioMode(raceType) || RuleUtilty.IsOldPve(raceType))
		{
			if ("scar_legend1" == weaponName)
			{
				return 40000;
			}
			if ("scar_legend2" == weaponName)
			{
				return 30000;
			}
			if ("scar_legend3" == weaponName)
			{
				return 20000;
			}
		}
		else if (RuleUtilty.IsBigHeadModel(raceType))
		{
			if ("scar_legend2" == weaponName)
			{
				return 45000;
			}
			if ("scar_legend3" == weaponName)
			{
				return 30000;
			}
		}
		return 15000;
	}

	public void Parse(string param)
	{
	}
}
