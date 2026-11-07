using System;
using System.Collections.Generic;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Assets.Sources.Utils;
using Entitas;
using SSJJBase.Logger;
using SSJJSceneLoader;
using utils;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class LoadPyEngineSystem : ReactiveSystem<SceneObjectEntity>, IEntityCreateSystem
{
	private Contexts _contexts;

	private BattleRoomContext _battleRoomContext;

	public LoadPyEngineSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
		_contexts = contexts;
		_battleRoomContext = _contexts.battleRoom;
	}

	public void OnInitModule()
	{
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.SceneMap.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		return entity.hasSceneMap;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			PyLoggerFactory.SetLogger(new PyLoggerAdapter());
			byte[] mapData = entity.sceneMap.AssetLoader.GetMapData();
			if (_contexts.battleRoom.hasPyEngine)
			{
				continue;
			}
			MapInfoComponent mapInfo = _battleRoomContext.mapInfo;
			BspClipMap bspClipMap = null;
			try
			{
				if (mapInfo.ParsedSceneDatas.ContainsKey(mapInfo.MapInfo.Id))
				{
					bspClipMap = ((SceneParsedData)mapInfo.ParsedSceneDatas[mapInfo.MapInfo.Id]).map as BspClipMap;
				}
			}
			catch (Exception message)
			{
				this.LogError(message);
			}
			PyEngineUtility.InitPyEngine(_contexts, mapData, _battleRoomContext.roomData.EngineId, bspClipMap);
		}
	}

	public void OnEntityCreate()
	{
		Execute();
	}
}
