using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Constant;
using Assets.Sources.Utils.Player;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

internal class AwmStrikeSpreadLogic : ISpreadLogic, IParamParse
{
	protected int Length2D1 = 350;

	protected int Length2D2 = 25;

	public float PveDefaultParam { get; set; }

	public float FovAddParam { get; set; }

	public float DefaultParam { get; set; }

	public float DuckParam { get; set; }

	public float LengthParam2 { get; set; }

	public float LengthParam1 { get; set; }

	public float AirParam { get; set; }

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 7);
		PveDefaultParam = restlts[0];
		AirParam = restlts[1];
		LengthParam1 = restlts[2];
		LengthParam2 = restlts[3];
		DuckParam = restlts[4];
		DefaultParam = restlts[5];
		FovAddParam = restlts[6];
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (currentWeapon.clip.Clip2 == 1 && (RuleUtilty.IsPve(raceType) || RuleUtilty.IsRpg(raceType) || RuleUtilty.IsBioMode(raceType)))
		{
			PveBeforeFire(out spread, player, currentWeapon, isWeightlessness);
		}
		else
		{
			PvpBeforeFire(out spread, player, currentWeapon, isWeightlessness);
		}
	}

	private void PveBeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		spread = PveDefaultParam;
	}

	private void PvpBeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		spread = PveDefaultParam;
		float num = ((!player.OnGround() && !isWeightlessness) ? AirParam : ((PlayerUtility.PlayerLength2D(player) > (float)Length2D1) ? LengthParam1 : ((PlayerUtility.PlayerLength2D(player) > (float)Length2D2) ? LengthParam2 : ((player.DuckState() != 0) ? DefaultParam : DuckParam))));
		if (player.fov.Fov == 90)
		{
			num += FovAddParam;
		}
		spread = num;
	}
}
