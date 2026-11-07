using Assets.Sources.Framework;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.ClientTime;

public class PlayerClientTimePredictionSystem : IPredicateSystem
{
	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		myPlayer.clientTime.ClientTime += cmd.FrameInterval;
	}
}
