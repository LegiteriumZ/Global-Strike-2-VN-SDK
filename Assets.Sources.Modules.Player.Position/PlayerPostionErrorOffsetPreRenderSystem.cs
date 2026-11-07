using Assets.Sources.Framework;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Position;

public class PlayerPostionErrorOffsetPreRenderSystem : IPlaybackSystem
{
	private readonly PlayerContext _playerContext;

	private readonly TimeContext _timeContext;

	public PlayerPostionErrorOffsetPreRenderSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_timeContext = contexts.time;
	}

	private bool IsNeedErrorSmooth(PlayerEntity player)
	{
		float magnitude = player.postionErrorSmooth.PredictedErrorOffet.magnitude;
		if (magnitude <= 0.1f)
		{
			return false;
		}
		if (!player.IsDead() && player.HasState(268435456))
		{
			return true;
		}
		if (magnitude < 200f || player.ImpulseTime() > 0 || player.move.ImpulseTime2 > 0)
		{
			return true;
		}
		return false;
	}

	public void OnPlayback()
	{
		PlayerEntity predictionEntity = _playerContext.predictionEntity;
		if (predictionEntity != null && predictionEntity.hasPostionErrorSmooth)
		{
			float num = (100f - (float)(_timeContext.time.ClientRealTime - predictionEntity.postionErrorSmooth.PredictedErrorTime)) / 100f;
			if (num > 0f && num <= 1f && IsNeedErrorSmooth(predictionEntity))
			{
				predictionEntity.postionErrorSmooth.PredictedErrorSmooth = predictionEntity.postionErrorSmooth.PredictedErrorOffet * num;
			}
			else
			{
				predictionEntity.postionErrorSmooth.PredictedErrorSmooth = Vector3.zero;
			}
		}
	}
}
