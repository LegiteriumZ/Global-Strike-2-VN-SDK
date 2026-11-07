using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.PyEntity;

public class RemovePhysicsEntitySystem : IEntityDestroySystem
{
	private readonly IGroup<PlayerEntity> _players;

	private BattleRoomContext _sceneMapContext;

	public RemovePhysicsEntitySystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Move, PlayerMatcher.Destroy));
		_sceneMapContext = contexts.battleRoom;
	}

	public void OnEntityDestroy()
	{
		if (!_sceneMapContext.hasPyEngine || _sceneMapContext.pyEngine.PyEngine == null)
		{
			return;
		}
		foreach (PlayerEntity player in _players)
		{
			_sceneMapContext.pyEngine.PyEngine.GetEntityManager().UpdateEntityNormalBrush(1, player.move.PyPlayerMove.GetEntity());
		}
	}
}
