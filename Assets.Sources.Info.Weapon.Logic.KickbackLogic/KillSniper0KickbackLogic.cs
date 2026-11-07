namespace Assets.Sources.Info.Weapon.Logic.KickbackLogic;

public class KillSniper0KickbackLogic : IKickbackLogic, IParamParse
{
	internal float AddPunchPitch { get; set; }

	public void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		if (currentWeapon.basicInfo.Data.Kill == 0)
		{
			player.punchOrientation.PunchPitch += AddPunchPitch;
		}
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 1);
		AddPunchPitch = restlts[0];
	}
}
