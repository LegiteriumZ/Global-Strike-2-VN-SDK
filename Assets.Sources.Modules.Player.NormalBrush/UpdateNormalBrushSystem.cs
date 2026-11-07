using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.NormalBrush;

public class UpdateNormalBrushSystem : IPlaybackSystem
{
	private IGroup<PlayerEntity> _group;

	private BattleRoomContext _sceneMapContext;

	public UpdateNormalBrushSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Move));
		_sceneMapContext = contexts.battleRoom;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _group)
		{
			_sceneMapContext.pyEngine.PyEngine.GetEntityManager().UpdateEntityNormalBrush(2, item.move.PyPlayerMove.GetEntity());
		}
	}
}
