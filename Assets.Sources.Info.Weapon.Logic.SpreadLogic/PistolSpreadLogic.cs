using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Utils.Player;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

internal class PistolSpreadLogic : ISpreadLogic, IParamParse
{
	private float AirParam { get; set; }

	private float LengthGreater13Param { get; set; }

	private float DuckParam { get; set; }

	private float DefaultParam { get; set; }

	public void SetParams(float[] ds, int s)
	{
		AirParam = ds[s];
		LengthGreater13Param = ds[1 + s];
		DuckParam = ds[2 + s];
		DefaultParam = ds[3 + s];
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 4);
		SetParams(restlts, 0);
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		float num = ((!player.OnGround() && !isWeightlessness) ? AirParam : ((PlayerUtility.PlayerLength2D(player) > 13f) ? LengthGreater13Param : ((player.DuckState() != 0) ? DefaultParam : DuckParam)));
		spread = num * (1f - currentWeapon.accuracy.Accuracy);
	}
}
