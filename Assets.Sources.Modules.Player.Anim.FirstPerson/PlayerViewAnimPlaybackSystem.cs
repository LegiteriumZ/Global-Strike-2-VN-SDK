using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Anim.FirstPerson;

public class PlayerViewAnimPlaybackSystem : IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _players;

	private TimeComponent _time;

	public PlayerViewAnimPlaybackSystem(Contexts contexts)
	{
		_time = contexts.time.time;
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ViewAnim).NoneOf(PlayerMatcher.Prediction));
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity player in _players)
		{
			if (!player.isPrediction)
			{
				player.viewAnim.RightCurrentTime += _time.FrameInterval;
				player.viewAnim.LeftCurrentTime += _time.FrameInterval;
				player.viewAnim.RemainTime = player.viewAnim.SnapshotRemainTime - (_time.RenderTime - player.basicInfo.SnapsotServerTime);
				player.viewAnim.LeftRemainTime = player.viewAnim.SnapshotLeftRemainTime - (_time.RenderTime - player.basicInfo.SnapsotServerTime);
			}
		}
	}
}
