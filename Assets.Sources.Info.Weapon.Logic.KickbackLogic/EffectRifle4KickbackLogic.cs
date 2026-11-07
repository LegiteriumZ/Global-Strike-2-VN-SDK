using System;

namespace Assets.Sources.Info.Weapon.Logic.KickbackLogic;

public class EffectRifle4KickbackLogic : IKickbackLogic, IParamParse
{
	private IKickbackLogic _normalLogic;

	private IKickbackLogic _effect4Logic;

	public void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		if ((currentWeapon.special.EffectLevel & 8) > 0 && _effect4Logic != null)
		{
			_effect4Logic.KickBack(seed, player, currentWeapon, isWeightlessness);
		}
		else if (_normalLogic != null)
		{
			_normalLogic.KickBack(seed, player, currentWeapon, isWeightlessness);
		}
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 56);
		_normalLogic = new RifleKickbackLogic();
		_effect4Logic = new RifleKickbackLogic();
		((RifleKickbackLogic)_effect4Logic).KickbackParamsRun = new float[7];
		Array.Copy(restlts, 0, ((RifleKickbackLogic)_effect4Logic).KickbackParamsRun, 0, 7);
		((RifleKickbackLogic)_effect4Logic).KickbackParamsAir = new float[7];
		Array.Copy(restlts, 7, ((RifleKickbackLogic)_effect4Logic).KickbackParamsAir, 0, 7);
		((RifleKickbackLogic)_effect4Logic).KickbackParamsDuck = new float[7];
		Array.Copy(restlts, 14, ((RifleKickbackLogic)_effect4Logic).KickbackParamsDuck, 0, 7);
		((RifleKickbackLogic)_effect4Logic).KickbackParams = new float[7];
		Array.Copy(restlts, 21, ((RifleKickbackLogic)_effect4Logic).KickbackParams, 0, 7);
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
