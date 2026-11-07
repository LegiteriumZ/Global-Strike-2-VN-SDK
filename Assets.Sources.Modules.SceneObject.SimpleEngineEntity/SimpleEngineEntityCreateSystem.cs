using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.SceneObject;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Entitas;
using NetData;
using SSJJPhysics;
using UnityEngine;
using data;
using physics.data;

namespace Assets.Sources.Modules.SceneObject.SimpleEngineEntity;

internal class SimpleEngineEntityCreateSystem : IPlaybackInitSystem
{
	private readonly SnapshotContext _snapshotContext;

	private readonly SceneObjectContext _sceneObjectContext;

	private readonly BattleRoomContext _battleRoomContext;

	private IGroup<SceneObjectEntity> _engineEngityObjects;

	public SimpleEngineEntityCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_battleRoomContext = contexts.battleRoom;
		_engineEngityObjects = _sceneObjectContext.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SimpleEngineEntity).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlaybackInit()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		if (nowSnapshot == null)
		{
			return;
		}
		foreach (BattleRoomEntity item in _battleRoomContext)
		{
			if (!item.hasSceneXmlFile)
			{
				continue;
			}
			foreach (KeyValuePair<int, SimpleEngineEntityData> item2 in nowSnapshot.SimpleEngineEntityDataDict)
			{
				SimpleEngineEntityData value = item2.Value;
				SceneObjectEntity sceneObjectEntity = _sceneObjectContext.GetEntityWithEntityId(value.Id);
				if (sceneObjectEntity == null)
				{
					SceneDynamicEntity sceneDynamicEntity = item.sceneXmlFile.DynamicEntityDictionary[value.ConfigId];
					sceneObjectEntity = SceneObjectFactory.Instance.CreateSimpleEngineEntityEntity(sceneDynamicEntity.Shape.Name, value);
					sceneObjectEntity.AddEntityId(value.Id);
					List<CBrush> newBrushs = new List<CBrush>
					{
						new SceneItemBrush()
					};
					sceneObjectEntity.AddSceneObjectPyhsics(new SimpleEngineEntityAdapter(sceneObjectEntity, new float[3]
					{
						(0f - sceneDynamicEntity.Shape.BoundsX) / 2f,
						(0f - sceneDynamicEntity.Shape.BoundsY) / 2f,
						(0f - sceneDynamicEntity.Shape.BoundsZ) / 2f
					}, new float[3]
					{
						sceneDynamicEntity.Shape.BoundsX / 2f,
						sceneDynamicEntity.Shape.BoundsY / 2f,
						sceneDynamicEntity.Shape.BoundsZ / 2f
					}), newBrushs);
					if (RuleUtilty.IsPitRule(_battleRoomContext))
					{
						sceneObjectEntity.AddUpdateColor(Color.white, Color.white, Color.white, 600, null);
					}
				}
				if (RuleUtilty.IsPitRule(_battleRoomContext) && sceneObjectEntity.simpleEngineEntity.data.IsStandPlayer && !sceneObjectEntity.hasLoadEffectObjects && (!sceneObjectEntity.hasEffectObjects || sceneObjectEntity.effectObjects.LoadResults.Count <= 0))
				{
					SceneObjectFactory.Instance.CreateSimpleEngineEntityEffect(sceneObjectEntity);
				}
			}
			foreach (SceneObjectEntity engineEngityObject in _engineEngityObjects)
			{
				if (!nowSnapshot.SimpleEngineEntityDataDict.ContainsKey(engineEngityObject.entityId.Value))
				{
					engineEngityObject.isDestroy = true;
				}
			}
		}
	}
}
