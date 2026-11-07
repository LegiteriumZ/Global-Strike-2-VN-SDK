using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.HeadScale;

public class HeadScalePlaybackSystem : IPlaybackSystem
{
	private IGroup<PlayerEntity> _group;

	public HeadScalePlaybackSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.HeadScale));
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _group)
		{
			item.headScale.Scale = 1f + item.basicInfo.Current.HeadEnlarge + item.basicInfo.Current.OtherHeadEnlarge;
		}
	}
}
