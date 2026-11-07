using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.Weapon.Logic.CdTimeLogic;

internal class SeaOfSharkCdTimeLogic : ICdTimeLogic, IParamParse
{
	public int GetCdTime(string weaponName, int raceType, int subRaceType)
	{
		if (RuleUtilty.IsPveModel(raceType) || RuleUtilty.IsGeneralPve(raceType))
		{
			return 35000;
		}
		return 30000;
	}

	public void Parse(string param)
	{
	}
}
