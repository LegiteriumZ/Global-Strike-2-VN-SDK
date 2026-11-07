using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class PlayerLegAnimPlaybackSystem : IPlaybackSystem
{
	private IGroup<PlayerEntity> _players;

	private TimeComponent _timeComponent;

	public PlayerLegAnimPlaybackSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.LegAnim).NoneOf(PlayerMatcher.Prediction));
		_timeComponent = contexts.time.time;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity player in _players)
		{
			float num = 1f;
			if (player.legAnim.LegsAnimInfo != null)
			{
				num = player.legAnim.LegsAnimInfo.GetAnimSpeed(player.move.Velocity2D);
			}
			player.legAnim.ScaledEclipsedTime = player.basicInfo.Current.LegsSpeedAnimTime + (int)((float)(_timeComponent.RenderTime - player.basicInfo.SnapsotServerTime) * num);
		}
	}
}
