using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Framework;
using SSJJAsset.Asset;

namespace Assets.Sources.Modules.SceneObject.PathGuide;

public class PathGuideCreateSystem : IEntityCreateSystem
{
	private readonly SceneObjectContext _sceneObjectContext;

	public Dictionary<int, ZhishiData> paths = new Dictionary<int, ZhishiData>();

	public PathGuideCreateSystem(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
		paths = contexts.gameRule.rpgPathGuide.scenePaths;
	}

	public void OnEntityCreate()
	{
		AssetInfo assetInfo = new AssetInfo("effectPrefab/pathguide", "guide");
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, ZhishiData> path in paths)
		{
			EntityEffectId entityEffectId = new EntityEffectId(path.Key, "PathGuide");
			SceneObjectEntity entityWithPlayerEffectId = _sceneObjectContext.GetEntityWithPlayerEffectId(entityEffectId);
			if (entityWithPlayerEffectId == null)
			{
				if (path.Value.PointList.Count > 0)
				{
					entityWithPlayerEffectId = _sceneObjectContext.CreateEntity();
					entityWithPlayerEffectId.AddPlayerEffectId(entityEffectId);
					LoadRequests loadRequests = new LoadRequests();
					loadRequests.Add(0, new LoadRequest(assetInfo));
					AssetInfo assetInfo2 = new AssetInfo("effectPrefab/pathguide", "Assets/Res/Assets/effectPrefab/pathguide/path_kind" + path.Value.Kind + ".png");
					loadRequests.Add(1, new LoadRequest(assetInfo2));
					entityWithPlayerEffectId.AddLoadUnityObjects(loadRequests, entityEffectId);
					entityWithPlayerEffectId.AddPathGuide(path.Value.PointList, 0);
				}
			}
			else if (path.Value.PointList.Count <= 0)
			{
				entityWithPlayerEffectId.isDestroy = true;
				list.Add(path.Key);
			}
		}
		foreach (int item in list)
		{
			paths.Remove(item);
		}
	}
}
