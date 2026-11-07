using Assets.Sources.Components.Interface.Info.Map;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Entitas;
using SSJJBase.Thread;
using SSJJSceneLoader;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class LoadSceneViewSystem : IResourceLoadSystem
{
	private IGroup<SceneObjectEntity> _group;

	private WorldCameraContext _worldCameraContext;

	private BattleRoomContext _battleRoomContext;

	public LoadSceneViewSystem(Contexts contexts)
	{
		_worldCameraContext = contexts.worldCamera;
		_battleRoomContext = contexts.battleRoom;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneMap).NoneOf(SceneObjectMatcher.MapUnityObjects));
	}

	private void SetUp(SceneObjectEntity entity)
	{
		IMapInfo mapInfo = entity.sceneMap.MapInfo;
		if (!MapRuleUtility.IsUnityScene(mapInfo.Id))
		{
			IMapAssetLoader assetLoader = entity.sceneMap.AssetLoader;
			_battleRoomContext.mapInfo.ParsedSceneDatas.TryGetValue(mapInfo.Id, out var value);
			GameObject gameObject = SSJJMapLoader.ConvertMap(assetLoader, renderRealTime: true, value as SceneParsedData);
			entity.AddMapUnityObjects(gameObject);
			BaseSceneRender component = gameObject.GetComponent<BaseSceneRender>();
			component.SetRenderController(new DefaultSceneRenderController(_worldCameraContext));
			Material[] array = new Material[component.GetMaterials().Count];
			int num = 0;
			Material[] array2 = array;
			foreach (Material material in array2)
			{
				array[num++] = material;
			}
			entity.AddLightMapUnityObjects(0, 0, 0, array);
		}
		else
		{
			GameObject newMapObject = GameObject.Find("UnitySceneRoot");
			entity.AddMapUnityObjects(newMapObject);
			entity.isMadeInUnity = true;
			_worldCameraContext.unityObjects.mainCamera.clearFlags = CameraClearFlags.Skybox;
			_worldCameraContext.unityObjects.mainCamera.useOcclusionCulling = true;
		}
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		foreach (SceneObjectEntity item in _group)
		{
			SetUp(item);
		}
	}
}
