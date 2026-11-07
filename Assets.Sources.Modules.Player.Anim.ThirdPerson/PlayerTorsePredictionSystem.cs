using Assets.Sources.Components.Player.Anims;
using Assets.Sources.Framework;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class PlayerTorsePredictionSystem : IPredicateSystem
{
	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		TorseAnimComponent torseAnim = myPlayer.torseAnim;
		torseAnim.RemainTime -= cmd.FrameInterval;
		torseAnim.EclipsedTime += cmd.FrameInterval;
		if (torseAnim.RemainTime < 0)
		{
			torseAnim.RemainTime = 0;
		}
	}
}
