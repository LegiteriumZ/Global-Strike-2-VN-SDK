using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.CdTimeLogic;

internal class DefaultCdTimeLogic : ICdTimeLogic, IParamParse
{
	private int _para;

	public int GetCdTime(string weaponName, int raceType, int subRaceType)
	{
		return _para;
	}

	public void Parse(string param)
	{
		_para = int.Parse(param);
	}
}
