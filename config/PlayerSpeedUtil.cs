using SSJJPhysics;
using physics;
using share.constant;

namespace config;

public class PlayerSpeedUtil
{
	public static int GetPlayerSpeed(IPyPlayerMove player, IPyUserCmd cmd)
	{
		int num = 0;
		BasePyPlayerAdapter basePyPlayerAdapter = Contexts.sharedInstance.player.myPlayerEntity.move.PyPlayerMove as BasePyPlayerAdapter;
		if (player.ActThirdMove())
		{
			return basePyPlayerAdapter.GetMaxSpeed();
		}
		if (player.IsDead())
		{
			if (player.GetDuckState() == 0 || player.GetDuckState() == 1)
			{
				return PlayerConf.CrouchMoveSpeed();
			}
			return basePyPlayerAdapter.GetMaxSpeed();
		}
		if (player.GetDuckState() == 0 || player.GetDuckState() == 1)
		{
			return PlayerConf.CrouchMoveSpeed() + player.GetAdditonalCrouchSpeed();
		}
		if (cmd.IsWalk)
		{
			return PlayerConf.WalkSpeed();
		}
		return basePyPlayerAdapter.GetMaxSpeed();
	}
}
