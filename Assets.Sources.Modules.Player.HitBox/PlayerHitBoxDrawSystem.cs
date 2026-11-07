using Assets.Sources.Framework;
using Entitas;
using physics.data;

namespace Assets.Sources.Modules.Player.HitBox;

public class PlayerHitBoxDrawSystem : IRenderSystem
{
	private readonly IGroup<PlayerEntity> _players;

	public PlayerHitBoxDrawSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.HitBox));
	}

	public void OnRender()
	{
		foreach (PlayerEntity player in _players)
		{
			if (player.isPrediction)
			{
				continue;
			}
			PlayerHitBoxBrushUtility.UpdatePlayerAllHitBoxBrush(player);
			foreach (HitBoxBrush item in player.hitBox.HitBoxBrush)
			{
				DebugDrawUtility.DrawHitBoxBrush(item);
			}
		}
	}
}
