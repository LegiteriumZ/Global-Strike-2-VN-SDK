using Assets.Sources.Framework;
using Entitas;
using SSJJBase.Logger;

namespace Assets.Sources.Modules.SceneObject.PyEntity;

internal class SceneObjectPhysicsRemoveSystem : IEntityDestroySystem
{
	private readonly IGroup<SceneObjectEntity> _sceneitems;

	private BattleRoomContext _sceneMapContext;

	public SceneObjectPhysicsRemoveSystem(Contexts contexts)
	{
		_sceneitems = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneObjectPyhsics, SceneObjectMatcher.Destroy));
		_sceneMapContext = contexts.battleRoom;
	}

	public void OnEntityDestroy()
	{
		if (!_sceneMapContext.hasPyEngine || _sceneMapContext.pyEngine.PyEngine == null)
		{
			return;
		}
		foreach (SceneObjectEntity sceneitem in _sceneitems)
		{
			this.DebugFormat("remove scenItem to pyEngine {0} ", sceneitem.entityId.Value);
			_sceneMapContext.pyEngine.PyEngine.GetEntityManager().UpdateEntityNormalBrush(1, sceneitem.sceneObjectPyhsics.PhysicsEntity);
		}
	}
}
