using System;
using Assets.Sources.Framework;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Orientation;

public class PlayerPunchOrientationPredictionSystem : IPredicateSystem
{
	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		if (player.basicInfo.IsDead)
		{
			return;
		}
		if (player.decay.DecayTime > 0)
		{
			player.decay.DecayTime -= cmd.FrameInterval;
			return;
		}
		float punchYaw = player.punchOrientation.PunchYaw;
		float punchPitch = player.punchOrientation.PunchPitch;
		float num = (float)cmd.FrameInterval / 1000f;
		float num2 = (float)Math.Sqrt(punchYaw * punchYaw + punchPitch * punchPitch);
		if (num2 > 0f)
		{
			punchYaw /= num2;
			punchPitch /= num2;
			num2 -= (10f + num2 * 0.5f) * num;
			num2 = Math.Max(num2, 0f);
			player.punchOrientation.PunchYaw = punchYaw * num2;
			player.punchOrientation.PunchPitch = punchPitch * num2;
		}
	}
}
