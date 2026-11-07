using Assets.Sources.Components.Time;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Move;

public class PlayerViewHeightPlaybackSystem : IPlaybackSystem
{
	private TimeComponent _time;

	private readonly IGroup<PlayerEntity> _players;

	public PlayerViewHeightPlaybackSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ViewHeight).NoneOf(PlayerMatcher.Prediction));
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity player in _players)
		{
			if (!player.isPrediction)
			{
				if (player.basicInfo.Current != null && player.basicInfo.Next != null && player.basicInfo.Current.ViewHeightSpecified && player.basicInfo.Next.ViewHeightSpecified)
				{
					player.move.ViewHeightBase = Mathf.Lerp(player.basicInfo.Current.ViewHeight, player.basicInfo.Next.ViewHeight, _time.FrameInterpolation);
				}
				else
				{
					player.move.ViewHeightBase = GetViewHeigh(player);
				}
			}
		}
	}

	private float GetViewHeigh(PlayerEntity player)
	{
		if (PlayerCareerConstantUtility.IsMech(player.basicInfo.CareerInfo.Name))
		{
			if (player.DuckState() == 0)
			{
				return 280f;
			}
			return 380f;
		}
		if (player.DuckState() == 0)
		{
			return 93f;
		}
		return 150f;
	}
}
