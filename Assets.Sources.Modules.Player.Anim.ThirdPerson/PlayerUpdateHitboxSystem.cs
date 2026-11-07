using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.HitBox;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class PlayerUpdateHitboxSystem : IPlaybackInitSystem
{
	private PlayerContext _playerContext;

	public PlayerUpdateHitboxSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public void OnPlaybackInit()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.isPrediction)
			{
				PlayerHitBoxBrushUtility.UpdatePlayerAllHitBoxBrush(item);
			}
		}
	}
}
