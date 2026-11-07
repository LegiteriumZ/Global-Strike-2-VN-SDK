using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.Weapon.Logic.CdTimeLogic;

internal class DarkDiamondCdTimeLogic : ICdTimeLogic, IParamParse
{
	public int GetCdTime(string weaponName, int raceType, int subRaceType)
	{
		if (RuleUtilty.IsBioMode(raceType) || RuleUtilty.IsBlade(raceType) || RuleUtilty.IsKnife(raceType, subRaceType))
		{
			return 30000;
		}
		if (RuleUtilty.IsPve(raceType))
		{
			return 25000;
		}
		return 30000;
	}

	public void Parse(string param)
	{
	}
}
