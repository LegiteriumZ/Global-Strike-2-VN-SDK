using Assets.Sources.Framework;
using Entitas;
using SSJJUserCmd;

namespace Assets.Sources.Modules.SceneObject.PyEntity;

public class SceneObjectPhysicsUpdateSystem : IPredicateSystem
{
	private IGroup<SceneObjectEntity> _group;

	private BattleRoomContext _battleRoomContext;

	public SceneObjectPhysicsUpdateSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneObjectPyhsics));
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		foreach (SceneObjectEntity item in _group)
		{
			if (item.sceneObjectPyhsics.PhysicsEntity != null)
			{
				_battleRoomContext.pyEngine.PyEngine.GetEntityManager().UpdateEntityNormalBrush(2, item.sceneObjectPyhsics.PhysicsEntity);
			}
		}
	}
}
