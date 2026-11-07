using Assets.Sources.Components.Interface.Info.Map;
using Assets.Sources.Framework;
using SSJJSceneLoader;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class SceneMapEntityCreateSystem : IEntityCreateSystem
{
	private readonly SceneObjectContext _sceneObjectContext;

	private readonly BattleRoomContext _battleGameContext;

	public SceneMapEntityCreateSystem(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
		_battleGameContext = contexts.battleRoom;
	}

	public void OnEntityCreate()
	{
		if (!_sceneObjectContext.hasSceneMap && _battleGameContext.hasMapInfo && _battleGameContext.mapInfo.MapInfo != null)
		{
			SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
			IMapInfo mapInfo = _battleGameContext.mapInfo.MapInfo;
			IMapAssetLoader assetLoader = _battleGameContext.mapInfo.AssetLoader;
			string sceneEffectXml = _battleGameContext.mapInfo.SceneEffectXml;
			sceneObjectEntity.AddSceneMap(mapInfo, assetLoader, sceneEffectXml);
			if (assetLoader.GetTexture("skybox0") != null || OfflineGameController.isOffline)
			{
				sceneObjectEntity.AddSkybox(0);
			}
		}
	}
}
