using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.Weapon.Logic.CdTimeLogic;

internal class ShieldPistolCdTimeLogic : ICdTimeLogic, IParamParse
{
	public int GetCdTime(string weaponName, int raceType, int subRaceType)
	{
		if (RuleUtilty.IsPveModel(raceType) || RuleUtilty.IsGeneralPve(raceType) || RuleUtilty.IsBigHeadModel(raceType) || RuleUtilty.IsBioMode(raceType))
		{
			return 25000;
		}
		return 40000;
	}

	public void Parse(string param)
	{
	}
}
