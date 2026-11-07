using System.Collections;
using Assets.Scripts.BattleLoading;
using Assets.Sources.Framework;
using Assets.Sources.Info.Map;
using NetData;
using SSJJAsset.AssetBundle;
using SSJJBase.String;
using SSJJBase.Thread;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Tests.PlayMode;

public class GameTestHelper
{
	public static IEnumerator InitTestGameController(Contexts contexts, IGameModule module)
	{
		if (!(Object.FindObjectOfType<TestGameController>() != null))
		{
			TestGameController testGameController = new GameObject("GameController").AddComponent<TestGameController>();
			yield return testGameController.Init(contexts, module);
		}
	}

	public static void AddMainCamera()
	{
		GameObject gameObject = new GameObject("Camera");
		UnityEngine.Camera camera = gameObject.AddComponent<UnityEngine.Camera>();
		gameObject.transform.position = new Vector3(0f, 0f, -200f);
		camera.fieldOfView = 90f;
		gameObject.transform.forward = Vector3.forward;
		camera.nearClipPlane = 10f;
		camera.farClipPlane = 1000f;
	}

	public static IEnumerator InitWorld(Contexts contexts, RoomData roomData)
	{
		contexts.battleRoom.roomData.Data = roomData;
		DefaultMapInfo mapInfo = new DefaultMapInfo(roomData.SceneId);
		IgnoreCaseString assetBundleName = new IgnoreCaseString(mapInfo.AssetBundleName);
		AssetBundleLoadAssetOperation mapAssetOperation = AssetBundleManager.LoadAllAssetsAsync(ref assetBundleName);
		yield return mapAssetOperation;
		MapAssetLoader mapAssetLoader = new MapAssetLoader(mapAssetOperation.GetAllAssets(), "");
		SceneObjectEntity sceneObjectEntity = contexts.sceneObject.CreateEntity();
		sceneObjectEntity.AddSceneMap(mapInfo, mapAssetLoader, null);
		if (mapAssetLoader.GetTexture("skybox0") != null)
		{
			sceneObjectEntity.AddSkybox(0);
		}
		while (!contexts.battleRoom.hasPyEngine)
		{
			yield return null;
		}
	}

	public static void Cleanup(Contexts contexts)
	{
		if (contexts.sceneObject.hasSceneMap)
		{
			if (contexts.sceneObject.sceneMapEntity.hasMapUnityObjects)
			{
				Object.Destroy(contexts.sceneObject.sceneMapEntity.mapUnityObjects.MapObject);
			}
			if (contexts.sceneObject.sceneMapEntity.hasSkyboxUnityObjects)
			{
				Object.Destroy(contexts.sceneObject.sceneMapEntity.skyboxUnityObjects.Skybox);
			}
			contexts.sceneObject.sceneMapEntity.Destroy();
		}
		contexts.battleRoom.roomData.Data = null;
		if (contexts.battleRoom.hasPyEngine)
		{
			contexts.battleRoom.pyEngine.PyEngine.Dispose();
			contexts.battleRoom.RemovePyEngine();
		}
		foreach (PlayerEntity item in contexts.player)
		{
			item.isDestroy = true;
		}
		foreach (SceneObjectEntity item2 in contexts.sceneObject)
		{
			item2.isDestroy = true;
		}
		BaseAsyncManager.Instance.StopAllCoroutines();
	}

	public static IEnumerator WaitForBattleBegin()
	{
		SceneManager.LoadScene("Lobby", LoadSceneMode.Additive);
		while (GameController.Instance == null || !GameController.Instance.InitFinish)
		{
			yield return null;
		}
		ConnectToServerUtility.Connect();
		while (!Contexts.sharedInstance.battleRoom.gameState.LoadingFinish)
		{
			yield return null;
		}
	}
}
