using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect;

public class TacticsSoundPlaybackSystem : IPlaybackSystem
{
	private TimeComponent _time;

	private IGroup<PlayerEntity> _playerGroup;

	public TacticsSoundPlaybackSystem(Contexts contexts)
	{
		_playerGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects));
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _playerGroup)
		{
			if (item.hasTacticsSound && item.tacticsSound.RemainTime > 0)
			{
				item.tacticsSound.RemainTime -= _time.FrameInterval;
			}
		}
	}
}
