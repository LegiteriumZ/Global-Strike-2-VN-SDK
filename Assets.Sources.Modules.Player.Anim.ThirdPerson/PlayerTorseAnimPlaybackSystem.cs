using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class PlayerTorseAnimPlaybackSystem : IPlaybackSystem
{
	private IGroup<PlayerEntity> _players;

	private TimeComponent _time;

	public PlayerTorseAnimPlaybackSystem(Contexts contexts)
	{
		_time = contexts.time.time;
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.TorseAnim).NoneOf(PlayerMatcher.Prediction));
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity player in _players)
		{
			player.torseAnim.EclipsedTime = _time.RenderTime - player.basicInfo.Current.TorsoAnimStartTime;
		}
	}
}
