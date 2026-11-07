using System.Collections.Generic;
using Entitas;
using SSJJPhysics;
using physics.entity;

namespace SSJJPhysicsExtensions;

public class SSJJBspTrace : BspTrace
{
	private readonly IGroup<PlayerEntity> _playersGroup;

	private readonly IGroup<SceneObjectEntity> _sceneItems;

	public SSJJBspTrace(BspClipMapEx map)
		: base(map)
	{
		_sceneItems = Contexts.sharedInstance.sceneObject.GetGroup(SceneObjectMatcher.SceneObjectPyhsics);
		_playersGroup = Contexts.sharedInstance.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.Move));
	}

	protected override List<IPyEntity> GetClipMoveEntityListList()
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
}
