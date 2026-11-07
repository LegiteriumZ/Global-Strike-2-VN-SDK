using System;

namespace Assets.Sources.Info.Weapon.Logic.KickbackLogic;

public class EffectRifleKickbackLogic : IKickbackLogic, IParamParse
{
	private IKickbackLogic _normalLogic;

	private IKickbackLogic _effect0Logic;

	public void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		if (currentWeapon.special.EffectLevel == 0 && _effect0Logic != null)
		{
			_effect0Logic.KickBack(seed, player, currentWeapon, isWeightlessness: false);
		}
		else if (!currentWeapon.special.SpecialMode && _normalLogic != null)
		{
			_normalLogic.KickBack(seed, player, currentWeapon, isWeightlessness: false);
		}
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 56);
		_normalLogic = new RifleKickbackLogic();
		_effect0Logic = new RifleKickbackLogic();
		((RifleKickbackLogic)_effect0Logic).KickbackParamsRun = new float[7];
		Array.Copy(restlts, 0, ((RifleKickbackLogic)_effect0Logic).KickbackParamsRun, 0, 7);
		((RifleKickbackLogic)_effect0Logic).KickbackParamsAir = new float[7];
		Array.Copy(restlts, 7, ((RifleKickbackLogic)_effect0Logic).KickbackParamsAir, 0, 7);
		((RifleKickbackLogic)_effect0Logic).KickbackParamsDuck = new float[7];
		Array.Copy(restlts, 14, ((RifleKickbackLogic)_effect0Logic).KickbackParamsDuck, 0, 7);
		((RifleKickbackLogic)_effect0Logic).KickbackParams = new float[7];
		Array.Copy(restlts, 21, ((RifleKickbackLogic)_effect0Logic).KickbackParams, 0, 7);
		((RifleKickbackLogic)_normalLogic).KickbackParamsRun = new float[7];
		Array.Copy(restlts, 28, ((RifleKickbackLogic)_normalLogic).KickbackParamsRun, 0, 7);
		((RifleKickbackLogic)_normalLogic).KickbackParamsAir = new float[7];
		Array.Copy(restlts, 35, ((RifleKickbackLogic)_normalLogic).KickbackParamsAir, 0, 7);
		((RifleKickbackLogic)_normalLogic).KickbackParamsDuck = new float[7];
		Array.Copy(restlts, 42, ((RifleKickbackLogic)_normalLogic).KickbackParamsDuck, 0, 7);
		((RifleKickbackLogic)_normalLogic).KickbackParams = new float[7];
		Array.Copy(restlts, 49, ((RifleKickbackLogic)_normalLogic).KickbackParams, 0, 7);
	}
}
