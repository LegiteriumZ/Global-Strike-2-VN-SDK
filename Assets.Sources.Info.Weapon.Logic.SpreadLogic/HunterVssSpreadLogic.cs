using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Constant;
using Assets.Sources.Utils.Player;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

public class HunterVssSpreadLogic : ISpreadLogic, IParamParse
{
	protected int Length2D1 = 350;

	protected int Length2D2 = 25;

	public float FovAddParam { get; set; }

	public float DefaultSpecialModeParam { get; set; }

	public float DefaultNormalParam { get; set; }

	public float pveParam { get; set; }

	public float DuckParam { get; set; }

	public float LengthParam2 { get; set; }

	public float LengthParam1 { get; set; }

	public float AirParam { get; set; }

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 8);
		AirParam = restlts[0];
		LengthParam1 = restlts[1];
		LengthParam2 = restlts[2];
		DuckParam = restlts[3];
		DefaultSpecialModeParam = restlts[4];
		DefaultNormalParam = restlts[5];
		FovAddParam = restlts[6];
		pveParam = restlts[7];
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		float num;
		if (RuleUtilty.IsPveModel(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			num = pveParam;
		}
		else
		{
			num = ((!player.OnGround() && !isWeightlessness) ? AirParam : ((PlayerUtility.PlayerLength2D(player) > (float)Length2D1) ? LengthParam1 : ((PlayerUtility.PlayerLength2D(player) > (float)Length2D2) ? LengthParam2 : ((player.DuckState() == 0) ? DuckParam : ((!currentWeapon.special.SpecialMode) ? DefaultNormalParam : DefaultSpecialModeParam)))));
			if (player.fov.Fov == 90)
			{
				num += FovAddParam;
			}
		}
		spread = num;
	}
}
