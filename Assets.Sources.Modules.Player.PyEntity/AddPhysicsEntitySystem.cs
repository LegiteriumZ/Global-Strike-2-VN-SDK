using Assets.Sources.Framework;
using Entitas;
using SSJJPhysicsExtensions;

namespace Assets.Sources.Modules.Player.PyEntity;

public class AddPhysicsEntitySystem : IEntityCreateSystem
{
	private BattleRoomContext _sceneMapContext;

	private WeaponContext _weaponContext;

	private IGroup<PlayerEntity> _group;

	public AddPhysicsEntitySystem(Contexts contexts)
	{
		_sceneMapContext = contexts.battleRoom;
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Move));
		_weaponContext = contexts.weapon;
	}

	public void OnEntityCreate()
	{
		foreach (PlayerEntity item in _group)
		{
			if (item.move.PyPlayerMove == null)
			{
				PyPlayerAdapter pyPlayerMove = new PyPlayerAdapter(item, _weaponContext);
				item.move.PyPlayerMove = pyPlayerMove;
				_sceneMapContext.pyEngine.PyEngine.GetEntityManager().UpdateEntityNormalBrush(0, item.move.PyPlayerMove.GetEntity());
			}
		}
	}
}
