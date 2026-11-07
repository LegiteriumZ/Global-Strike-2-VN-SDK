using System;
using Assets.Sources.Utils.Player;

namespace Assets.Sources.Info.Weapon.Logic.KickbackLogic;

[Serializable]
public class RunGroundDuckKickBack : IKickbackLogic
{
	public KickBackData runKickBack;

	public KickBackData notOnGround;

	public KickBackData duckGround;

	public KickBackData defaultGround;

	public void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		KickBackData kickBackData = (isRunKickBack(player, isWeightlessness) ? runKickBack : ((!player.OnGround()) ? notOnGround : ((player.DuckState() != 0) ? defaultGround : duckGround)));
		M4a1LegendKickbackLogic.setKickBackToWeapon(seed, player, currentWeapon, kickBackData);
	}

	public bool isRunKickBack(PlayerEntity player, bool isWeightlessness)
	{
		if (player.RunUpMax() || PlayerUtility.PlayerLength2D(player) > 300f || (!player.OnGround() && isWeightlessness))
		{
			return true;
		}
		return false;
	}
}
