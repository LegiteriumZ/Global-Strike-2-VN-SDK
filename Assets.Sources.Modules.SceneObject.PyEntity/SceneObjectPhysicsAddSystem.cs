using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.PyEntity;

public class SceneObjectPhysicsAddSystem : IEntityCreateSystem
{
	private IGroup<SceneObjectEntity> _group;

	private BattleRoomContext _battleRoomContext;

	public SceneObjectPhysicsAddSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneObjectPyhsics));
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnEntityCreate()
	{
		foreach (SceneObjectEntity item in _group)
		{
			if (!item.sceneObjectPyhsics.getAdded())
			{
				_battleRoomContext.pyEngine.PyEngine.GetEntityManager().UpdateEntityNormalBrush(0, item.sceneObjectPyhsics.PhysicsEntity);
				item.sceneObjectPyhsics.setAdded(value: true);
			}
		}
	}
}
