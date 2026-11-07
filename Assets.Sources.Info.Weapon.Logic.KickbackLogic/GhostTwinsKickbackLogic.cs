using System;

namespace Assets.Sources.Info.Weapon.Logic.KickbackLogic;

public class GhostTwinsKickbackLogic : IKickbackLogic, IParamParse
{
	private IKickbackLogic _normalLogic;

	private IKickbackLogic _specialLogic;

	public void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		if (currentWeapon.special.SpecialMode && _specialLogic != null)
		{
			_specialLogic.KickBack(seed, player, currentWeapon, isWeightlessness: false);
		}
		else if (!currentWeapon.special.SpecialMode && _normalLogic != null)
		{
			_normalLogic.KickBack(seed, player, currentWeapon, isWeightlessness: false);
		}
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 29);
		_normalLogic = new SniperKickbackLogic();
		_specialLogic = new RifleKickbackLogic();
		((RifleKickbackLogic)_specialLogic).KickbackParamsRun = new float[7];
		Array.Copy(restlts, 0, ((RifleKickbackLogic)_specialLogic).KickbackParamsRun, 0, 7);
		((RifleKickbackLogic)_specialLogic).KickbackParamsAir = new float[7];
		Array.Copy(restlts, 7, ((RifleKickbackLogic)_specialLogic).KickbackParamsAir, 0, 7);
		((RifleKickbackLogic)_specialLogic).KickbackParamsDuck = new float[7];
		Array.Copy(restlts, 14, ((RifleKickbackLogic)_specialLogic).KickbackParamsDuck, 0, 7);
		((RifleKickbackLogic)_specialLogic).KickbackParams = new float[7];
		Array.Copy(restlts, 21, ((RifleKickbackLogic)_specialLogic).KickbackParams, 0, 7);
		((SniperKickbackLogic)_normalLogic).AddPunchPitch = restlts[28];
	}
}
