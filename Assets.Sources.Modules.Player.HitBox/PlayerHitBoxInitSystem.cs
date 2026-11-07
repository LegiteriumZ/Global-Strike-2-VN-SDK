using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.HitBox;

public class PlayerHitBoxInitSystem : IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _players;

	public PlayerHitBoxInitSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.HitBox));
	}

	public void InitPlayerHitBox(PlayerEntity player)
	{
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity player in _players)
		{
			if (!player.isPrediction && player.hasHitBox && !player.isMyPlayer)
			{
				player.hitBox.HitBoxBrushDirty = true;
			}
		}
	}
}
