using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Constant;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

internal class VssSpreadLogic : ISpreadLogic
{
	private static float PvpSpread(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		float num = ((!player.OnGround() && !isWeightlessness) ? 0.85f : ((player.move.Velocity2D > 350) ? 0.2f : ((player.move.Velocity2D > 25) ? 0.1f : ((player.DuckState() != 0) ? (currentWeapon.special.SpecialMode ? 0.0015f : 0.001f) : 0f))));
		if (player.fov.Fov == 90)
		{
			num += 0.08f;
		}
		return num;
	}

	private static float PveSpread(PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		return 0.001f;
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		spread = ((RuleUtilty.IsPve(raceType) || RuleUtilty.IsRpg(raceType)) ? PveSpread(player, currentWeapon, isWeightlessness) : PvpSpread(player, currentWeapon, cmd, isWeightlessness));
	}
}
