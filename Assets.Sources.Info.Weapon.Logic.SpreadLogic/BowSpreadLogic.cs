using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Constant;
using Assets.Sources.Utils.Player;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

public class BowSpreadLogic : ISpreadLogic, IParamParse
{
	protected int Length2D1 = 350;

	protected int Length2D2 = 25;

	public float FovAddParam { get; set; }

	public float DefaultParam { get; set; }

	public float DuckParam { get; set; }

	public float LengthParam2 { get; set; }

	public float LengthParam1 { get; set; }

	public float AirParam { get; set; }

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 6);
		AirParam = restlts[0];
		LengthParam1 = restlts[1];
		LengthParam2 = restlts[2];
		DuckParam = restlts[3];
		DefaultParam = restlts[4];
		FovAddParam = restlts[5];
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		float num = ((player.fov.Fov != 90 || RuleUtilty.IsPve(raceType) || RuleUtilty.IsRpg(raceType)) ? DefaultParam : ((!player.OnGround() && !isWeightlessness) ? AirParam : ((PlayerUtility.PlayerLength2D(player) > (float)Length2D1) ? LengthParam1 : ((PlayerUtility.PlayerLength2D(player) > (float)Length2D2) ? LengthParam2 : ((player.DuckState() != 0) ? DefaultParam : DuckParam)))));
		spread = num;
	}
}
