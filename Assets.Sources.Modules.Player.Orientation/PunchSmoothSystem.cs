using Assets.Sources.Framework;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Orientation;

public class PunchSmoothSystem : IAfterPredicationSystem
{
	private readonly IGroup<PlayerEntity> _players;

	private readonly TimeContext _timeContext;

	public PunchSmoothSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.CameraOwner));
		_timeContext = contexts.time;
	}

	public void OnAfterPredication()
	{
		foreach (PlayerEntity player in _players)
		{
			if (player.isPrediction)
			{
				DoSmooth(player);
			}
		}
	}

	private void DoSmooth(PlayerEntity entity)
	{
		float t = (float)_timeContext.time.FrameInterval / 1000f * 60f * 0.4f;
		if (entity.punchSmooth.TempPunchYaw > entity.punchOrientation.PunchYaw)
		{
			entity.punchSmooth.TempPunchYaw = entity.punchOrientation.PunchYaw;
		}
		else
		{
			entity.punchSmooth.TempPunchYaw = Mathf.Lerp(entity.punchSmooth.TempPunchYaw, entity.punchOrientation.PunchYaw, t);
		}
		if (entity.punchSmooth.TempPunchPitch > entity.punchOrientation.PunchPitch)
		{
			entity.punchSmooth.TempPunchPitch = entity.punchOrientation.PunchPitch;
		}
		else
		{
			entity.punchSmooth.TempPunchPitch = Mathf.Lerp(entity.punchSmooth.TempPunchPitch, entity.punchOrientation.PunchPitch, t);
		}
	}
}
