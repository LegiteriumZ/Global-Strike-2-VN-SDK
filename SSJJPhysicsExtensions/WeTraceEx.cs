using System.Collections.Generic;
using Entitas;
using SSJJPhysics;
using physics;
using physics.engine;
using physics.engine.entity;
using physics.entity;

namespace SSJJPhysicsExtensions;

public class WeTraceEx : BaseWeTraceEx
{
	private readonly IGroup<SceneObjectEntity> _sceneItems;

	private readonly IGroup<PlayerEntity> _playersGroup;

	public WeTraceEx(Contexts contexts, WeScene scene, IPyEntityManager entityManager, EngineProfiler profiler)
		: base(contexts, scene, entityManager, profiler)
	{
		_sceneItems = contexts.sceneObject.GetGroup(SceneObjectMatcher.SceneObjectPyhsics);
		_playersGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.Move));
	}

	protected override IList<IPyEntity> GetClipMoveEntityListList()
	{
		_clipMoveEntities.Clear();
		foreach (PlayerEntity item in _playersGroup)
		{
			if (IsEnableEtype(item))
			{
				_clipMoveEntities.Add(item.move.PyPlayerMove.GetEntity());
			}
		}
		foreach (SceneObjectEntity sceneItem in _sceneItems)
		{
			_clipMoveEntities.Add(sceneItem.sceneObjectPyhsics.PhysicsEntity);
		}
		return _clipMoveEntities;
	}

	private bool IsEnableEtype(PlayerEntity entity)
	{
		if (entity.hasBasicInfo)
		{
			if (_playerContext.myPlayerEntity == entity)
			{
				return false;
			}
			switch (entity.basicInfo.Current.EType)
			{
			case 1:
				return false;
			case 0:
			case 6:
			case 8:
			case 9:
			case 11:
			case 13:
			case 14:
			case 18:
			case 19:
			case 23:
				return true;
			}
		}
		return false;
	}

	private bool IsEnableEtype(SceneObjectEntity entity)
	{
		if (entity.hasEtype)
		{
			switch (entity.etype.Etype)
			{
			case 1:
				return false;
			case 0:
			case 6:
			case 8:
			case 9:
			case 11:
			case 13:
			case 14:
			case 18:
			case 19:
			case 23:
				return true;
			}
		}
		return false;
	}
}
