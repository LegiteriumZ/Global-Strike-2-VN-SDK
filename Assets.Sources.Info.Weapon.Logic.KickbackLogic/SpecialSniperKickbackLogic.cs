namespace Assets.Sources.Info.Weapon.Logic.KickbackLogic;

public class SpecialSniperKickbackLogic : IKickbackLogic, IParamParse
{
	internal float AddSpecialMode { get; set; }

	internal float AddDefaultPitch { get; set; }

	public void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		if (currentWeapon.special.SpecialMode)
		{
			player.punchOrientation.PunchPitch += AddSpecialMode;
		}
		else
		{
			player.punchOrientation.PunchPitch += AddDefaultPitch;
		}
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 2);
		AddSpecialMode = restlts[0];
		AddDefaultPitch = restlts[1];
	}
}
