using System;

namespace Assets.Sources.Info.Weapon.Logic.KickbackLogic;

public class SpecialKickbackLogic : IKickbackLogic, IParamParse
{
	private IKickbackLogic _normalLogic;

	private IKickbackLogic _specialLogic;

	public void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		if (currentWeapon.special.SpecialMode && _specialLogic != null)
		{
			_specialLogic.KickBack(seed, player, currentWeapon, isWeightlessness);
		}
		else if (!currentWeapon.special.SpecialMode && _normalLogic != null)
		{
			_normalLogic.KickBack(seed, player, currentWeapon, isWeightlessness);
		}
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 29);
		_normalLogic = new RifleKickbackLogic();
		_specialLogic = new SniperKickbackLogic();
		((SniperKickbackLogic)_specialLogic).AddPunchPitch = restlts[0];
		((RifleKickbackLogic)_normalLogic).KickbackParamsRun = new float[7];
		Array.Copy(restlts, 1, ((RifleKickbackLogic)_normalLogic).KickbackParamsRun, 0, 7);
		((RifleKickbackLogic)_normalLogic).KickbackParamsAir = new float[7];
		Array.Copy(restlts, 8, ((RifleKickbackLogic)_normalLogic).KickbackParamsAir, 0, 7);
		((RifleKickbackLogic)_normalLogic).KickbackParamsDuck = new float[7];
		Array.Copy(restlts, 15, ((RifleKickbackLogic)_normalLogic).KickbackParamsDuck, 0, 7);
		((RifleKickbackLogic)_normalLogic).KickbackParams = new float[7];
		Array.Copy(restlts, 22, ((RifleKickbackLogic)_normalLogic).KickbackParams, 0, 7);
	}
}
