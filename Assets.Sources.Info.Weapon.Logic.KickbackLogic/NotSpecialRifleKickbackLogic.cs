namespace Assets.Sources.Info.Weapon.Logic.KickbackLogic;

internal class NotSpecialRifleKickbackLogic : IKickbackLogic
{
	internal float AddPunchPitch { get; set; }

	public void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		if (!currentWeapon.special.SpecialMode)
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
