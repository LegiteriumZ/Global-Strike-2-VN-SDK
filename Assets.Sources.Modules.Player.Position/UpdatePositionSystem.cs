using Assets.Sources.Framework;
using Entitas;
using SSJJMath;

namespace Assets.Sources.Modules.Player.Position;

public class UpdatePositionSystem : IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _players;

	public UpdatePositionSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.Fpos));
	}

	public void OnRender()
	{
		foreach (PlayerEntity player in _players)
		{
			UpdateLocation(player);
		}
	}

	private static void UpdateLocation(PlayerEntity entity)
	{
		VectorCoordConverter.SsjjToUnity(entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex()), out var dest);
		entity.thirdPersonUnityObjects.ThirdTran.RootContainer.transform.position = dest;
	}

	public void OnPlayback()
	{
		OnRender();
	}
}
